using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Contas
    {
        public Contas()
        {
            CadastrosApps = new HashSet<CadastrosApps>();
            Clientes = new HashSet<Clientes>();
            Pagamentos = new HashSet<Pagamentos>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public bool? Ativo { get; set; }
        public DateTime DataInserido { get; set; }

        public virtual ICollection<CadastrosApps> CadastrosApps { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<Pagamentos> Pagamentos { get; set; }
    }
}
