using System;
using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class AccountBalanceRepository : Repository<CheckingAccountBalance>, IAccountBalanceRepository
    {
        public IEnumerable<CheckingAccountBalance> GetByPeriod(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) && 
                                    (x.ReferenceDate >= startDate && x.ReferenceDate <= endDate)
            , x => x.ReferenceDate);
        }
    }
}