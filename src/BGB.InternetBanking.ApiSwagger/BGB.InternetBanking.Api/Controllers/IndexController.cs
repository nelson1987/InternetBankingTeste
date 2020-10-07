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
    public class IndexController : Controller
    {
        #region [ Queries ]

        [HttpGet("GetQuotationByReferenceDate")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IndexQuotationDto>))] //OK
        [ProducesResponseType(500)] //Erro interno de servidor
        public IActionResult GetQuotationByReferenceDate(DateTime referenceDate,
                                        [FromServices] IIndexQuotationService _indexQuotationService)
        {
            var quotations = _indexQuotationService.GetByReferenceDate(referenceDate);

            return Ok(Mapper.Map<IEnumerable<IndexQuotationDto>>(quotations));
        }

        #endregion [ Queries ]

    }
}