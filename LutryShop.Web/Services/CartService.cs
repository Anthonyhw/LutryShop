using LutryShop.Web.Models;
using LutryShop.Web.Services.IServices;
using LutryShop.Web.Utils;
using System.Net.Http.Headers;
using System.Text.Json;

namespace LutryShop.Web.Services
{
    public class CartService : ICartService
    {

        private readonly HttpClient _httpClient;
        public const string url =  $"api/v1/cart";

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.GetAsync( $"{url}/find-cart/{userId}");
            return await response.ReadContentAsync<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            //_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.PostAsJson($"{url}/add-cart", cart);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CartViewModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.PutAsJson($"{url}/update-cart", cart);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CartViewModel>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.DeleteAsync($"{url}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Something went wrong when calling the API.");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }
    }
}
