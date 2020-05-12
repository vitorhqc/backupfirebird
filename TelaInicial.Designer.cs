namespace BackupAutomatico
{
    partial class TelaInicial
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicial));
            this.bkpNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.BoasVindas = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Acessarbtn = new System.Windows.Forms.Button();
            this.Sairbtn = new System.Windows.Forms.Button();
            this.Loginlbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Datalbl = new System.Windows.Forms.Label();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bkpNotify
            // 
            this.bkpNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bkpNotify.BalloonTipText = "Minas_Software";
            this.bkpNotify.ContextMenuStrip = this.contextMenuStrip1;
            this.bkpNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("bkpNotify.Icon")));
            this.bkpNotify.Text = "Minas_Software";
            this.bkpNotify.Visible = true;
            this.bkpNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.bkpNotify_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            this.contextMenuStrip1.Text = "Sair;";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Sair";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // BoasVindas
            // 
            this.BoasVindas.AutoSize = true;
            this.BoasVindas.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoasVindas.Location = new System.Drawing.Point(80, 41);
            this.BoasVindas.Name = "BoasVindas";
            this.BoasVindas.Size = new System.Drawing.Size(628, 44);
            this.BoasVindas.TabIndex = 1;
            this.BoasVindas.Text = "Bem vindo ao gerenciador de backup da Minas Software!\r\nIntegrado com o Google Dri" +
    "ve para que seu backup esteja sempre disponível!";
            this.BoasVindas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(321, 104);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(139, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Clique aqui para saber mais!";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Acessarbtn
            // 
            this.Acessarbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acessarbtn.Location = new System.Drawing.Point(258, 270);
            this.Acessarbtn.Name = "Acessarbtn";
            this.Acessarbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Acessarbtn.Size = new System.Drawing.Size(112, 37);
            this.Acessarbtn.TabIndex = 3;
            this.Acessarbtn.Text = "Acessar Google Drive";
            this.Acessarbtn.UseVisualStyleBackColor = true;
            // 
            // Sairbtn
            // 
            this.Sairbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sairbtn.Location = new System.Drawing.Point(414, 270);
            this.Sairbtn.Name = "Sairbtn";
            this.Sairbtn.Size = new System.Drawing.Size(110, 37);
            this.Sairbtn.TabIndex = 4;
            this.Sairbtn.Text = "Sair";
            this.Sairbtn.UseVisualStyleBackColor = true;
            this.Sairbtn.Click += new System.EventHandler(this.Sairbtn_Click);
            // 
            // Loginlbl
            // 
            this.Loginlbl.AutoSize = true;
            this.Loginlbl.Location = new System.Drawing.Point(196, 164);
            this.Loginlbl.Name = "Loginlbl";
            this.Loginlbl.Size = new System.Drawing.Size(0, 13);
            this.Loginlbl.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(109, 304);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 95);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(557, 323);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 76);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Datalbl
            // 
            this.Datalbl.AutoSize = true;
            this.Datalbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datalbl.Location = new System.Drawing.Point(311, 376);
            this.Datalbl.Name = "Datalbl";
            this.Datalbl.Size = new System.Drawing.Size(0, 17);
            this.Datalbl.TabIndex = 8;
            this.Datalbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.Datalbl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Loginlbl);
            this.Controls.Add(this.Sairbtn);
            this.Controls.Add(this.Acessarbtn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BoasVindas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon bkpNotify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label BoasVindas;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button Acessarbtn;
        private System.Windows.Forms.Button Sairbtn;
        private System.Windows.Forms.Label Loginlbl;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Datalbl;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

