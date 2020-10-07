using System;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IDeedRepository
    {
        IEnumerable<Deed> GetByMaturityDate(int accountNumber, DateTime startDate, DateTime endDate);
    }
}