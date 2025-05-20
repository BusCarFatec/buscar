using System;
using System.Windows.Forms;
using BusCar.Properties;

namespace BusCar.view
{
    partial class RegisterScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_box_name_register = new TextBox();
            txt_box_senha = new TextBox();
            txt_box_cnpj = new TextBox();
            txt_box_cpf = new TextBox();
            btn_cadastrar = new Button();
            SuspendLayout();
            // 
            // txt_box_name_register
            // 
            txt_box_name_register.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_box_name_register.Location = new Point(977, 284);
            txt_box_name_register.Name = "txt_box_name_register";
            txt_box_name_register.Size = new Size(605, 54);
            txt_box_name_register.TabIndex = 0;
            // 
            // txt_box_senha
            // 
            txt_box_senha.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_box_senha.Location = new Point(977, 426);
            txt_box_senha.Name = "txt_box_senha";
            txt_box_senha.Size = new Size(605, 54);
            txt_box_senha.TabIndex = 1;
            // 
            // txt_box_cnpj
            // 
            txt_box_cnpj.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_box_cnpj.Location = new Point(977, 564);
            txt_box_cnpj.Name = "txt_box_cnpj";
            txt_box_cnpj.Size = new Size(605, 54);
            txt_box_cnpj.TabIndex = 2;
            // 
            // txt_box_cpf
            // 
            txt_box_cpf.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_box_cpf.Location = new Point(977, 700);
            txt_box_cpf.Name = "txt_box_cpf";
            txt_box_cpf.Size = new Size(605, 54);
            txt_box_cpf.TabIndex = 3;
            // 
            // btn_cadastrar
            // 
            btn_cadastrar.BackColor = SystemColors.Window;
            btn_cadastrar.BackgroundImage = Resources.Tela_de_Cadastro;
            btn_cadastrar.Location = new Point(1067, 832);
            btn_cadastrar.Name = "btn_cadastrar";
            btn_cadastrar.Size = new Size(427, 75);
            btn_cadastrar.TabIndex = 4;
            btn_cadastrar.Text = "button1";
            btn_cadastrar.UseVisualStyleBackColor = false;
            btn_cadastrar.Click += btn_cadastrar_Click;
            // 
            // RegisterScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.Tela_de_Cadastro;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_cadastrar);
            Controls.Add(txt_box_cpf);
            Controls.Add(txt_box_cnpj);
            Controls.Add(txt_box_senha);
            Controls.Add(txt_box_name_register);
            DoubleBuffered = true;
            Name = "RegisterScreen";
            Text = "RegisterScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_box_name_register;
        private TextBox txt_box_senha;
        private TextBox txt_box_cnpj;
        private TextBox txt_box_cpf;
        private Button btn_cadastrar;
    }
}