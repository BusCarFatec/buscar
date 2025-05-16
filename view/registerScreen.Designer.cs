namespace BusCar.view
{
    partial class registerScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerScreen));
            txt_cadastro_email = new TextBox();
            txt_cadastro_senha = new TextBox();
            txt_cadastro_confirma_senha = new TextBox();
            Btn_Cadastrar = new Button();
            txt_cadastro_nome = new TextBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // txt_cadastro_email
            // 
            txt_cadastro_email.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_cadastro_email.Location = new Point(964, 428);
            txt_cadastro_email.Name = "txt_cadastro_email";
            txt_cadastro_email.Size = new Size(625, 50);
            txt_cadastro_email.TabIndex = 1;
            // 
            // txt_cadastro_senha
            // 
            txt_cadastro_senha.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_cadastro_senha.Location = new Point(964, 565);
            txt_cadastro_senha.Name = "txt_cadastro_senha";
            txt_cadastro_senha.Size = new Size(625, 50);
            txt_cadastro_senha.TabIndex = 2;
            // 
            // txt_cadastro_confirma_senha
            // 
            txt_cadastro_confirma_senha.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_cadastro_confirma_senha.Location = new Point(964, 698);
            txt_cadastro_confirma_senha.Name = "txt_cadastro_confirma_senha";
            txt_cadastro_confirma_senha.Size = new Size(625, 50);
            txt_cadastro_confirma_senha.TabIndex = 3;
            // 
            // Btn_Cadastrar
            // 
            Btn_Cadastrar.Location = new Point(1064, 830);
            Btn_Cadastrar.Name = "Btn_Cadastrar";
            Btn_Cadastrar.Size = new Size(428, 82);
            Btn_Cadastrar.TabIndex = 5;
            Btn_Cadastrar.UseVisualStyleBackColor = true;
            // 
            // txt_cadastro_nome
            // 
            txt_cadastro_nome.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_cadastro_nome.Location = new Point(964, 292);
            txt_cadastro_nome.Name = "txt_cadastro_nome";
            txt_cadastro_nome.Size = new Size(625, 50);
            txt_cadastro_nome.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(980, 784);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(26, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "\r\n";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.UseWaitCursor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // registerScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1904, 1041);
            Controls.Add(checkBox1);
            Controls.Add(Btn_Cadastrar);
            Controls.Add(txt_cadastro_confirma_senha);
            Controls.Add(txt_cadastro_senha);
            Controls.Add(txt_cadastro_email);
            Controls.Add(txt_cadastro_nome);
            Name = "registerScreen";
            Text = "registerScreen";
            Load += registerScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_cadastro_email;
        private TextBox txt_cadastro_senha;
        private TextBox txt_cadastro_confirma_senha;
        private Button Btn_Cadastrar;
        private TextBox txt_cadastro_nome;
        public CheckBox checkBox1;
    }
}