using System;
using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class AccountMovementRepository : Repository<CheckingAccountMovement>, IAccountMovementRepository
    {
        public IEnumerable<CheckingAccountMovement> GetByPeriod(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) && 
                                    (x.MovementDate >= startDate && x.MovementDate <= endDate)
            , x => x.MovementDate);
        }

        public IEnumerable<CheckingAccountMovement> GetLast(int accountNumber, int quantity)
        {
            var rowCount = 0;

            return LoadByFilterPagedDescending(x => x.CheckingAccount.Number.Equals(accountNumber)
            , x => x.MovementDate, 1, quantity, out rowCount);
        }
    }
}