using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class InvestmentBalanceService : IInvestmentBalanceService
    {

        #region [ Attributes ]

        private readonly IInvestmentBalanceRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public InvestmentBalanceService(IInvestmentBalanceRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        #endregion [ Queries ]

    }
}