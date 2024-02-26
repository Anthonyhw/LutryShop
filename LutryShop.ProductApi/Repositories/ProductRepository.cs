using AutoMapper;
using LutryShop.ProductApi.Context;
using LutryShop.ProductApi.Data.ValueObjects;
using LutryShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products =  await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductVO>>(products);

        }
        public async Task<ProductVO> FindById(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return vo;
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return vo;
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                
                if (product == null) return false;

                _context.Products.Remove(product);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
