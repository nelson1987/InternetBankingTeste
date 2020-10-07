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
    /// Conta Corrente
    /// </summary>
    [AllowAnonymous]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class CheckingAccountController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetMovementByPeriod")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CheckingAccountMovementDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetMovementByPeriod(int accountNumber, int digitoConta, DateTime startDate, DateTime endDate, 
            [FromServices] IAccountMovementService _accountMovementService)
        {
            var movements = _accountMovementService.GetByAccountPeriod(accountNumber, startDate, endDate);

            if (movements == null)
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<CheckingAccountMovementDto>>(movements));
        }

        [HttpGet("GetCurrentBalance")]
        [ProducesResponseType(200, Type = typeof(CheckingAccountBalanceDto))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetCurrentBalance(int accountNumber, 
            [FromServices] IAccountBalanceService _accountBalanceService)
        {
            var balance = _accountBalanceService.GetCurrent(accountNumber);

            if (balance == null)
                return Ok(new CheckingAccountBalanceDto());

            return Ok(Mapper.Map<CheckingAccountBalanceDto>(balance));
        }

        [HttpGet("GetMovementLast")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CheckingAccountMovementDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetMovementLast(int accountNumber, int quantity, 
            [FromServices] IAccountMovementService _accountMovementService)
        {
            var movements = _accountMovementService.GetLast(accountNumber, quantity);

            return Ok(Mapper.Map<IEnumerable<CheckingAccountMovementDto>>(movements));
        }

        #endregion [ Queries ]

    }
}