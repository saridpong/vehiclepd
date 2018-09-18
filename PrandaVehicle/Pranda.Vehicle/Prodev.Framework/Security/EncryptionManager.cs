using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Prodev.Framwork.Extensions;

namespace Prodev.Framework.Security
{
   public class EncryptionManager
    {
        private static byte[] _sellTokenIV = new byte[] { 115, 31, 49, 175, 126, 221, 141, 16, 91, 181, 203, 40, 198, 201, 123, 10 };
        private static byte[] _sellTokenKey = new byte[] { 93, 239, 60, 28, 109, 32, 146, 175, 187, 25, 203, 70, 231, 8, 11, 253, 159, 150, 55, 143, 190, 65, 103, 46, 48, 150, 204, 67, 23, 110, 81, 79 };

        /// <summary>
        /// Encrypt string by AES algorythm 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Base64 string of AES encrypted data</returns>
        public static string Encrypt(string data)
        {
            byte[] encrypted = null;
            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var encryptor = csp.CreateEncryptor(csp.Key, csp.IV))
            {
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// decrypt the encrypted text
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            string decrypted_data = null;

            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var decryptor = csp.CreateDecryptor(_sellTokenKey, _sellTokenIV))
            {
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(data)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted_data = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted_data;
        }


        /// <summary>
        /// Encrypt string by AES algorythm 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Base64 string of AES encrypted data</returns>
        public static string EncryptHex(string data)
        {
            byte[] encrypted = null;
            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var encryptor = csp.CreateEncryptor(csp.Key, csp.IV))
            {
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return ConvertStringToHex(encrypted.ToString(), System.Text.Encoding.Unicode);
        }

        /// <summary>
        /// decrypt the encrypted text
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DecryptHex(string data)
        {
            string decrypted_data = null;

            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var decryptor = csp.CreateDecryptor(_sellTokenKey, _sellTokenIV))
            {
                using (MemoryStream msDecrypt = new MemoryStream(ConvertHexToByteArray(data)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted_data = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted_data;
        }

        /// <summary>
        /// encrypt sell token of journey and fare sell key
        /// </summary>
        /// <param name="journeySellKey"></param>
        /// <param name="fareSellKey"></param>
        /// <returns></returns>
        public static string GetSellToken(string journeySellKey, string fareSellKey)
        {
            string sellTokenData = Guid.NewGuid().ToString().Substring(0, 8) + "\r\n"  //for a bit of randomness...
                + journeySellKey + "\r\n"
                + fareSellKey + "\r\n"
                + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            byte[] encrypted = null;
            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var encryptor = csp.CreateEncryptor(csp.Key, csp.IV))
            {
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(sellTokenData);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// decrypt sell token
        /// </summary>
        /// <param name="sellToken"></param>
        /// <returns></returns>
        public static Tuple<string, string, DateTime> DecryptSellToken(string sellToken)
        {
            string sellTokenDecrypted = null;

            AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
            csp.IV = _sellTokenIV;
            csp.Key = _sellTokenKey;
            csp.Padding = PaddingMode.ISO10126;
            using (var decryptor = csp.CreateDecryptor(_sellTokenKey, _sellTokenIV))
            {
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(sellToken)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            sellTokenDecrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(sellTokenDecrypted))
            {
                string[] keyParts = sellTokenDecrypted.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (keyParts.Length == 4)
                {
                    return new Tuple<string, string, DateTime>(keyParts[1], keyParts[2], DateTime.Parse(keyParts[3], System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal));
                }
            }
            return null;
        }

        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public static byte[] ConvertHexToByteArray(String hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return bytes;
        }
    }

}

