using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Dtos.Location;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Location;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : BaseApiController<LocationController>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(
            ILocationRepository locationRepository,
            IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetLocations()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var locationResult = _mapper.Map<List<LocationResponseDto>>(await _locationRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var locationResult = _mapper.Map<List<LocationResponseDto>>(await _locationRepository.TableNoTracking.ToListAsync());
            if (locationResult.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", locationResult);
            else
                return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> GetLocation(Guid id)
        {

            var locationResult = _mapper.Map<LocationResponseDto>(await _locationRepository.GetById(id));
            if (locationResult != null)
                return new WebApiResponse<LocationResponseDto>(true, "Success", locationResult);
            else
                return new WebApiResponse<LocationResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> PostLocation(LocationRequestDto request)
        {
            Location location = _mapper.Map<Location>(request);
            var insertResult = await _locationRepository.Add(location);
            if (insertResult != null)
            {
                LocationResponseDto rm = _mapper.Map<LocationResponseDto>(insertResult);
                return new WebApiResponse<LocationResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<LocationResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> PutLocation(Guid id, LocationRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Location entity = await _locationRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _locationRepository.Update(entity);
                if (updateResult != null)
                {
                    LocationResponseDto rm = _mapper.Map<LocationResponseDto>(updateResult);
                    return new WebApiResponse<LocationResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<LocationResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponseDto>>> DeleteLocation(Guid id)
        {
            var location = await _locationRepository.GetById(id);
            if (location != null)
            {
                if (await _locationRepository.Remove(location))
                    return new WebApiResponse<LocationResponseDto>(true, "Success", _mapper.Map<LocationResponseDto>(location));
                else
                    return new WebApiResponse<LocationResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<LocationResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateLocation(Guid id)
        {
            bool result = await _locationRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetActiveLocations()
        {
            var locationResult = _mapper.Map<List<LocationResponseDto>>(await _locationRepository.GetActive().ToListAsync());
            if (locationResult.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", locationResult);
            else
                return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }

        [HttpGet("GetByCountryId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponseDto>>>> GetByCountryId(Guid id)
        {
            var locationLists = await _locationRepository.GetDefault(x => x.CountryId == id).ToListAsync();
            if (locationLists.Count > 0)
                return new WebApiResponse<List<LocationResponseDto>>(true, "Success", _mapper.Map<List<LocationResponseDto>>(locationLists));
            return new WebApiResponse<List<LocationResponseDto>>(false, "Error");
        }
    }
}
