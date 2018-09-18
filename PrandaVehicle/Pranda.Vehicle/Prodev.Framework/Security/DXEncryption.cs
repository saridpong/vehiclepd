using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.Security
{
    public class DXEncryption
    {
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            byte[] zeroIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    //var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = passwordBytes;
                    AES.IV = zeroIV;
                    AES.Padding = PaddingMode.Zeros;
                    AES.Mode = CipherMode.ECB;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            byte[] zeroIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    //var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = passwordBytes;
                    AES.IV = zeroIV;
                    AES.Padding = PaddingMode.Zeros;
                    AES.Mode = CipherMode.ECB;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public string EncryptTextWithHashPassword(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string EncryptTextWithoutHashPassword(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = DXEncryption.StringToByteArray(password);

            // Hash the password with SHA256
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string EncryptTextToBitConverter(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = DXEncryption.StringToByteArray(password);

            // Hash the password with SHA256
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = BitConverter.ToString(bytesEncrypted.ToArray()).Replace("-", String.Empty);

            return result;
        }

        public string EncryptTextWithoutHashPassword(string input)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = DXEncryption.StringToByteArray("862d75e134b05028fa38f1c3977ab1e8739583941006befbe09c0ac102d7f374");

            // Hash the password with SHA256
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public string DecryptTextWithoutHashPassword(string input)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = DXEncryption.StringToByteArray("862d75e134b05028fa38f1c3977ab1e8739583941006befbe09c0ac102d7f374");

            // Hash the password with SHA256
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Decrypt(bytesToBeEncrypted, passwordBytes);

            string result = System.Text.Encoding.UTF8.GetString(bytesEncrypted).TrimEnd('\0');

            return result;
        }

        public string DecryptTextWithoutHashPassword(string input, string password)
        {
            try
            {
                // Get the bytes of the string
                byte[] bytesToBeEncrypted = Convert.FromBase64String(input);
                byte[] passwordBytes = DXEncryption.StringToByteArray(password);

                // Hash the password with SHA256
                //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesEncrypted = AES_Decrypt(bytesToBeEncrypted, passwordBytes);

                //string result = System.Text.Encoding.UTF8.GetString(bytesEncrypted).TrimEnd('\0').TrimEnd('\u0001').TrimEnd('\u0002').TrimEnd('\u0003');
                string result1 = DXEncryption.BytesToStringConverted(bytesEncrypted);
                int i = result1.LastIndexOf("}");
                if (i < result1.Length -1)
                {
                    result1 = result1.Remove(i + 1);
                }

                i = result1.IndexOf("{");
                if (i != 0)
                {
                    result1 = result1.Remove(0, i);
                }

                return result1;
            }
            catch (Exception ex)
            {
                throw new Exception("input cannot be decrypt please contact support.", ex);
            }
        }

        static string BytesToStringConverted(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
