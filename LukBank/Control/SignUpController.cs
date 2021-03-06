using LukBank.Model.Services;
using System;

namespace LukBank.Control
{
    static class SignUpController
    {
        public static bool CriarConta(int agencia, string tipoConta, string usuario, string senha)
        {
            var sucesso = false;

            try
            {
                var conta = ContasService.CriarConta(agencia, tipoConta);

                if(conta != default)
                    if (CadastroAppService.CriarCadastroApp(usuario, senha, conta))
                        sucesso = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Houve um erro ao criar a conta. Erro: {e}");
            }

            return sucesso;
        }
    }
}
