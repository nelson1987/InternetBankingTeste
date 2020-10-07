using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface ICardMovementRepository : IRepository<CardMovement>
    {
        IEnumerable<CardMovement> GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId);
        IEnumerable<CardMovement> GetScheduledByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId);
    }
}