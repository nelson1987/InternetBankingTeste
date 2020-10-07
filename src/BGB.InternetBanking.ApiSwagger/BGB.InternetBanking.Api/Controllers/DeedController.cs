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
    public class DeedController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetByMaturityDate")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DeedDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate,
                                        [FromServices] IDeedService _deedService)
        {
            var deeds = _deedService.GetByMaturityDate(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<IEnumerable<DeedDto>>(deeds));
        }

        #endregion [ Queries ]

    }
}