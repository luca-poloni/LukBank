using System;
using System.Collections.Generic;

namespace LukBank.Models
{
    public partial class Tipostransacoes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
    }
}
