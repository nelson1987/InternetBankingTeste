using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class CustomerService : ICustomerService
    {

        #region [ Attributes ]

        private readonly ICustomerRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public Customer Get(int id, bool @readonly = true)
        {
            return _repository.LoadById(id, @readonly);
        }

        public Customer GetByAccount(CheckingAccount checkingAccount)
        {
            return _repository.GetByAccount(checkingAccount);
        }

        #endregion [ Queries ]

    }
}