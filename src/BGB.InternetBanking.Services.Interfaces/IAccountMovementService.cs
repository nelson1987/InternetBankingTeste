using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IAccountMovementService
    {

        #region [ Queries ]

        IEnumerable<CheckingAccountMovement> GetByAccountPeriod(int accountNumber, DateTime startDate, DateTime endDate);
        IEnumerable<CheckingAccountMovement> GetLast(int accountNumber, int quantity);

        #endregion [ Queries ]

    }
}