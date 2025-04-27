﻿using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                //_response.Result = objList;

                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(item => item.CouponId == id);

                //We need to use Automapper
                //CouponDto coupondto = new CouponDto()
                //{
                //    CouponId = obj.CouponId,
                //    CouponCode = obj.CouponCode,
                //    DiscountAmount = obj.DiscountAmount,
                //    MinAmount = obj.MinAmount
                //};

                //_response.Result = coupondto;

                _response.Result = _mapper.Map<CouponDto>(obj);


                //_response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(item => item.CouponCode.ToLower() == code.ToLower());

                if(obj == null)
                {
                    _response.IsSucces = false;
                    _response.Mesages = "Coupon Does Not Exists";
                }

                _response.Result = _mapper.Map<CouponDto>(obj);


            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj =  _mapper.Map<Coupon>(couponDto);

                if (obj == null)
                {
                    _response.IsSucces = false;
                    _response.Mesages = "Coupon Does Not Exists";
                }
                else
                {
                    _db.Coupons.Add(obj);
                    _db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u=>u.CouponId == id);

                _db.Coupons.Remove(obj);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Mesages = ex.Message;
            }

            return _response;
        }
    }
}
