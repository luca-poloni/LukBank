using LukBank.Models;
using System;
using System.Linq;

namespace LukBank.Model.Services
{
    static class PessoasService 
    {
        private static Context _context = new Context();

        public static Pessoas CriarPessoa(string nome, string cpfCnpj, DateTime dataNascimento, bool tipoPessoa)
        {
            Pessoas pessoa = null;

            try
            {
                if(!_context.Pessoas.Any(p => p.CpfCnpj == cpfCnpj))
                    pessoa = new Pessoas() { Nome = nome, CpfCnpj = cpfCnpj, DataNascimento = dataNascimento, TipoPessoa = tipoPessoa };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao criar a pessoa : {e}");
            }

            return pessoa;
        }
    }
}
