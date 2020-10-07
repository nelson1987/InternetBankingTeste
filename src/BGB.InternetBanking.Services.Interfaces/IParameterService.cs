using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Services.Interfaces
{
    public interface IParameterService
    {

        #region [ Queries ]

        Parameter GetByCode(string code);

        #endregion [ Queries ]
        
    }
}