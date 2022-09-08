using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserApp:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool isTeamLead { get; set; }
        public bool IsActive { get; set; }
        public string Skills { get; set; }
        public string Picture { get; set; }

    }
}