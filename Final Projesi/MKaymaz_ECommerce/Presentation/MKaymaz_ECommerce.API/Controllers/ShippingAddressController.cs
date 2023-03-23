using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.ShippingAddres;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.ShippingAddress;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("shippingAddress")]
    [ApiController]
    public class ShippingAddressController : BaseApiController<ShippingAddressController>
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        private readonly IMapper _mapper;

        public ShippingAddressController(
            IShippingAddressRepository shippingAddressRepository,
            IMapper mapper)
        {
            _shippingAddressRepository = shippingAddressRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddresResponseDto>>>> GetShippingAddresses()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var shippingAddressResult = _mapper.Map<List<ShippingAddresResponseDto>>(await _shippingAddressRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var shippingAddressResult = _mapper.Map<List<ShippingAddresResponseDto>>(await _shippingAddressRepository.TableNoTracking.ToListAsync());
            if (shippingAddressResult.Count > 0)
                return new WebApiResponse<List<ShippingAddresResponseDto>>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<List<ShippingAddresResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ShippingAddresResponseDto>>> GetShippingAddress(Guid id)
        {

            var shippingAddressResult = _mapper.Map<ShippingAddresResponseDto>(await _shippingAddressRepository.GetById(id));
            if (shippingAddressResult != null)
                return new WebApiResponse<ShippingAddresResponseDto>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<ShippingAddresResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingAddresResponseDto>>> PostShippingAddress(ShippingAddresRequestDto request)
        {
            ShippingAddres shippingAddress = _mapper.Map<ShippingAddres>(request);
            var insertResult = await _shippingAddressRepository.Add(shippingAddress);
            if (insertResult != null)
            {
                ShippingAddresResponseDto rm = _mapper.Map<ShippingAddresResponseDto>(insertResult);
                return new WebApiResponse<ShippingAddresResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ShippingAddresResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddresResponseDto>>> PutShippingAddress(Guid id, ShippingAddresRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingAddres entity = await _shippingAddressRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _shippingAddressRepository.Update(entity);
                if (updateResult != null)
                {
                    ShippingAddresResponseDto rm = _mapper.Map<ShippingAddresResponseDto>(updateResult);
                    return new WebApiResponse<ShippingAddresResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ShippingAddresResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddresResponseDto>>> DeleteShippingAddress(Guid id)
        {
            var shippingAddress = await _shippingAddressRepository.GetById(id);
            if (shippingAddress != null)
            {
                if (await _shippingAddressRepository.Remove(shippingAddress))
                    return new WebApiResponse<ShippingAddresResponseDto>(true, "Success", _mapper.Map<ShippingAddresResponseDto>(shippingAddress));
                else
                    return new WebApiResponse<ShippingAddresResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ShippingAddresResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateShippingAddress(Guid id)
        {
            bool result = await _shippingAddressRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddresResponseDto>>>> GetActiveShippingAddresses()
        {
            var shippingAddressResult = _mapper.Map<List<ShippingAddresResponseDto>>(await _shippingAddressRepository.GetActive().ToListAsync());
            if (shippingAddressResult.Count > 0)
                return new WebApiResponse<List<ShippingAddresResponseDto>>(true, "Success", shippingAddressResult);
            else
                return new WebApiResponse<List<ShippingAddresResponseDto>>(false, "Error");
        }
    }
}
