using eCommers.Infrastructure;
using eCommers.Core;
using eCommers.Api.Middlewares;
using System.Text.Json.Serialization;
using eCommers.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add services here...
builder.Services.AddInfrastructure();
builder.Services.AddCore();
//Add Controllers here...
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
//Add mappers
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Add automatic fluent validations 
builder.Services.AddFluentValidationAutoValidation();
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
