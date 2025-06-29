
namespace eCommerce.Core.DTO;

//Automatically contstructor will be generated that is called as parameterised or primary constructor
public record RegisterRequest(
    string? Email,
    string? Password,
    string? PersonName,
    GenderOptions? Gender
    )
{
    //Parameterless constructor

    public RegisterRequest() : this(default, default, default, default)
    {
    }
};
