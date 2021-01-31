using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Pagamentos
    {
        public int Id { get; set; }
        public int Conta { get; set; }
        public decimal Valor { get; set; }
        public string CodigoBarra { get; set; }
        public DateTime? Data { get; set; }

        public virtual Contas ContaNavigation { get; set; }
    }
}
