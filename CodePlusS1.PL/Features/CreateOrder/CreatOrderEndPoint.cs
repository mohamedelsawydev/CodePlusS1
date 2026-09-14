using CodePlusS1.Application.Features.CreateOrder;

namespace CodePlusS1.API.Features.CreateOrder
{
    public static class CreatOrderEndPoint
    {
        public static void MapCreateOrderEndPoint(WebApplication app)
        {
            app.MapPost("/api/orders", async (
                GetAllOrdersQuery command,
                GetAllOrdersHandler handler) =>
            {
                var response = await handler.Handle(command);

                return Results.Ok(response);
            }).WithTags("Order");
        }
    }
}
