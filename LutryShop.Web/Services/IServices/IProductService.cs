using LutryShop.Web.Models;

namespace LutryShop.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> FindAll(string token);
        Task<ProductViewModel> FindById(long id, string token);
        Task<ProductViewModel> Create(ProductViewModel product, string token);
        Task<ProductViewModel> Update(ProductViewModel product, string token);
        Task<bool> Delete(long id, string token);
    }
}
