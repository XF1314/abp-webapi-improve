using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Fdc.Common
{

    public class FinanceDESHelper
    {
        //密钥
        private static string sessionKey = "111111111111111111111111";
        //向量
        private static string iv = "12345678";

        /// <summary>
        /// C# 财务 费用报销 DES加密方法
        /// </summary>
        public static string DESEncrypt(string originalValue)
        {
            return DESEncrypt(originalValue, sessionKey, iv);
        }

        public static string DESEncrypt(string originalValue, string key, string iv)
        {
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(originalValue);
            originalValue = Convert.ToBase64String(bytes);
            byte[] rgbKey = Encoding.Default.GetBytes(key);
            byte[] rgbIV = Encoding.Default.GetBytes(iv);
            byte[] inputByteArray = Encoding.Default.GetBytes(originalValue);
            TripleDESCryptoServiceProvider dCSP = new TripleDESCryptoServiceProvider();
            dCSP.Padding = PaddingMode.PKCS7;//补位
            dCSP.Mode = CipherMode.CBC;
            dCSP.Key = rgbKey;
            dCSP.IV = rgbIV;

            using (var mStream = new MemoryStream())
            {
                using (var cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cStream.Write(inputByteArray, 0, inputByteArray.Length);
                    cStream.FlushFinalBlock();
                    string returnVal = Convert.ToBase64String(mStream.ToArray());
                    return returnVal;
                }
            }
        }

        /// <summary>
        ///  C# 财务 费用报销 DES解密方法 
        /// </summary>
        public static string DESDecrypt(string encryptedValue)
        {
            return DESDecrypt(encryptedValue, sessionKey, iv);
        }

        public static string DESDecrypt(string encryptedValue, string key, string iv)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = Encoding.UTF8.GetBytes(iv);
                byte[] inputByteArray = Convert.FromBase64String(encryptedValue);
                TripleDESCryptoServiceProvider dCSP = new TripleDESCryptoServiceProvider();
                dCSP.Padding = PaddingMode.PKCS7;//补位
                dCSP.Mode = CipherMode.CBC;
                dCSP.Key = rgbKey;
                dCSP.IV = rgbIV;
                using (var mStream = new MemoryStream())
                {
                    byte[] inData = Convert.FromBase64String(encryptedValue);
                    using (CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cStream.FlushFinalBlock();
                        string encodeResult = Encoding.UTF8.GetString(mStream.ToArray());
                        byte[] bytes = Convert.FromBase64String(encodeResult);
                        return Encoding.GetEncoding("UTF-8").GetString(bytes);
                    }
                }
            }
            catch (Exception)
            {
                return encryptedValue;
            }
        }

        /// <summary>
        ///  C# 财务 费用报销 MD5加密
        /// </summary>
        public static string MD5Encrypt(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Default.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            //将加密结果进行转换字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in targetData)
            {
                //将字节转换成16进制表示的字符串，而且是恒占用两位从头再来
                sb.Append(b.ToString("x2"));
            }
            //返回加密的字符串
            return sb.ToString();
        }
    }
}
