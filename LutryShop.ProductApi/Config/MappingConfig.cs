using AutoMapper;
using LutryShop.ProductApi.Data.ValueObjects;
using LutryShop.ProductApi.Models;

namespace LutryShop.ProductApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
