using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignHeader")]
    public class AssignHeader
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal AssignHeaderID { get; set; }


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

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        
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
      
    }
}
