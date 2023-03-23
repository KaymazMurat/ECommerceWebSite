using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.OrderAddress;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.OrderAddress;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("orderAddress")]
    [ApiController]
    public class OrderAddressController : BaseApiController<OrderAddressController>
    {
        private readonly IOrderAddressRepository _orderAddressRepository;
        private readonly IMapper _mapper;

        public OrderAddressController(
            IOrderAddressRepository orderAddressRepository,
            IMapper mapper)
        {
            _orderAddressRepository = orderAddressRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderAddressResponseDto>>>> GetOrderAddresses()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var orderAddressResult = _mapper.Map<List<OrderAddressResponseDto>>(await _orderAddressRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var orderAddressResult = _mapper.Map<List<OrderAddressResponseDto>>(await _orderAddressRepository.TableNoTracking.ToListAsync());
            if (orderAddressResult.Count > 0)
                return new WebApiResponse<List<OrderAddressResponseDto>>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<List<OrderAddressResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> GetOrderAddress(Guid id)
        {

            var orderAddressResult = _mapper.Map<OrderAddressResponseDto>(await _orderAddressRepository.GetById(id));
            if (orderAddressResult != null)
                return new WebApiResponse<OrderAddressResponseDto>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> PostOrderAddress(OrderAddressRequestDto request)
        {
            OrderAddress orderAddress = _mapper.Map<OrderAddress>(request);
            var insertResult = await _orderAddressRepository.Add(orderAddress);
            if (insertResult != null)
            {
                OrderAddressResponseDto rm = _mapper.Map<OrderAddressResponseDto>(insertResult);
                return new WebApiResponse<OrderAddressResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> PutOrderAddress(Guid id, OrderAddressRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderAddress entity = await _orderAddressRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _orderAddressRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderAddressResponseDto rm = _mapper.Map<OrderAddressResponseDto>(updateResult);
                    return new WebApiResponse<OrderAddressResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponseDto>>> DeleteOrderAddress(Guid id)
        {
            var orderAddress = await _orderAddressRepository.GetById(id);
            if (orderAddress != null)
            {
                if (await _orderAddressRepository.Remove(orderAddress))
                    return new WebApiResponse<OrderAddressResponseDto>(true, "Success", _mapper.Map<OrderAddressResponseDto>(orderAddress));
                else
                    return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<OrderAddressResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrderAddress(Guid id)
        {
            bool result = await _orderAddressRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderAddressResponseDto>>>> GetActiveOrderAddresses()
        {
            var orderAddressResult = _mapper.Map<List<OrderAddressResponseDto>>(await _orderAddressRepository.GetActive().ToListAsync());
            if (orderAddressResult.Count > 0)
                return new WebApiResponse<List<OrderAddressResponseDto>>(true, "Success", orderAddressResult);
            else
                return new WebApiResponse<List<OrderAddressResponseDto>>(false, "Error");
        }
    }
}
