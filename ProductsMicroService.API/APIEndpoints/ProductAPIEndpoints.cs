
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;

namespace eCommerce.ProductsMicroService.API.APIEndpoints;

public static class ProductAPIEndpoints
{
    public static IEndpointRouteBuilder MapProductAPIEndpoints(this IEndpointRouteBuilder app)
    {
        //GET /api/products
        app.MapGet("/api/products",  async (IProductService productService) =>
        {
           List<ProductResponse?> products = await productService.GetProducts();

            return Results.Ok(products);
        });


        //GET /api/products/search/product-id/0000000-0000000000-0000000000000000
        app.MapGet("/api/products/search/product-id/{ProductID:guid}", async (IProductService productService, Guid
             ProductID) =>
        {
            ProductResponse? product = await productService.GetProductByCondition(temp => temp.ProductId == ProductID);

            return Results.Ok(product);
        });

        //GET /api/products/search/xxxxxxxxxxxxx
        app.MapGet("/api/products/search/{SearchString}", async (IProductService productService,string SearchString) =>
        {
            List<ProductResponse?> productsByProductName = await productService.GetProductsByCondition(temp => temp.ProductName != null && 
            temp.ProductName.Contains(SearchString, StringComparison.OrdinalIgnoreCase));

            List<ProductResponse?> productsByCategoryName = await productService.GetProductsByCondition(temp => temp.Category != null &&
            temp.Category.Contains(SearchString, StringComparison.OrdinalIgnoreCase));

            var products = productsByProductName.Union(productsByCategoryName).ToList();

            return Results.Ok(products);
        });


        //POST /api/products/
        app.MapPost("/api/products/", async (IProductService productService, IValidator<ProductAddRequest> productAddRequestValidator, ProductAddRequest productAddRequest) =>
        {
            //Validate the ProductAddRequest object using Fluent Validation

            ValidationResult validationResult = await productAddRequestValidator.ValidateAsync(productAddRequest);

            if (!validationResult.IsValid)
            {
                Dictionary<string, string[]> errors = validationResult.Errors
                .GroupBy(temp => temp.PropertyName)
                .ToDictionary(grp => grp.Key,
                    grp => grp.Select(err => err.ErrorMessage).ToArray());
                return Results.ValidationProblem(errors);
            };

            var addedProductResponse = await productService.AddProduct(productAddRequest);

            if (addedProductResponse != null)
                return Results.Created($"/api/products/search/product-id/{addedProductResponse.ProductId}", addedProductResponse);
            else
                return Results.Problem("Error in adding product");
        });


        //PUT /api/products/
        app.MapPut("/api/products/", async (IProductService productService, IValidator<ProductUpdateRequest> productUpdateRequestValidator, ProductUpdateRequest productUpdateRequest) =>
        {
            //Validate the ProductAddRequest object using Fluent Validation

            ValidationResult validationResult = await productUpdateRequestValidator.ValidateAsync(productUpdateRequest);

            if (!validationResult.IsValid)
            {
                Dictionary<string, string[]> errors = validationResult.Errors
                .GroupBy(temp => temp.PropertyName)
                .ToDictionary(grp => grp.Key,
                    grp => grp.Select(err => err.ErrorMessage).ToArray());
                return Results.ValidationProblem(errors);
            };

            var updatedProductResponse = await productService.UpdatedProduct(productUpdateRequest);

            if (updatedProductResponse != null)
                return Results.Ok(updatedProductResponse);
            else
                return Results.Problem("Error in updating product");
        });

        //DELETE /api/products/{ProductID}
        app.MapDelete("/api/products/{ProductID:guid}", async (IProductService productService, Guid ProductID) =>
        {
            bool isProductDelete = await productService.DeleteProduct(ProductID);

            if(isProductDelete)
                return Results.Ok(isProductDelete);
            else
                return Results.Problem("Error in deleting product");
        });

        return app;
    }
}
