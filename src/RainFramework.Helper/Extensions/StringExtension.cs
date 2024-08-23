using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace RainFramework.Helper.Extensions
{
    public static class StringExtension
    {
        public static string ToMd5(this string value)
        {
            using MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(value + "12x@#!#$!@$!$");
            byte[] hashBytes = md5.ComputeHash(bytes);
            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2")); // 将字节转换为十六进制字符串
            }
            return sb.ToString();
        }


        public static IPEndPoint ToIPEndPoint(this string value)
        {
            var strArray = value.Split(":");
            return new IPEndPoint(IPAddress.Parse(strArray[0]), int.Parse(strArray[1]));
        }

        public static byte[] ToUTF8ByteArray(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static ArraySegment<byte> ToUTF8ByteArraySegment(this string value)
        {
            return new ArraySegment<byte>(value.ToUTF8ByteArray());
        }
    }
}
