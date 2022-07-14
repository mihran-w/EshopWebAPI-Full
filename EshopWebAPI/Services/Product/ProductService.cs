using EshopWeb.CoreLayer.DTOs.Products;
using EshopWeb.CoreLayer.Mapper.Products;
using EshopWeb.CoreLayer.Utilities;
using EshopWebAPI.Context;
using EshopWebAPI.Services.FileManager;

namespace EshopWebAPI.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        private readonly IFileManager _fileManager;
        public ProductService(MyDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
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

            product.ImageName = _fileManager.SaveFile(createDto.ImageFile, PathDirectories.ProductImage);

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
