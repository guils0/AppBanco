namespace AppBanco
{
    partial class FormBanco
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
            this.btnCartoes = new System.Windows.Forms.Button();
            this.btnEmprestimos = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCartoes
            // 
            this.btnCartoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartoes.Location = new System.Drawing.Point(181, 256);
            this.btnCartoes.Name = "btnCartoes";
            this.btnCartoes.Size = new System.Drawing.Size(172, 110);
            this.btnCartoes.TabIndex = 0;
            this.btnCartoes.Text = "Cartões";
            this.btnCartoes.UseVisualStyleBackColor = true;
            // 
            // btnEmprestimos
            // 
            this.btnEmprestimos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmprestimos.Location = new System.Drawing.Point(402, 256);
            this.btnEmprestimos.Name = "btnEmprestimos";
            this.btnEmprestimos.Size = new System.Drawing.Size(172, 110);
            this.btnEmprestimos.TabIndex = 1;
            this.btnEmprestimos.Text = "Emprestimos";
            this.btnEmprestimos.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(678, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(110, 90);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(32, 81);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(330, 48);
            this.lblSaldo.TabIndex = 3;
            this.lblSaldo.Text = "Saldo: R$700,00";
            // 
            // FormBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnEmprestimos);
            this.Controls.Add(this.btnCartoes);
            this.Name = "FormBanco";
            this.Text = "Banco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCartoes;
        private System.Windows.Forms.Button btnEmprestimos;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblSaldo;
    }
}