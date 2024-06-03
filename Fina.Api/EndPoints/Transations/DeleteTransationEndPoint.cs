using System.Security.Claims;
using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transations;

public class DeleteTransationEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}",HandleAsync)
            .WithName("Transation: Delete")
            .WithSummary("Excluir uma Transacao")
            .WithDescription("Excluir uma Transacao")
            .WithOrder(3)
            .Produces<Response<Core.Models.Transation?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransationHandler handler,
        long id)
    {
        var request = new DeleteTransationRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}