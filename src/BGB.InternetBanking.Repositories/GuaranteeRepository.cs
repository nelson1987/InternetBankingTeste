using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class GuaranteeRepository : Repository<Guarantee>, IGuaranteeRepository
    {
        public IEnumerable<Guarantee> GetByAccount(int accountNumber)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) || 
                                     x.CheckingAccountGarantor.Number.Equals(accountNumber), 
                    x => x.Contract);
        }
    }
}