using System;
using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class CardMovementRepository : Repository<CardMovement>, ICardMovementRepository
    {
        public IEnumerable<CardMovement> GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) &&
                                     x.LiquidationDate.HasValue && 
                                     (x.LiquidationDate >= startDate.Date && x.LiquidationDate <= endDate.Date) && 
                                     (!flagId.HasValue || x.Flag.Id == flagId) &&
                                     (!acquirerId.HasValue || x.Acquirer.Id == acquirerId) 
                                , x => x.LiquidationDate);
        }

        public IEnumerable<CardMovement> GetScheduledByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) &&
                                     !x.LiquidationDate.HasValue &&
                                     (x.MovementDate >= startDate.Date && x.MovementDate <= endDate.Date) &&
                                     (!flagId.HasValue || x.Flag.Id == flagId) &&
                                     (!acquirerId.HasValue || x.Acquirer.Id == acquirerId)
                                , x => x.MovementDate);
        }
    }
}