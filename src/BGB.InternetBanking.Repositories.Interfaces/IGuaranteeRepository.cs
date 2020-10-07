using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IGuaranteeRepository : IRepository<Guarantee>
    {
        IEnumerable<Guarantee> GetByAccount(int accountNumber);
    }
}