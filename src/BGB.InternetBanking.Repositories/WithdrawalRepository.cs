using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using System.Collections.Generic;

namespace BGB.InternetBanking.Repositories
{
    public class WithdrawalRepository : Repository<WithdrawalCommunication>, IWithdrawalRepository
    {
        public IEnumerable<WithdrawalCommunication> GetByCustomer(int customerId)
        {
            return LoadByFilterDescending(x => x.Customer.Id == customerId, x => x.ExpectedDate);
        }
    }
}