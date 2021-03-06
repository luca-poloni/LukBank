using LukBank.Control;
using LukBank.View;
using System;
using System.Windows.Forms;

namespace LukBank
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            if (SignInController.RealizarLogin(TxtUser.Text, TxtPassword.Text))
                MessageBox.Show("Login realizado com sucesso!");
            else
                MessageBox.Show("Usuário e/ou senha incorreto(s).");

            ShowHome();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            ShowSignUp();
        }

        private void ShowSignUp()
        {
            Hide();

            SignUp signUp = new SignUp();

            signUp.ShowDialog();

            Close();
        }

        private void ShowHome()
        {
            Hide();

            Home home = new Home();

            home.ShowDialog();

            Close();
        }
    }
}
