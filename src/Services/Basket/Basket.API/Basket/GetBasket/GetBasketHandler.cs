namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName): IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    internal class GetBasketQueryHandler: 
        IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implement GET Basket from dataBase
            //var basket = await _repository.GetBasket(requests.UserName);

            return new GetBasketResult(new ShoppingCart("swn"));
            
        }
    }
}
