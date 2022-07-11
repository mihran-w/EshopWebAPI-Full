using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopWeb.DataLayer.Entities
{
    public class Product : BaseEntity
    {
        [Display(Name ="عنوان محصول")]
        [Required(ErrorMessage ="وارد کردن {} الزامیست")]
        public string Title { get; set; }
        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public string Description { get; set; }
        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public int Price { get; set; }
        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "وارد کردن {} الزامیست")]
        public string ImageName { get; set; }
    }
}
