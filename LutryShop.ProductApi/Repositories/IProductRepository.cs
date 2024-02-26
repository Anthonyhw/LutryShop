using LutryShop.ProductApi.Data.ValueObjects;

namespace LutryShop.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);

    }
}
