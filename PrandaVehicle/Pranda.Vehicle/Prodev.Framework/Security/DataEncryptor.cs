using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using we.mdw.shared.Data.Repository;
using we.mdw.utils.Bll.Interfaces;
using we.mdw.utils.Dal;

namespace we.mdw.utils.Bll
{
    /// <summary>
    /// DataEncryptor class implemening IDataEncryptor interface provides data encryption functionality.
    /// </summary>
    public class DataEncryptor : IDataEncryptor
    {
        #region [Fields]

        /// <summary>
        /// The utilities unit of work for manipulating utilities data in database.
        /// </summary>
        private readonly IUnitOfWork _utilsUnitOfWork;
        /// <summary>
        /// The encryption key size (256 bits).
        /// </summary>
        private const int KEY_SIZE = 32;
        /// <summary>
        /// {0} = 1A Altea DX Booking Flow Endpoint.
        /// {1} = Current GMT time as yyyyMMddHHmmss format
        /// {2} = Encrypted params
        /// {3} = EMBEDDED_TRANSACTION what required by 1A Altea DX booking flow.
        /// {4} = SITE what required by 1A Altea DX booking flow.
        /// {5} = LANGUAGE what required by 1A Altea DX booking flow.
        /// </summary>
        private const string BOOKING_FLOW_URL_PARAMS_PATTERN = "{0}?ENCT=1&ENC_TIME={1}&ENC={2}&EMBEDDED_TRANSACTION={3}&SITE={4}&LANGUAGE={5}";

        #endregion


        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="DataEncryptor" /> class.
        /// </summary>
        /// <param name="utilsUnitOfWork">The utilities unit of work.</param>
        public DataEncryptor(IUnitOfWork utilsUnitOfWork)
        {
            _utilsUnitOfWork = utilsUnitOfWork;
        }

        #endregion


        #region [Methods]

        /// <summary>
        /// Get1AEncryptionKey method is intended for retrieving 1A Altea DX encryption key from database
        /// to encrypt tripflow parameters before redirect to booking flow system.
        /// </summary>
        /// <returns>The encryption key as byte array.</returns>
        public byte[] Get1AEncryptionKey()
        {
            return HexToBytes(_utilsUnitOfWork.GetRepository<Configuration>().GetById(Properties.Resources.ONE_A_ENC_KEY_NAME).Value);
        }

        /// <summary>
        /// GetMdwEncryptionKey method is intended for retrieving middleware encryption key from database
        /// to decrypt tripflow parameters which got from tripflow generator.
        /// </summary>
        /// <returns>The encryption key as byte array.</returns>
        public byte[] GetMdwEncryptionKey()
        {
            return HexToBytes(_utilsUnitOfWork.GetRepository<Configuration>().GetById(Properties.Resources.MDW_ENC_KEY_NAME).Value);
        }

        /// <summary>
        /// DecryptTripflow method is intended for decrypting tripflow parameters which got from tripflow generator.
        /// </summary>
        /// <param name="encryptionKey">The midleware encryption key.</param>
        /// <param name="tripflowEncryptedParams">The encrypted tripflow parameters which got from tripflow generator.</param>
        /// <returns>The plain tripflow parameters as query string.</returns>
        /// <exception cref="System.ArgumentNullException">encryptionKey, tripflowEncryptedParams</exception>
        /// <exception cref="System.ArgumentException">The encryptionKey length was wrong.</exception>
        public string DecryptTripflow(byte[] encryptionKey, string tripflowEncryptedParams)
        {
            // Validates parameters.
            if (encryptionKey == null || encryptionKey.Length == 0)
            {
                throw new ArgumentNullException(nameof(encryptionKey));
            }
            if (encryptionKey.Length != KEY_SIZE)
            {
                throw new ArgumentException(String.Format(Properties.Resources.ERR_WRONG_KEY_SIZE, KEY_SIZE * 8), nameof(encryptionKey));
            }
            if (String.IsNullOrEmpty(tripflowEncryptedParams))
            {
                throw new ArgumentNullException(nameof(tripflowEncryptedParams));
            }

            // Decrypts data with AES followed by Amadeus specification.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Mode = CipherMode.ECB;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor();

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(HexToBytes(tripflowEncryptedParams)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and return as string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// EncryptTripflow method is intended for encrypting tripflow parameters before redirect to booking flow system.
        /// </summary>
        /// <param name="encryptionKey">The 1A Altea DX encryption key.</param>
        /// <param name="tripflowParams">The plain tripflow parameters as query string.</param>
        /// <returns>The encrypted tripflow parameters as hex-decimal string without hyphen.</returns>
        /// <exception cref="System.ArgumentNullException">encryptionKey, tripflowParams</exception>
        /// <exception cref="System.ArgumentException">The encryptionKey length was wrong.</exception>
        public string EncryptTripflow(byte[] encryptionKey, string tripflowParams)
        {
            // Validates parameters.
            if (encryptionKey == null || encryptionKey.Length == 0)
            {
                throw new ArgumentNullException(nameof(encryptionKey));
            }
            if (encryptionKey.Length != KEY_SIZE)
            {
                throw new ArgumentException(String.Format(Properties.Resources.ERR_WRONG_KEY_SIZE, KEY_SIZE * 8), nameof(encryptionKey));
            }
            if (String.IsNullOrEmpty(tripflowParams))
            {
                throw new ArgumentNullException(nameof(tripflowParams));
            }

            // Encrypts data with AES followed by Amadeus specification.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Mode = CipherMode.ECB;

                // Create a encrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(tripflowParams);
                        }

                        return BitConverter.ToString(msEncrypt.ToArray()).Replace("-", String.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Get1ABookingFlowUrl method provides fully url for redirecting to booking flow system.
        /// </summary>
        /// <param name="tripflowEncryptedParams">The encrypted tripflow parameters as hex-decimal string without hyphen.</param>
        /// <param name="embeddedTransaction">The EMBEDDED_TRANSACTION query string what booking flow system requires.</param>
        /// <param name="site">The SITE query string what booking flow system requires.</param>
        /// <param name="language">The LANGUAGE query string what booking flow system requires.</param>
        /// <returns>The fully url for redirecting to booking flow system.</returns>
        /// <exception cref="System.ArgumentNullException">tripflowEncryptedParams, embeddedTransaction, site, language</exception>
        public Uri Get1ABookingFlowUrl(string tripflowEncryptedParams, string embeddedTransaction, string site, string language)
        {
            // Validates parameters.
            if (String.IsNullOrEmpty(tripflowEncryptedParams))
            {
                throw new ArgumentNullException(nameof(tripflowEncryptedParams));
            }
            if (String.IsNullOrEmpty(embeddedTransaction))
            {
                throw new ArgumentNullException(nameof(embeddedTransaction));
            }
            if (String.IsNullOrEmpty(site))
            {
                throw new ArgumentNullException(nameof(site));
            }
            if (String.IsNullOrEmpty(language))
            {
                throw new ArgumentNullException(nameof(language));
            }

            // Consolidates all parameters needed to be url.
            return new Uri(String.Format(BOOKING_FLOW_URL_PARAMS_PATTERN,
                                         _utilsUnitOfWork.GetRepository<Configuration>()
                                                         .GetById(Properties.Resources.ONE_A_BOOKING_FLOW_URL).Value,
                                         DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                                         tripflowEncryptedParams,
                                         embeddedTransaction,
                                         site,
                                         language));
        }

        /// <summary>
        /// HexToBytes method provides converting from hex-decimal without hyphen to byte array.
        /// </summary>
        /// <param name="hexString">The hex-decimal without hyphen.</param>
        /// <returns>The byte array.</returns>
        private byte[] HexToBytes(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                             .ToArray();
        }

        #endregion
    }
}
