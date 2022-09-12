﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //[Required]
        public string? UpdatedKey { get; set; }
    }
}
