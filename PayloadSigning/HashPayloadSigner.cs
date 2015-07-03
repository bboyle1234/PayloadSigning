using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayloadSigning {

    /// <summary>
    /// Use this class to sign byte arrays with the first four bytes of a hash generated from 
    /// a concatenation of the byte array and a secret key.
    /// </summary>
    public class HashPayloadSigner : IPayloadSigner, IDisposable {

        /// <summary>
        /// How many bytes from the hash that we should use in the signature
        /// </summary>
        const int SIGNING_LENGTH = 4;

        /// <summary>
        /// The secret key
        /// </summary>
        readonly byte[] signingKeyBytes;

        /// <summary>
        /// An object to compute hashes
        /// </summary>
        readonly SHA512Managed sha;

        public HashPayloadSigner(string signingKey) {
            signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);
            sha = new SHA512Managed();
        }

        public byte[] Sign(byte[] payload) {
            var hash = ComputeHash(payload);
            return ArrayUtilities.Concatenate(payload, hash, SIGNING_LENGTH);
        }

        public bool TryVerifySignature(byte[] signedPayload, out byte[] payload) {
            byte[] signature;
            ArrayUtilities.Split(signedPayload, signedPayload.Length - SIGNING_LENGTH, out payload, out signature);
            var hash = ComputeHash(payload);
            if (signature.SequenceEqual(hash.Take(SIGNING_LENGTH))) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Computes a hash of the given byte array, using the signingKey
        /// </summary>
        private byte[] ComputeHash(byte[] value) {
            var saltedValue = ArrayUtilities.Concatenate(value, signingKeyBytes);
            return sha.ComputeHash(saltedValue);
        }

        public void Dispose() {
            sha.Dispose();
        }
    }
}
