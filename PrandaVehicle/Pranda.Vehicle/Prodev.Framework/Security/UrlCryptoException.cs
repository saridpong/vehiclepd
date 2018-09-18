using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.Security
{
    public class UrlCryptoException : Exception
    {
        public UrlCryptoException() : base()
        {
        }

        // Constructor with exception message
        public UrlCryptoException(string message) : base(message)
        {
        }

        // Constructor with message and inner exception
        public UrlCryptoException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
