using LutryShop.Web.Models;
using LutryShop.Web.Services.IServices;
using LutryShop.Web.Utils;

namespace LutryShop.Web.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;
        public const string url = $"api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAll()
        {
            var response = await _httpClient.GetAsync(url);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindById(long id)
        {
            var response = await _httpClient.GetAsync($"{url}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            var response = await _httpClient.PostAsJson(url, product);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProductModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<ProductModel> Update(ProductModel product)
        {
            var response = await _httpClient.PutAsJson(url, product);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProductModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Something went wrong when calling the API.");
        }
    }
}
