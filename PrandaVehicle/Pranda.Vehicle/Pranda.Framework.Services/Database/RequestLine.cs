namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestLine")]
    public partial class RequestLine
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal RequestHeaderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string RequestHeaderCode { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal RequestLineID { get; set; }

        [StringLength(100)]
        public string RequestLineDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? placeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string UpdateBy { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime UpdateDate { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal RequestLineStatus { get; set; }
    }
}
