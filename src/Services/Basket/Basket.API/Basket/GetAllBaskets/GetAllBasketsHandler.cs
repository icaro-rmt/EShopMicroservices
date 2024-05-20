using Marten.Linq.QueryHandlers;

namespace Basket.API.Basket.GetAllBaskets
{
    public record  GetAllBasketsQuery(): IQuery<GetAllBasketsResult>;
    public record GetAllBasketsResult(IEnumerable<string> UserName);
    internal class GetAllBasketsHandler(IBasketRepository repository)
        : IQueryHandler<GetAllBasketsQuery, GetAllBasketsResult>
    {
        public async Task<GetAllBasketsResult> Handle(GetAllBasketsQuery request, CancellationToken cancellationToken)
        {
            var usernames = await repository.GetAllBaskets(cancellationToken);

            return new GetAllBasketsResult(usernames);
        }
    }
}
