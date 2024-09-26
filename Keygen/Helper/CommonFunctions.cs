using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Keygen
{
    internal static class CommonFunctions
    {
        [DllImport(@"\GetKey\ArLib.dll", SetLastError = true)]
        private static extern int DllGetComputerCode(StringBuilder stringBuilder);

        [DllImport(@"\GetKey\ArLib.dll", SetLastError = true)]
        private static extern int DllEncryptString_Des(StringBuilder enc, string dec, string str = "Ld_Tq_Se");

        [DllImport(@"\GetKey\ArLib.dll", SetLastError = true)]
        private static extern int MD5(string a1, StringBuilder a2);

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //[DllImport("user32.dll")]
        //private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);
        public static event EventHandler GetMd5Progress;

        public static byte[] CreateArray(byte[] md5)
        {
            byte[] byteArry2 = new byte[52];
            for (int i = 0; i < 20; i++)
                byteArry2[i] = 0x02;
            Array.Copy(md5, 0, byteArry2, 20, md5.Length);

            byte[] byteArry1 = new byte[256];
            for (int i = 0; i <= 255; i++)
            {
                byteArry1[i] = (byte)i;
            }
            int index1esi = 0;
            int index2edx = 0;
            UInt32 temp, edi, eax, ecx = 0;

            for (int j = 256; j > 0; j--)
            {
                temp = edi = byteArry1[index1esi];
                eax = byteArry2[index2edx];
                eax += edi;
                ecx += eax;
                ecx &= 0x800000ff;
                byteArry1[index1esi] = byteArry1[ecx];
                index2edx = (int)(eax % 0x14);
                index1esi++;
                byteArry1[ecx] = (byte)temp;
            }

            return byteArry1;
        }

        public static void DecryptAndEncrypt(byte[] Code, byte[] md5, int len)
        {
            byte[] createArray = CreateArray(md5);
            int index = 0;
            UInt32 temp1, temp2, temp3;
            UInt32 ebx = 0;

            for (int i = 0; i < len; i++)
            {
                index++;
                index &= 0xff;
                temp1 = temp3 = createArray[index];
                temp1 += ebx;
                temp1 &= 0xff;
                ebx = temp1;
                temp2 = createArray[ebx];
                createArray[index] = (byte)temp2;
                temp2 += temp3;
                temp2 &= 0xff;
                createArray[ebx] = (byte)temp3;
                byte dl = createArray[temp2];
                byte al = Code[i];
                byte re = (byte)(dl ^ al);
                Code[i] = (byte)re;
            }
        }

        public static string GetMd5()
        {
            //int WM_GETTEXT = 0x000D;
            //int WM_GETTEXTLENGTH = 0x000E;
            //string md5 = "";
            //Process process = new Process();
            //process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\GetKey", "GetKey.exe");
            //process.Start();
            //process.WaitForInputIdle();
            //IntPtr hWnd = FindWindow("#32770", null);
            //if (hWnd == IntPtr.Zero) return md5;
            //IntPtr textBoxHandle = FindWindowEx(hWnd, IntPtr.Zero, "Edit", null);
            //if (textBoxHandle == IntPtr.Zero) return md5;
            //StringBuilder sb = new StringBuilder(SendMessage(textBoxHandle, WM_GETTEXTLENGTH, 0, null) + 1);
            //SendMessage(textBoxHandle, WM_GETTEXT, sb.Capacity, sb);
            //md5 = sb.ToString();
            //process.Kill();
            //return md5;

            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\GetKey", "GetMd5.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                GetMd5Progress?.Invoke(null, new Progress(i));
            }

            string str = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MD5.txt"));
            return str;
        }

        public static string GetComputerCode()
        {
            StringBuilder sb = new StringBuilder(32);
            DllGetComputerCode(sb);
            return sb.ToString();
        }

        public static byte[] GetBaseIrsBytes()
        {
            return File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\GetKey", "Base.irs"));
        }

        public static void WriteTempIrs(byte[] data)
        {
            File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\GetKey", "trInfoPf1.irs"), data);
        }

        public static void WritetrInfoPf1(byte[] data, string filPath)
        {
            File.WriteAllBytes(Path.Combine(filPath, "trInfoPf1.irs"), data);
        }

        public static void ChangeBody(byte[] head, byte[] body, string computerCode, string md5, string use)
        {
            byte[] user = Encoding.ASCII.GetBytes(use);
            byte[] date = new byte[8] { 0x32, 0x30, 0x38, 0x38, 0x2f, 0x38, 0x2f, 0x38 };
            byte[] temp = Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyzabcdef");

            Array.Copy(Encoding.ASCII.GetBytes(md5), 0, head, 15, md5.Length);
            Array.Copy(Encoding.ASCII.GetBytes(computerCode), 0, body, 1, computerCode.Length);
            Array.Copy(user, 0, body, 0x56, user.Length);
            Array.Copy(user, 0, body, 0x50b, user.Length);
            Array.Copy(user, 0, body, 0x9bd, user.Length);
            Array.Copy(user, 0, body, 0xe6f, user.Length);

            Array.Copy(date, 2, body, 0x40, date.Length - 2);
            Array.Copy(date, 0, body, 0x6a, date.Length);
            Array.Copy(date, 0, body, 0x9d1, date.Length);
            Array.Copy(date, 0, body, 0x4f3, date.Length);
            Array.Copy(date, 0, body, 0x9a5, date.Length);
            Array.Copy(date, 0, body, 0xe57, date.Length);
            Array.Copy(date, 0, body, 0xe83, date.Length);
            Array.Copy(date, 0, body, 0x51f, date.Length);

            Array.Copy(temp, 0, body, 0xd2, temp.Length);
            Array.Copy(temp, 0, body, 0x587, temp.Length);
            Array.Copy(temp, 0, body, 0xa39, temp.Length);
            Array.Copy(temp, 0, body, 0xeeb, temp.Length);
            body[0x54] = 0xff;
            body[0x55] = 0xff;
        }

        public static string GetRegCode(string str)
        {
            StringBuilder sb = new StringBuilder(32);
            string v = int.Parse(str).ToString("X8");
            MD5(v, sb);
            DllEncryptString_Des(sb, v + sb.ToString().Substring(8, 8));
            return sb.ToString();
        }
    }

    public class Progress : EventArgs
    {
        public int V2 { get; set; }

        public Progress(int v1)
        {
            V2 = v1;
        }
    }
}