using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class ParameterService : IParameterService
    {

        #region [ Attributes ]

        private readonly IParameterRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public ParameterService(IParameterRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public Parameter GetByCode(string code)
        {
            return _repository.GetByCode(code);
        }

        #endregion [ Queries ]

    }
}