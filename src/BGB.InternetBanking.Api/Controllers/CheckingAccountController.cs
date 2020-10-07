using System;
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
    public class CheckingAccountController : BaseController
    {

        #region [ Attributes ]

        private readonly IAccountMovementService _accountMovementService;
        private readonly IAccountBalanceService _accountBalanceService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public CheckingAccountController(IAccountMovementService accountMovementService,
            IAccountBalanceService accountBalanceService)
        {
            _accountMovementService = accountMovementService;
            _accountBalanceService = accountBalanceService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetMovementByPeriod(int accountNumber, int digitoConta, DateTime startDate, DateTime endDate)
        {
            var movements = _accountMovementService.GetByAccountPeriod(accountNumber, startDate, endDate);

            if (movements == null)
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<CheckingAccountMovementDto>>(movements));
        }

        [HttpGet]
        public IActionResult GetCurrentBalance(int accountNumber)
        {
            var balance = _accountBalanceService.GetCurrent(accountNumber);

            if (balance == null)
                return Ok(new CheckingAccountBalanceDto());

            return Ok(Mapper.Map<CheckingAccountBalanceDto>(balance));
        }

        [HttpGet]
        public IActionResult GetMovementLast(int accountNumber, int quantity)
        {
            var movements = _accountMovementService.GetLast(accountNumber, quantity);

            return Ok(Mapper.Map<IEnumerable<CheckingAccountMovementDto>>(movements));
        }

        #endregion [ Queries ]

    }
}