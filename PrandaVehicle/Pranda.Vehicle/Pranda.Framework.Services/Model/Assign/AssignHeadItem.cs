using Pranda.Framework.Services.Model.ForUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Assign
{
    public class AssignHeadItem
    {
        public decimal AssignHeaderID { get; set; }
        public int RequestHeaderStatus { get; set; }
        public DateTime DueDate { get; set; }
        public string Remark { get; set; }
        public decimal Status { get; set; }

        private string _statusDesc = "รออนุมัติ";
        public string StatusDesc
        {
            get
            {
                if (Status == 1)
                {
                    return "รออนุมัติ";
                }
                else if (Status == 2)
                {
                    return "อนุมัติ";
                }
                else if (Status == 6)
                {
                    return "ยกเลิก";
                }
                else
                {
                    return "รออนุมัติ";
                }
            }
            set
            {
                _statusDesc = value;
            }
        }
        public List<AssignLineItem> Lines { get; set; }
      
    }
}
