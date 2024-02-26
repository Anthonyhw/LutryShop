using LutryShop.ProductApi.Data.ValueObjects;
using LutryShop.ProductApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LutryShop.ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll() 
        {
            var products = await _productRepository.FindAll();

            if (products == null) return NoContent();
            return Ok(products);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductVO>> FindById(long id) 
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NoContent(); 
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO product)
        {
            var result = await _productRepository.Create(product);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO product)
        {
            await _productRepository.Update(product);
            return Ok(product);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
    }
}
