using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.OrderItem;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.OrderItem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("orderItem")]
    [ApiController]
    public class OrderItemController : BaseApiController<OrderItemController>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemController(
            IOrderItemRepository orderItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetOrderItems()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var orderItemResult = _mapper.Map<List<OrderItemResponseDto>>(await _orderItemRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var orderItemResult = _mapper.Map<List<OrderItemResponseDto>>(await _orderItemRepository.TableNoTracking.ToListAsync());
            if (orderItemResult.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> GetOrderItem(Guid id)
        {

            var orderItemResult = _mapper.Map<OrderItemResponseDto>(await _orderItemRepository.GetById(id));
            if (orderItemResult != null)
                return new WebApiResponse<OrderItemResponseDto>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> PostOrderItem(OrderItemRequestDto request)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(request);
            var insertResult = await _orderItemRepository.Add(orderItem);
            if (insertResult != null)
            {
                OrderItemResponseDto rm = _mapper.Map<OrderItemResponseDto>(insertResult);
                return new WebApiResponse<OrderItemResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> PutOrderItem(Guid id, OrderItemRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderItem entity = await _orderItemRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _orderItemRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderItemResponseDto rm = _mapper.Map<OrderItemResponseDto>(updateResult);
                    return new WebApiResponse<OrderItemResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponseDto>>> DeleteOrderItem(Guid id)
        {
            var orderItem = await _orderItemRepository.GetById(id);
            if (orderItem != null)
            {
                if (await _orderItemRepository.Remove(orderItem))
                    return new WebApiResponse<OrderItemResponseDto>(true, "Success", _mapper.Map<OrderItemResponseDto>(orderItem));
                else
                    return new WebApiResponse<OrderItemResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderItemResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrderItem(Guid id)
        {
            bool result = await _orderItemRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponseDto>>>> GetActiveOrderItems()
        {
            var orderItemResult = _mapper.Map<List<OrderItemResponseDto>>(await _orderItemRepository.GetActive().ToListAsync());
            if (orderItemResult.Count > 0)
                return new WebApiResponse<List<OrderItemResponseDto>>(true, "Success", orderItemResult);
            else
                return new WebApiResponse<List<OrderItemResponseDto>>(false, "Error");
        }
    }
}
