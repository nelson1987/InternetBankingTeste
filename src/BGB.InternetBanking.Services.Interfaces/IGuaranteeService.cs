using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IGuaranteeService
    {

        #region [ Queries ]

        IEnumerable<Guarantee> GetByAccount(int accountNumber);

        #endregion [ Queries ]

    }
}