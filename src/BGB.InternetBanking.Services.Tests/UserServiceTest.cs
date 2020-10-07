using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Test.Moq;

namespace BGB.InternetBanking.Services.Tests
{
    [TestClass]
    public class UserServiceTest
    {

        #region [ Get ]

        [TestMethod]
        public void Get_Found()
        {
            var id = 1;

            var mocker = new AutoMoqer();
            mocker.Create<UserService>();

            var userService = mocker.Resolve<UserService>();
            var userRepository = mocker.GetMock<IUserRepository>();

            var userModel = UserRepositoryMoq.LoadById(id);

            userRepository.Setup(x => x.LoadById(id, true)).Returns(userModel);

            var result = userService.Get(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
        }

        [TestMethod]
        public void Get_NotFound()
        {
            var id = 0;

            var mocker = new AutoMoqer();
            mocker.Create<UserService>();

            var userService = mocker.Resolve<UserService>();
            var userRepository = mocker.GetMock<IUserRepository>();

            var userModel = UserRepositoryMoq.LoadById(id);

            userRepository.Setup(x => x.LoadById(id, true)).Returns(userModel);

            var result = userService.Get(id);

            Assert.IsNull(result);
        }

        #endregion [ Get ]

        #region [ GetByAccount ]

        [TestMethod]
        public void GetByAccount_CorrectReturn()
        {
            var accountNumber = 11;

            var mocker = new AutoMoqer();
            mocker.Create<UserService>();

            var userService = mocker.Resolve<UserService>();
            var userRepository = mocker.GetMock<IUserRepository>();

            var userModel = UserRepositoryMoq.LoadAll();

            userRepository.Setup(x => x.GetByAccount(accountNumber)).Returns(userModel);

            var result = userService.GetByAccount(accountNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), userModel.Count());
        }

        [TestMethod]
        public void GetByAccount_EmptyList()
        {
            var accountNumber = 0;

            var mocker = new AutoMoqer();
            mocker.Create<UserService>();

            var userService = mocker.Resolve<UserService>();
            var userRepository = mocker.GetMock<IUserRepository>();

            var userModel = UserRepositoryMoq.LoadAll().Where(x => x.Id == 0);

            userRepository.Setup(x => x.GetByAccount(accountNumber)).Returns(userModel);

            var result = userService.GetByAccount(accountNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), userModel.Count());
        }

        #endregion [ GetByAccount ]

    }
}