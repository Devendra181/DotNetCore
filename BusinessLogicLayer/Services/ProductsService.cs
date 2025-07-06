using AutoMapper;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.DataAccessLayer.Entities;
using eCommerce.DataAccessLayer.RepositoryContracts;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace eCommerce.BusinessLogicLayer.Services;

public class ProductsService : IProductService
{
    private readonly IValidator<ProductAddRequest> _productAddRequestValidator;
    private readonly IValidator<ProductUpdateRequest> _productUpdateRequestValidator;
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IValidator<ProductAddRequest> productAddRequestValidator,
        IValidator<ProductUpdateRequest> productUpdateRequestValidator,
        IMapper mapper, IProductsRepository productsRepository
        )
    {
        _productAddRequestValidator = productAddRequestValidator;
        _productUpdateRequestValidator = productUpdateRequestValidator;
        _mapper = mapper;
        _productsRepository = productsRepository;

    }

    public async Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest)
    {
        if (productAddRequest == null)
        {
            throw new ArgumentNullException(nameof(productAddRequest));
        }

        //Validate the product using Fluent Validation
        ValidationResult validationResult = await _productAddRequestValidator.ValidateAsync(productAddRequest);

        //Check the validation result
        if (!validationResult.IsValid)
        {
           string errors = string.Join(",", validationResult.Errors.Select(temp => temp.ErrorMessage)); //Error1, Error2, ...
            throw new ArgumentException(errors);
        }

        //Attempt to add product
       Product productInput =  _mapper.Map<Product>(productAddRequest); //Map productAddRequest into 'Product' type (it invokes ProductAddRequestToProductMappingProfile)
       Product? addedProduct = await _productsRepository.AddProduct(productInput);

        if(addedProduct == null)
        {
            return null;
        }

        ProductResponse addedProductResponse =
        _mapper.Map<ProductResponse>(addedProduct); //Map addedProduct into 'ProductResponse' type (it invokes ProductToProductResponseMappingProfile)

        return addedProductResponse;
    }

    public async Task<bool> DeleteProduct(Guid productID)
    {
        //it's fomality Product service and repository layer for database operation should be self sufficient to do the validation
        Product? existingProduct = await _productsRepository.GetProductByCondition(temp => temp.ProductId == productID);

        if (existingProduct == null)
        {
            return false;
        }
        
        //Attempt to delete product
        bool isProductDeleted = await _productsRepository.DeleteProduct(productID);

        return isProductDeleted;
    }

    public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        Product? product = await _productsRepository.GetProductByCondition(conditionExpression);

        if (product == null)
        {
            return null;
        }

        ProductResponse? productResponse = _mapper.Map<ProductResponse>(product); // ProductToProductResponseMappingProfile

        return productResponse;
    }

    public async Task<List<ProductResponse?>> GetProducts()
    {
        IEnumerable<Product?> Products = await _productsRepository.GetProducts();

        List<ProductResponse> allProductResponse = _mapper.Map<List<ProductResponse>>(Products);

        return allProductResponse.ToList();
    }

    public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        IEnumerable<Product?> Products = await _productsRepository.GetProductsByCondition(conditionExpression);

        List<ProductResponse?> allProductResponse = _mapper.Map<List<ProductResponse?>>(Products);

        return allProductResponse.ToList();
    }

    public async Task<ProductResponse?> UpdatedProduct(ProductUpdateRequest productUpdateRequest)
    {

        Product? existingProduct = await _productsRepository.GetProductByCondition(temp => temp.ProductId == productUpdateRequest.productId);

        if (existingProduct == null)
        {
            throw new ArgumentException("Invalid Product ID");
        }

        if (productUpdateRequest == null)
        {
            throw new ArgumentException("Product Not Supplied");
        }

        //Validate the product using Fluent Validation
        ValidationResult validationResult = await _productUpdateRequestValidator.ValidateAsync(productUpdateRequest);

        //Check the validation result
        if (!validationResult.IsValid)
        {
            string errors = string.Join(",", validationResult.Errors.Select(temp => temp.ErrorMessage)); //Error1, Error2, ...
            throw new ArgumentException(errors);
        }

        Product product = _mapper.Map<Product>(productUpdateRequest); //Invokes ProductUpdateRequestToProductMappingProfile

        Product? updatedProduct = await _productsRepository.UpdateProduct(product);

        ProductResponse productResponse = _mapper.Map<ProductResponse>(updatedProduct); //Invokes ProductToProductResponseMappingProfile

        return productResponse;
    }
}
