using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//TODO
//using BGB.Core.Config;
using BGB.Core.Email;
using BGB.Core.Models;
using BGB.Core.Resources;
using BGB.InternetBanking.Models;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services.Interfaces;

namespace BGB.InternetBanking.Services
{
    public class WithdrawalService : IWithdrawalService
    {

        #region [ Constants ] 

        private const string MinimumAmountCode = "VMCSA";
        private const string DaysInAdvanceCode = "DACSA";
        private const string ScheduledCode = "CSAGE";
        private const string CanceledCode = "CSCAN";
        private const string LimitHourCode = "HLCSA";
        private const string NotificationCode = "EMNCS";
        private const string NotificationTemplate = "NotificacaoComunicacaoSaque.html";

        #endregion [ Constants ] 

        #region [ Attributes ]

        private readonly IWithdrawalRepository _repository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IStatusRepository _statusRepository;

        #endregion [ Attributes ]

        #region [ Constructor ]

        public WithdrawalService(IWithdrawalRepository repository, 
            IHolidayRepository holidayRepository, 
            IParameterRepository parameterRepository,
            IStatusRepository statusRepository)
        {
            _repository = repository;
            _holidayRepository = holidayRepository;
            _parameterRepository = parameterRepository;
            _statusRepository = statusRepository;
        }

        #endregion [ Constructor ]

        #region [ Actions ]

        public ReturnMessage Insert(WithdrawalCommunication withdrawal)
        {
            var minimumAmount = _parameterRepository.GetByCode(MinimumAmountCode);
            var daysInAdvance = _parameterRepository.GetByCode(DaysInAdvanceCode);

            withdrawal.Status = _statusRepository.GetByCode(ScheduledCode);
            withdrawal.CommunicationDate = DateTime.Now;
            withdrawal.CommunicationDateValid = CalculateDateValid(withdrawal.CommunicationDate);
            withdrawal.Protocol = withdrawal.CommunicationDate.ToString("yyyyMMddHHmmssffff");

            withdrawal.MinimumAmount = decimal.Parse(minimumAmount.Value);
            withdrawal.ExpectedDateValid = CalculateDateValid(withdrawal.ExpectedDate);
            withdrawal.DaysInAdvance = int.Parse(daysInAdvance.Value);

            if (withdrawal.IsValid)
            {
                _repository.Insert(withdrawal);

                Notify(withdrawal);
            }

            return new ReturnMessage(
                withdrawal.IsValid,
                BusinessMessage.RecordUpdatedWithSuccess,
                withdrawal.ValidationResult.GetErrorMessage()
            );
        }

        public ReturnMessage Cancel(int id)
        {
            var withdrawal = _repository.LoadById(id);
            var erros = new List<string>();

            if (withdrawal == null || withdrawal.Id == 0)
                erros.Add(BusinessMessage.RecordNotFound);
            else
            {
                if (!withdrawal.Status.Code.Equals(ScheduledCode))
                    erros.Add(BusinessMessage.WithdrawalCanNotIsCanceled);

                if ((withdrawal.ExpectedDate.Date - DateTime.Now.Date).Days < 2)
                    erros.Add(BusinessMessage.WithdrawalOutOfDeadline);

            }

            if (erros == null || erros.Count == 0)
            {
                var status = _statusRepository.GetByCode(CanceledCode);

                withdrawal.Status = status;

                _repository.Update(withdrawal);
            }

            return new ReturnMessage(
                !erros.Any(),
                BusinessMessage.WithdrawalCanceled,
                erros
            );
        }

        #endregion [ Actions ]

        #region [ Queries ]

        public IEnumerable<WithdrawalCommunication> GetByCustomer(int customerId)
        {
            return _repository.GetByCustomer(customerId);
        }

        #endregion [ Queries ]

        #region [ Private Methods ]

        private DateTime CalculateDateValid(DateTime date)
        {
            var validDate = date;
            var limitHour = _parameterRepository.GetByCode(LimitHourCode);
            var holidays = _holidayRepository.GetNextYears(date.Year, 1);

            while (true)
            {
                if (validDate.Hour + 1 > int.Parse(limitHour.Value))
                    validDate = validDate.AddDays(1).Date;
                else if (holidays.Any(x => x.Date.Date == validDate.Date))
                    validDate = validDate.AddDays(1).Date;
                else if (validDate.DayOfWeek == DayOfWeek.Saturday)
                    validDate = validDate.AddDays(1).Date;
                else if (validDate.DayOfWeek == DayOfWeek.Sunday)
                    validDate = validDate.AddDays(1).Date;
                else
                    break;
            }

            return validDate;
        }

        private void Notify(WithdrawalCommunication withdrawal)
        {
            var parameter = _parameterRepository.GetByCode(NotificationCode);

            if (parameter == null || string.IsNullOrEmpty(parameter.Value))
                return;

            string body;

            //TODO:
            //using (var arquivo = new StreamReader(Path.Combine(ApplicationSettings.FolderTemplates, NotificationTemplate), Encoding.UTF7))
            //{
            //    body = arquivo.ReadToEnd();
            //}
            body = string.Empty;

            body = body.Replace("#Cliente", withdrawal.Customer.Name);
            body = body.Replace("#Protocolo", withdrawal.Protocol);
            body = body.Replace("#Valor", string.Format("{0:C2}", withdrawal.Amount));
            body = body.Replace("#DataSaque", withdrawal.ExpectedDate.ToString("dd/MM/yyyy"));

            var emailClient = new EmailClient
            {
                SendTo = parameter.Value.Trim(),
                MessageBody = body,
                MessageSubject = $"IB - Cadastro de comunicação de saque. No. {withdrawal.Protocol}",
                MessageBodyIsHtml = true
            };

            emailClient.Send();
        }

        #endregion [ Private Methods ]

    }
}
