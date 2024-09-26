using System;
using System.Collections.Generic;
using System.Linq;

namespace Keygen
{
    internal class DecryptHelper
    {
        public static Tuple<byte[], byte[]> GetDecryptFileByte()
        {
            List<byte> list = new List<byte>();
            byte[] ar;
            byte[] byteArray = CommonFunctions.GetBaseIrsBytes();
            byte[] md5 = byteArray.Skip(15).Take(32).ToArray();
            int len = byteArray.Length - 52;
            int startindex = 52, blockSize = 512;
            while (true)
            {
                if (len < 0) break;
                if (len < 512) blockSize = len;
                ar = new byte[blockSize];
                Array.Copy(byteArray, startindex, ar, 0, blockSize);
                CommonFunctions.DecryptAndEncrypt(ar, md5, blockSize);
                len -= 512;
                startindex += 512;
                list.AddRange(ar);
            }
            return new Tuple<byte[], byte[]>(byteArray.Take(52).ToArray(), list.ToArray()); ;
        }
    }
}