using LutryShop.ProductApi.Data.ValueObjects;
using LutryShop.ProductApi.Repositories;
using LutryShop.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LutryShop.ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [AllowAnonymous]
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
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO product)
        {
            var result = await _productRepository.Create(product);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO product)
        {
            await _productRepository.Update(product);
            return Ok(product);
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
    }
}
