using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.ProductComment;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.ProductComment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("productComment")]
    [ApiController]
    public class ProductCommentController : BaseApiController<ProductCommentController>
    {
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IMapper _mapper;

        public ProductCommentController(
            IProductCommentRepository productCommentRepository,
            IMapper mapper)
        {
            _productCommentRepository = productCommentRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductCommentResponseDto>>>> GetProductComments()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var productCommentResult = _mapper.Map<List<ProductCommentResponseDto>>(await _productCommentRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var productCommentResult = _mapper.Map<List<ProductCommentResponseDto>>(await _productCommentRepository.TableNoTracking.ToListAsync());
            if (productCommentResult.Count > 0)
                return new WebApiResponse<List<ProductCommentResponseDto>>(true, "Success", productCommentResult);
            else
                return new WebApiResponse<List<ProductCommentResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponseDto>>> GetProductComment(Guid id)
        {

            var productCommentResult = _mapper.Map<ProductCommentResponseDto>(await _productCommentRepository.GetById(id));
            if (productCommentResult != null)
                return new WebApiResponse<ProductCommentResponseDto>(true, "Success", productCommentResult);
            else
                return new WebApiResponse<ProductCommentResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponseDto>>> PostProductComment(ProductCommentRequestDto request)
        {
            ProductComment productComment = _mapper.Map<ProductComment>(request);
            var insertResult = await _productCommentRepository.Add(productComment);
            if (insertResult != null)
            {
                ProductCommentResponseDto rm = _mapper.Map<ProductCommentResponseDto>(insertResult);
                return new WebApiResponse<ProductCommentResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<ProductCommentResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponseDto>>> PutProductComment(Guid id, ProductCommentRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductComment entity = await _productCommentRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _productCommentRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductCommentResponseDto rm = _mapper.Map<ProductCommentResponseDto>(updateResult);
                    return new WebApiResponse<ProductCommentResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<ProductCommentResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponseDto>>> DeleteProductComment(Guid id)
        {
            var productComment = await _productCommentRepository.GetById(id);
            if (productComment != null)
            {
                if (await _productCommentRepository.Remove(productComment))
                    return new WebApiResponse<ProductCommentResponseDto>(true, "Success", _mapper.Map<ProductCommentResponseDto>(productComment));
                else
                    return new WebApiResponse<ProductCommentResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<ProductCommentResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateProductComment(Guid id)
        {
            bool result = await _productCommentRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductCommentResponseDto>>>> GetActiveProductComments()
        {
            var productCommentResult = _mapper.Map<List<ProductCommentResponseDto>>(await _productCommentRepository.GetActive().ToListAsync());
            if (productCommentResult.Count > 0)
                return new WebApiResponse<List<ProductCommentResponseDto>>(true, "Success", productCommentResult);
            else
                return new WebApiResponse<List<ProductCommentResponseDto>>(false, "Error");
        }

    }
}
