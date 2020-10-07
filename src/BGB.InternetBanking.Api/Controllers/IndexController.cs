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
    public class IndexController : BaseController
    {

        #region [ Attributes ]

        private readonly IIndexQuotationService _indexQuotationService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public IndexController(IIndexQuotationService indexQuotationService)
        {
            _indexQuotationService = indexQuotationService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult GetQuotationByReferenceDate(DateTime referenceDate)
        {
            var quotations = _indexQuotationService.GetByReferenceDate(referenceDate);

            return Ok(Mapper.Map<IEnumerable<IndexQuotationDto>>(quotations));
        }

        #endregion [ Queries ]

    }
}