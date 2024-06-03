using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transations;

public class CreateTransationEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/",HandleAsync)
            .WithName("Transation: Create")
            .WithSummary("Cria uma nova Transacao")
            .WithDescription("Cria uma nova Transacao")
            .WithOrder(1)
            .Produces<Response<Core.Models.Transation?>>();

    public static async Task<IResult> HandleAsync(
        ITransationHandler handler,
        CreateTransationRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}