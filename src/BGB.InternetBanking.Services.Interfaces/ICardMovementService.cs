using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface ICardMovementService
    {

        #region [ Queries ]

        IEnumerable<CardMovement> GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId);
        IEnumerable<CardMovement> GetScheduledByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId);

        #endregion [ Queries ]

    }
}