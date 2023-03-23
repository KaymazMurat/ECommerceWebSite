using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Maillist;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Maillist;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("maillist")]
    [ApiController]
    public class MaillistController : BaseApiController<MaillistController>
    {
        private readonly IMaillistRepository _maillistRepository;
        private readonly IMapper _mapper;

        public MaillistController(
            IMaillistRepository maillistRepository,
            IMapper mapper)
        {
            _maillistRepository = maillistRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MaillistResponseDto>>>> GetMaillists()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var maillistResult = _mapper.Map<List<MaillistResponseDto>>(await _maillistRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var maillistResult = _mapper.Map<List<MaillistResponseDto>>(await _maillistRepository.TableNoTracking.ToListAsync());
            if (maillistResult.Count > 0)
                return new WebApiResponse<List<MaillistResponseDto>>(true, "Success", maillistResult);
            else
                return new WebApiResponse<List<MaillistResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MaillistResponseDto>>> GetMaillist(Guid id)
        {

            var maillistResult = _mapper.Map<MaillistResponseDto>(await _maillistRepository.GetById(id));
            if (maillistResult != null)
                return new WebApiResponse<MaillistResponseDto>(true, "Success", maillistResult);
            else
                return new WebApiResponse<MaillistResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MaillistResponseDto>>> PostMaillist(MaillistRequestDto request)
        {
            Maillist maillist = _mapper.Map<Maillist>(request);
            var insertResult = await _maillistRepository.Add(maillist);
            if (insertResult != null)
            {
                MaillistResponseDto rm = _mapper.Map<MaillistResponseDto>(insertResult);
                return new WebApiResponse<MaillistResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<MaillistResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistResponseDto>>> PutMaillist(Guid id, MaillistRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Maillist entity = await _maillistRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _maillistRepository.Update(entity);
                if (updateResult != null)
                {
                    MaillistResponseDto rm = _mapper.Map<MaillistResponseDto>(updateResult);
                    return new WebApiResponse<MaillistResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<MaillistResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistResponseDto>>> DeleteMaillist(Guid id)
        {
            var maillist = await _maillistRepository.GetById(id);
            if (maillist != null)
            {
                if (await _maillistRepository.Remove(maillist))
                    return new WebApiResponse<MaillistResponseDto>(true, "Success", _mapper.Map<MaillistResponseDto>(maillist));
                else
                    return new WebApiResponse<MaillistResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<MaillistResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateMaillist(Guid id)
        {
            bool result = await _maillistRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MaillistResponseDto>>>> GetActiveMaillists()
        {
            var maillistResult = _mapper.Map<List<MaillistResponseDto>>(await _maillistRepository.GetActive().ToListAsync());
            if (maillistResult.Count > 0)
                return new WebApiResponse<List<MaillistResponseDto>>(true, "Success", maillistResult);
            else
                return new WebApiResponse<List<MaillistResponseDto>>(false, "Error");
        }
    }
}
