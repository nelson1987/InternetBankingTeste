using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;
using System.Collections.Generic;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IStatusRepository : IRepository<Status>
    {
        IEnumerable<Status> GetByType(string typeCode);
        Status GetByCode(string code);
    }
}