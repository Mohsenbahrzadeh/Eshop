

namespace Catalog.Api.Products.CreateProduct;

public record CreateProductRequest(string Name,
                                    List<string> Categories,
                                    string Description,
                                    string ImageFile,
                                    decimal Price);

/// <summary>
/// Represents the response returned after creating a new product.
/// </summary>
/// <param name="Id">The unique identifier of the newly created product.</param>
public record CreateProductResponse(Guid Id);


public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();
            // result Results.Created("/products/{id}", response);
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create a new product")
       .WithDescription("This endpoint allows you to create a new product in the catalog. " +
            "You need to provide the product name, categories, description, image file, and price.");
    }
    /*
    public static void MapCreateProductEndpoint(WebApplication app)
    {
        app.MapPost("/products", async (CreateProductCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Created($"/products/{result.Id}", result);
        })
        .WithName("CreateProduct")
        .WithTags("Products");
    }
    */

}
