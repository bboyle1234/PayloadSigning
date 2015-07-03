# Hash method

#### Hash method initialization

Signing key
```
sLruG18jtHqncgh0W8ZbB1YqKRJtR
```
Signing key bytes
```
115, 76, 114, 117, 71, 49, 56, 106, 116, 72, 113, 110, 99, 103, 104, 48, 87, 56, 90, 98, 66, 49, 89, 113, 75, 82, 74, 116, 82
```

#### Hash method processing
Session raw json (note the escaping of the non-standard-ascii characters and the formatting of the UTC timestamp including timezone)
```
{"p":{"q":35,"np":"Benjamin \ufeff\u95dc\u65bc\u6211\u5011","e":"bboyle1234@gmail.com"},"r":[1,2,3,4,5,6,7,8,9,10],"e":"2015-09-30T14:00:00Z"}
```
Session raw json converted to utf-8 byte array (this is the "payload")
```
123, 34, 112, 34, 58, 123, 34, 113, 34, 58, 51, 53, 44, 34, 110, 112, 34, 58, 34, 66, 101, 110, 106, 97, 109, 105, 110, 32, 92, 117, 102, 101, 102, 102, 92, 117, 57, 53, 100, 99, 92, 117, 54, 53, 98, 99, 92, 117, 54, 50, 49, 49, 92, 117, 53, 48, 49, 49, 34, 44, 34, 101, 34, 58, 34, 98, 98, 111, 121, 108, 101, 49, 50, 51, 52, 64, 103, 109, 97, 105, 108, 46, 99, 111, 109, 34, 125, 44, 34, 114, 34, 58, 91, 49, 44, 50, 44, 51, 44, 52, 44, 53, 44, 54, 44, 55, 44, 56, 44, 57, 44, 49, 48, 93, 44, 34, 101, 34, 58, 34, 50, 48, 49, 53, 45, 48, 57, 45, 51, 48, 84, 49, 52, 58, 48, 48, 58, 48, 48, 90, 34, 125
```
Salted payload (Signing key bytes are added to the end of the payload)
```
123, 34, 112, 34, 58, 123, 34, 113, 34, 58, 51, 53, 44, 34, 110, 112, 34, 58, 34, 66, 101, 110, 106, 97, 109, 105, 110, 32, 92, 117, 102, 101, 102, 102, 92, 117, 57, 53, 100, 99, 92, 117, 54, 53, 98, 99, 92, 117, 54, 50, 49, 49, 92, 117, 53, 48, 49, 49, 34, 44, 34, 101, 34, 58, 34, 98, 98, 111, 121, 108, 101, 49, 50, 51, 52, 64, 103, 109, 97, 105, 108, 46, 99, 111, 109, 34, 125, 44, 34, 114, 34, 58, 91, 49, 44, 50, 44, 51, 44, 52, 44, 53, 44, 54, 44, 55, 44, 56, 44, 57, 44, 49, 48, 93, 44, 34, 101, 34, 58, 34, 50, 48, 49, 53, 45, 48, 57, 45, 51, 48, 84, 49, 52, 58, 48, 48, 58, 48, 48, 90, 34, 125, 115, 76, 114, 117, 71, 49, 56, 106, 116, 72, 113, 110, 99, 103, 104, 48, 87, 56, 90, 98, 66, 49, 89, 113, 75, 82, 74, 116, 82
```
SHA512 hash of the salted payload
```
54, 111, 250, 113, 164, 18, 174, 202, 30, 222, 115, 98, 193, 135, 158, 23, 2, 43, 63, 60, 215, 75, 211, 243, 239, 62, 121, 66, 60, 104, 34, 162, 213, 187, 170, 139, 210, 192, 154, 172, 147, 96, 218, 49, 248, 166, 25, 70, 209, 239, 69, 129, 236, 168, 90, 187, 6, 76, 179, 11, 73, 72, 36, 39
```
Signed payload (Original payload with first four bytes of the above hash added to the end)
```
123, 34, 112, 34, 58, 123, 34, 113, 34, 58, 51, 53, 44, 34, 110, 112, 34, 58, 34, 66, 101, 110, 106, 97, 109, 105, 110, 32, 92, 117, 102, 101, 102, 102, 92, 117, 57, 53, 100, 99, 92, 117, 54, 53, 98, 99, 92, 117, 54, 50, 49, 49, 92, 117, 53, 48, 49, 49, 34, 44, 34, 101, 34, 58, 34, 98, 98, 111, 121, 108, 101, 49, 50, 51, 52, 64, 103, 109, 97, 105, 108, 46, 99, 111, 109, 34, 125, 44, 34, 114, 34, 58, 91, 49, 44, 50, 44, 51, 44, 52, 44, 53, 44, 54, 44, 55, 44, 56, 44, 57, 44, 49, 48, 93, 44, 34, 101, 34, 58, 34, 50, 48, 49, 53, 45, 48, 57, 45, 51, 48, 84, 49, 52, 58, 48, 48, 58, 48, 48, 90, 34, 125, 54, 111, 250, 113
```
Signed payload converted to base64
```
eyJwIjp7InEiOjM1LCJucCI6IkJlbmphbWluIFx1ZmVmZlx1OTVkY1x1NjViY1x1NjIxMVx1NTAxMSIsImUiOiJiYm95bGUxMjM0QGdtYWlsLmNvbSJ9LCJyIjpbMSwyLDMsNCw1LDYsNyw4LDksMTBdLCJlIjoiMjAxNS0wOS0zMFQxNDowMDowMFoifTZv+nE=
```
Final result: Base64 modified slightly to be html-and-url-friendy
```
eyJwIjp7InEiOjM1LCJucCI6IkJlbmphbWluIFx1ZmVmZlx1OTVkY1x1NjViY1x1NjIxMVx1NTAxMSIsImUiOiJiYm95bGUxMjM0QGdtYWlsLmNvbSJ9LCJyIjpbMSwyLDMsNCw1LDYsNyw4LDksMTBdLCJlIjoiMjAxNS0wOS0zMFQxNDowMDowMFoifTZv-nE_
```

# RSA method

#### RSA method initialisation
Private key
```
<RSAKeyValue><Modulus>sLruG18jtHqncgh0W8ZbB1YqKRJtR7MauFvG2YmAdSPkr7bZLVeguIwPn1qGNfXNQXkC2vMvznK+R2g+YvlA24KjsShvIO5MCUxhcaXgLX8i63UN4CzIUVlnLKXhQ3jSC2Nd5X7TuhtKFPpUkQc7peQYEdGPmD3gyyinJj2oz/U=</Modulus><Exponent>AQAB</Exponent><P>uaiFxP8IGaBjM4A8f1lS+ZqIWP0LsHNrKpx6jKQHU+j/yn0Z7dKzyxQMbBd7YMaof6rrGTrI1T0bgVCam1yo/Q==</P><Q>87By0hiP/VtWvB+O40hs3igPhJ6RcmmLnUlMAUjgdOQq7JVIUdOu7wFUAZDfXH4SDW+h4yW8I4ABzDTwux9QWQ==</Q><DP>d6KfqKTKnHDc29f7o/h0XoF08RsGiEqnuQqicbRVQH35LotUxQqsbuVZZ+Ht0BvTgokp+9UEi1xYOAkvx4N7JQ==</DP><DQ>1+2WoFGBbRb9MO6ptv0a8nL+5R14da/ONU2YWl8P/KOc4UuZ7F+s1z0PCeAr+xH+vwcWpGZwYehwL1kNolEp6Q==</DQ><InverseQ>WAGLC3jwsbC9c3Efgdbtzp+nVPTFKWmWFT7CD33BoxznB4mPBEMDzlOuOOzqOblx9QItuKHJyUhlx5EDOjOGqg==</InverseQ><D>JyoBpqSugaoVrdZUTNs35HgSh0ALYhJ9hyHlfuMzCaJ+5PahCaSL3CHDu4VgzRfv2MTDnng6XaZ9Zs8h1iaU2cEj2iNxUcSfSjsMufbYYI3xMY0T9+m8k3k/wvtnfiMTbaOY51iqiFzlBGbRKgW5l50TOOrSUBOoDLjNKWn1/Ik=</D></RSAKeyValue>
```
Public key
```
<RSAKeyValue><Modulus>sLruG18jtHqncgh0W8ZbB1YqKRJtR7MauFvG2YmAdSPkr7bZLVeguIwPn1qGNfXNQXkC2vMvznK+R2g+YvlA24KjsShvIO5MCUxhcaXgLX8i63UN4CzIUVlnLKXhQ3jSC2Nd5X7TuhtKFPpUkQc7peQYEdGPmD3gyyinJj2oz/U=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
```
#### RSA method processing
Session raw json (note the escaping of the non-standard-ascii characters and the formatting of the UTC timestamp including timezone)
```
{"p":{"q":35,"np":"Benjamin \ufeff\u95dc\u65bc\u6211\u5011","e":"bboyle1234@gmail.com"},"r":[1,2,3,4,5,6,7,8,9,10],"e":"2015-09-30T14:00:00Z"}
```
Session raw json converted to utf-8 byte array (this is the "payload")
```
123, 34, 112, 34, 58, 123, 34, 113, 34, 58, 51, 53, 44, 34, 110, 112, 34, 58, 34, 66, 101, 110, 106, 97, 109, 105, 110, 32, 92, 117, 102, 101, 102, 102, 92, 117, 57, 53, 100, 99, 92, 117, 54, 53, 98, 99, 92, 117, 54, 50, 49, 49, 92, 117, 53, 48, 49, 49, 34, 44, 34, 101, 34, 58, 34, 98, 98, 111, 121, 108, 101, 49, 50, 51, 52, 64, 103, 109, 97, 105, 108, 46, 99, 111, 109, 34, 125, 44, 34, 114, 34, 58, 91, 49, 44, 50, 44, 51, 44, 52, 44, 53, 44, 54, 44, 55, 44, 56, 44, 57, 44, 49, 48, 93, 44, 34, 101, 34, 58, 34, 50, 48, 49, 53, 45, 48, 57, 45, 51, 48, 84, 49, 52, 58, 48, 48, 58, 48, 48, 90, 34, 125
```
RSA Signature
```
126, 126, 203, 31, 142, 45, 112, 230, 138, 68, 115, 45, 112, 181, 106, 27, 10, 28, 224, 165, 145, 77, 77, 161, 240, 4, 1, 56, 244, 208, 224, 28, 234, 3, 33, 176, 24, 69, 74, 249, 58, 236, 232, 153, 58, 191, 137, 205, 146, 113, 225, 244, 197, 16, 108, 28, 178, 96, 5, 206, 2, 20, 14, 71, 47, 128, 173, 204, 90, 67, 63, 13, 239, 160, 165, 170, 228, 123, 41, 165, 87, 77, 176, 169, 206, 214, 181, 32, 16, 228, 74, 17, 189, 189, 217, 233, 28, 143, 142, 226, 107, 104, 196, 225, 193, 125, 211, 223, 176, 252, 181, 84, 241, 11, 110, 202, 14, 65, 8, 216, 202, 237, 190, 169, 65, 24, 30, 202
```
Signed payload (Original payload with RSA signature added to the end)
```
123, 34, 112, 34, 58, 123, 34, 113, 34, 58, 51, 53, 44, 34, 110, 112, 34, 58, 34, 66, 101, 110, 106, 97, 109, 105, 110, 32, 92, 117, 102, 101, 102, 102, 92, 117, 57, 53, 100, 99, 92, 117, 54, 53, 98, 99, 92, 117, 54, 50, 49, 49, 92, 117, 53, 48, 49, 49, 34, 44, 34, 101, 34, 58, 34, 98, 98, 111, 121, 108, 101, 49, 50, 51, 52, 64, 103, 109, 97, 105, 108, 46, 99, 111, 109, 34, 125, 44, 34, 114, 34, 58, 91, 49, 44, 50, 44, 51, 44, 52, 44, 53, 44, 54, 44, 55, 44, 56, 44, 57, 44, 49, 48, 93, 44, 34, 101, 34, 58, 34, 50, 48, 49, 53, 45, 48, 57, 45, 51, 48, 84, 49, 52, 58, 48, 48, 58, 48, 48, 90, 34, 125, 126, 126, 203, 31, 142, 45, 112, 230, 138, 68, 115, 45, 112, 181, 106, 27, 10, 28, 224, 165, 145, 77, 77, 161, 240, 4, 1, 56, 244, 208, 224, 28, 234, 3, 33, 176, 24, 69, 74, 249, 58, 236, 232, 153, 58, 191, 137, 205, 146, 113, 225, 244, 197, 16, 108, 28, 178, 96, 5, 206, 2, 20, 14, 71, 47, 128, 173, 204, 90, 67, 63, 13, 239, 160, 165, 170, 228, 123, 41, 165, 87, 77, 176, 169, 206, 214, 181, 32, 16, 228, 74, 17, 189, 189, 217, 233, 28, 143, 142, 226, 107, 104, 196, 225, 193, 125, 211, 223, 176, 252, 181, 84, 241, 11, 110, 202, 14, 65, 8, 216, 202, 237, 190, 169, 65, 24, 30, 202
```
Signed payload converted to base64
```
eyJwIjp7InEiOjM1LCJucCI6IkJlbmphbWluIFx1ZmVmZlx1OTVkY1x1NjViY1x1NjIxMVx1NTAxMSIsImUiOiJiYm95bGUxMjM0QGdtYWlsLmNvbSJ9LCJyIjpbMSwyLDMsNCw1LDYsNyw4LDksMTBdLCJlIjoiMjAxNS0wOS0zMFQxNDowMDowMFoifX5+yx+OLXDmikRzLXC1ahsKHOClkU1NofAEATj00OAc6gMhsBhFSvk67OiZOr+JzZJx4fTFEGwcsmAFzgIUDkcvgK3MWkM/De+gparkeymlV02wqc7WtSAQ5EoRvb3Z6RyPjuJraMThwX3T37D8tVTxC27KDkEI2MrtvqlBGB7K
```
Final result: Base64 modified slightly to be html-and-url-friendy
```
eyJwIjp7InEiOjM1LCJucCI6IkJlbmphbWluIFx1ZmVmZlx1OTVkY1x1NjViY1x1NjIxMVx1NTAxMSIsImUiOiJiYm95bGUxMjM0QGdtYWlsLmNvbSJ9LCJyIjpbMSwyLDMsNCw1LDYsNyw4LDksMTBdLCJlIjoiMjAxNS0wOS0zMFQxNDowMDowMFoifX5-yx-OLXDmikRzLXC1ahsKHOClkU1NofAEATj00OAc6gMhsBhFSvk67OiZOr-JzZJx4fTFEGwcsmAFzgIUDkcvgK3MWkM~De-gparkeymlV02wqc7WtSAQ5EoRvb3Z6RyPjuJraMThwX3T37D8tVTxC27KDkEI2MrtvqlBGB7K
```
