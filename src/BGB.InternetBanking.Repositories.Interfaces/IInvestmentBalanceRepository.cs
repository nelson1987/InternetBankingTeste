using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IInvestmentBalanceRepository : IRepository<InvestmentBalance>
    {
        IEnumerable<InvestmentBalance> GetByReferencetDate(int accountNumber, DateTime startDate, DateTime endDate);
    }
}