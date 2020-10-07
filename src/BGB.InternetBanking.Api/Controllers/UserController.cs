using System.Collections.Generic;
using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Infra;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGB.InternetBanking.Api.Controllers
{
    //[Authorize("Bearer")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        
        #region [ Attributes ]

        private readonly IUserService _userService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(Mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<UserDto>(user));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetByAccount(int accountNumber, int accountDigit)
        {
            var users = _userService.GetByAccount(accountNumber, accountDigit);
            var re = Mapper.Map<IEnumerable<UserDto>>(users);

            //return Ok(Mapper.Map<IEnumerable<UserDto>>(users));
            return Ok(re);
        }

        #endregion [ Queries ]

    }
}