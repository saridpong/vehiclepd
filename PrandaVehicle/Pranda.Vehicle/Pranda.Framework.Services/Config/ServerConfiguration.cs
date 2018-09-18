using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Config
{
    public class ServerConfiguration
    {
        public static SiteEnvrionment SiteEnvrionment
        {
            get
            {
                return SiteEnvrionment.DEV;
            }
        }
    }
    public enum SiteEnvrionment
    {
        PROD = 1,
        DEV = 2
    }
}
