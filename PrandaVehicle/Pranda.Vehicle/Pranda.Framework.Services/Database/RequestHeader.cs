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

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string RequestHeaderCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestHeaderDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DepartmentID { get; set; }

        [StringLength(20)]
        public string DepartmentCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ApproveBy { get; set; }

        [StringLength(20)]
        public string ApproveByCode { get; set; }

        [StringLength(200)]
        public string JobType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Piority { get; set; }

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

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal RequestBy { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string RequestByCode { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal UpdateBy { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string UpdateByCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RequestHeaderStatus { get; set; }
    }
}
