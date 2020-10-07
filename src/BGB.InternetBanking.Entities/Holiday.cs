using System;

namespace BGB.InternetBanking.Entities
{
    public class Holiday
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsNational { get; set; }
        public virtual bool IsVariableDate { get; set; }
    }
}