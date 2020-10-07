using BGB.InternetBanking.Models;
using System.Collections.Generic;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IAccountBalanceService
    {

        #region [ Queries ]

        CheckingAccountBalance GetCurrent(int numeroConta);
        IEnumerable<CheckingAccountBalance> GetCurrent(IEnumerable<int> accountNumbers);

        #endregion [ Queries ]

    }
}