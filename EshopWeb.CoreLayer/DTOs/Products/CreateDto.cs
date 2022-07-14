using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopWeb.CoreLayer.DTOs.Products
{
    public class CreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
