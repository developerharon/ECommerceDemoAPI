using AutoMapper;
using ECommerceDemoAPI.DTOs.Products;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<GetProductDTO> MapProductListToGetProductDTOList(this IEnumerable<Product> products, IMapper mapper)
        {
            var result = new List<GetProductDTO>(products.Count());
            foreach (var product in products)
            {
                result.Add(MapProductToGetProductDto(product, mapper));
            }
            return result;
        }

        public static GetProductDTO MapProductToGetProductDto(this Product product, IMapper mapper)
        {
            return mapper.Map<GetProductDTO>(product);
        }
    }
}