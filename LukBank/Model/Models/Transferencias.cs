using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Transferencias
    {
        public int Id { get; set; }
        public int ContaRemetente { get; set; }
        public int ContaDestinataria { get; set; }
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data { get; set; }

        public virtual Contas ContaDestinatariaNavigation { get; set; }
        public virtual Contas ContaRemetenteNavigation { get; set; }
        public virtual Tipotransacoes TipoTransacaoNavigation { get; set; }
    }
}
