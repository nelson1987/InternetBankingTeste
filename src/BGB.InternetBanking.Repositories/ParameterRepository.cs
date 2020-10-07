using System.Linq;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class ParameterRepository : Repository<Parameter>, IParameterRepository
    {
        public Parameter GetByCode(string code)
        {
            return LoadByFilter(x => x.Code.Equals(code)).FirstOrDefault();

        }
    }
}