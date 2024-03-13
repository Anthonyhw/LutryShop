using AutoMapper;
using LutryShop.CartApi.Context;
using LutryShop.CartApi.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net;
using System;
using System.Text.Json;

namespace LutryShop.CartApi.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        private readonly string url = "api/v1/coupon";

        public async Task<CouponVO> GetCouponByCode(string code, string token)
        {

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _client.GetAsync($"{url}/{code}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK) return new CouponVO();

            return JsonSerializer.Deserialize<CouponVO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
