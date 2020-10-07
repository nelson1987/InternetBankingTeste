using System;
using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class DeedRepository : Repository<Deed>, IDeedRepository
    {
        public IEnumerable<Deed> GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return LoadByFilter(x => x.CheckingAccount.Number.Equals(accountNumber) &&
                                     (x.MaturityDateDayUtil >= startDate.Date && x.MaturityDateDayUtil <= endDate.Date)
                                , x => x.MaturityDateDayUtil);
        }
    }
}