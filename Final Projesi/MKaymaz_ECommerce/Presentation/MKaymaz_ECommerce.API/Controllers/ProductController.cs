using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Product;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("product")]
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponseDto>>>> GetProducts()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var productResult = _mapper.Map<List<ProductResponseDto>>(await _productRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var productResult = _mapper.Map<List<ProductResponseDto>>(await _productRepository.TableNoTracking.ToListAsync());
            if (productResult.Count > 0)
                return new WebApiResponse<List<ProductResponseDto>>(true, "Success", productResult);
            else
                return new WebApiResponse<List<ProductResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductResponseDto>>> GetProduct(Guid id)
        {

            var productResult = _mapper.Map<ProductResponseDto>(await _productRepository.GetById(id));
            if (productResult != null)
                return new WebApiResponse<ProductResponseDto>(true, "Success", productResult);
            else
                return new WebApiResponse<ProductResponseDto>(false, "Error");
        }

        [HttpGet("ProductDetail/{id}"),AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductResponseDto>>> ProductDetail(Guid id)
        {
            try
            {
                Product product = await _productRepository.GetById(id, x => x.User);
                product.ViewCount++;
                var updateResult = _mapper.Map<ProductResponseDto>(await _productRepository.Update(product));
                if (updateResult != null)
                    return new WebApiResponse<ProductResponseDto>(true, "Success", updateResult);
                return new WebApiResponse<ProductResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductResponseDto>>> PostProduct(ProductRequestDto request)
        {
            Product product = _mapper.Map<Product>(request);
            var insertResult = await _productRepository.Add(product);
            if (insertResult != null)
            {
                ProductResponseDto rm = _mapper.Map<ProductResponseDto>(insertResult);
                return new WebApiResponse<ProductResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ProductResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponseDto>>> PutProduct(Guid id, ProductRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Product entity = await _productRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _productRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductResponseDto rm = _mapper.Map<ProductResponseDto>(updateResult);
                    return new WebApiResponse<ProductResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ProductResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponseDto>>> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                if (await _productRepository.Remove(product))
                    return new WebApiResponse<ProductResponseDto>(true, "Success", _mapper.Map<ProductResponseDto>(product));
                else
                    return new WebApiResponse<ProductResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ProductResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateProduct(Guid id)
        {
            bool result = await _productRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponseDto>>>> GetActiveProducts()
        {
            var productResult = _mapper.Map<List<ProductResponseDto>>(await _productRepository.GetActive().ToListAsync());
            if (productResult.Count > 0)
                return new WebApiResponse<List<ProductResponseDto>>(true, "Success", productResult);
            else
                return new WebApiResponse<List<ProductResponseDto>>(false, "Error");
        }

        [HttpGet("GetByCategoryId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponseDto>>>> GetByCategoryId(Guid id)
        {
            var productLists = await _productRepository.GetDefault(x => x.CategoryId == id).ToListAsync();
            if (productLists.Count > 0)
                return new WebApiResponse<List<ProductResponseDto>>(true, "Success", _mapper.Map<List<ProductResponseDto>>(productLists));
            return new WebApiResponse<List<ProductResponseDto>>(false, "Error");
        }

        [HttpGet("GetByBrandId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponseDto>>>> GetByBrandId(Guid id)
        {
            var productLists = await _productRepository.GetDefault(x => x.BrandId == id).ToListAsync();
            if (productLists.Count > 0)
                return new WebApiResponse<List<ProductResponseDto>>(true, "Success", _mapper.Map<List<ProductResponseDto>>(productLists));
            return new WebApiResponse<List<ProductResponseDto>>(false, "Error");
        }

        [HttpGet("GetByCurrencyId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponseDto>>>> GetByCurrencyId(Guid id)
        {
            var productLists = await _productRepository.GetDefault(x => x.CurrencyId == id).ToListAsync();
            if (productLists.Count > 0)
                return new WebApiResponse<List<ProductResponseDto>>(true, "Success", _mapper.Map<List<ProductResponseDto>>(productLists));
            return new WebApiResponse<List<ProductResponseDto>>(false, "Error");
        }
    }
}
