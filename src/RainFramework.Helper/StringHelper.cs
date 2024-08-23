using System.Security.Cryptography;
using System.Text;

namespace RainFramework.Helper
{
    /// <summary>
    /// String帮助类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 转化为Md5 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToMD5Str(string text)
        {
            using MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text + "12x@#!#$!@$!$");
            byte[] hashBytes = md5.ComputeHash(bytes);
            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2")); // 将字节转换为十六进制字符串
            }
            return sb.ToString();
        }
    }
}
