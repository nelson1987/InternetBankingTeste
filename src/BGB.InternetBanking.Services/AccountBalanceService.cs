using System;
using System.Collections.Generic;
using System.Linq;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class AccountBalanceService : IAccountBalanceService
    {

        #region [ Attributes ]

        private readonly IAccountMovementRepository _accountMovementRepository;
        private readonly IAccountBalanceRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public AccountBalanceService(IAccountMovementRepository accountMovementRepository, 
            IAccountBalanceRepository repository)
        {
            _repository = repository;
            _accountMovementRepository = accountMovementRepository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public CheckingAccountBalance GetCurrent(int accountNumber)
        {
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-5);

            var balances = _repository.GetByPeriod(accountNumber, startDate, endDate);
            var movements = _accountMovementRepository.GetByPeriod(accountNumber, endDate, endDate);

            if (balances == null || balances.Count() == 0)
                return null;

            var currentBalance = balances.OrderByDescending(x => x.ReferenceDate).FirstOrDefault();

            currentBalance.Amount += movements.Sum(x => x.Amount);

            return currentBalance;
        }

        public IEnumerable<CheckingAccountBalance> GetCurrent(IEnumerable<int> accountNumbers)
        {
            var balances = new List<CheckingAccountBalance>();

            foreach (var account in accountNumbers)
                balances.Add(GetCurrent(account));

            balances.RemoveAll(x => x == null);

            return balances;
        }

        #endregion [ Queries ]

    }
}