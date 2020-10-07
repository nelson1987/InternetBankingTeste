using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface ICustomerService
    {

        #region [ Queries ] 

        Customer Get(int id, bool @readonly = true);
        Customer GetByAccount(CheckingAccount checkingAccount);

        #endregion [ Queries ] 

    }
}