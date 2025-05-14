using tarea9_DAEA.Domain.Entities;
using tarea9_DAEA.Domain.Services;

namespace tarea9_DAEA.API;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", (ProductService service) =>
        {
            return Results.Ok(service.GetAllProducts());
        });

        app.MapPost("/products", (Product product, ProductService service) =>
        {
            try
            {
                service.AddProduct(product);
                return Results.Created($"/products/{product.Id}", product);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}
