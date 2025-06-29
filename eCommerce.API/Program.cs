using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);


//Add Infrasture services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers to the serivce collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add
    (new JsonStringEnumConverter());    
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Build the web application
var app = builder.Build();


app.UseExceptionHandlingMiddleware();

//Routng
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
