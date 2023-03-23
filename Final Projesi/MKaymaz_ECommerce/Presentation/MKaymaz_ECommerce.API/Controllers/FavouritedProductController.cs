using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.FavouritedProduct;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("favouritedProduct")]
    [ApiController]
    public class FavouritedProductController : BaseApiController<FavouritedProductController>
    {
        private readonly IFavouritedProductRepository _favouritedProductRepository;
        private readonly IMapper _mapper;

        public FavouritedProductController(
            IFavouritedProductRepository favouritedProductRepository,
            IMapper mapper)
        {
            _favouritedProductRepository = favouritedProductRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponseDto>>>> GetFavouritedProduct()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var favouritedProductResult = _mapper.Map<List<FavouritedProductResponseDto>>(await _favouritedProductRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var favouritedProductResult = _mapper.Map<List<FavouritedProductResponseDto>>(await _favouritedProductRepository.TableNoTracking.ToListAsync());
            if (favouritedProductResult.Count > 0)
                return new WebApiResponse<List<FavouritedProductResponseDto>>(true, "Success", favouritedProductResult);
            else
                return new WebApiResponse<List<FavouritedProductResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponseDto>>> GetFavouritedProduct(Guid id)
        {

            var favouritedProductResult = _mapper.Map<FavouritedProductResponseDto>(await _favouritedProductRepository.GetById(id));
            if (favouritedProductResult != null)
                return new WebApiResponse<FavouritedProductResponseDto>(true, "Success", favouritedProductResult);
            else
                return new WebApiResponse<FavouritedProductResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponseDto>>> PostFavouritedProduct(FavouritedProductRequestDto request)
        {
            FavouritedProduct favouritedProduct = _mapper.Map<FavouritedProduct>(request);
            var insertResult = await _favouritedProductRepository.Add(favouritedProduct);
            if (insertResult != null)
            {
                FavouritedProductResponseDto rm = _mapper.Map<FavouritedProductResponseDto>(insertResult);
                return new WebApiResponse<FavouritedProductResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<FavouritedProductResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponseDto>>> PutFavouritedProduct(Guid id, FavouritedProductRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                FavouritedProduct entity = await _favouritedProductRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _favouritedProductRepository.Update(entity);
                if (updateResult != null)
                {
                    FavouritedProductResponseDto rm = _mapper.Map<FavouritedProductResponseDto>(updateResult);
                    return new WebApiResponse<FavouritedProductResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<FavouritedProductResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponseDto>>> DeleteFavouritedProduct(Guid id)
        {
            var favouritedProduct = await _favouritedProductRepository.GetById(id);
            if (favouritedProduct != null)
            {
                if (await _favouritedProductRepository.Remove(favouritedProduct))
                    return new WebApiResponse<FavouritedProductResponseDto>(true, "Success", _mapper.Map<FavouritedProductResponseDto>(favouritedProduct));
                else
                    return new WebApiResponse<FavouritedProductResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<FavouritedProductResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateFavouritedProduct(Guid id)
        {
            bool result = await _favouritedProductRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponseDto>>>> GetActiveFavouritedProduct()
        {
            var favouritedProductResult = _mapper.Map<List<FavouritedProductResponseDto>>(await _favouritedProductRepository.GetActive().ToListAsync());
            if (favouritedProductResult.Count > 0)
                return new WebApiResponse<List<FavouritedProductResponseDto>>(true, "Success", favouritedProductResult);
            else
                return new WebApiResponse<List<FavouritedProductResponseDto>>(false, "Error");
        }
    }
}
