using EshopWeb.CoreLayer.DTOs.Products;
using EshopWeb.CoreLayer.Mapper.Products;
using EshopWeb.CoreLayer.Utilities;
using EshopWebAPI.Context;

namespace EshopWebAPI.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        public ProductService(MyDbContext context)
        {
            _context = context;
        }

        public List<ProductDto> GetAllProduct()
        {
            return _context.products.Select(product => new ProductDto()
            {
                ID = product.ID,
                Title = product.Title,
                Description = product.Description,
                ImageName = product.ImageName,
                Price = product.Price,
            }).ToList();
        }
        public async Task<OperationResult> CreateProduct(CreateDto createDto)
        {
            if (createDto == null)
                return OperationResult.Error("مقدار ورودی نباید خالی باشد");

            var product = CreateDtoMapper.Map(createDto);

            if (createDto.ImageFile != null)
            {
                string savePath = Path.Combine(Directory.GetCurrentDirectory(), PathDirectories.ProductImage, createDto.ImageFile.FileName);
                using var fs = new FileStream(savePath, FileMode.Create);
                createDto.ImageFile.CopyTo(fs);
            }

            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
        public Task<OperationResult> UpdateProduct(EditDto product)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ProductDto> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProduct(string id)
        {
            throw new NotImplementedException();
        }


    }
}
