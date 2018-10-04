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
        [Column(Order = 1, TypeName = "numeric")]
        public decimal RequestLineID { get; set; }

        [StringLength(100)]
        public string RequestLineDescription { get; set; }

        [StringLength(100)]
        public string Place { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }


        [StringLength(20)]
        public string UpdateBy { get; set; }


        public DateTime? UpdateDate { get; set; }
        [StringLength(20)]
        public string CreateBy { get; set; }


        public DateTime? CreateDate { get; set; }


    }
}
