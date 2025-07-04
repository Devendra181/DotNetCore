

using BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductService
{
    /// <summary>
    /// Retrives the list of products from the prodts repository
    /// </summary>
    /// <returns>Retruns list of ProductResponse object</returns>
    Task<List<ProductResponse?>> GetProducts();

    /// <summary>
    /// Retrives the list of products matching with given condition
    /// </summary>
    /// <param name="conditionExpression">Expression that represents the condition to check</param>
    /// <returns>Retuns the maching products</returns>
    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);

    /// <summary>
    /// Retrives the single product matching with given condition
    /// </summary>
    /// <param name="conditionExpression">Expression that represents the condition to check</param>
    /// <returns>Retuns the maching product or null</returns>
    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);

    /// <summary>
    /// Adds (inserts) product into the table using products repository
    /// </summary>
    /// <param name="productAddRequest">prodct to insert</param>
    /// <returns>Rroduct after inserting or null if unsuccsesful</returns>
    Task<ProductResponse?> AddProduct(ProductUpdateRequest productAddRequest);


  
    /// <summary>
    /// Updates the existing product based on the ProductID
    /// </summary>
    /// <param name="productUpdateRequest">Product data to update</param>
    /// <returns>Returns product object after successful updation; otherwise null</returns>
    Task<ProductResponse?> UpdatedProduct(ProductUpdateRequest productUpdateRequest);

    /// <summary>
    /// Deletes an existing product based on given product id
    /// </summary>
    /// <param name="productID">ProductID to search and delete</param>
    /// <returns>Returns true if the deletion is successful; otherwise false</returns>
    Task<bool> DeleteProduct(Guid productID);
}
