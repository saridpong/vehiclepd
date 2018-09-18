namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Section")]
    public partial class Section
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal SectionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string SectionCode { get; set; }

        [StringLength(100)]
        public string SectionName { get; set; }

        [StringLength(100)]
        public string SectionApproveName { get; set; }

        [StringLength(100)]
        public string SectionApprovePosition { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Status { get; set; }
    }
}
