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
    public partial class RegisterScreen : Form
    {
        public RegisterScreen()
        {
            InitializeComponent();

            var db = new Buscar.Database.Database();
            db.OpenConnection();


            db.CloseConnection();

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            string Nome = txt_box_name_register.Text;
            string Senha = txt_box_senha.Text;
            string Cnpj = txt_box_cnpj.Text;
            string Cpf = txt_box_cpf.Text;

            Console.WriteLine(Nome, Senha, Cnpj, Cpf);
        }
    }
}
