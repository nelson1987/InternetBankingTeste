using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Test.Moq;
using BGB.InternetBanking.Entities;

namespace BGB.InternetBanking.Services.Tests
{
    [TestClass]
    public class CustomerServiceTest
    {
        
        #region [ Get ]

        [TestMethod]
        public void Get_Found()
        {
            var id = 1;

            var mocker = new AutoMoqer();
            mocker.Create<CustomerService>();

            var customerService = mocker.Resolve<CustomerService>();
            var customerRepository = mocker.GetMock<ICustomerRepository>();

            var customerModel = CustomerRepositoryMoq.LoadById(id);

            customerRepository.Setup(x => x.LoadById(id, true)).Returns(customerModel);

            var result = customerService.Get(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
        }

        [TestMethod]
        public void Get_NotFound()
        {
            var id = 0;

            var mocker = new AutoMoqer();
            mocker.Create<CustomerService>();

            var customerService = mocker.Resolve<CustomerService>();
            var customerRepository = mocker.GetMock<ICustomerRepository>();

            var customerModel = CustomerRepositoryMoq.LoadById(id);

            customerRepository.Setup(x => x.LoadById(id, true)).Returns(customerModel);

            var result = customerService.Get(id);

            Assert.IsNull(result);
        }

        #endregion [ Get ]

        #region [ GetByAccount ]

        [TestMethod]
        public void GetByAccount_Found()
        {
            var account = new CheckingAccount { Number = 11, Digit = 2 };

            var mocker = new AutoMoqer();
            mocker.Create<CustomerService>();

            var customerService = mocker.Resolve<CustomerService>();
            var customerRepository = mocker.GetMock<ICustomerRepository>();

            var customerModel = CustomerRepositoryMoq.LoadAll().FirstOrDefault(x => x.CheckingAccount.Equals(account));

            customerRepository.Setup(x => x.GetByAccount(account)).Returns(customerModel);

            var result = customerService.GetByAccount(account);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.CheckingAccount.Number, account.Number);
        }

        [TestMethod]
        public void GetByAccount_NotFound()
        {
            var account = new CheckingAccount { Number = 0, Digit = 0 };

            var mocker = new AutoMoqer();
            mocker.Create<CustomerService>();

            var customerService = mocker.Resolve<CustomerService>();
            var customerRepository = mocker.GetMock<ICustomerRepository>();

            var customerModel = CustomerRepositoryMoq.LoadAll().FirstOrDefault(x => x.CheckingAccount.Equals((object)account));

            customerRepository.Setup(x => x.GetByAccount(account)).Returns(customerModel);

            var result = customerService.GetByAccount(account);

            Assert.IsNull(result);
        }

        #endregion [ GetByAccount ]

    }
}