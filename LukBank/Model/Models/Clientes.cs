using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Clientes
    {
        public int Id { get; set; }
        public int Pessoa { get; set; }
        public int Conta { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime? DataInserido { get; set; }

        public virtual Contas ContaNavigation { get; set; }
        public virtual Pessoas PessoaNavigation { get; set; }
    }
}
