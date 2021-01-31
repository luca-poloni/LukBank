using LukBank.Model.Services;

namespace LukBank.Control
{
    static class CadastroAppControler
    {
        public static bool RealizarLogin(string usuario, string senha)
        {
            if (CadastroAppService.RealizarLogin(usuario, senha))
                return true;

            return false;
        }
    }
}
