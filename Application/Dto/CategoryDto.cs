using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //[Required]
        public string? UpdatedKey{ get; set; }
        //[Required]
        public DateTime? CreatedDate { get; set; }
        //[Required]
        public string? CreatedKey { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedKey { get; set; }

    }
}
