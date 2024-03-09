using LutryShop.Web.Models;
using LutryShop.Web.Services.IServices;
using LutryShop.Web.Utils;
using System.Net;

namespace LutryShop.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;
        public const string url = $"api/v1/coupon";

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<CouponViewModel> GetCoupon(string code, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.GetAsync($"{url}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
            return await response.ReadContentAsync<CouponViewModel>();
        }
    }
}
