using Fina.Api.Api;
using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transations;

public class GetByIdTransationEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}",HandleAsync)
            .WithName("Transation: Get By Id")
            .WithSummary("Recuperar uma Transacao")
            .WithDescription("Recuperar uma Transacao")
            .WithOrder(3)
            .Produces<Response<Core.Models.Transation?>>();

    private static async Task<IResult> HandleAsync(
        //ClaimsPrincipal user,
        ITransationHandler handler,
        long id)
    {
        var request = new GetByIdTransationRequest
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