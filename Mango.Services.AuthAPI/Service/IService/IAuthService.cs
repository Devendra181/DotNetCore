using Mango.Services.AuthAPI.Models.Dto;
using System.Globalization;

namespace Mango.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        //Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
