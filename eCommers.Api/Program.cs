using eCommers.Infrastructure;
using eCommers.Core;
using eCommers.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//Add services here...
builder.Services.AddInfrastructure();
builder.Services.AddCore();
//AdD Controllers here...
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controllers routes
app.MapControllers();

app.Run();
