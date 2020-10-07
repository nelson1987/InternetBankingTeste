using System.Web.Http.Results;
using AutoMoq;
using BGB.InternetBanking.Api.Controllers;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BGB.InternetBanking.Test.Moq;
using BGB.InternetBanking.Api.Contracts.Datas;
using System.Web.Http;

namespace BGB.InternetBanking.Api.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestInitialize]
        public void Setup()
        {
            MapperConfig.Initialize();
        }

        #region [ Get ]

        [TestMethod]
        public void Get_Found()
        {
            var id = 1;

            var mocker = new AutoMoqer();
            mocker.Create<CustomerController>();

            var customerApi = mocker.Resolve<CustomerController>();
            var customerService = mocker.GetMock<ICustomerService>();

            var customerModel = CustomerRepositoryMoq.LoadById(id);

            customerService.Setup(x => x.Get(id, true)).Returns(customerModel);

            var result = customerApi.Get(id) as OkNegotiatedContentResult<CustomerDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, id);
        }

        [TestMethod]
        public void Get_NotFound()
        {
            var id = 0;

            var mocker = new AutoMoqer();
            mocker.Create<CustomerController>();

            var customerApi = mocker.Resolve<CustomerController>();
            var customerService = mocker.GetMock<ICustomerService>();

            var customerModel = CustomerRepositoryMoq.LoadById(id);

            customerService.Setup(x => x.Get(id, true)).Returns(customerModel);

            IHttpActionResult result = customerApi.Get(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        #endregion [ Get ]

    }
}
