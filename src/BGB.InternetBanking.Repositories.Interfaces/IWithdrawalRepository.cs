using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;
using System.Collections.Generic;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IWithdrawalRepository : IRepository<WithdrawalCommunication>
    {
        IEnumerable<WithdrawalCommunication> GetByCustomer(int customerId);
    }
}