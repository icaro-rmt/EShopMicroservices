﻿namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart): ICommand<StoreBasketResult>;
    public record StoreBasketResult(string Username); 

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is Required");
        }
    }
    public class StoreBasketCommandHandler
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>

    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;

            //TODO: Store basket in database (using Marten UPSERT - if exist = update, if not = Create)
            //TODO: Update cache

            return new StoreBasketResult("swn");


        }
    }
}
