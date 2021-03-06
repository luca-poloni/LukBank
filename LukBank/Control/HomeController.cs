using LukBank.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukBank.Control
{
    static class HomeController
    {
        public static string ShowClientName()
        {
            return $"Olá, {CadastroAppService.NameClient}!";
        }
    }
}
