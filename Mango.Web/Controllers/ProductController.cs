using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPrductService _prductService;

        public ProductController(IPrductService prductService)
        {
                _prductService = prductService;
        }
        public async Task<ActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();

            ResponseDto? response = await _prductService.GetAllProductAsync();

            if (response != null && response.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(list);
        }

        
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _prductService.CreateProductAsync(model);

                if (response != null && response.IsSucces)
                {
                    TempData["success"] = "Product Created Successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Mesages;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
          
            ResponseDto? response = await _prductService.GetProductAsync(productId);

            if (response != null && response.IsSucces)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));   
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }
           
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {

            ResponseDto? response = await _prductService.DeleteProductAsync(productDto.ProductId);

            if (response != null && response.IsSucces)
            {
                TempData["success"] = "Product Deleted Successfullys";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(productDto);
        }


        public async Task<IActionResult> ProductEdit(int productId)
        {

            ResponseDto? response = await _prductService.GetProductAsync(productId);

            if (response != null && response.IsSucces)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {

            ResponseDto? response = await _prductService.UpdateProductAsync(productDto);

            if (response != null && response.IsSucces)
            {
                TempData["success"] = "Product Edited Successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Mesages;
            }

            return View(productDto);
        }

    }
}
