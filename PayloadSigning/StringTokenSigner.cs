﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayloadSigning {

    /// <summary>
    /// Use this class to serialize any object into a signed html-and-url-friendly string token.
    /// The payload is not encrypted and can be read by anyone, but users are able to verify
    /// that the token was signed by a holder of the secret key.
    /// </summary>
    public class StringTokenSigner {

        /// <summary>
        /// When we serialize an object to json, we take care to escape the non-standard-ascii characters.
        /// This is necessary because we will convert to the json string to a UTF-8 byte array.
        /// This is the settings object that allows us to serialize correctly.
        /// </summary>
        static readonly JsonSerializerSettings serializationSettings = new JsonSerializerSettings() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii };

        /// <summary>
        /// The payload signing algorithm
        /// </summary>
        readonly IPayloadSigner payloadSigner;

        /// <summary>
        /// Inversion of control allows you to sign with any algorithm you provide here
        /// </summary>
        public StringTokenSigner(IPayloadSigner payloadSigner) {
            this.payloadSigner = payloadSigner;
        }

        /// <summary>
        /// Serializes the given payload to a signed token.
        /// The payload is not encrypted and can be read by anyone, but users are able
        /// to verify that the signature was generated by a holder of the signing key.
        /// Token returned is a html-and-url-friendly conversion of base64 string
        /// </summary>
        public string Sign<T>(T payload) {

            // serialize the payload to json, taking care to escape the non-standard-ascii characters first
            var json = JsonConvert.SerializeObject(payload, serializationSettings);

            // convert the json to UTF-8 byte array (that's why we had to escape the non-standard-ascii characters)
            var payloadBytes = Encoding.UTF8.GetBytes(json);

            // use the given payload signer to sign the byte array
            var signedPayloadBytes = payloadSigner.Sign(payloadBytes);

            // convert the byte array to a base64 string
            var base64 = Convert.ToBase64String(signedPayloadBytes);

            // slightly modify the base64 string so it is convenient to use in urls and html
            return base64.Replace('+', '-').Replace('=', '_').Replace('/', '~');
        }

        /// <summary>
        /// Reads the given token, verifies the signature and outputs the payload contained in the token.
        /// Returns true if the token was correctly signed, false otherwise.
        /// </summary>
        public bool TryVerifySignature<T>(string signedToken, out T payload) {

            // prepare storage for the payload bytes
            byte[] payloadBytes;

            // start by taking the url-and-html-safe string and returning it to standard base64
            var base64 = signedToken.Replace('-', '+').Replace('_', '=').Replace('~', '/');

            // get the signed payload byte array from the base64 string
            var signedPayloadBytes = Convert.FromBase64String(base64);

            // use the given payload signer to verify the byte array's signature and output the orignal payload bytes
            if (payloadSigner.TryVerifySignature(signedPayloadBytes, out payloadBytes)) {

                // convert the original payload bytes back from UTF-8 encoding to a json string
                var json = Encoding.UTF8.GetString(payloadBytes);

                // deserialize the json into the payload object and return success
                payload = JsonConvert.DeserializeObject<T>(json);
                return true;
            }

            // signature verification failed - set output variables and return failure
            payload = default(T);
            return false;
        }
    }
}
