namespace Basket.API.Basket.GetAllBaskets
{
    public record GetAllBasketResponse(IEnumerable<string> UserName);
    public class GetAllBasketsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket_GetAll", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAllBasketsQuery());
                var response = result.Adapt<GetAllBasketResponse>();

                return Results.Ok(response);
            })
                .WithName("GetAllBasket")
                .Produces<GetAllBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get All Basket")
                .WithDescription("Get All Basket");
        }
    }
}
