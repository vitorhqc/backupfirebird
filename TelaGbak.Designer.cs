namespace BackupAutomatico
{
    partial class TelaGbak
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
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.executar = new System.Windows.Forms.Button();
            this.Fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(194, 12);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(476, 472);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            // 
            // executar
            // 
            this.executar.Location = new System.Drawing.Point(48, 187);
            this.executar.Name = "executar";
            this.executar.Size = new System.Drawing.Size(99, 42);
            this.executar.TabIndex = 1;
            this.executar.Text = "Executar BKP";
            this.executar.UseVisualStyleBackColor = true;
            this.executar.Click += new System.EventHandler(this.executar_Click);
            // 
            // Fechar
            // 
            this.Fechar.Location = new System.Drawing.Point(48, 265);
            this.Fechar.Name = "Fechar";
            this.Fechar.Size = new System.Drawing.Size(99, 42);
            this.Fechar.TabIndex = 2;
            this.Fechar.Text = "Fechar";
            this.Fechar.UseVisualStyleBackColor = true;
            this.Fechar.Click += new System.EventHandler(this.Fechar_Click);
            // 
            // TelaGbak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 496);
            this.Controls.Add(this.Fechar);
            this.Controls.Add(this.executar);
            this.Controls.Add(this.LogBox);
            this.Name = "TelaGbak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Button executar;
        private System.Windows.Forms.Button Fechar;
    }
}