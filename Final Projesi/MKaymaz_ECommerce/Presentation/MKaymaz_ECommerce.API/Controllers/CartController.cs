using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartController : BaseApiController<CartController>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(
            ICartRepository cartRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCarts()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.TableNoTracking.ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }

        [HttpGet("query/{userId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCartsByQuery(Guid userId)
        {
            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetDefault(x => x.UserId == userId && string.IsNullOrEmpty(x.Locked) && x.Status != Status.Deleted, x=>x.Cartİtems).ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }

        [HttpGet("session/{sessionId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetCartsBySession(Guid sessionId)
        {
            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetDefault(x => x.SessionId == sessionId && string.IsNullOrEmpty(x.Locked) && x.Status != Status.Deleted, x => x.Cartİtems).ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }


        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> GetCart(Guid id)
        {

            var cartResult = _mapper.Map<CartResponseDto>(await _cartRepository.GetById(id));
            if (cartResult != null)
                return new WebApiResponse<CartResponseDto>(true, "Success", cartResult);
            else
                return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpGet("query/active/{userId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> GetActiveCart(Guid userId)
        {
            var activeCart = await _cartRepository.GetDefault(x => x.UserId==userId && (x.Locked== null || x.Locked == "")).ToListAsync();
            var cartResult = _mapper.Map<CartResponseDto>(activeCart.LastOrDefault());
            if (cartResult != null)
                return new WebApiResponse<CartResponseDto>(true, "Success", cartResult);
            else
                return new WebApiResponse<CartResponseDto>(false, "Error");
        }


        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> PostCart(CartRequestDto request)
        {
            Cart cart = _mapper.Map<Cart>(request);
            var insertResult = await _cartRepository.Add(cart);
            if (insertResult != null)
            {
                CartResponseDto rm = _mapper.Map<CartResponseDto>(insertResult);
                return new WebApiResponse<CartResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> PutCart(Guid id, CartRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Cart entity = await _cartRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _cartRepository.Update(entity);
                if (updateResult != null)
                {
                    CartResponseDto rm = _mapper.Map<CartResponseDto>(updateResult);
                    return new WebApiResponse<CartResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CartResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponseDto>>> DeleteCart(Guid id)
        {
            var cart = await _cartRepository.GetById(id);
            if (cart != null)
            {
                if (await _cartRepository.Remove(cart))
                    return new WebApiResponse<CartResponseDto>(true, "Success", _mapper.Map<CartResponseDto>(cart));
                else
                    return new WebApiResponse<CartResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CartResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCart(Guid id)
        {
            bool result = await _cartRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponseDto>>>> GetActiveCarts()
        {
            var cartResult = _mapper.Map<List<CartResponseDto>>(await _cartRepository.GetActive().ToListAsync());
            if (cartResult.Count > 0)
                return new WebApiResponse<List<CartResponseDto>>(true, "Success", cartResult);
            else
                return new WebApiResponse<List<CartResponseDto>>(false, "Error");
        }
    }
}
