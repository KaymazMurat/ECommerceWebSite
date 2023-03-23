using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Currency;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Currency;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("currency")]
    [ApiController]
    public class CurrencyController : BaseApiController<CurrencyController>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyRepository currencyRepository,
            IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyResponseDto>>>> GetCurrencies()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var currencyResult = _mapper.Map<List<CurrencyResponseDto>>(await _currencyRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var currencyResult = _mapper.Map<List<CurrencyResponseDto>>(await _currencyRepository.TableNoTracking.ToListAsync());
            if (currencyResult.Count > 0)
                return new WebApiResponse<List<CurrencyResponseDto>>(true, "Success", currencyResult);
            else
                return new WebApiResponse<List<CurrencyResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyResponseDto>>> GetCurrency(Guid id)
        {

            var currencyResult = _mapper.Map<CurrencyResponseDto>(await _currencyRepository.GetById(id));
            if (currencyResult != null)
                return new WebApiResponse<CurrencyResponseDto>(true, "Success", currencyResult);
            else
                return new WebApiResponse<CurrencyResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CurrencyResponseDto>>> PostCurrency(CurrencyRequestDto request)
        {
            Currency currency = _mapper.Map<Currency>(request);
            var insertResult = await _currencyRepository.Add(currency);
            if (insertResult != null)
            {
                CurrencyResponseDto rm = _mapper.Map<CurrencyResponseDto>(insertResult);
                return new WebApiResponse<CurrencyResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CurrencyResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyResponseDto>>> PutCurrency(Guid id, CurrencyRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Currency entity = await _currencyRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _currencyRepository.Update(entity);
                if (updateResult != null)
                {
                    CurrencyResponseDto rm = _mapper.Map<CurrencyResponseDto>(updateResult);
                    return new WebApiResponse<CurrencyResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CurrencyResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyResponseDto>>> DeleteCurrency(Guid id)
        {
            var currency = await _currencyRepository.GetById(id);
            if (currency != null)
            {
                if (await _currencyRepository.Remove(currency))
                    return new WebApiResponse<CurrencyResponseDto>(true, "Success", _mapper.Map<CurrencyResponseDto>(currency));
                else
                    return new WebApiResponse<CurrencyResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CurrencyResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCurrency(Guid id)
        {
            bool result = await _currencyRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyResponseDto>>>> GetActiveCurrencies()
        {
            var currencyResult = _mapper.Map<List<CurrencyResponseDto>>(await _currencyRepository.GetActive().ToListAsync());
            if (currencyResult.Count > 0)
                return new WebApiResponse<List<CurrencyResponseDto>>(true, "Success", currencyResult);
            else
                return new WebApiResponse<List<CurrencyResponseDto>>(false, "Error");
        }
    }
}
