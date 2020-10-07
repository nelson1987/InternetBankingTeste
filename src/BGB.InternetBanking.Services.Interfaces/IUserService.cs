using BGB.InternetBanking.Models;
using System.Collections.Generic;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IUserService
    {

        #region [ Queries ]

        IEnumerable<User> GetAll();
        User Get(int id, bool @readonly = true);
        IEnumerable<User> GetByAccount(int accountNumber, int accountDigit);

        #endregion [ Queries ]

    }
}