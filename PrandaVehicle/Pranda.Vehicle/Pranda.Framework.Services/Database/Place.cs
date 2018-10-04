namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Place")]
    public partial class Place
    {
        [Key]
        public int PlaceID { get; set; }

    
        [StringLength(20)]
        public string PlaceCode { get; set; }

    
        [StringLength(80)]
        public string PlaceName { get; set; }
        [StringLength(100)]
        public string LocationName { get; set; }
        [StringLength(100)]
        public string Province { get; set; }
        
        [Column(TypeName = "numeric")]
        public decimal Status { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }

       
        public DateTime UpdateDate { get; set; }
        [StringLength(20)]
        public string CreateBy { get; set; }


        public DateTime CreateDate { get; set; }
    }
}
