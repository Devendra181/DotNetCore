
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID fo the user
        user.UserId = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? passwor)
    {

        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = passwor,
            PersonName = "Person Name",
            Gender = GenderOptions.Male.ToString()
        };

    }
}
