using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Tipotransacoes
    {
        public Tipotransacoes()
        {
            Transferencias = new HashSet<Transferencias>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public sbyte Ativo { get; set; }

        public virtual ICollection<Transferencias> Transferencias { get; set; }
    }
}
