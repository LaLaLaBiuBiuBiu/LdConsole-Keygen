using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Keygen
{
    internal class EncryptHelper
    {
        public static byte[] GetEncryptFileByte(byte[] head, byte[] body, string computerCode, string md5, string user)
        {
            byte[] ar;
            CommonFunctions.ChangeBody(head, body, computerCode, md5, user);
            List<byte> list = new List<byte>();
            int len = body.Length;
            int startindex = 0, blockSize = 512;
            while (true)
            {
                if (len < 0) break;
                if (len < 512) blockSize = len;
                ar = new byte[blockSize];
                Array.Copy(body, startindex, ar, 0, blockSize);
                CommonFunctions.DecryptAndEncrypt(ar, Encoding.ASCII.GetBytes(md5), blockSize);
                len -= 512;
                startindex += 512;
                list.AddRange(ar);
            }
            List<byte> bytes = new List<byte>();
            bytes.AddRange(head);
            bytes.AddRange(list);

            return bytes.ToArray();
        }
    }
}