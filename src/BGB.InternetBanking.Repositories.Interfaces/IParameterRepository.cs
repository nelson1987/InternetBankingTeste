using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IParameterRepository : IRepository<Parameter>
    {
        Parameter GetByCode(string code);
    }
}