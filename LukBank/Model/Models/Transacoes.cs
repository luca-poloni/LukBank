using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Transacoes
    {
        public int Id { get; set; }
        public int ContaRemetente { get; set; }
        public int ContaDestino { get; set; }
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
