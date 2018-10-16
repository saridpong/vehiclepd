namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformationLogin")]
    public partial class InformationLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "numeric")]
        public int InformationLoginID { get; set; }

        [StringLength(2000)]
        public string InformationLoginData { get; set; }

        public decimal Status { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
