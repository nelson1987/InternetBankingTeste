using System.Collections.Generic;
using System.Linq;

namespace BGB.InternetBanking.Entities
{
    public class GuaranteeBoard
    {

        #region [ Attributes ]

        private readonly IEnumerable<Guarantee> _guarantees;
        private readonly IEnumerable<CheckingAccountBalance> _checkingAccountBalances;
        private readonly IEnumerable<CheckingAccountBalance> _guaranteedAccountBalances;

        #endregion [ Attributes ]

        #region [ Properties ]        

        public decimal Required { get; private set; }
        public decimal Duplicate { get; private set; }
        public decimal Check { get; private set; }
        public decimal Card { get; private set; }
        public decimal Expired { get; private set; }
        public decimal Margin { get; private set; }
        public CheckingAccountBalance CheckingAccountBalance { get; private set; }
        public CheckingAccountBalance GuaranteedAccountBalance { get; private set; }
        
        #endregion [ Properties ]

        #region [ Constructor ]

        public GuaranteeBoard(IEnumerable<Guarantee> guarantees, 
            IEnumerable<CheckingAccountBalance> checkingAccountBalances, 
            IEnumerable<CheckingAccountBalance> guaranteedAccountBalances)
        {
            _guarantees = guarantees;
            _checkingAccountBalances = checkingAccountBalances;
            _guaranteedAccountBalances = guaranteedAccountBalances;

            Initialize();
        }

        #endregion [ Constructor ]

        #region [ Privates Methods ]

        private void Initialize()
        {
            Required = _guarantees.GroupBy(x => x.Contract)
                            .Select(x => new { Contrato = x.Key, Exigida = x.Sum(g => g.RequiredAmount) }).Sum(x => x.Exigida);

            Duplicate = _guarantees.GroupBy(x => x.CheckingAccountGarantor.Number)
                            .Select(x => new { Number = x.Key, Duplicate = x.Sum(g => g.DuplicateAmount) }).Sum(x => x.Duplicate);

            Check =  _guarantees.GroupBy(x => x.CheckingAccountGarantor.Number)
                            .Select(x => new { Number = x.Key, Cheque = x.Sum(g => g.CheckAmount) }).Sum(x => x.Cheque);

            Card =  _guarantees.GroupBy(x => x.CheckingAccountGarantor.Number)
                            .Select(x => new { Number = x.Key, Card = x.Sum(g => g.CardAmount) }).Sum(x => x.Card);

            Expired = _guarantees.GroupBy(x => x.CheckingAccountGarantor.Number)
                        .Select(x => new { Number = x.Key, Expired = x.Sum(g => g.ExpiredAmount) }).Sum(x => x.Expired);

            CheckingAccountBalance = _checkingAccountBalances.GroupBy(g => g.ReferenceDate).Select(g => new CheckingAccountBalance
            {
                ReferenceDate = g.Key,
                Amount = g.Sum(x => x.Amount),
                Blocked = g.Sum(x => x.Blocked)
            }).FirstOrDefault();

            GuaranteedAccountBalance = _guaranteedAccountBalances.GroupBy(g => g.ReferenceDate).Select(g => new CheckingAccountBalance
            {
                ReferenceDate = g.Key,
                Amount = g.Sum(x => x.Amount),
                Blocked = g.Sum(x => x.Blocked)
            }).FirstOrDefault();
        }

        #endregion [ Privates Methods ]

    }
}