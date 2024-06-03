using Fina.Api.EndPoints.Category;

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
            .RequireAuthorization();
        //.MapEndPoint<CreateCategoryEndPoint>()
        
    }
    
}














