using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingInASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [Route("Emp/All")]
        [HttpGet]
        public string GetAllEmployees()
        {
            return "Response from GetAllEmployees Method";
        }

        [Route("Emp/ById/{Id}")]
        [HttpGet]
        public string GetEmployeeById(int Id)
        {
            return $"Response from GetEmployeeById Method Id: {Id}";
        }

        [Route("Employee/Search")]
        [HttpGet]
        public string SearchEmployees(string? Department = "DefaultDepart")
        {
            return $"Return Employees with Department: {Department}";
        }

        // Using both route parameter and query string
        [Route("Employee/{Department}")]
        [HttpGet]
        public string GetEmployeesByGenderAndCity(string? Department, string? Gender, int? CityId)
        {
            return $"Return Employees with Gender: {Gender}, City: {CityId}, Department: {Department}";

        }
    }
}