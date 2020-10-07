using System;
using System.Linq;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Test.Moq
{
    public class CheckingAccountBalanceRepositoryMoq
    {

        #region [ Properties ]

        private static IList<CheckingAccountBalance> _list;

        private static IList<CheckingAccountBalance> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = LoadData();

                return _list;
            }
        }

        #endregion [ Properties ]

        public static IList<CheckingAccountBalance> LoadAll()
        {
            return List;
        }

        public static CheckingAccountBalance LoadById(int id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }

        #region [ Private Methods ]

        private static IList<CheckingAccountBalance> LoadData()
        {
            var list = new List<CheckingAccountBalance>();

            list.Add(new CheckingAccountBalance
            {
                Id = 1,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                ReferenceDate = new DateTime(2018, 1, 10),
                Blocked = 0,
                Amount = (decimal)10250.50,
                BusinessCheck = new BusinessCheck { Start = new DateTime(2018, 1, 1), End = new DateTime(2018, 6, 30), Limit = 300000}
            });
            list.Add(new CheckingAccountBalance
            {
                Id = 2,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                ReferenceDate = new DateTime(2018, 1, 11),
                Blocked =(decimal)600.56,
                Amount = (decimal)15290.00,
                BusinessCheck = new BusinessCheck { Start = new DateTime(2018, 1, 1), End = new DateTime(2018, 6, 30), Limit = 300000 }
            });
            list.Add(new CheckingAccountBalance
            {
                Id = 3,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                ReferenceDate = new DateTime(2018, 1, 12),
                Blocked = (decimal)600.56,
                Amount = (decimal)26000.00,
                BusinessCheck = new BusinessCheck { Start = new DateTime(2018, 1, 1), End = new DateTime(2018, 6, 30), Limit = 300000 }
            });
            list.Add(new CheckingAccountBalance
            {
                Id = 4,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(22),
                ReferenceDate = new DateTime(2018, 1, 8),
                Blocked = 0,
                Amount = (decimal)8000.00
            });

            return list;
        }

        #endregion [ Private Method ]

    }
}