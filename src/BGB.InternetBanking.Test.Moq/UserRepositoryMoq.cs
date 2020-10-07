using System.Linq;
using System.Collections.Generic;
using BGB.InternetBanking.Entities;
using BGB.InternetBanking.Entities.Enums;

namespace BGB.InternetBanking.Test.Moq
{
    public static class UserRepositoryMoq
    {

        #region [ Properties ]

        private static IList<User> _list;

        private static IList<User> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = LoadData();

                return _list;
            }
        }

        #endregion [ Properties ]

        public static IList<User> LoadAll()
        {
            return List;
        }

        public static User LoadById(int id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }

        #region [ Private Method ]

        private static IList<User> LoadData()
        {
            var list = new List<User>();

            list.Add(new User
            {
                Id = 1,
                Name = "Nome usuário teste A",
                Customer = CustomerRepositoryMoq.LoadById(1),
                Email = "E-mail usuário teste A",
                Profile = ProfileEnum.Master,
                Credential = new Credential { Login = "Login teste A", Key = "Chave teste A", TemporaryKey = true},
                Active = true
            });
            list.Add(new User
            {
                Id = 2,
                Name = "Nome usuário teste B",
                Customer = CustomerRepositoryMoq.LoadById(1),
                Email = "E-mail usuário teste B",
                Profile = ProfileEnum.Operation,
                Credential = new Credential { Login = "Login teste B", Key = "Chave teste B", TemporaryKey = true },
                Active = true
            });
            list.Add(new User
            {
                Id = 3,
                Name = "Nome usuário teste C",
                Customer = CustomerRepositoryMoq.LoadById(1),
                Email = "E-mail usuário teste C",
                Profile = ProfileEnum.Visualization,
                Credential = new Credential { Login = "Login teste C", Key = "Chave teste C", TemporaryKey = true },
                Active = true
            });
            list.Add(new User
            {
                Id = 4,
                Name = "Nome usuário teste D",
                Customer = CustomerRepositoryMoq.LoadById(2),
                Email = "E-mail usuário teste D",
                Profile = ProfileEnum.Master,
                Credential = new Credential { Login = "Login teste D", Key = "Chave teste D", TemporaryKey = true },
                Active = true
            });

            return list;
        }

        #endregion [ Private Method ]

    }
}