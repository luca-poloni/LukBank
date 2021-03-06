using LukBank.Models;
using System;

namespace LukBank.Model.Services
{
    static class ClientesService 
    {
        public static Clientes CriarCliente(string nome, string cpfCnpj, DateTime dataNascimento, bool tipoPessoa, int agencia, string tipoConta)
        {
            Clientes cliente = null;

            try
            {
                var pessoa = PessoasService.CriarPessoa(nome, cpfCnpj, dataNascimento, tipoPessoa);
                var conta = ContasService.CriarConta(agencia, tipoConta);

                cliente.PessoaNavigation = pessoa;
                cliente.ContaNavigation = conta;
                cliente.Ativo = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao criar o Cliente : {e}");
            }

            return cliente;
        }
    }
}
