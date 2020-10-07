using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;
using System.Collections.Generic;

namespace BGB.InternetBanking.Services
{
    public class UserService : IUserService
    {

        #region [ Attributes ]

        private readonly IUserRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<User> GetAll()
        {
            return _repository.LoadAll();
        }

        public User Get(int id, bool @readonly = true)
        {
            return _repository.LoadById(id, @readonly);
        }

        public IEnumerable<User> GetByAccount(int accountNumber, int accountDigit)
        {
            return _repository.GetByAccount(accountNumber, accountDigit);
        }

        #endregion [ Queries ]

    }
}