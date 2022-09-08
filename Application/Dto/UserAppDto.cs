using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserAppDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }//identity user'daki verileri döneceğiz
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        //public string Password { get; set; }
        public string Picture { get; set; }
        public string Skills { get; set; }
    }
}
