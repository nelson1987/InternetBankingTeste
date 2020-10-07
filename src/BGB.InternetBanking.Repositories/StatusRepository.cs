using System.Collections.Generic;
using System.Linq;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public Status GetByCode(string code)
        {
            return LoadByFilter(x => x.Code.Equals(code)).FirstOrDefault();
        }

        public IEnumerable<Status> GetByType(string typeCode)
        {
            return LoadByFilter(x => x.TypeStatus.Code.Equals(typeCode), x => x.Description);
        }
    }
}