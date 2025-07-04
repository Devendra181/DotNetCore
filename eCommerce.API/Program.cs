using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

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

builder.Services.AddFluentValidationAutoValidation();

//Add API explorer service
builder.Services.AddEndpointsApiExplorer();

//Add swagger generation services to create swagger specification
builder.Services.AddSwaggerGen();

//Add cores services
builder.Services.AddCors(optinos =>
{
    optinos.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


var app = builder.Build();


app.UseExceptionHandlingMiddleware();

//Routng
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger(); //Adds endpoint that can serve the swagger.json
app.UseSwaggerUI(); //Adds swagger UI (interactive page to explore and test API endpoints)

app.UseCors();

//Controller routes
app.MapControllers();

app.Run();
