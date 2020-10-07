using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        Holiday GetByDate(DateTime date);
        IEnumerable<Holiday> GetNextYears(int year, int quantityYears);
    }
}