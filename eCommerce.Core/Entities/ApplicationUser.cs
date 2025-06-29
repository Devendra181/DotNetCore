using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Entities;

public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}

//public record ApplicationUser
//(  
//    //Guid UserId,
//    string? Email,
//    string? Password,
//    string? PersonName,
//    string? Gender
//)
//{
//    public Guid UserId { get; init; }
//    public ApplicationUser() : this( default, default, default, default)
//    {
//    }
//};

