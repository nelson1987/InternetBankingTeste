using System;
using System.Collections.Generic;
using System.Linq;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class AccountMovementService : IAccountMovementService
    {

        #region [ Attributes ]

        private readonly IAccountMovementRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public AccountMovementService(IAccountMovementRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<CheckingAccountMovement> GetByAccountPeriod(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return _repository.GetByPeriod(accountNumber, startDate, endDate);
        }

        public IEnumerable<CheckingAccountMovement> GetLast(int accountNumber, int quantity)
        {
            var movements = _repository.GetLast(accountNumber, quantity);

            return movements.OrderBy(x => x.MovementDate);
        }

        #endregion [ Queries ]

    }
}