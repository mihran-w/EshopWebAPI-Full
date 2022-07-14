using EshopWeb.CoreLayer.DTOs.Products;
using EshopWeb.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopWeb.CoreLayer.Mapper.Products
{
    public class CreateDtoMapper
    {
        public static Product Map(CreateDto CreateDto)
        {
            return new Product()
            {
                Title = CreateDto.Title,
                Description = CreateDto.Description,
                Price = CreateDto.Price,
                ImageName = CreateDto.ImageFile.FileName
            };
        }
    }
}
