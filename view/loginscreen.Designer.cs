using System;
using System.Windows.Forms;
using BusCar.Properties;


namespace BusCar.view
{
    partial class LoginScreen
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
            btn_goto_cadastro = new Button();
            SuspendLayout();
            // 
            // btn_goto_cadastro
            // 
            btn_goto_cadastro.Location = new Point(1291, 926);
            btn_goto_cadastro.Name = "btn_goto_cadastro";
            btn_goto_cadastro.Size = new Size(205, 30);
            btn_goto_cadastro.TabIndex = 0;
            btn_goto_cadastro.Text = "button1";
            btn_goto_cadastro.UseVisualStyleBackColor = true;
            btn_goto_cadastro.Click += btn_goto_cadastro_Click;
            // 
            // LoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.Tela_de_Login;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_goto_cadastro);
            Name = "LoginScreen";
            Text = "LoginScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_goto_cadastro;
    }
}