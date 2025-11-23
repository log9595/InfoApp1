using System;
using System.Security.Cryptography;
using System.Text;

namespace InfoApp
{
    public class SecurityManager
    {
        private static string _key = "efAKC2vOGjN3LVPpC9IVyECj1xfF8P6cizChNEAexYU=";

        public static string MD5Protect(string input)
        {
            MD5 x = MD5.Create();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public static string XorEncrypt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
            byte[] result = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                result[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Convert.ToBase64String(result);
        }

        public static string XorDecrypt(string encrypted)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);
            byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
            byte[] result = new byte[encryptedBytes.Length];

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                result[i] = (byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Encoding.UTF8.GetString(result);
        }
    }
}
