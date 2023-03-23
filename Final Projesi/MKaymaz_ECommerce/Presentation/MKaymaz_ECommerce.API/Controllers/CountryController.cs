using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Country;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("country")]
    [ApiController]
    public class CountryController : BaseApiController<CountryController>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountryResponseDto>>>> GetCountries()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var countryResult = _mapper.Map<List<CountryResponseDto>>(await _countryRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var countryResult = _mapper.Map<List<CountryResponseDto>>(await _countryRepository.TableNoTracking.ToListAsync());
            if (countryResult.Count > 0)
                return new WebApiResponse<List<CountryResponseDto>>(true, "Success", countryResult);
            else
                return new WebApiResponse<List<CountryResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> GetCountry(Guid id)
        {

            var countryResult = _mapper.Map<CountryResponseDto>(await _countryRepository.GetById(id));
            if (countryResult != null)
                return new WebApiResponse<CountryResponseDto>(true, "Success", countryResult);
            else
                return new WebApiResponse<CountryResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> PostCountry(CountryRequestDto request)
        {
            Country country = _mapper.Map<Country>(request);
            var insertResult = await _countryRepository.Add(country);
            if (insertResult != null)
            {
                CountryResponseDto rm = _mapper.Map<CountryResponseDto>(insertResult);
                return new WebApiResponse<CountryResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CountryResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> PutCountry(Guid id, CountryRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Country entity = await _countryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _countryRepository.Update(entity);
                if (updateResult != null)
                {
                    CountryResponseDto rm = _mapper.Map<CountryResponseDto>(updateResult);
                    return new WebApiResponse<CountryResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CountryResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CountryResponseDto>>> DeleteCountry(Guid id)
        {
            var country = await _countryRepository.GetById(id);
            if (country != null)
            {
                if (await _countryRepository.Remove(country))
                    return new WebApiResponse<CountryResponseDto>(true, "Success", _mapper.Map<CountryResponseDto>(country));
                else
                    return new WebApiResponse<CountryResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CountryResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCountry(Guid id)
        {
            bool result = await _countryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountryResponseDto>>>> GetActiveCountries()
        {
            var countryResult = _mapper.Map<List<CountryResponseDto>>(await _countryRepository.GetActive().ToListAsync());
            if (countryResult.Count > 0)
                return new WebApiResponse<List<CountryResponseDto>>(true, "Success", countryResult);
            else
                return new WebApiResponse<List<CountryResponseDto>>(false, "Error");
        }
    }
}
