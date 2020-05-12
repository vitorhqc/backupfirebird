using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using CodigoBackup;

namespace BackupAutomatico
{
    static class Program
    {
        static Infos info = new Infos(); //INSTANCIA GLOBAL DA CLASSE PARA UTILIZACAO DOS METODOS
        static Parametros bkpparams = new Parametros(); //INSTANCIA GLOBAL DA CLASSE PARA UTILIZACAO DOS METODOS
        static Backup backup = new Backup(); //INSTANCIA GLOBAL DA CLASSE PARA UTILIZACAO DOS METODOS 
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //bkpparams.buscarParametrosBD();       //BUSCA DOS PARAMETROS NO BANCO DE DADOS
            bkpparams.buscarParametrosTXT();        //BUSCA DOS PARAMETROS NO ARQUIVO DE CONFIGURACAO TXT
            Timer timerbkp = new Timer();       //INSTANCIA DO TIMER PARA VERIFICACAO DA HORA
            if (bkpparams.bkpativo == true && bkpparams.bkpintervalo != 0)
            {
                timerbkp.Interval = 60 * 1000;      //INTERVALO DO BKP EM MILISEGUNDOS!!
                timerbkp.Tick += Timerbkp_Tick;
                timerbkp.Enabled = true;
                timerbkp.Start();
            }

            if (bkpparams.bkptipo == "gbak")
            {
                Application.Run(new TelaGbak());
            }

            else
                Application.Run(new TelaInicial());
            
              
        }

        private static void Timerbkp_Tick(object sender, EventArgs e)
        {
            //TESTA SE A HORA ATUAL (HORAS EM MINUTOS + OS MINUTOS) É DIVISIVEL PELO INTERVALO CONFIGURADO
            //CASO SEJA ELE VAI FAZER O BACKUP, CASO CONTRARIO NAO FARA O BACKUP
            if ((info.horasemminutos() + Int32.Parse(info.Datahoranow().Substring(14,2))) % (bkpparams.bkpintervalo) == 0 )
            {
                backup.BACKUP();
            }

        }
    }

    //CLASSE DOS PARAMETROS BUSCADOS NO BANCO DE DADOS PARA CONFIGURAR O BACKUP
    public class Parametros 
    {
        public bool bkpativo = false;
        public int bkpintervalo = 0;
        public string bkptipo = "default";
        public string gbakpath = AppDomain.CurrentDomain.BaseDirectory + @"BackupMinasGBAK/"; //CAMINHO ONDE O ARQUIVO DE BACKUP SERA SALVO **SOMENTE PARA BACKUP GBAK**

        //FUNCAO PARA BUSCAR OS PARAMETROS NO ARQUIVO BKPCONFIG.TXT
        public void buscarParametrosTXT()
        {
            int n = 0;
            string separator = @"//";
            string[] parametro;
            using (StreamReader sr = new StreamReader("BKPConfig.ini"))
            {
                parametro = sr.ReadToEnd().Split('\u000A');
            }

            foreach(string linha in parametro)
            {
                if (linha.Contains(separator))
                {
                    parametro[n] = linha.Remove(linha.IndexOf(separator)).Trim();
                }
                n++;
            }

            if (parametro[0].Substring(parametro[0].IndexOf('=') + 1, 4) == "true")
            {
                bkpativo = true;
            }

            bkpintervalo = Int32.Parse(parametro[1].Substring(parametro[1].IndexOf('=') + 1, parametro[1].Length - (parametro[1].IndexOf('=') + 1)));

            bkptipo = (parametro[2].Substring(parametro[2].IndexOf('=') + 1, parametro[2].Length - (parametro[2].IndexOf('=') + 1)));

            if ((parametro[3].Substring(parametro[3].IndexOf('=') + 1, parametro[3].Length - (parametro[3].IndexOf('=') + 1))) != "default")
            {
                gbakpath = (parametro[3].Substring(parametro[3].IndexOf('=') + 1, parametro[3].Length - (parametro[3].IndexOf('=') + 1)));
            }
            
        }

    }

    //CLASSE DE INFORMACOES NECESSARIAS AO PROGRAMA COMO CAMINHO DO BANCO, HORA ATUAL, IP DO SERVIDOR
    public class Infos
    {
        //FUNCAO QUE RETORNA A HORA ATUAL FORMATADA PARA UTILIZAR EM NOME DE ARQUIVOS
        public string Datahoranow()
        {
            string agora = DateTime.Now.ToString();
            agora = agora.Replace(@"/", @"-");
            agora = agora.Replace(@" ",@"_");
            agora = agora.Replace(@":", @"_");
            return agora;
        }

        //FUNCAO QUE RETORNA A HORA DO DIA EM MINUTOS
        public int horasemminutos()
        {
            int horaemminuto = Int32.Parse(DateTime.Now.ToString().Substring(11,2));
            horaemminuto = horaemminuto * 60;
            return horaemminuto;
        }

        //FUNCAO QUE RETORNA O MES E O ANO
        public string meseano()
        {
            string mesano = DateTime.Now.ToString();
            mesano = mesano.Replace(@"/", @"-");
            mesano = mesano.Replace(@" ", @"_");
            mesano = mesano.Replace(@":", @"_");
            mesano = mesano.Substring(3, 5);
            return mesano;
        }

        //FUNCAO QUE RETORNA O DIA E O MES
        public string diaemes()
        {
            string diames = DateTime.Now.ToString();
            diames = diames.Replace(@"/", @"-");
            diames = diames.Replace(@" ", @"_");
            diames = diames.Replace(@":", @"_");
            diames = diames.Substring(0, 5);
            return diames;
        }

        //FUNCAO QUE LE O ARQUIVO MSBANCO NA PASTA TEMP E ARMAZENA O CAMINHO DO BANCO DE DADOS
        public string pathBD()
        {
            string caminhobd;
            using (StreamReader sr = File.OpenText(@"TEMP/msbanco.dll")) 
            {
                caminhobd = sr.ReadToEnd();
                caminhobd = caminhobd.Trim();
            }
            return caminhobd;
        }

        //FUNCAO QUE PEGA O IP OU O NOME DA MAQUINA NO ARQUIVO MSBANCO NA PASTA TEMP
        public string getIP()
        {
            string ipbd = pathBD().Substring(0, pathBD().IndexOf(@":"));
            return ipbd;
        }

        //FUNCAO QUE PEGA O CAMINHO DO BANCO DE DADOS NO SERVIDOR
        public string getCaminho()
        {
            string caminhobd = pathBD().Substring(pathBD().IndexOf(@":") + 1, pathBD().Length - pathBD().IndexOf(@":") - 1);
            return caminhobd;
        }

        //FUNCAO QUE PEGA O CAMINHO DOS UTILITARIOS DO FIREBIRD
        public string getFirebirdpath()
        {
            bool arquivosdeprogramaencontrado = false;
            string path = "default";
            DirectoryInfo dinfos = new DirectoryInfo(@"C:");
            foreach (DirectoryInfo subdinfos in dinfos.GetDirectories())
            {
                if (arquivosdeprogramaencontrado == true)
                {
                    break;
                }
                else if (subdinfos.Name.Contains("Arquivos de Programas(x86)"))
                {
                    foreach (DirectoryInfo subdinfos2 in subdinfos.GetDirectories())
                    {
                        if (subdinfos2.Name.Contains("Firebird"))
                        {
                            path = subdinfos2.FullName + @"Firebird_2_5/bin/";
                            arquivosdeprogramaencontrado = true;
                        }
                    }
                }
                else if (subdinfos.Name.Contains("Arquivos de Programas"))
                {
                    foreach (DirectoryInfo subdinfos2 in subdinfos.GetDirectories())
                    {
                        if (subdinfos2.Name.Contains("Firebird"))
                        {
                            path = subdinfos2.FullName + @"Firebird_2_5/bin/";
                            arquivosdeprogramaencontrado = true;
                        }
                    }
                }
                else if (subdinfos.Name.Contains("Program Files(x86)"))
                {
                    foreach (DirectoryInfo subdinfos2 in subdinfos.GetDirectories())
                    {
                        if (subdinfos2.Name.Contains("Firebird"))
                        {
                            path = subdinfos2.FullName + @"Firebird_2_5/bin/";
                            arquivosdeprogramaencontrado = true;
                        }
                    }
                }
                else if (subdinfos.Name.Contains("Program Files"))
                {
                    foreach (DirectoryInfo subdinfos2 in subdinfos.GetDirectories())
                    {
                        if (subdinfos2.Name.Contains("Firebird"))
                        {
                            path = subdinfos2.FullName + @"Firebird_2_5/bin/";
                            arquivosdeprogramaencontrado = true;
                        }
                    }
                }
                else path = @"C:/Arquivos de Programas/Firebird/Firebird_2_5/bin/";
            }
            return path;
        }

    } 

}
