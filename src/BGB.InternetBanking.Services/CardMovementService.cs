using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class CardMovementService : ICardMovementService
    {

        #region [ Attributes ]

        private readonly ICardMovementRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public CardMovementService(ICardMovementRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<CardMovement> GetLiquidatedByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId)
        {
            return _repository.GetLiquidatedByPeriod(accountNumber, startDate, endDate, flagId, acquirerId);
        }

        public IEnumerable<CardMovement> GetScheduledByPeriod(int accountNumber, DateTime startDate, DateTime endDate, int? flagId, int? acquirerId)
        {
            return _repository.GetScheduledByPeriod(accountNumber, startDate, endDate, flagId, acquirerId);
        }

        #endregion [ Queries ]

    }
}