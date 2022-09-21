using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    internal class UserAppRoleSeed : IEntityTypeConfiguration<UserAppRole>
    {
        public void Configure(EntityTypeBuilder<UserAppRole> builder)
        {
            builder.HasData(
                new UserAppRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new UserAppRole { Id = "2", Name = "TeamLead", NormalizedName = "TEAMLEAD" },
                new UserAppRole { Id = "3", Name = "User", NormalizedName = "USER" }
                );
        }
    }
}
