using CodePlusS1.Application.Features.CreateOrder;

namespace CodePlusS1.Application.Features.CreateOrder
{
    public record GetAllOrdersResponse
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();









    }
}
