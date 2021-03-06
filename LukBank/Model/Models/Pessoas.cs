using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Pessoas
    {
        public Pessoas()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool TipoPessoa { get; set; }
        public DateTime DataInserido { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
