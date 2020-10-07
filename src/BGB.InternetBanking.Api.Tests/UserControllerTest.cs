using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Results;
using AutoMoq;
using BGB.InternetBanking.Api.Controllers;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BGB.InternetBanking.Test.Moq;
using BGB.InternetBanking.Api.Contracts.Datas;

namespace BGB.InternetBanking.Api.Tests
{
    [TestClass]
    public class UserControllerTest
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
            mocker.Create<UserController>();

            var userApi = mocker.Resolve<UserController>();
            var userService = mocker.GetMock<IUserService>();

            var userModel = UserRepositoryMoq.LoadById(id);

            userService.Setup(x => x.Get(id, true)).Returns(userModel);

            var result = userApi.Get(id) as OkNegotiatedContentResult<UserDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, id);
        }

        [TestMethod]
        public void Get_NotFound()
        {
            var id = 0;

            var mocker = new AutoMoqer();
            mocker.Create<UserController>();

            var userApi = mocker.Resolve<UserController>();
            var userService = mocker.GetMock<IUserService>();

            var userModel = UserRepositoryMoq.LoadById(id);

            userService.Setup(x => x.Get(id, true)).Returns(userModel);

            var result = userApi.Get(id); 

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        #endregion [ Get ]

        #region [ GetByAccount ]

        [TestMethod]
        public void GetByAccount_CorrectReturn()
        {
            var accountNumber = 11;

            var mocker = new AutoMoqer();
            mocker.Create<UserController>();

            var userApi = mocker.Resolve<UserController>();
            var userService = mocker.GetMock<IUserService>();

            var userModel = UserRepositoryMoq.LoadAll().Where(x => x.Customer.CheckingAccount.Number.Equals(accountNumber)).ToList();

            userService.Setup(x => x.GetByAccount(accountNumber)).Returns(userModel);

            var result = userApi.GetByAccount(accountNumber) as OkNegotiatedContentResult<IEnumerable<UserDto>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count(), userModel.Count);
        }

        [TestMethod]
        public void GetByAccount_EmptyList()
        {
            var accountNumber = 0;

            var mocker = new AutoMoqer();
            mocker.Create<UserController>();

            var userApi = mocker.Resolve<UserController>();
            var userService = mocker.GetMock<IUserService>();

            var userModel = UserRepositoryMoq.LoadAll().Where(x => x.Customer.CheckingAccount.Number.Equals(accountNumber)).ToList();

            userService.Setup(x => x.GetByAccount(accountNumber)).Returns(userModel);

            var result = userApi.GetByAccount(accountNumber) as OkNegotiatedContentResult<IEnumerable<UserDto>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count(), userModel.Count());
        }

        #endregion [ GetByAccount ]

    }
}