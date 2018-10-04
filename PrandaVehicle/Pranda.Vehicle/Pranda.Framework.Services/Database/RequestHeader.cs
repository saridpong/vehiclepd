namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestHeader")]
    public partial class RequestHeader
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal RequestHeaderID { get; set; }


        [StringLength(20)]
        public string DocumentNo { get; set; }

        public int UserID { get; set; }

        [StringLength(100)]
        public string UserFirstName { get; set; }

        [StringLength(100)]
        public string UserSurname { get; set; }

        [StringLength(100)]
        public string UserPosition { get; set; }
        [StringLength(20)]
        public string UserSectionCode { get; set; }
        [StringLength(100)]
        public string UserSectionName { get; set; }
        [StringLength(20)]
        public string UserDepartmentCode { get; set; }
        [StringLength(100)]
        public string UserDepartmentName { get; set; }
        [StringLength(20)]
        public string UserPhone { get; set; }
        [StringLength(20)]
        public string UserMobile { get; set; }
        [StringLength(100)]
        public string Approver { get; set; }

        public DateTime? DocumentDate { get; set; }



        [Column(TypeName = "numeric")]
        public decimal? ApproveBy { get; set; }

        [StringLength(20)]
        public string ApproveByCode { get; set; }

        [StringLength(200)]
        public string JobType { get; set; }

        public string Priority { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalPasenger { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EstimateDistance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EstimateCost { get; set; }

        [StringLength(1000)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RequestHeaderStatus { get; set; }


        [Column(TypeName = "numeric")]
        public decimal? VehicleID { get; set; }
        [StringLength(50)]
        public string VehicleCode { get; set; }
        [StringLength(20)]
        public string VehicleTypeCode { get; set; }
        [StringLength(100)]
        public string VehicleTypeName { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? DriverID { get; set; }
        [StringLength(20)]
        public string DriverCode { get; set; }
        [StringLength(80)]
        public string DriverName { get; set; }
        [StringLength(40)]
        public string DriverMobile { get; set; }
        [StringLength(300)]
        public string ApproveRemark { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? MilesIn { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? MilesOut { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? Diff_Miles { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? Diff_Miles_Est { get; set; }
        public DateTime? VehicleTimeIn { get; set; }
        public DateTime? VehicleTimeOut { get; set; }
        public TimeSpan? DiffVehicleTime { get; set; }
    }
}
