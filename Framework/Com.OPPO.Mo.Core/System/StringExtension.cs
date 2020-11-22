using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static string Md5Digest(this string source)
        {
            var stringBuilder = new StringBuilder();
            using (var md5 = MD5.Create())
            {

                var md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                for (var i = 0; i < md5Bytes.Length; i++)
                {
                    var val = Convert.ToInt32(md5Bytes[i] & 0xff);
                    if (val < 16)
                    {
                        stringBuilder.Append("0");
                    }
                    stringBuilder.Append(string.Format("{0:X}", val));
                }
            }

            return stringBuilder.ToString();
        }

        public static string HmacMd5Digest(this string source, string secret)
        {
            var stringBuilder = new StringBuilder();
            using (var hmacMd5 = new HMACMD5(Encoding.UTF8.GetBytes(secret)))
            {
                var md5Bytes = hmacMd5.ComputeHash(Encoding.UTF8.GetBytes(source));
                //转化为大写的16进制,不足的2位的前面补0,如 0x0A 如果没有2,就只会输出0xA

                #region Method 1
                //for (var i = 0; i < md5Bytes.Length; i++)
                //{
                //    var val = Convert.ToInt32(md5Bytes[i] & 0xff);
                //    if (val < 16)
                //    {
                //        stringBuilder.Append("0");
                //    }

                //    stringBuilder.Append(string.Format("{0:X}", val));
                //}
                #endregion

                #region Method 2
                for (var i = 0; i < md5Bytes.Length; i++)
                    stringBuilder.Append(md5Bytes[i].ToString("X2"));
                #endregion

                hmacMd5.Clear();
            }
            return stringBuilder.ToString();
        }


        public static string Md5DigestToLower(this string src)
        {
            //uft8,x2
            //创建对象的方法：构造方法，静态方法（工厂）
            MD5 md5 = MD5.Create();
            //将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(src);
            //调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            //将加密结果进行转换字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                //将字节转换成16进制表示的字符串，而且是恒占用两位从头再来
                sb.Append(b.ToString("x2"));
            }
            //返回加密的字符串
            return sb.ToString();
        }

    }
}
