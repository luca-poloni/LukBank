using LukBank.Models;
using System;
using System.Linq;

namespace LukBank.Model.Services
{
    static class CadastroAppService
    {
        private static Context _context = new Context();

        public static bool CriarCadastroApp(string usuario, string senha, Contas conta)
        {
            var sucesso = false;

            try
            {
                var cadastroApp = new CadastrosApps() { Usuario = usuario, Senha = senha, ContaNavigation = conta };

                _context.CadastrosApps.Add(cadastroApp);
                _context.SaveChanges();

                sucesso = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao criar o cadastro: {e}");
            }

            return sucesso;
        }

        public static bool RealizarLogin(string usuario, string senha)
        {
            var sucesso = false;

            try
            {
                if (_context.CadastrosApps.Any(c => c.Usuario == usuario && c.Senha == senha))
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
