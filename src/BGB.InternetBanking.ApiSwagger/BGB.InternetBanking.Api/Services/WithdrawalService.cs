using BGB.InternetBanking.Api.Entities;
using BGB.InternetBanking.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGB.InternetBanking.Api.Services
{
    public class WithdrawalService : IWithdrawalService
    {
        private IConfiguration configuration;

        public WithdrawalService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WithDrawalCommunication> GetByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Insert(WithDrawalCommunication withdrawal)
        {
            throw new NotImplementedException();
        }
    }
}
