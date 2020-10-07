using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Controllers
{
    /// <summary>
    /// Contas
    /// </summary>
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class AccountController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetLiquidatedByPeriod")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CardMovementDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId,
            [FromServices] ICardMovementService _cardMovementService)
        {
            var movements = _cardMovementService.GetLiquidatedByPeriod(accountNumber, startDate, endDate, flagId, acquirerId);

            return Ok(Mapper.Map<IEnumerable<CardMovementDto>>(movements));
        }

        #endregion [ Queries ]

    }
}