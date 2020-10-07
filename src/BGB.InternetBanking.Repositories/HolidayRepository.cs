using System;
using System.Collections.Generic;
using System.Linq;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public Holiday GetByDate(DateTime date)
        {
            return LoadByFilter(x => x.Date == date).FirstOrDefault();
        }

        public IEnumerable<Holiday> GetNextYears(int year, int quantityYears)
        {
            return LoadByFilter(x => x.Date.Year >= year && x.Date.Year <= (year + quantityYears), x => x.Date);
        }
    }
}