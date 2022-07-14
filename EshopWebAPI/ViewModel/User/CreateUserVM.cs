using System.ComponentModel.DataAnnotations;

namespace EshopWebAPI.ViewModel.User
{
    public class CreateUserVM
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن {} الزامی میباشد")]
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
    }
}
