using Fina.Api.Commom.Api;
using Fina.Api.EndPoints.Categories;
using Fina.Api.EndPoints.Transations;

namespace Fina.Api.EndPoints;

public static class EndPoint
{
    public static void MapEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        endpoints.MapGroup("/")
            .WithTags("health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            //.RequireAuthorization()
            .MapEndPoint<CreateCategoryEndPoint>()
            .MapEndPoint<CreateCategoryEndPoint>()
            .MapEndPoint<UpdateCategoryEndPoint>()
            .MapEndPoint<DeleteCategoryEndPoint>()
            .MapEndPoint<GetByIdCategoryEndPoint>()
            .MapEndPoint<GetAllCategoryEndPoint>();
        
        
        endpoints.MapGroup("v1/transation")
            .WithTags("Transations")
            //.RequireAuthorization()
            .MapEndPoint<CreateTransationEndPoint>()
            .MapEndPoint<CreateTransationEndPoint>()
            .MapEndPoint<UpdateTransationEndPoint>()
            .MapEndPoint<DeleteTransationEndPoint>()
            .MapEndPoint<GetByIdTransationEndPoint>()
            .MapEndPoint<GetByPeriodTransationEndPoint>();
        
    }

    private static IEndpointRouteBuilder MapEndPoint<TEndpoints>(this IEndpointRouteBuilder app)
        where TEndpoints : IEndpoint
    {
        TEndpoints.Map(app);
        return app;
    }
    
}














