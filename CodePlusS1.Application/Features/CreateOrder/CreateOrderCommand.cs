using CodePlusS1.Application.Features.CreateOrder;
using CodePlusS1.Domain.Models;

namespace CodePlusS1.Application.Features.CreateOrder
{
    public record GetAllOrdersQuery
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItemDto> OrderItemsDto { get; set; } = new List<OrderItemDto>();



    }
}
