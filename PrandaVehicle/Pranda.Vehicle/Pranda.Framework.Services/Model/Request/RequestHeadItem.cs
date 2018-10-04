using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Request
{
    public class RequestHeadItem
    {
        public decimal RequestHeaderID { get; set; }
        public int RequestHeaderStatus { get; set; }
        public string JobType { get; set; }
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalPassenger { get; set; }
        public decimal EstimateDistance { get; set; }
        public decimal EstimateCost { get; set; }
        public string Remark { get; set; }
        public decimal Status { get; set; }

        private string _statusDesc = "รออนุมัติ";
        public string StatusDesc { get
            {
                if(Status == 1)
                {
                    return "รออนุมัติ";
                }
                else if (Status == 2)
                {
                    return "อนุมัติ";
                }
                else if (Status == 2)
                {
                    return "อนุมัติ";
                }
                else if (Status == 3)
                {
                    return "รอให้คะแนน";
                }
                else if (Status == 4)
                {
                    return "รอบันทึกค่าแรง";
                }
                else if (Status == 5)
                {
                    return "ปิดงาน";
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
                _statusDesc =  value;
            }
        }
        public List<RequestLineItem> Places { get; set; }
        public VehicleItem Vehicle { get; set; }
        public DriverItem Driver { get; set; }
        public string ApproveRemark { get; set; }

    }
}
