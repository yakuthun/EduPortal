using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FollowBaseEntity
    {
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public int UpdatedKey{ get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedKey { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedKey { get; set; }
    }
}
