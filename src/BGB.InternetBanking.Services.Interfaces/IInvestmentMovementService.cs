using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IInvestmentMovementService
    {

        #region [ Queries ]

        InvestmentStatement GetStatement(int accountNumber, DateTime startDate, DateTime endDate);
        IEnumerable<PresumedIncome> GetPresumedIncome(int accountNumber, DateTime startDate, DateTime endDate);

        #endregion [ Queries ]

    }
}