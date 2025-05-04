using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System.IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPrductService _productService;
        private readonly ICartService _cartService;
        public HomeController(ILogger<HomeController> logger, IPrductService prductService, ICartService cartService)
        {
            _logger = logger;
            _productService = prductService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> products = new List<ProductDto>();

            ResponseDto? response = await _productService.GetAllProductAsync();

            if (response != null && response.IsSucces) 
            { 
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));  
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(products);
        }


        [Authorize]
        public async Task<ActionResult> ProdutDetails(int productId)
        {
            ProductDto? product = new ProductDto();

            ResponseDto? response = await _productService.GetProductAsync(productId);

            if (response != null && response.IsSucces)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(product);
        }


        [Authorize]
        [HttpPost]
        [ActionName("ProdutDetails")]
        public async Task<ActionResult> ProdutDetails(ProductDto productDto)
        {
            CartDto cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto()
                {
                    UserId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value
                }
            };

            CartDetailsDto cartDetails = new CartDetailsDto()
            {
                Count = productDto.Count,
                ProductId = productDto.ProductId,
            };

            List<CartDetailsDto> cartDetailsDtos = new() { cartDetails };
            cartDto.CartDetails = cartDetailsDtos;

            ResponseDto? response = await _cartService.UpsertCartAsych(cartDto);

            if (response != null && response.IsSucces)
            {
                TempData["success"] = "Item has been added to Shopping cart";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(productDto);
        }

        // [Authorize(Roles = SD.RoleAdmin)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
