using System.Linq;
using BGB.Core.Repository;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;

namespace BGB.InternetBanking.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public Customer GetByAccount(CheckingAccount checkingAccount)
        {
            return LoadByFilter(x => x.CheckingAccount.Equals(checkingAccount)).FirstOrDefault();
        }
    }
}