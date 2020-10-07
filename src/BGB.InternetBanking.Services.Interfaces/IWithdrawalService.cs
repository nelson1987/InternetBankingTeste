using System.Collections.Generic;
using BGB.Core.Models;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IWithdrawalService
    {

        #region [ Actions ]

        ReturnMessage Insert(WithdrawalCommunication withdrawal);
        ReturnMessage Cancel(int id);

        #endregion [ Actions ]

        #region [ Queries ]

        IEnumerable<WithdrawalCommunication> GetByCustomer(int customerId);

        #endregion [ Queries ]

    }
}