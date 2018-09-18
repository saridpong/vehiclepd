using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RefreshToken")]
    public partial class RefreshToken
    {
        [StringLength(400)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        public DateTime? IssuedUtc { get; set; }

        public DateTime? ExpiresUtc { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }
    }
}
