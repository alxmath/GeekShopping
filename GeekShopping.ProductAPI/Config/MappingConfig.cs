using AutoMapper;
using GeekShopping.ProductAPI.Data.DataObjects;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}