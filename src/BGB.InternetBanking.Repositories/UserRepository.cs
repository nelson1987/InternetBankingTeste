using System.Collections.Generic;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public IEnumerable<User> GetByAccount(int accountNumber, int accountDigit)
        {
            return LoadByFilter(x => x.Customer.CheckingAccount.Number == accountNumber && 
                                    x.Customer.CheckingAccount.Digit == accountDigit
                    , x => x.Name);
        }
    }
}