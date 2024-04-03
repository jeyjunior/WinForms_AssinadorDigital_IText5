namespace WinForms_AssinadorDigital_IText5
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAssinarPades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAssinarPades
            // 
            this.btnAssinarPades.Location = new System.Drawing.Point(12, 12);
            this.btnAssinarPades.Name = "btnAssinarPades";
            this.btnAssinarPades.Size = new System.Drawing.Size(230, 60);
            this.btnAssinarPades.TabIndex = 0;
            this.btnAssinarPades.Text = "Assinar Pades B Level";
            this.btnAssinarPades.UseVisualStyleBackColor = true;
            this.btnAssinarPades.Click += new System.EventHandler(this.btnAssinarPades_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 86);
            this.Controls.Add(this.btnAssinarPades);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAssinarPades;
    }
}

