using AutoMapper;
using LutryShop.CouponApi.Data.ValueObjects;
using LutryShop.CouponApi.Models;

namespace LutryShop.CouponApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
