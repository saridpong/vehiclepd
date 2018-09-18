using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response
{
    public class BaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string Description { get; set; }
        public Exception Exception { get; set; }
        public int Total { get; set; }
    }

    public enum ResponseStatus
    {
        Success = 1,
        NotFound = 2,
        Duplicated = 3,
        AlreadyPayment = 4,
        Failed = 9,
        Timeout = 5
    }
}
