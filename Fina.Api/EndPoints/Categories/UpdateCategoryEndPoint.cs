using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories;

public class UpdateCategoryEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    =>app.MapPut("/{id}",HandleAsync)
    .WithName("Categories: Update")
        .WithSummary("Actualiza uma  Categoria")
        .WithDescription("Actualiza uma  Categoria")
        .WithOrder(1)
        .Produces<Response<Core.Models.Category?>>();

    private static async Task<IResult> HandleAsync(
       // ClaimsPrincipal user,
        ICategoryHandler handler,
        UpdateCategoryRequest request,
        long id)
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;
        var result=await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}