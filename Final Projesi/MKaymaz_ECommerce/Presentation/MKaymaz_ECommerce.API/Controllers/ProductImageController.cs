using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Common.Dtos.ProductImage;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.ProductImage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("productImage")]
    [ApiController]
    public class ProductImageController : Controller
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageController(
            IProductImageRepository productImageRepository,
            IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductImageResponseDto>>>> GetProductImages()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var productImageResult = _mapper.Map<List<ProductImageResponseDto>>(await _productImageRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var productImageResult = _mapper.Map<List<ProductImageResponseDto>>(await _productImageRepository.TableNoTracking.ToListAsync());
            if (productImageResult.Count > 0)
                return new WebApiResponse<List<ProductImageResponseDto>>(true, "Success", productImageResult);
            else
                return new WebApiResponse<List<ProductImageResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductImageResponseDto>>> GetProductImage(Guid id)
        {

            var productImageResult = _mapper.Map<ProductImageResponseDto>(await _productImageRepository.GetById(id));
            if (productImageResult != null)
                return new WebApiResponse<ProductImageResponseDto>(true, "Success", productImageResult);
            else
                return new WebApiResponse<ProductImageResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductImageResponseDto>>> PostProductImage(ProductImageRequestDto request)
        {
            ProductImage productImage = _mapper.Map<ProductImage>(request);
            var insertResult = await _productImageRepository.Add(productImage);
            if (insertResult != null)
            {
                ProductImageResponseDto rm = _mapper.Map<ProductImageResponseDto>(insertResult);
                return new WebApiResponse<ProductImageResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ProductImageResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductImageResponseDto>>> PutProductImage(Guid id, ProductImageRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductImage entity = await _productImageRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _productImageRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductImageResponseDto rm = _mapper.Map<ProductImageResponseDto>(updateResult);
                    return new WebApiResponse<ProductImageResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ProductImageResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductImageResponseDto>>> DeleteProductImage(Guid id)
        {
            var productImage = await _productImageRepository.GetById(id);
            if (productImage != null)
            {
                if (await _productImageRepository.Remove(productImage))
                    return new WebApiResponse<ProductImageResponseDto>(true, "Success", _mapper.Map<ProductImageResponseDto>(productImage));
                else
                    return new WebApiResponse<ProductImageResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ProductImageResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateProductImage(Guid id)
        {
            bool result = await _productImageRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductImageResponseDto>>>> GetActiveProductImages()
        {
            var productImageResult = _mapper.Map<List<ProductImageResponseDto>>(await _productImageRepository.GetActive().ToListAsync());
            if (productImageResult.Count > 0)
                return new WebApiResponse<List<ProductImageResponseDto>>(true, "Success", productImageResult);
            else
                return new WebApiResponse<List<ProductImageResponseDto>>(false, "Error");
        }

        [HttpGet("GetByProductId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductImageResponseDto>>>> GetByProductId(Guid id)
        {
            var productImageLists = await _productImageRepository.GetDefault(x => x.ProductId == id).ToListAsync();
            if (productImageLists.Count > 0)
                return new WebApiResponse<List<ProductImageResponseDto>>(true, "Success", _mapper.Map<List<ProductImageResponseDto>>(productImageLists));
            return new WebApiResponse<List<ProductImageResponseDto>>(false, "Error");
        }
    }
}
