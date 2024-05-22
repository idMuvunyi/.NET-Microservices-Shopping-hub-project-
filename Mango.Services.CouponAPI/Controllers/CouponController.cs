using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CouponController(AppDbContext db, IMapper imapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = imapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(couponList);
                _response.Message = "Fetched the coupons successfully";

            }
            catch (Exception ex){
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.Message = "Fetched successfully";
               

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpGet]
        [Route("GetCode/{code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                if(coupon == null)
                {
                    _response.IsSuccess=false;
                }
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.Message = "Fetched successfully";


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPost]
        public ResponseDTO CreateCoupon([FromBody] CouponDTO couponDTO)
        {
            try
            {

                Coupon couponObj = _mapper.Map<Coupon>(couponDTO);

                var addedCoupon = _db.Coupons.Add(couponObj);
                if(addedCoupon == null)
                {
                    _response.IsSuccess=false;
                    _response.Message = "coupon set no right";
                }
                _db.SaveChanges();

                
                _response.Result = _mapper.Map<CouponDTO>(couponObj);
                _response.Message = "Saved successfully";
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDTO UpdateCoupon([FromBody] CouponDTO couponDTO)
        {
            try
            {

                Coupon couponObj = _mapper.Map<Coupon>(couponDTO);

                var addedCoupon = _db.Coupons.Update(couponObj);
                if (addedCoupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "coupon set no right";
                }
                _db.SaveChanges();


                _response.Result = _mapper.Map<CouponDTO>(couponObj);
                _response.Message = "Updated successfully";

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO DeleteCoupon(int id)
        {
            try
            {

                Coupon coupon = _db.Coupons.First(u => u.CouponId == id);
               
                if (coupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon with not exists";
                }

                var addedCoupon = _db.Coupons.Remove(coupon);
                if (addedCoupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "coupon not deleted";
                }
                _db.SaveChanges();

                _response.Message = "Deleted successfully";

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
