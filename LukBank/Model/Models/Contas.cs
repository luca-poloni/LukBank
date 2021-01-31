using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Contas
    {
        public Contas()
        {
            Cadastroapp = new HashSet<CadastroApp>();
            Clientes = new HashSet<Clientes>();
            Pagamentos = new HashSet<Pagamentos>();
            TransferenciasContaDestinatariaNavigation = new HashSet<Transferencias>();
            TransferenciasContaRemetenteNavigation = new HashSet<Transferencias>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime? DataInserido { get; set; }

        public virtual ICollection<CadastroApp> Cadastroapp { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<Pagamentos> Pagamentos { get; set; }
        public virtual ICollection<Transferencias> TransferenciasContaDestinatariaNavigation { get; set; }
        public virtual ICollection<Transferencias> TransferenciasContaRemetenteNavigation { get; set; }
    }
}
