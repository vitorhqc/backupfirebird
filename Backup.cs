using System;
using System.IO;
using System.Management;
using System.Diagnostics;
using BackupAutomatico;

namespace CodigoBackup
{
    //CLASSE COM OS METODOS QUE REALIZAM O BACKUP
    public class Backup
    {
        Infos infos = new Infos();

        public void BACKUP()
        {
            //TESTA SE O DIRETORIO DE BACKUP NAO EXISTE, SE NAO EXISTE ELE CRIA, SE EXISTE, SEGUE O BAILE
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP");
            }

            //TESTA SE O DIRETORIO DE BACKUP NIVEL ZERO NAO EXISTE, SE NAO EXISTE ELE CRIA, SE EXISTE, ELE VAI TESTAR
            //SE O DIRETORIO POSSUI ALGUM BACKUP NIVEL ZERO NELE, SE EXISTER O BACKUP, SEGUE O BAILE, SE NAO EXISTIR ELE FAZ O BACKUP
            //NIVEL ZERO
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano()))
            {
                CriaDiretorioMes();
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano());
            int i = 0;
            foreach (FileInfo diretorio in directoryInfo.GetFiles())
            {
                if (diretorio.Name.Contains("N0"))
                {
                    i = i + 1;
                }
            }

            //TESTE DE EXISTENCIA DO BACKUP NIVEL ZERO, SE i == 0 ENTAO NAO EXISTE NIVEL ZERO ENTAO ELE E FEITO
            if (i == 0)
            {
                FazerBackup("N0");
            }

            //SE EXISTE NIVEL ZERO ENTAO ELE TESTA A EXISTENCIA DA PASTA COM O DIA, SE NAO EXISTE A PASTA DO DIA
            //ELE CRIA A PASTA E JA REALIZA UM BACKUP NIVEL UM
            else if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano() + @"/" + infos.diaemes()))
            {
                CriaDiretorioDia();
                FazerBackup("N1");
            }

            //SE A PASTA EXISTE ELE TESTA A EXISTENCIA DE UM BACKUP NIVEL UM NA PASTA (TEORICAMENTE SE A PASTA EXISTE O BACKUP NIVEL UM
            // TAMBEM DEVERIA EXISTIR, MAS MESMO ASSIM TA AI O TESTE). SE NAO TIVER O BACKUP NIVEL UM ELE REALIZA O BACKUP NIVEL UM
            //SE EXISTIR O BACKUP NIVEL UM ELE REALIZA UM BACKUP NIVEL DOIS
            else
            {
                DirectoryInfo dirinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano() + @"/" + infos.diaemes());
                int x = 0;
                foreach (FileInfo diretorio in dirinfo.GetFiles())
                {
                    if (diretorio.Name.Contains("N1"))
                    {
                        x = x + 1;
                    }
                }
                if (x == 0)
                {
                    FazerBackup("N1");
                }
                else
                {
                    FazerBackup("N2");
                }
            }
            
        }

        //FUNCAO QUE CRIA O DIRETORIO DO MES E ANO QUE VAI RECEBER O BACKUP NIVEL ZERO EM SUA RAIZ 
        //E ONDE SERAO CRIADOS OS DIRETORIOS DE CADA DIA DO MES
        public string CriaDiretorioMes()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano());
            return ((AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano()).ToString() + @"/");
        }

        //FUNCAO QUE CRIA O DIRETORIO DO DIA DO MES QUE VAI RECEBER OS BACKUPS NIVEL UM E DOIS EM SUA RAIZ
        public string CriaDiretorioDia()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano() + @"/" + infos.diaemes());
            return ((AppDomain.CurrentDomain.BaseDirectory + @"SUPORTE/AUTOBKP/" + infos.meseano() + @"/" + infos.diaemes()).ToString() + @"/");
        }

        //FUNCAO QUE RECEBE AS INFORMACOES DE QUAL BACKUP DEVE SER USADO E ENVIA OS COMANDOS PARA O PROMPT DO WINDOWS PARA REALIZAR
        //O BACKUP. O CAMINHO DO FIREBIRD_2_5/BIN E NECESSARIO POIS, O FIREBIRD TEM O EXECUTAVEL NBACKUP QUE E RESPONSAVEL
        //POR REALIZAR O BACKUP. PORTANTO O PROMPT DEVE SER DIRECIONADO PRA DENTRO DESSA PASTA E DEPOIS RODAR OS COMANDOS
        public void FazerBackup(string nivelbkp)
        {
            string comando;
            string pathBKP;
            if (nivelbkp == "N0")
            {
                pathBKP = string.Format("{0}{1}{2}", CriaDiretorioMes(), "msbanco" + nivelbkp, infos.Datahoranow() + @".nbk");
            }

            else
            {
                pathBKP = string.Format("{0}{1}{2}", CriaDiretorioDia(), "msbanco" + nivelbkp, infos.Datahoranow() + @".nbk");
            }
            ProcessStartInfo promptlines = new ProcessStartInfo();

            comando = string.Format(@"/C cd {3} & nbackup -U SYSDBA -P masterkey -B {0} {1} {2}", nivelbkp[1], infos.getCaminho(), pathBKP, infos.getFirebirdpath());
            promptlines.Arguments = comando;
            promptlines.FileName = "CMD.exe";
            //promptlines.UseShellExecute = true;
            //promptlines.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(promptlines);
        }

    }
}