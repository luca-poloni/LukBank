using LukBank.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukBank
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            if (CadastroAppControler.RealizarLogin(TxtUser.Text, TxtPassword.Text))
                MessageBox.Show("Login realizado com sucesso!");
            else
                MessageBox.Show("Usuário e/ou senha incorreto(s).");
        }
    }
}
