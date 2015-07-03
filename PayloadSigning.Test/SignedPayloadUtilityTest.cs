using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayloadSigning.Test {

    [TestClass]
    public class SignedPayloadUtilityTest {

        [TestMethod]
        public void SignedPayloadUtilities() {

            // create a payload
            var payload = CreateTestPayload();

            // test the HASH signing payload utility
            string signingKey = "sLruG18jtHqncgh0W8ZbB1YqKRJtR";
            using (var hashSigner = new HashPayloadSigner(signingKey)) {
                Test(new StringTokenSigner(hashSigner), payload);
            }

            // test the RSA signing payload utility
            string privateRSAKeyXML = @"<RSAKeyValue><Modulus>sLruG18jtHqncgh0W8ZbB1YqKRJtR7MauFvG2YmAdSPkr7bZLVeguIwPn1qGNfXNQXkC2vMvznK+R2g+YvlA24KjsShvIO5MCUxhcaXgLX8i63UN4CzIUVlnLKXhQ3jSC2Nd5X7TuhtKFPpUkQc7peQYEdGPmD3gyyinJj2oz/U=</Modulus><Exponent>AQAB</Exponent><P>uaiFxP8IGaBjM4A8f1lS+ZqIWP0LsHNrKpx6jKQHU+j/yn0Z7dKzyxQMbBd7YMaof6rrGTrI1T0bgVCam1yo/Q==</P><Q>87By0hiP/VtWvB+O40hs3igPhJ6RcmmLnUlMAUjgdOQq7JVIUdOu7wFUAZDfXH4SDW+h4yW8I4ABzDTwux9QWQ==</Q><DP>d6KfqKTKnHDc29f7o/h0XoF08RsGiEqnuQqicbRVQH35LotUxQqsbuVZZ+Ht0BvTgokp+9UEi1xYOAkvx4N7JQ==</DP><DQ>1+2WoFGBbRb9MO6ptv0a8nL+5R14da/ONU2YWl8P/KOc4UuZ7F+s1z0PCeAr+xH+vwcWpGZwYehwL1kNolEp6Q==</DQ><InverseQ>WAGLC3jwsbC9c3Efgdbtzp+nVPTFKWmWFT7CD33BoxznB4mPBEMDzlOuOOzqOblx9QItuKHJyUhlx5EDOjOGqg==</InverseQ><D>JyoBpqSugaoVrdZUTNs35HgSh0ALYhJ9hyHlfuMzCaJ+5PahCaSL3CHDu4VgzRfv2MTDnng6XaZ9Zs8h1iaU2cEj2iNxUcSfSjsMufbYYI3xMY0T9+m8k3k/wvtnfiMTbaOY51iqiFzlBGbRKgW5l50TOOrSUBOoDLjNKWn1/Ik=</D></RSAKeyValue>";
            string publicRSAKeyXML = @"<RSAKeyValue><Modulus>sLruG18jtHqncgh0W8ZbB1YqKRJtR7MauFvG2YmAdSPkr7bZLVeguIwPn1qGNfXNQXkC2vMvznK+R2g+YvlA24KjsShvIO5MCUxhcaXgLX8i63UN4CzIUVlnLKXhQ3jSC2Nd5X7TuhtKFPpUkQc7peQYEdGPmD3gyyinJj2oz/U=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            using (var rsaSigner = new RSAPayloadSigner(privateRSAKeyXML, publicRSAKeyXML)) {
                Test(new StringTokenSigner(rsaSigner), payload);
            }
        }

        /// <summary>
        /// A generic test to validate the StringTokenSigner and whatever algorithm it is using under the hood
        /// </summary>
        static void Test<T>(StringTokenSigner tokenSigner, T payload) {

            // convert the payload object to a signed and serialized payload
            var signedToken = tokenSigner.Sign(payload);

            T restoredPayload;

            // test that the payload utility verifies the payload
            Assert.IsTrue(tokenSigner.TryVerifySignature(signedToken, out restoredPayload));

            // test that the restored payload is exactly the same as the test payload
            // we cheat a little here because it was quicker to borrow serialization than manually code an "Equals" comparison method for the payload object.
            Assert.AreEqual(JsonConvert.SerializeObject(payload), JsonConvert.SerializeObject(restoredPayload));

            // now damage the token signature slightly by changing the last character
            signedToken = signedToken.Substring(0, signedToken.Length - 1) + "a";

            // make sure that token verification fails
            Assert.IsFalse(tokenSigner.TryVerifySignature(signedToken, out restoredPayload));
        }

        /// <summary>
        /// Creates an object containing test cookie data
        /// </summary>
        public static Session CreateTestPayload() {

            return new Session {

                Person = new Person {

                    // amember user id
                    Id = 35,

                    // users's preferred name
                    // I'm not sure if amember facilitates the 'preferred name'. If not, just use the user's login id
                    // I have added chinese characters to test conversion of non-standard ascii characters.
                    PreferredName = "Benjamin ﻿關於我們",

                    // user's email
                    EmailAddress = "bboyle1234@gmail.com",
                },

                // use a constant value here so tests will give repeatable results
                // make sure the time is converted to UTC
                ExpiresAt = new DateTime(2015, 10, 1).ToUniversalTime(),

                // list of amember product ids that the user currently has access to
                ProductIds = new List<uint>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            };
        }
    }
}
