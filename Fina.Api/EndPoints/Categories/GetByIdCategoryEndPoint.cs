using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories;

public class GetByIdCategoryEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get by Id")
            .WithSummary("Recupera uma Categoria")
            .WithDescription("Recupera uma Categoria")
            .WithOrder(4)
            .Produces<Response<Core.Models.Category?>>();


    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new GetByIdCategoryRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}