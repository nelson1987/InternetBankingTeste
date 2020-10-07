using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class UserController : Controller
    {
        #region [ Queries ]

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]    //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetAll([FromServices] IUserService _userService)
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(Mapper.Map<IEnumerable<UserDto>>(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserDto))]    //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult Get(int id,
            [FromServices] IUserService _userService)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<UserDto>(user));
        }

        [AllowAnonymous]
        [HttpGet("Get/{accountNumber}/{accountDigit}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]    //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetByAccount(int accountNumber, int accountDigit,
                                        [FromServices] IUserService _userService)
        {
            var users = _userService.GetByAccount(accountNumber, accountDigit);
            var re = Mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(re);
        }

        #endregion [ Queries ]
    }
}