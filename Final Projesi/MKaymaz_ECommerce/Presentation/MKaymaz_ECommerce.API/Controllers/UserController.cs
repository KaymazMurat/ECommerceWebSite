using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.API.Controllers.Base;
using MKaymaz_ECommerce.Common.Dtos.User;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Service.Repository.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<UserResponseDto>>>> GetUsers()
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            //var userResult = _mapper.Map<List<UserResponseDto>>(await _userRepository.GetByDefault(x => x.Id != System.Guid.Empty));
            var userResult = _mapper.Map<List<UserResponseDto>>(await _userRepository.TableNoTracking.ToListAsync());
            if (userResult.Count > 0)
                return new WebApiResponse<List<UserResponseDto>>(true, "Success", userResult);
            else
                return new WebApiResponse<List<UserResponseDto>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<UserResponseDto>>> GetUser(Guid id)
        {

            var userResult = _mapper.Map<UserResponseDto>(await _userRepository.GetById(id));
            if (userResult != null)
                return new WebApiResponse<UserResponseDto>(true, "Success", userResult);
            else
                return new WebApiResponse<UserResponseDto>(false, "Error");
        }

        [HttpGet("exists/{email}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> ExistsUser(string email)
        {

            var userResult = await _userRepository.Any(x=>x.Email==email);
            if (userResult != null)
                return new WebApiResponse<bool>(true, "Success", userResult);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpPost,AllowAnonymous] 
        public async Task<ActionResult<WebApiResponse<UserResponseDto>>> PostUser(UserRequestDto request)
        {
            User user = _mapper.Map<User>(request);
            var insertResult = await _userRepository.Add(user);
            if (insertResult != null)
            {
                UserResponseDto rm = _mapper.Map<UserResponseDto>(insertResult);
                return new WebApiResponse<UserResponseDto>(true, "Success", rm);
            }
            return new WebApiResponse<UserResponseDto>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponseDto>>> PutUser(Guid id, UserRequestDto request)
        {
            //UserResponseDto user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                User entity = await _userRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Öenmli!!! Kaynaktan gelen değişiklik varsa onu entity üzerinde güncelle, eğer yoksa karışma veya elleme gibi düşünebilirsiniz.
                _mapper.Map(request, entity);

                var updateResult = await _userRepository.Update(entity);
                if (updateResult != null)
                {
                    UserResponseDto rm = _mapper.Map<UserResponseDto>(updateResult);
                    return new WebApiResponse<UserResponseDto>(true, "Success", rm);
                }
                return new WebApiResponse<UserResponseDto>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponseDto>>> DeleteUser(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                if (await _userRepository.Remove(user))
                    return new WebApiResponse<UserResponseDto>(true, "Success", _mapper.Map<UserResponseDto>(user));
                else
                    return new WebApiResponse<UserResponseDto>(false, "Error");
            }
            else
                return new WebApiResponse<UserResponseDto>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateUser(Guid id)
        {
            bool result = await _userRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", result);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<UserResponseDto>>>> GetActiveUsers()
        {
            var userResult = _mapper.Map<List<UserResponseDto>>(await _userRepository.GetActive().ToListAsync());
            if (userResult.Count > 0)
                return new WebApiResponse<List<UserResponseDto>>(true, "Success", userResult);
            else
                return new WebApiResponse<List<UserResponseDto>>(false, "Error");
        }
    }
}
