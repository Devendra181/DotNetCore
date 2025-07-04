
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID fo the user
        //ApplicationUser user1 = new ApplicationUser();
        user.UserId = Guid.NewGuid();

        //SQL Query to insert user data into the "Users" table
        string query = "INSERT INTO public. \"Users\" (\"UserID\", \"Email\", \"Password\", \"PersonName\", \"Gender\")" +
            "Values(@UserID, @Email, @Password, @PersonName, @Gender)";

        //We are exuting non query insert, delete, update
        int rowCountAfftected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowCountAfftected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }

    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? passwor)
    {

        //SQL Query to select a user by Email and Password

        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        var parameters = new { Email = email, Password = passwor };

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;

        //return new ApplicationUser()
        //{
        //    UserId = Guid.NewGuid(),
        //    Email = email,
        //    Password = passwor,
        //    PersonName = "Person Name",
        //    Gender = GenderOptions.Male.ToString()
        //};

    }
}
