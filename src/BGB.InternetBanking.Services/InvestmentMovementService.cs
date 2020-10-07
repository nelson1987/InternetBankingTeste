using System;
using System.Collections.Generic;
using System.Linq;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Models.Enums;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class InvestmentMovementService : IInvestmentMovementService
    {

        #region [ Attributes ]

        private readonly IInvestmentMovementRepository _repository;
        private readonly IIndexQuotationRepository _indexQuotationRepository;
        private readonly IInvestmentBalanceRepository _investmentBalanceRepository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public InvestmentMovementService(IInvestmentMovementRepository repository,
            IIndexQuotationRepository indexQuotationRepository,
            IInvestmentBalanceRepository investmentBalanceRepository)
        {
            _repository = repository;
            _indexQuotationRepository = indexQuotationRepository;
            _investmentBalanceRepository = investmentBalanceRepository;
        }

        #endregion [ Constructor ]

        #region [ Queries ]

        public InvestmentStatement GetStatement(int accountNumber, DateTime startDate, DateTime endDate)
        {
            var movements = _repository.GetByMovementDate(accountNumber, startDate, endDate);
            var indexes = _indexQuotationRepository.GetByReferenceDate(endDate);

            var statement = new InvestmentStatement
            {
                Applications = movements.Where(x => x.Type == InvestmentMovementTypeEnum.Application),
                Rescues = movements.Where(x => x.Type == InvestmentMovementTypeEnum.Rescue),
                Indexes = indexes
            };

            return statement;
        }

        public IEnumerable<PresumedIncome> GetPresumedIncome(int accountNumber, DateTime startDate, DateTime endDate)
        {
            var balances = _investmentBalanceRepository.GetByReferencetDate(accountNumber, startDate.AddDays(-5), endDate.AddDays(5));
            var movements = _repository.GetByMovementDate(accountNumber, startDate, endDate);

            var incomes = balances.GroupBy(x => x.ReferenceDate).Select(x => new PresumedIncome
            {
                ReferenceDate = x.Key.Date,
                BalanceCurrent = x.Sum(o => o.Amount),
                Ir = movements.Where(o => o.MovementDate == x.Key.Date && o.Type == InvestmentMovementTypeEnum.Rescue).Sum(o => o.Ir),
                Iof = movements.Where(o => o.MovementDate == x.Key.Date && o.Type == InvestmentMovementTypeEnum.Rescue).Sum(o => o.Iof),
                Application = movements.Where(o => o.MovementDate == x.Key.Date && o.Type == InvestmentMovementTypeEnum.Application).Sum(o => o.Amount),
                Rescue = movements.Where(o => o.MovementDate == x.Key.Date && o.Type == InvestmentMovementTypeEnum.Rescue).Sum(o => o.Amount)
            }).ToList();

            for (int i = 1; i < incomes.Count(); i++)
                incomes[i].BalancePrevious = incomes[i - 1].BalanceCurrent;

            incomes = incomes.Where(x => x.ReferenceDate >= startDate && x.ReferenceDate <= endDate).ToList();

            return incomes;
        }

        #endregion [ Queries ]

    }
}