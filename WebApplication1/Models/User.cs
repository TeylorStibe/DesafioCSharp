using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public User()
        {

        }

        public User(string name, DateTime birthdate, string cpf, string address, string city)
        {
            Name = name;
            Birthdate = birthdate;
            CPF = cpf;
            Address = address;
            City = city;
        }
    }
}
