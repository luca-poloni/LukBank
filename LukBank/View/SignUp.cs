using LukBank.Control;
using System;
using System.Windows.Forms;

namespace LukBank.View
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (SignUpController.CriarConta(Convert.ToInt32(TextBoxAgency.Text), TextBoxAccountType.Text, TextBoxUser.Text, TextBoxPassword.Text))
                MessageBox.Show("Account successfully created");
            else
                MessageBox.Show("Could not create an account");

            OpenHome();
        }

        private void OpenHome()
        {
            Hide();

            var home = new SignIn();

            home.ShowDialog();

            Close();
        }
    }
}
