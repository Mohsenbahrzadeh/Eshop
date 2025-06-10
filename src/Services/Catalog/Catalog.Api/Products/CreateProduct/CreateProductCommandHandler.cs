
using  BuildingBlocks.CQRS;
using Catalog.Api.Models;

namespace Catalog.Api.Products.CreateProduct;
public record CreateProductCommand(string Name,
                                   List<string> Categories, 
                                   string Description,
                                   string ImageFile,
                                   decimal Price):ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);



public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //create product entity from command object
        //save product entity to database
        //return the created product id

        var product=new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };


        return new CreateProductResult(Guid.NewGuid());
       
    }
}

