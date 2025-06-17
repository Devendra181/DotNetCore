
using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

//? means nullable

/// <summary>
/// Contract to be implemented by UsersRepository tht contails data access logic of Users data store
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a user to the data store and return the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);


    /// <summary>
    /// Method to retrive existing user by their email and passwordd
    /// </summary>
    /// <param name="email"></param>
    /// <param name="passwor"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? passwor);
}
