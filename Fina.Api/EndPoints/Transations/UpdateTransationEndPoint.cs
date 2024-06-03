using System.Security.Claims;
using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transations;

public class UpdateTransationEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        =>app.MapPut("/{id}",HandleAsync)
            .WithName("Transation: Get By All")
            .WithSummary("Recuperar todas as Transacoes")
            .WithDescription("Recuperar todas as Transacoes")
            .WithOrder(5)
            .Produces<Response<Core.Models.Transation?>>();

    public static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransationHandler handler,
        UpdateTransationRequest request,
        long id
    )
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }

}








