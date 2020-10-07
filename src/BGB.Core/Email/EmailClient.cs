using System;
using System.Collections.ObjectModel;
using System.Net.Mail;
//TODO
//using BGB.Core.Config;

namespace BGB.Core.Email
{
    public class EmailClient
    {

        #region [ Properties ]

        public bool MessageBodyIsHtml { get; set; }

        public string MessageBody { get; set; }

        //TODO
        //private string SendFrom { get { return ApplicationSettings.EmailSendFrom; } }
        private string SendFrom { get { return string.Empty; } }

        private string _sendTo;
        //public string SendTo
        //{
        //    get
        //    {
        //        return ApplicationSettings.SystemExecutionEnvironment.Equals("P")
        //                   ? _sendTo
        //                   : ApplicationSettings.EmailSendToAlternative;
        //    }
        //    set { _sendTo = value; }
        //}
        public string SendTo
        {
            get
            {
                return string.Empty;
            }
            set { _sendTo = value; }
        }

        public string SendToCopy { get; set; }

        public string MessageSubject { get; set; }

        private Collection<Attachment> _attachments = new Collection<Attachment>();
        public Collection<Attachment> Attachments
        {
            get { return _attachments ?? (_attachments = new Collection<Attachment>()); }
            set { _attachments = value; }
        }

        #endregion [ Properties ]

        public void Send()
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient();

            mail.From = new MailAddress(SendFrom);

            if (!string.IsNullOrEmpty(SendTo))
                foreach (var item in SendTo.Split(Convert.ToChar(";")))
                    mail.To.Add(item);

            if (!string.IsNullOrEmpty(SendToCopy))
                foreach (var item in SendToCopy.Split(Convert.ToChar(";")))
                    mail.CC.Add(item);

            mail.Subject = MessageSubject;

            mail.IsBodyHtml = MessageBodyIsHtml;
            mail.Body = MessageBody;

            foreach (var attachment in Attachments)
                mail.Attachments.Add(attachment);

            smtpServer.Send(mail);
        }
    }
}