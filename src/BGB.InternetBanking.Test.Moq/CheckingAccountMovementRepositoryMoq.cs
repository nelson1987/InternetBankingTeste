using System;
using System.Linq;
using System.Collections.Generic;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Models.Enums;

namespace BGB.InternetBanking.Test.Moq
{
    public class CheckingAccountMovementRepositoryMoq
    {

        #region [ Properties ]

        private static IList<CheckingAccountMovement> _list;

        private static IList<CheckingAccountMovement> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = LoadData();

                return _list;
            }
        }

        #endregion [ Properties ]

        public static IList<CheckingAccountMovement> LoadAll()
        {
            return List;
        }

        public static CheckingAccountMovement LoadById(int id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }

        #region [ Private Methods ]

        private static IList<CheckingAccountMovement> LoadData()
        {
            var list = new List<CheckingAccountMovement>();

            list.Add(new CheckingAccountMovement
            {
                Id = 1,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                MovementDate = new DateTime(2018, 1, 10),
                CompensationDate = new DateTime(2018, 1, 10),
                Document = "Documento movimento teste A",
                PaymentType = PaymentTypeEnum.Money,
                History = new CheckingAccountHistory {  Id = 1, Description = "Descrição histórico teste A" },
                Amount = (decimal)25600.15
            });
            list.Add(new CheckingAccountMovement
            {
                Id = 2,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                MovementDate = new DateTime(2018, 1, 10),
                CompensationDate = new DateTime(2018, 1, 10),
                Document = "Documento movimento teste B",
                PaymentType = PaymentTypeEnum.Doc,
                History = new CheckingAccountHistory { Id = 1, Description = "Descrição histórico teste B" },
                Amount = (decimal)-15000.00
            });
            list.Add(new CheckingAccountMovement
            {
                Id = 3,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                MovementDate = new DateTime(2018, 1, 11),
                CompensationDate = new DateTime(2018, 1, 11),
                Document = "Documento movimento teste C",
                PaymentType = PaymentTypeEnum.Money,
                History = new CheckingAccountHistory { Id = 1, Description = "Descrição histórico teste C" },
                Amount = (decimal)-25.00
            });
            list.Add(new CheckingAccountMovement
            {
                Id = 4,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(11),
                MovementDate = new DateTime(2018, 1, 11),
                CompensationDate = new DateTime(2018, 1, 11),
                Document = "Documento movimento teste D",
                PaymentType = PaymentTypeEnum.Money,
                History = new CheckingAccountHistory { Id = 1, Description = "Descrição histórico teste D" },
                Amount = (decimal)23658.22
            });
            list.Add(new CheckingAccountMovement
            {
                Id = 5,
                CheckingAccount = CheckingAccountRepositoryMoq.LoadByNumber(22),
                MovementDate = new DateTime(2018, 1, 18),
                CompensationDate = new DateTime(2018, 1, 18),
                Document = "Documento movimento teste E",
                PaymentType = PaymentTypeEnum.Money,
                History = new CheckingAccountHistory { Id = 1, Description = "Descrição histórico teste E" },
                Amount = (decimal)4500.00
            });

            return list;
        }

        #endregion [ Private Method ]

    }
}