using LutryShop.Web.Models;
using LutryShop.Web.Services.IServices;
using LutryShop.Web.Utils;
using System.Net.Http.Headers;

namespace LutryShop.Web.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;
        public const string url =  $"api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductViewModel>> FindAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.GetAsync(url);
            return await response.ReadContentAsync<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.GetAsync($"{url}/{id}");
            return await response.ReadContentAsync<ProductViewModel>();
        }

        public async Task<ProductViewModel> Create(ProductViewModel product, string token   )
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.PostAsJson(url, product);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProductViewModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<ProductViewModel> Update(ProductViewModel product, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.PutAsJson(url, product);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProductViewModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<bool> Delete(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Something went wrong when calling the API.");
        }
    }
}
