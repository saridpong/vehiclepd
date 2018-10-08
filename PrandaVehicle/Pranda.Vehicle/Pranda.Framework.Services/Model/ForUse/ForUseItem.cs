using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.ForUse
{
    public class ForUseItem
    {
        public int ForUseID { get; set; }
        public string ForUseCode { get; set; }
        public string ForUseName { get; set; }
        public string Priority { get; set; }
        public decimal Status { get; set; }
    }
}
