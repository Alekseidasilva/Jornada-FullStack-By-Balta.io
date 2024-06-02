using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

const string connectionsString = "Server=localhost,1433;Database=FinaDb;User ID=sa;Password=049222Xp12;Trusted_Connection=false;TrustServerCertificate=true;";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(x=>x
    .UseSqlServer(connectionsString));
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransationHandler, TransationHandler>();




var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


