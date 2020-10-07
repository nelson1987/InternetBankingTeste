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
    public class DeedController : BaseController
    {

        #region [ Attributes ]

        private readonly IDeedService _deedService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public DeedController(IDeedService deedService)
        {
            _deedService = deedService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate)
        {
            var deeds = _deedService.GetByMaturityDate(accountNumber, startDate, endDate);

            return Ok(Mapper.Map<IEnumerable<DeedDto>>(deeds));
        }

        #endregion [ Queries ]

    }
}