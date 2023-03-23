using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Order;
using MKaymaz_ECommerce.Service.Repository.OrderItem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderRepository orderRepository,
            IMapper mapper, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderItemRepository=orderItemRepository;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderResponseDto>>>> GetOrders()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var orderResult = _mapper.Map<List<OrderResponseDto>>(await _orderRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var orderResult = _mapper.Map<List<OrderResponseDto>>(await _orderRepository.TableNoTracking.ToListAsync());
            if (orderResult.Count > 0)
                return new WebApiResponse<List<OrderResponseDto>>(true, "Success", orderResult);
            else
                return new WebApiResponse<List<OrderResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderResponseDto>>> GetOrder(Guid id)
        {

            var orderResult = _mapper.Map<OrderResponseDto>(await _orderRepository.GetById(id));
            if (orderResult != null)
                return new WebApiResponse<OrderResponseDto>(true, "Success", orderResult);
            else
                return new WebApiResponse<OrderResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderResponseDto>>> PostOrder(OrderRequestDto request)
        {
            Order order = _mapper.Map<Order>(request);
            var insertResult = await _orderRepository.Add(order);
            if (insertResult != null)
            {

                OrderResponseDto rm = _mapper.Map<OrderResponseDto>(insertResult);
                return new WebApiResponse<OrderResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponseDto>>> PutOrder(Guid id, OrderRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Order entity = await _orderRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _orderRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderResponseDto rm = _mapper.Map<OrderResponseDto>(updateResult);
                    return new WebApiResponse<OrderResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponseDto>>> DeleteOrder(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            if (order != null)
            {
                if (await _orderRepository.Remove(order))
                    return new WebApiResponse<OrderResponseDto>(true, "Success", _mapper.Map<OrderResponseDto>(order));
                else
                    return new WebApiResponse<OrderResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrder(Guid id)
        {
            bool result = await _orderRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderResponseDto>>>> GetActiveOrders()
        {
            var orderResult = _mapper.Map<List<OrderResponseDto>>(await _orderRepository.GetActive().ToListAsync());
            if (orderResult.Count > 0)
                return new WebApiResponse<List<OrderResponseDto>>(true, "Success", orderResult);
            else
                return new WebApiResponse<List<OrderResponseDto>>(false, "Error");
        }
    }
}
