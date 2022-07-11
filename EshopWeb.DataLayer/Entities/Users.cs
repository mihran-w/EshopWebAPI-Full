using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopWeb.DataLayer.Entities
{
    public class Users:BaseEntity
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage ="وارد کردن {} الزامی میباشد")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن {} الزامی میباشد")]
        public string Family { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {} الزامی میباشد")]
        public string UserName { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "وارد کردن {} الزامی میباشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}
