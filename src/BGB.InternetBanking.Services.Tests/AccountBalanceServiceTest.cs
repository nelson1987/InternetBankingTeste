using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Test.Moq;
using BGB.InternetBanking.Entities;
using System;

namespace BGB.InternetBanking.Services.Tests
{
    [TestClass]
    public class AccountBalanceServiceTest
    {

        #region [ GetCurrent ]

        [TestMethod]
        public void GetCurrent_Found()
        {
            var accountNumer = 11;
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-5);

            var mocker = new AutoMoqer();
            mocker.Create<AccountBalanceService>();

            var accountBalanceService = mocker.Resolve<AccountBalanceService>();
            var accountBalanceRepository = mocker.GetMock<IAccountBalanceRepository>();
            var accountMovementRepository = mocker.GetMock<IAccountMovementRepository>();

            var balanceModel = CheckingAccountBalanceRepositoryMoq.LoadAll();
            balanceModel = balanceModel.Where(x => x.CheckingAccount.Number.Equals(accountNumer)).ToList();

            var movementModel = CheckingAccountMovementRepositoryMoq.LoadAll();
            movementModel = movementModel.Where(x => x.CheckingAccount.Number.Equals(accountNumer) 
                                    && (x.MovementDate >= startDate && x.MovementDate <= endDate)).ToList();

            accountBalanceRepository.Setup(x => x.GetByPeriod(accountNumer, startDate, endDate)).Returns(balanceModel);
            accountMovementRepository.Setup(x => x.GetByPeriod(accountNumer, startDate, endDate)).Returns(movementModel);

            var result = accountBalanceService.GetCurrent(accountNumer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.CheckingAccount.Number, accountNumer);
            Assert.IsTrue(result.Amount > 0);
        }

        [TestMethod]
        public void GetCurrent_NotFound()
        {
            var accountNumer = 0;
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-5);

            var mocker = new AutoMoqer();
            mocker.Create<AccountBalanceService>();

            var accountBalanceService = mocker.Resolve<AccountBalanceService>();
            var accountBalanceRepository = mocker.GetMock<IAccountBalanceRepository>();
            var accountMovementRepository = mocker.GetMock<IAccountMovementRepository>();

            var balanceModel = CheckingAccountBalanceRepositoryMoq.LoadAll();
            balanceModel = balanceModel.Where(x => x.CheckingAccount.Number.Equals(accountNumer)).ToList();

            var movementModel = CheckingAccountMovementRepositoryMoq.LoadAll();
            movementModel = movementModel.Where(x => x.CheckingAccount.Number.Equals(accountNumer)
                                    && (x.MovementDate >= startDate && x.MovementDate <= endDate)).ToList();

            accountBalanceRepository.Setup(x => x.GetByPeriod(accountNumer, startDate, endDate)).Returns(balanceModel);
            accountMovementRepository.Setup(x => x.GetByPeriod(accountNumer, startDate, endDate)).Returns(movementModel);

            var result = accountBalanceService.GetCurrent(accountNumer);

            Assert.IsNull(result);
        }

        #endregion [ GetCurrent ]


        #region [ GetCurrent List ]

        [TestMethod]
        public void GetCurrentList_CorrectReturn()
        {
            var accountNumer = new int[]{ 11, 22 };
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-5);

            var mocker = new AutoMoqer();
            mocker.Create<AccountBalanceService>();

            var accountBalanceService = mocker.Resolve<AccountBalanceService>();

            var moqeee = mocker.GetMock<AccountBalanceService>();

            var balanceModel = CheckingAccountBalanceRepositoryMoq.LoadById(1);

            moqeee.Setup(x => x.GetCurrent(1)).Returns(balanceModel);

            var result = accountBalanceService.GetCurrent(accountNumer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void GetCurrentList_EmptyList()
        {
            var accountNumer = new int[] { 999, 9999 };
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-5);

            var mocker = new AutoMoqer();
            mocker.Create<AccountBalanceService>();

            var accountBalanceService = mocker.Resolve<AccountBalanceService>();

            var moqeee = mocker.GetMock<AccountBalanceService>();

            var balanceModel = CheckingAccountBalanceRepositoryMoq.LoadById(1);

            moqeee.Setup(x => x.GetCurrent(1)).Returns(balanceModel);

            var result = accountBalanceService.GetCurrent(accountNumer);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);
        }

        #endregion [ GetCurrent ]

    }
}