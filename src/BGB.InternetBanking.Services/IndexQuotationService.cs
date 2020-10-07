using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class IndexQuotationService : IIndexQuotationService
    {

        #region [ Attributes ]

        private readonly IIndexQuotationRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public IndexQuotationService(IIndexQuotationRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<IndexQuotation> GetByReferenceDate(DateTime referenceDate)
        {
            return _repository.GetByReferenceDate(referenceDate);
        }

        #endregion [ Queries ]

    }
}