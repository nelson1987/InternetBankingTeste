using System;

namespace BGB.InternetBanking.Entities
{
    public class EventLog
    {
        public virtual long Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string UserName { get; set; }
        public virtual string AccessIp { get; set;  }
        public virtual string OperationName { get; set; }
        public virtual string Parameter { get; set; }
    }
}