using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IAccountBalanceRepository : IRepository<CheckingAccountBalance>
    {
        IEnumerable<CheckingAccountBalance> GetByPeriod(int accountNumber, DateTime startDate, DateTime endDate);
    }
}