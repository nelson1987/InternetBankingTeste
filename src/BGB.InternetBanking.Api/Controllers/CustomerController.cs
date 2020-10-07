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
    public class CustomerController : BaseController
    {

        #region [ Attributes ]

        private readonly ICustomerService _customerService;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        [HttpGet]
        public IActionResult Get(int id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<CustomerDto>(customer));
        }

        #endregion [ Queries ]

    }
}