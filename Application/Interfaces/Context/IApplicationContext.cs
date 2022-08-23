using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Context
{
    public interface IApplicationContext
    {
        DbSet<Education> Educations { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
