using LukBank.Model.Services;

namespace LukBank.Control
{
    static class SignInController
    {
        public static bool RealizarLogin(string usuario, string senha)
        {
            var sucesso = false;

            if (CadastroAppService.RealizarLogin(usuario, senha))
                sucesso = true;

            return sucesso;
        }
    }
}
