using CodePlusS1.Application.Features.CreateOrder;
using CodePlusS1.Application.Features.GetAllOrders;

namespace CodePlusS1.API.Features.GetAllOrders
{
    public static class GetAllOrdersEndPoint
    {
        public static void MapGetAllOrdersEndPoint(WebApplication app)
        {
            app.MapGet("/api/orders", async (
                GetOrderDetailsQueryHandler handler) =>
            {
                var response = await handler.Handle();

                return Results.Ok(response);
            }).WithTags("Order");
        }
    }
}
