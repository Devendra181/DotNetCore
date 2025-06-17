using eCommerce.Core.DTO;
namespace eCommerce.Core.ServiceContracts;


/// <summary>
/// Contract for the users service that contains us cases for the uses
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handel user login use case and returns an AuthenticationResponse object that contains status of login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
  Task<AuthenticationResponse?>  Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handel user registration use case and returns an AuthenticationResponse object that contains status of registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse>  Register(RegisterRequest registerRequest);
}
