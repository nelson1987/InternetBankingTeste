using BGB.Core.Repository;
using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class InvestmentBalanceRepository : Repository<InvestmentBalance>, IInvestmentBalanceRepository
    {
        public IEnumerable<InvestmentBalance> GetByReferencetDate(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) &&
                                     (x.ReferenceDate >= startDate.Date && x.ReferenceDate <= endDate.Date)
                                , x => x.ReferenceDate);
        }
    }
}