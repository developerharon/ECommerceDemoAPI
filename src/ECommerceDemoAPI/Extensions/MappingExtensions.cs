﻿using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
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
                result.Add(MapProductToGetProductDTO(product, mapper));
            }
            return result;
        }

        public static GetProductDTO MapProductToGetProductDTO(this Product product, IMapper mapper)
        {
            return mapper.Map<GetProductDTO>(product);
        }

        public static IEnumerable<GetOrderDTO> MapOrderListToGetOrderDTOList(this IEnumerable<Order> orders, IMapper mapper)
        {
            var result = new List<GetOrderDTO>(orders.Count());
            foreach (var order in orders)
            {
                result.Add(MapOrderToGetOrderDTO(order, mapper));
            }
            return result;
        }

        public static GetOrderDTO MapOrderToGetOrderDTO(this Order order, IMapper mapper)
        {
            return mapper.Map<GetOrderDTO>(order);
        }
    }
}