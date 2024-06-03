using Fina.Api;
using Fina.Api.Commom.Api;
using Fina.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
//builder.addSecurity();
builder.AddDataContext();
builder.AddCrossOrigins();
builder.AddDocumentation();
builder.AddServices();



var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
//app.UseSecurity();
app.MapEndPoints();
app.Run();













