using Fina.Api.Commom.Api;
using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories;

public class CreateCategoryEndPoint:IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/",HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova Categoria")
            .WithDescription("Cria uma nova Categoria")
            .WithOrder(1)
            .Produces<Response<Core.Models.Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
      var response=await  handler.CreateAsync(request);
      return response.IsSuccess ? TypedResults.Created($"v1/Categories/{response.Data?.Id}",response) 
          : TypedResults.BadRequest(response);
    }
}






