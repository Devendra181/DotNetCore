using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public ProductAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            _db = appDbContext;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> productsList = _db.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(productsList);
            }
            catch (Exception ex) 
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product product = _db.Products.First(x => x.ProductId == id);
                _responseDto.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                Product? product = _db.Products.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());

                if (product == null)
                {
                    _responseDto.IsSucces = false;
                    _responseDto.Mesages = "Product Not found";
                }

                _responseDto.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);

                if (product == null) 
                {
                    _responseDto.IsSucces = false;
                    _responseDto.Mesages = "Product Does Not Exists";
                }
                else
                {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _db.Products.Update(product);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex) 
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product product = _db.Products.First(x => x.ProductId == id);
                
                _db.Products.Remove(product);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                _responseDto.IsSucces = false;
                _responseDto.Mesages = ex.Message;
            }
            return _responseDto;
        }
    }
}
