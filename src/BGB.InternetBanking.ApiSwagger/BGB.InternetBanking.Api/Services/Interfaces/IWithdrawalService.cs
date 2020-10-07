using BGB.InternetBanking.Api.Entities;
using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Services.Interfaces
{
    public interface IWithdrawalService
    {
        #region [ Actions ]

        void Insert(WithDrawalCommunication withdrawal);
        void Cancel(int id);

        #endregion [ Actions ]

        #region [ Queries ]

        IEnumerable<WithDrawalCommunication> GetByCustomer(int customerId);

        #endregion [ Queries ]
    }
}
