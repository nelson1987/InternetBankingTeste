using System.Linq;
using System.Collections.Generic;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Test.Moq
{
    public static class CheckingAccountRepositoryMoq
    {

        #region [ Properties ]

        private static IList<CheckingAccount> _list;

        private static IList<CheckingAccount> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = LoadData();

                return _list;
            }
        }

        #endregion [ Properties ]

        public static IList<CheckingAccount> LoadAll()
        {
            return List;
        }

        public static CheckingAccount LoadByNumber(int number)
        {
            return List.FirstOrDefault(x => x.Number == number);
        }

        #region [ Private Method ]

        private static IList<CheckingAccount> LoadData()
        {
            var list = new List<CheckingAccount>();

            list.Add(new CheckingAccount { Number = 11, Digit = 2 });
            list.Add(new CheckingAccount { Number = 22, Digit = 4 });
            list.Add(new CheckingAccount { Number = 44, Digit = 8 });
            list.Add(new CheckingAccount { Number = 55, Digit = 0 });

            return list;
        }

        #endregion [ Private Method ]

    }
}