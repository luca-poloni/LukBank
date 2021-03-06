using System;

namespace LukBank.Models
{
    public partial class CadastrosApps
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int Conta { get; set; }
        public DateTime DataInserido { get; set; }

        public virtual Contas ContaNavigation { get; set; }
    }
}
