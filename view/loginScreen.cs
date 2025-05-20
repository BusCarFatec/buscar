using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusCar.view
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
         
        }

        private void btn_goto_cadastro_Click(object sender, EventArgs e)
        {
            var RegisterScreen = new RegisterScreen(); // ou qualquer outro Form
            RegisterScreen.Show(); // abre a nova tela
            this.Hide(); // oculta a atual
            Application.Exit();

        }
    }
}
