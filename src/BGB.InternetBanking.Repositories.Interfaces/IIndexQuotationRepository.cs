using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IIndexQuotationRepository : IRepository<IndexQuotation>
    {
        IEnumerable<IndexQuotation> GetByReferenceDate(DateTime referenceDate);
    }
}