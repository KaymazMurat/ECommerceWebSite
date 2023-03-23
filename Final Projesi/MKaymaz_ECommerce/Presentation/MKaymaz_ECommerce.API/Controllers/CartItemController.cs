using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.CartItem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("cartItem")]
    [ApiController]
    public class CartItemController : BaseApiController<CartItemController>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemController(
            ICartItemRepository cartItemRepository,
            IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponseDto>>>> GetCartItems()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var cartItemResult = _mapper.Map<List<CartItemResponseDto>>(await _cartItemRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var cartItemResult = _mapper.Map<List<CartItemResponseDto>>(await _cartItemRepository.TableNoTracking.ToListAsync());
            if (cartItemResult.Count > 0)
                return new WebApiResponse<List<CartItemResponseDto>>(true, "Success", cartItemResult);
            else
                return new WebApiResponse<List<CartItemResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponseDto>>> GetCartItem(Guid id)
        {

            var cartItemResult = _mapper.Map<CartItemResponseDto>(await _cartItemRepository.GetById(id));
            if (cartItemResult != null)
                return new WebApiResponse<CartItemResponseDto>(true, "Success", cartItemResult);
            else
                return new WebApiResponse<CartItemResponseDto>(false, "Error");
        }

        [HttpGet("query/{cartId}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponseDto>>>> GetCartItemQuery(Guid cartId)
        {

            var cartItemResult = _mapper.Map<List<CartItemResponseDto>>(await _cartItemRepository.GetDefault(x=>x.CartId==cartId && x.Status != Common.Enums.Status.Deleted).Include(x=>x.Product).ToListAsync());
            if (cartItemResult != null)
                return new WebApiResponse<List<CartItemResponseDto>>(true, "Success", cartItemResult);
            else
                return new WebApiResponse<List<CartItemResponseDto>>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponseDto>>> PostCartItem(CartItemRequestDto request)
        {
            CartItem cartItem = _mapper.Map<CartItem>(request);
            var insertResult = await _cartItemRepository.Add(cartItem);
            if (insertResult != null)
            {
                CartItemResponseDto rm = _mapper.Map<CartItemResponseDto>(insertResult);
                return new WebApiResponse<CartItemResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CartItemResponseDto>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponseDto>>> PutCartItem(Guid id, CartItemRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                CartItem entity = await _cartItemRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _cartItemRepository.Update(entity);
                if (updateResult != null)
                {
                    CartItemResponseDto rm = _mapper.Map<CartItemResponseDto>(updateResult);
                    return new WebApiResponse<CartItemResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CartItemResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponseDto>>> DeleteCartItem(Guid id)
        {
            var cartItem = await _cartItemRepository.GetById(id);
            if (cartItem != null)
            {
                if (await _cartItemRepository.Remove(cartItem))
                    return new WebApiResponse<CartItemResponseDto>(true, "Success", _mapper.Map<CartItemResponseDto>(cartItem));
                else
                    return new WebApiResponse<CartItemResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CartItemResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCartItem(Guid id)
        {
            bool result = await _cartItemRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponseDto>>>> GetActiveCartItems()
        {
            var cartItemResult = _mapper.Map<List<CartItemResponseDto>>(await _cartItemRepository.GetActive().ToListAsync());
            if (cartItemResult.Count > 0)
                return new WebApiResponse<List<CartItemResponseDto>>(true, "Success", cartItemResult);
            else
                return new WebApiResponse<List<CartItemResponseDto>>(false, "Error");
        }

        [HttpGet("GetByProductId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponseDto>>>> GetByProductId(Guid id)
        {
            var productImageLists = await _cartItemRepository.GetDefault(x => x.ProductId == id).ToListAsync();
            if (productImageLists.Count > 0)
                return new WebApiResponse<List<CartItemResponseDto>>(true, "Success", _mapper.Map<List<CartItemResponseDto>>(productImageLists));
            return new WebApiResponse<List<CartItemResponseDto>>(false, "Error");
        }
    }
}
