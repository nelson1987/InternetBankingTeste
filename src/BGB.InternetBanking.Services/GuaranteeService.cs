using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class GuaranteeService : IGuaranteeService
    {

        #region [ Attributes ]

        private readonly IGuaranteeRepository _repository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public GuaranteeService(IGuaranteeRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public IEnumerable<Guarantee> GetByAccount(int accountNumber)
        {
            return _repository.GetByAccount(accountNumber);
        }

        #endregion [ Queries ]

    }
}