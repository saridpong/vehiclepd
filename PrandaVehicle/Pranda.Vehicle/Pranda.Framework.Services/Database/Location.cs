namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "numeric")]
        public decimal LocationID { get; set; }

     
        [StringLength(20)]
        public string LocationCode { get; set; }

        [StringLength(80)]
        public string LocationName { get; set; }

 
        [Column( TypeName = "numeric")]
        public decimal Status { get; set; }


        [StringLength(20)]
        public string UpdateBy { get; set; }


        public DateTime UpdateDate { get; set; }
        [StringLength(20)]
        public string CreateBy { get; set; }


        public DateTime CreateDate { get; set; }
    }
}
