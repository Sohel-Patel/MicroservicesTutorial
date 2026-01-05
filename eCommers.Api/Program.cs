using eCommers.Infrastructure;
using eCommers.Core;
using eCommers.Api.Middlewares;
using System.Text.Json.Serialization;
using eCommers.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);
//Add services here...
builder.Services.AddInfrastructure();
builder.Services.AddCore();
//AdD Controllers here...
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

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
