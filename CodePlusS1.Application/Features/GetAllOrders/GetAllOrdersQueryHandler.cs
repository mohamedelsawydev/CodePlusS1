using CodePlusS1.Domain.Models;
using CodePlusS1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePlusS1.Application.Features.GetAllOrders
{
    public class GetOrderDetailsQueryHandler
    {
        private readonly TaskDbContext context;

        public GetOrderDetailsQueryHandler(TaskDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OrderDto>> Handle()
        {
            var orders = context.Orders.Include(o=>o.OrderItems).ToList();
            var orderDtos = orders.Select(order => new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            }).ToList();
            return orderDtos;

        }

        
    }
}
