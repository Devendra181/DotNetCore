
using eCommerce.ProductsService.DataAccessLayer;
using eCommerce.ProductsService.BusinessLogicLayer;
using FluentValidation.AspNetCore;
using eCommerce.ProductsMicroService.API.Middleware;
using eCommerce.ProductsMicroService.API.APIEndpoints;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Add model binder to read values fro JSON to enum
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

//Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Core
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseExceptionHandingMiddleware();

app.UseRouting();

//Cores
app.UseCors();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Https Redirection
app.UseHttpsRedirection();

//Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();

app.Run();
