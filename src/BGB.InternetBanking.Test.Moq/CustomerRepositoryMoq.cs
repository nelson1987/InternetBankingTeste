using System.Linq;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Models.Enums;

namespace BGB.InternetBanking.Test.Moq
{
    public static class CustomerRepositoryMoq
    {

        #region [ Properties ]

        private static IList<Customer> _list;

        private static IList<Customer> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = LoadData();

                return _list;
            }
        }

        #endregion [ Properties ]

        public static IList<Customer> LoadAll()
        {
            return List;
        }

        public static Customer LoadById(int id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }

        #region [ Private Methods ]

        private static IList<Customer> LoadData()
        {
            var list = new List<Customer>();

            list.Add(new Customer
            {
                Id = 1,
                Name = "Nome cliente teste A",
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11) ,
                CpfCnpj = 12345678901234,
                PersonType = PersonTypeEnum.Legal,
                Active = true
            });
            list.Add(new Customer
            {
                Id = 2,
                Name = "Nome cliente teste B",
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(22),
                CpfCnpj = 43210987654321,
                PersonType = PersonTypeEnum.Legal,
                Active = true
            });
            list.Add(new Customer
            {
                Id = 3,
                Name = "Nome cliente teste C",
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(44),
                CpfCnpj = 12345678901,
                PersonType = PersonTypeEnum.Natural,
                Active = true
            });

            return list;
        }

        #endregion [ Private Method ]

    }
}