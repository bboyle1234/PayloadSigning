using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayloadSigning {

    public static class ArrayUtilities {

        /// <summary>
        /// Concatenates two byte arrays and returns the result
        /// </summary>
        public static byte[] Concatenate(byte[] b1, byte[] b2) {
            var result = new byte[b1.Length + b2.Length];
            Buffer.BlockCopy(b1, 0, result, 0, b1.Length);
            Buffer.BlockCopy(b2, 0, result, b1.Length, b2.Length);
            return result;
        }

        /// <summary>
        /// Concatenates the entirety of the first byte array and the first 'take' bytes of the second array and returns the result
        /// </summary>
        public static byte[] Concatenate(byte[] payload, byte[] hash, int take) {
            var result = new byte[payload.Length + take];
            Buffer.BlockCopy(payload, 0, result, 0, payload.Length);
            Buffer.BlockCopy(hash, 0, result, payload.Length, take);
            return result;
        }

        /// <summary>
        /// Splits a byte array into two at the index given
        /// </summary>
        public static void Split(byte[] input, int index, out byte[] b1, out byte[] b2) {
            b1 = new byte[index];
            b2 = new byte[input.Length - index];
            Buffer.BlockCopy(input, 0, b1, 0, index);
            Buffer.BlockCopy(input, index, b2, 0, input.Length - index);
        }
    }
}
