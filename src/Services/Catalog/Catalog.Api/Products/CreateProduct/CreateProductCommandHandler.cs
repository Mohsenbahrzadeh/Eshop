using MediatR;
using  BuildingBlocks.CQRS;

namespace Catalog.Api.Products.CreateProduct;
public record CreateProductCommand(string Name,
                                   List<string> Categories, 
                                   string Description,
                                   string ImageFile,
                                   decimal Price):ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);



public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

