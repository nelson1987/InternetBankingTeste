using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IIndexQuotationService
    {

        #region [ Queries ]

        IEnumerable<IndexQuotation> GetByReferenceDate(DateTime referenceDate);

        #endregion [ Queries ]

    }
}