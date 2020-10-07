using BGB.Core.Repository;
using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class InvestmentMovementRepository : Repository<InvestmentMovement>, IInvestmentMovementRepository
    {
        public IEnumerable<InvestmentMovement> GetByMovementDate(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) &&
                                     (x.MovementDate >= startDate.Date && x.MovementDate <= endDate.Date) 
                                , x => x.MovementDate);
        }

    }
}