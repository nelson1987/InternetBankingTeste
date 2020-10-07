using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByAccount(CheckingAccount checkingAccount);
    }
}