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
    public class AccountController : BaseController
    {

        #region [ Attributes ]

        private readonly ICardMovementService _cardMovementService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public AccountController(ICardMovementService cardMovementService)
        {
            _cardMovementService = cardMovementService;
        }

        #endregion [ Constructor ]
        
        #region [ Queries ]

        [HttpGet]
        public IActionResult GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId)
        {
            var movements = _cardMovementService.GetLiquidatedByPeriod(accountNumber, startDate, endDate, flagId, acquirerId);

            return Ok(Mapper.Map<IEnumerable<CardMovementDto>>(movements));
        }

        #endregion [ Queries ]

    }
}