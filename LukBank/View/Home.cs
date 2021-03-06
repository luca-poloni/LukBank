using LukBank.Control;
using System.Windows.Forms;

namespace LukBank.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            Apresentation();
        }

        private void Apresentation()
        {
            LabelApresentation.Text = HomeController.ShowClientName();
        }
    }
}
