using System.ComponentModel.DataAnnotations;

namespace EshopWebAPI.ViewModel.Product
{
    public class CreateVM
    {
        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public string Title { get; set; }
        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public string Description { get; set; }
        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public int Price { get; set; }
        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public IFormFile ImageFile { get; set; }
    }
}
