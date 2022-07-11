using EshopWeb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopWeb.CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}
