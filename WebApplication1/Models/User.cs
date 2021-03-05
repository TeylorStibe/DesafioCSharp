using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int id{ get; set; }
        public string Name{ get; set; }
        public DateTime Birthdate{ get; set; }
        public int CPF { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}
