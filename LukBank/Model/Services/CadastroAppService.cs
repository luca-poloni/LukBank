using LukBank.Models;
using System;
using System.Linq;

namespace LukBank.Model.Services
{
    static class CadastroAppService
    {
        private static Context _context = new Context();

        public static CadastroApp CriarCadastroApp(string usuario, string senha, int numeroConta)
        {
            CadastroApp cadastroApp = null;

            try
            {
                var conta = _context.Contas.FirstOrDefault(c => c.Numero == numeroConta);

                if (conta != default)
                    cadastroApp = new CadastroApp() { Usuario = usuario, Senha = senha, Conta = conta.Id };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao criar o cadastro: {e}");
            }

            return cadastroApp;
        }

        public static bool RealizarLogin(string usuario, string senha)
        {
            var sucesso = false;

            try
            {
                if (_context.CadastroApp.Any(c => c.Usuario == usuario && c.Senha == senha))
                    sucesso = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao realizar o login: {e}");
            }

            return sucesso;
        }
    }
}
