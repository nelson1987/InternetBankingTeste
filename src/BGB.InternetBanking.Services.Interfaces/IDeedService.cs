using System;
using BGB.InternetBanking.Models;
using System.Collections.Generic;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IDeedService
    {

        #region [ Queries ]

        IEnumerable<Deed> GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate);

        #endregion [ Queries ]

    }
}