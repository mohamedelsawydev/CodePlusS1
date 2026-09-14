using CodePlusS1.Domain.Models;
using CodePlusS1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePlusS1.Application.Features.CreateOrder
{
    public class GetAllOrdersHandler
    {
        private readonly TaskDbContext context;

        public GetAllOrdersHandler(TaskDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(GetAllOrdersQuery command)
        {
            foreach (var item in command.OrderItemsDto)
            {
                var product = context.Products.Find(item.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {item.ProductId} not found.");
                }
                if (product.StockQuantity < item.Quantity)
                {
                    throw new Exception($"Not enough quantity for product with ID {item.ProductId}. Available: {product.StockQuantity}, Requested: {item.Quantity}");
                }
                product.StockQuantity -= item.Quantity;
            }
            var order = new Order
            {
                CustomerName = command.CustomerName,
                CustomerEmail = command.CustomerEmail,
                TotalAmount = command.OrderItemsDto.Sum(item => item.Quantity * GetProductPrice(item.ProductId)),
                OrderItems = command.OrderItemsDto.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };
          

            context.Orders.Add(order);
            await context.SaveChangesAsync();
            //return the order ID after saving the order
            return order.Id;
        }

        private decimal GetProductPrice(int productId)
        {
                
            var product = context.Products.Find(productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }
            return product.Price;
        }
    }
}
