namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category, string Description,string ImageFile,decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Required Name");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Required Category");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Required ImageFile");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be higher than 0");
        }
    }

    internal class CreateProductCommandHandler
        (IDocumentSession session, ILogger<CreateProductCommandHandler> logger) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create Product entity from Command Object
            //Creating a product Logic

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //Save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //Return CreateProductResult resul

            return new CreateProductResult(product.Id);

        }
    }
}

