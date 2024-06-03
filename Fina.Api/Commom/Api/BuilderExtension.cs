using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Commom.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
        Configuration.BackEndUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? String.Empty;
        Configuration.FrontEndUrl = builder.Configuration.GetValue<string>("FrontEndUrl") ?? String.Empty;
    }
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            //Category=>Fina.Core.Models.Category
            x.CustomSchemaIds(n => n.FullName);
        });
    }
    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(ApiConfiguration.ConnectionString));
      //  builder.Services.AddIdentityCore<User>()
        //    .AddRoles<IdentityRole<long>>()
          //  .AddEntityFrameworkStores<AppDbContext>()
            //.AddApiEndPoints();
    }

    public static void AddCrossOrigins(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => options.AddPolicy(
            ApiConfiguration.CorsPolicyName,
            policy => policy.WithOrigins([
                    Configuration.BackEndUrl,
                    Configuration.FrontEndUrl
                ])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
        ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
        builder.Services.AddTransient<ITransationHandler, TransationHandler>();
    }
    
}
