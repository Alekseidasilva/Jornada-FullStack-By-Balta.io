using Fina.Api.Api;
using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.EndPoints.Transations;

public class GetByPeriodTransationEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    =>app.MapPost("/{id}",HandleAsync)
    .WithName("Transation: Get By All")
        .WithSummary("Recuperar todas as Transacoes")
        .WithDescription("Recuperar todas as Transacoes")
        .WithOrder(5)
        .Produces<Response<Core.Models.Transation?>>();

    private static async Task<IResult> HandleAsync(
        //ClaimsPrincipal user,
        ITransationHandler handler,
        [FromQuery] DateTime? startDate=null,
        [FromQuery]DateTime? endDate=null,
        [FromQuery]int pageNumber=ApiConfiguration.DefaultPageNumber,
        [FromQuery]int pageSize=ApiConfiguration.DefaultPageSize)
    {
        var request = new GetTransationByPeriodRequest
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate,
        };
        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);

    }

}