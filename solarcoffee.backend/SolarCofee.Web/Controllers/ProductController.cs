using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCofee.Services.Product;
using SolarCofee.Web.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCofee.Web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
             _logger = logger;
            _productService = productService;
        }

        [HttpGet("/api/products")]
        public ActionResult GetProduc()
        {
            _logger.LogInformation("Getting all products");
            var products = _productService.GetAllProducts();
            var productViewModels = products.Select(ProductMapper.SerializeProductModel);
            return Ok(productViewModels); 
        }
    }
}
