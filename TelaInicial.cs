using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using GoogleDriveAPI;
using System.Net.Http;
using CodigoBackup;
using BackupAutomatico;

namespace BackupAutomatico
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
            this.FormClosing += TelaInicial_FormClosing;
        }

        private void TelaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //Infos info = new Infos();
            //MessageBox.Show(info.pathBD()[0].ToString());
            //MessageBox.Show(info.Datahoranow().Substring(14, 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Infos infos = new Infos();
            //int horaemminuto = Int32.Parse(DateTime.Now.ToString().Substring(11, 2));
            //horaemminuto = horaemminuto * 60;
            //Conexao conex = new Conexao();
            // Parametros bkpparametros = new Parametros();
            //bkpparametros.buscarParametros();
            //MessageBox.Show(horaemminuto.ToString());
            //DirectoryInfo directoryInfo = new DirectoryInfo(@"C:/Minas_Software/SUPORTE/DEBUG/");
            //MessageBox.Show(directoryInfo.GetFiles().Length.ToString());
        }

        private void bkpNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            GDrive drive = new GDrive();
            this.Loginlbl.Text = drive.getLogin();
            this.Datalbl.Text = DateTime.Now.ToString();
            AtualizaHora();
        }

        private void Sairbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void AtualizaHora()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Datalbl.Text = DateTime.Now.ToString();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count != 0)
            {
                foreach (Form forms in Application.OpenForms)
                {
                    foreach (Control controle in forms.Controls)
                    {
                        MessageBox.Show(controle.Name);
                    }
                    //forms.Controls();
                    //forms.Close();
                }
            }
            Form telaprincipal = new TelaInicial();
           // MessageBox.Show(telaprincipal.Controls.ToString());
            
            telaprincipal.Activate();
            telaprincipal.Show();
        }
    }
}
