using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class DeedService : IDeedService
    {

        #region [ Attributes ]

        private readonly IDeedRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public DeedService(IDeedRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<Deed> GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return _repository.GetByMaturityDate(accountNumber, startDate, endDate);
        }

        #endregion [ Queries ]

    }
}