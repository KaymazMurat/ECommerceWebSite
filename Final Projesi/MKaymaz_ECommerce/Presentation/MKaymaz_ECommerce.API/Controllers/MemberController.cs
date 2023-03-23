using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.Member;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("member")]
    [ApiController]
    public class MemberController : BaseApiController<MemberController>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(
            IMemberRepository memberRepository,
            IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetMembers()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var memberResult = _mapper.Map<List<MemberResponseDto>>(await _memberRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var memberResult = _mapper.Map<List<MemberResponseDto>>(await _memberRepository.TableNoTracking.ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", memberResult);
            else
                return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> GetMember(Guid id)
        {

            var memberResult = _mapper.Map<MemberResponseDto>(await _memberRepository.GetById(id));
            if (memberResult != null)
                return new WebApiResponse<MemberResponseDto>(true, "Success", memberResult);
            else
                return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> PostMember(MemberRequestDto request)
        {
            Member member = _mapper.Map<Member>(request);
            var insertResult = await _memberRepository.Add(member);
            if (insertResult != null)
            {
                MemberResponseDto rm = _mapper.Map<MemberResponseDto>(insertResult);
                return new WebApiResponse<MemberResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> PutMember(Guid id, MemberRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                Member entity = await _memberRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _memberRepository.Update(entity);
                if (updateResult != null)
                {
                    MemberResponseDto rm = _mapper.Map<MemberResponseDto>(updateResult);
                    return new WebApiResponse<MemberResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<MemberResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponseDto>>> DeleteMember(Guid id)
        {
            var member = await _memberRepository.GetById(id);
            if (member != null)
            {
                if (await _memberRepository.Remove(member))
                    return new WebApiResponse<MemberResponseDto>(true, "Success", _mapper.Map<MemberResponseDto>(member));
                else
                    return new WebApiResponse<MemberResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<MemberResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateMember(Guid id)
        {
            bool result = await _memberRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetActiveMembers()
        {
            var memberResult = _mapper.Map<List<MemberResponseDto>>(await _memberRepository.GetActive().ToListAsync());
            if (memberResult.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", memberResult);
            else
                return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }

        [HttpGet("GetByCountryId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetByCountryId(Guid id)
        {
            var memberLists = await _memberRepository.GetDefault(x => x.CountryId == id).ToListAsync();
            if (memberLists.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", _mapper.Map<List<MemberResponseDto>>(memberLists));
            return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }
        [HttpGet("GetByLocationId/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponseDto>>>> GetByLocationId(Guid id)
        {
            var memberLists1 = await _memberRepository.GetDefault(x => x.LocationId == id).ToListAsync();
            if (memberLists1.Count > 0)
                return new WebApiResponse<List<MemberResponseDto>>(true, "Success", _mapper.Map<List<MemberResponseDto>>(memberLists1));
            return new WebApiResponse<List<MemberResponseDto>>(false, "Error");
        }
    }
}
