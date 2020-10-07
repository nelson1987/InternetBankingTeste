using System;
using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class IndexQuotationRepository : Repository<IndexQuotation>, IIndexQuotationRepository
    {
        public IEnumerable<IndexQuotation> GetByReferenceDate(DateTime referenceDate)
        {
            return LoadByFilter(x => x.ReferenceDate.Month == referenceDate.Month && x.ReferenceDate.Year == referenceDate.Year, x => x.Index.Description);
        }
    }
}