using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IInvestmentMovementRepository : IRepository<InvestmentMovement>
    {
        IEnumerable<InvestmentMovement> GetByMovementDate(int accountNumber, DateTime startDate, DateTime endDate);
    }
}