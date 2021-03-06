﻿using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Model.ForUse;
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
        public string DocumentNoRef { get; set; }
        public int? ForUseID { get; set; }
        public string JobType { get; set; }
        public ForUseItem ForUse { get; set; }
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
        public string Rating { get; set; }
        public string Comment { get; set; }
        public decimal? MilesIn { get; set; }
        public decimal? MilesOut { get; set; }
        public decimal? Diff_Miles { get; set; }
        public decimal? Diff_Miles_Est { get; set; }
        public DateTime? VehicleTimeIn { get; set; }
        public DateTime? VehicleTimeOut { get; set; }
        public TimeSpan? DiffVehicleTime { get; set; }
   
        public decimal? LabourCost { get; set; }

        public decimal? FuelCost { get; set; }
 
        public decimal? FeeCost { get; set; }

        public decimal? OtherCost { get; set; }
    
        public decimal? TotalCost { get; set; }
  
        public decimal? DiffCost { get; set; }

    }
}
