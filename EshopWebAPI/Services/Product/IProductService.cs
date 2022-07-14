using EshopWeb.CoreLayer.DTOs.Products;
using EshopWeb.CoreLayer.Utilities;

namespace EshopWebAPI.Services.Product
{
    public interface IProductService
    {
        List<ProductDto> GetAllProduct();
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> GetProduct(string id);
        Task<OperationResult> CreateProduct(CreateDto createDto);
        Task<OperationResult> UpdateProduct(EditDto product);
        Task<OperationResult> DeleteProduct(int id);
    }
}
