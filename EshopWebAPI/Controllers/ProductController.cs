using EshopWeb.CoreLayer.DTOs.Products;
using EshopWeb.CoreLayer.Utilities;
using EshopWebAPI.Services.Product;
using EshopWebAPI.ViewModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            return _productService.GetAllProduct();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var product = await _productService.GetProduct(id);
            return (product == null) ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var data = HttpContext.Request.Form;
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

            var product = new CreateDto();
            foreach (var kvp in dic.Keys)
            {
                PropertyInfo pi = product.GetType().GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {
                    pi.SetValue(product, dic[kvp], null);
                }

                if (data.Files.Count > 0)
                {
                    IFormFile img = data.Files[0];
                    product.ImageFile = img;
                }

            }

            await _productService.CreateProduct(product);

            return Ok(product);
        }

    }
}
