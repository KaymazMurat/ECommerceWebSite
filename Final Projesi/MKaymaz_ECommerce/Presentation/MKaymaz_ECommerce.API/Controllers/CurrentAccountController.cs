using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.CurrentAccount;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.CurrentAccount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("currentAccount")]
    [ApiController]
    public class CurrentAccountController : BaseApiController<CurrentAccountController>
    {
        private readonly ICurrentAccountRepository _currentAccountRepository;
        private readonly IMapper _mapper;

        public CurrentAccountController(
            ICurrentAccountRepository currentAccountRepository,
            IMapper mapper)
        {
            _currentAccountRepository = currentAccountRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrentAccountResponseDto>>>> GetCurrentAccounts()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var currentAccountResult = _mapper.Map<List<CurrentAccountResponseDto>>(await _currentAccountRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var currentAccountResult = _mapper.Map<List<CurrentAccountResponseDto>>(await _currentAccountRepository.TableNoTracking.ToListAsync());
            if (currentAccountResult.Count > 0)
                return new WebApiResponse<List<CurrentAccountResponseDto>>(true, "Success", currentAccountResult);
            else
                return new WebApiResponse<List<CurrentAccountResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrentAccountResponseDto>>> GetCurrentAccount(Guid id)
        {

            var currentAccountResult = _mapper.Map<CurrentAccountResponseDto>(await _currentAccountRepository.GetById(id));
            if (currentAccountResult != null)
                return new WebApiResponse<CurrentAccountResponseDto>(true, "Success", currentAccountResult);
            else
                return new WebApiResponse<CurrentAccountResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CurrentAccountResponseDto>>> PostCurrentAccount(CurrentAccountRequestDto request)
        {
            CurrentAccount currentAccount = _mapper.Map<CurrentAccount>(request);
            var insertResult = await _currentAccountRepository.Add(currentAccount);
            if (insertResult != null)
            {
                CurrentAccountResponseDto rm = _mapper.Map<CurrentAccountResponseDto>(insertResult);
                return new WebApiResponse<CurrentAccountResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<CurrentAccountResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrentAccountResponseDto>>> PutCurrentAccount(Guid id, CurrentAccountRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                CurrentAccount entity = await _currentAccountRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _currentAccountRepository.Update(entity);
                if (updateResult != null)
                {
                    CurrentAccountResponseDto rm = _mapper.Map<CurrentAccountResponseDto>(updateResult);
                    return new WebApiResponse<CurrentAccountResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<CurrentAccountResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrentAccountResponseDto>>> DeleteCurrentAccount(Guid id)
        {
            var currentAccount = await _currentAccountRepository.GetById(id);
            if (currentAccount != null)
            {
                if (await _currentAccountRepository.Remove(currentAccount))
                    return new WebApiResponse<CurrentAccountResponseDto>(true, "Success", _mapper.Map<CurrentAccountResponseDto>(currentAccount));
                else
                    return new WebApiResponse<CurrentAccountResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<CurrentAccountResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCurrentAccount(Guid id)
        {
            bool result = await _currentAccountRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrentAccountResponseDto>>>> GetActiveCurrentAccounts()
        {
            var currentAccountResult = _mapper.Map<List<CurrentAccountResponseDto>>(await _currentAccountRepository.GetActive().ToListAsync());
            if (currentAccountResult.Count > 0)
                return new WebApiResponse<List<CurrentAccountResponseDto>>(true, "Success", currentAccountResult);
            else
                return new WebApiResponse<List<CurrentAccountResponseDto>>(false, "Error");
        }
    }
}
