using Fina.Api.Api;
using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories;

public class DeleteCategoryEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", handleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Exclui uma Categoria")
            .WithDescription("Exclui uma Categoria")
            .WithOrder(3)
            .Produces<Response<Core.Models.Category?>>();

    private static async Task<IResult> handleAsync(
      //  ClaimsPrincipal user,
        
        ICategoryHandler handler,
        long id)
    {
        var request = new DeleteCategoryRequest
        {
            UserId =ApiConfiguration.UserId,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
    
}