using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace BackupAutomatico
{
    public partial class TelaGbak : Form
    {
        static Infos info = new Infos(); //INSTANCIA GLOBAL DA CLASSE PARA UTILIZACAO DOS METODOS
        static Parametros bkpparams = new Parametros(); //INSTANCIA GLOBAL DA CLASSE PARA UTILIZACAO DOS METODOS
        string caminholog = AppDomain.CurrentDomain.BaseDirectory + @"TEMP/LOG"; //CAMINHO ONDE SERA CRIADO O LOG
        public FileInfo fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"TEMP/LOG"); //VARIAVEL QUE OBSERVARA AS INFORMACOES DO CAMINHO DESEJADO
        public FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
        public long tamanholog = 0;
        public TelaGbak()
        {
            InitializeComponent();
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void executar_Click(object sender, EventArgs e)
        {
            LogBox.Text = "Aguarde até o backup ser finalizado!";
            string argumentos;
            if (!Directory.Exists(bkpparams.gbakpath))
            {
                Directory.CreateDirectory(bkpparams.gbakpath);
            }

            if (File.Exists(caminholog))
            {
                File.Delete(caminholog);
            }
            fileSystemWatcher.Path = caminholog.Replace("LOG", "");
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;
            argumentos = string.Format(@"/K cd {0} & gbak -b -v -y {1} -user SYSDBA -password masterkey {2} {3} & exit", info.getFirebirdpath(), caminholog, info.pathBD(), bkpparams.gbakpath + "msbanco" + info.Datahoranow() + @".fbk");
            ProcessStartInfo processo = new ProcessStartInfo();
            processo.Arguments = argumentos;
            processo.CreateNoWindow = true;
            processo.UseShellExecute = true;
            processo.WindowStyle = ProcessWindowStyle.Hidden;
            processo.FileName = "cmd";
            Process.Start(processo);
            //Task FazerBKP = new Task(() => Process.Start(processo).WaitForExit());
            //FazerBKP.Start();
            //FazerBKP.Wait();
            //fileSystemWatcher.Dispose();
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Path = caminholog.Replace("LOG", "");
            fileSystemWatcher.Filter = @"LOG";
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName;
            fileSystemWatcher.EnableRaisingEvents = true;
            Task AtualizaInfo = new Task(new Action(() => atualizainfo(tamanholog)));
            //AtualizaInfo.Start();
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            LerLog();
            this.Invoke(new Action(() =>
            {
                LogBox.Focus();
                LogBox.Select(LogBox.Text.Length, 0);
            }));
        }

        private void LerLog()
        {
            string newFileLines = "";
            using (FileStream stream = File.Open(caminholog,
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    newFileLines = reader.ReadToEnd();
                }
            }

            LogBox.Invoke(new Action(() =>
            {
                LogBox.Focus();
                LogBox.Select(LogBox.Text.Length, 0);
                LogBox.Text += LogBox.Text + "\n" + newFileLines;
                LogBox.Focus();
                LogBox.Select(LogBox.Text.Length, 0);
            }));

        }

        private void atualizainfo(long tamanhologtxt)
        {
            fi.Refresh();
            //MessageBox.Show(fi.Length.ToString());
            //MessageBox.Show(tamanhologtxt.ToString());
            if (fi.Length > tamanhologtxt)
            {
                tamanholog = fi.Length;
                LerLog();
            }
            Thread.Sleep(200);
            atualizainfo(tamanholog);
        }
    }
}
