using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using ChatCliente.Config;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
namespace ChatCliente
{
    public partial class frmCliente : Form
    {
        int sh = 0;
        String caminho = AppDomain.CurrentDomain.BaseDirectory;
        // Trata o nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
    
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private delegate void sho();
        private Thread mensagemThread;
        private Thread tt;
        private IPAddress enderecoIP;
        private bool Conectado;
        System.Threading.Timer timer1;
   public     Conn conection = new Conn();
        public frmCliente()
        {
           // Na saida da aplicação : desconectar

           InitializeComponent();
            conection.InicializaConexao();
            InicializaConexao();
         


        }
    


        private void InicializaConexao()
        {
            try
            {
           
              

                // AJuda a verificar se estamos conectados ou não
                Conectado = true;

                // Prepara o formulário
           

                // Desabilita e habilita os campos apropriados
            
   
       
             

                // Envia o nome do usuário ao servidor
            
             

                //Inicia a thread para receber mensagens e nova comunicação
                mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
                mensagemThread.Start();
                timer1 = new System.Threading.Timer(new TimerCallback(timer1_Tick), null, 5000, 30000);
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Erro : " + ex.Message, "Erro na conexão com servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread.Sleep(100800);

            }
        }


        private void timer1_Tick(object sender)
        {
            conection.comunica();
        }

        private void RecebeMensagens()
        {
            try
            {








                // recebe a resposta do servidor
                strReceptor = new StreamReader(conection.tcpServidor.GetStream());
                string ConResposta = strReceptor.ReadLine();
                // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
                if (ConResposta[0] == '1')
                {
                    // Atualiza o formulário para informar que esta conectado
                    // this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
                }
                else // Se o primeiro caractere não for 1 a conexão falhou
                {
                    string Motivo = "Não Conectado: ";
                    // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                    Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                    // Atualiza o formulário como o motivo da falha na conexão

                    // Sai do método
                    return;
                }


            }
            catch (Exception ex)
            {
                Thread.Sleep(100800);
                RecebeMensagens();

            }



            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // exibe mensagems no Textbox
                try
                {


                    sh = 1;
                    string msg = strReceptor.ReadLine();

                    string u = conection.GetHostprop().getmac();
                    if (captusuario(msg) == u)
                    {
                        string mg = caputramensagem(msg);
                        if (mg[1] == '#' && mg[2] == '#')
                        {
                            conection.txtset(attstring(mg));
                        }


                    }
                    this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { msg });

                }
                catch (Exception ex)
                {
                  
                   
                  
                    Thread.Sleep(10000);
                    string c = "/C start C:\\hostlog\\config\\restart.bat";
                    Process.Start("cmd.exe", c);
                    this.Close();



                }


            }
        }

        public string captusuario(string s)

        { 
            string ret = "";
            int i = 0;
            do
            {

                ret = ret + s[i];
                i++;
            } while (s[i] != '!');


            return ret;

        }
        public string caputramensagem(string s)
        {
          Boolean mesagem = false;
            string ret = "";
            for(int i = 0; i < s.Count(); i++)
            {
                if (s[i] == '!')
                {
                    Boolean menssagem = true;
                }
                if (mesagem == true)
                {
                    ret = ret + s[i];
                }
            

            }


            return ret;


        }
        List<string> attstring (string s)
        {
            List<string> rets = new List<string>();
            string ss = "";
            int i = 2;
            do
            {
                do
                {
                    ss = ss + s[i];
                    i++;

                } while (s[i] != '!');
                i++;
                ss = ss + '!';
                do
                {
                    ss = ss + s[i];
                    i++;

                } while (s[i] != '*');
                i++;
                ss = ss + '!';
                rets.Add(ss);
            } while (i < s.Count());
            return rets;
        }


        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            sh = 1;
         
            txtLog.AppendText(strMensagem + "\r\n");
        }
        public void shi()
        {
            this.Show();
        }
        private void btnEnviar_Click(object sender, System.EventArgs e)
        {
        
        }

 

        // Fecha a conexão com o servidor




        private void frmCliente_Paint(object sender, PaintEventArgs e)
        {
          
            if (sh == 0)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


           
                sh = 0;
                this.Hide();
            }
            catch (Exception ex)
            {
          


            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sh =1;
            this.Show();
        }

        private void frmCliente_ParentChanged(object sender, EventArgs e)
        {

        }

        private void minizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sh = 0;
            this.Hide();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Text = "Reconectando...";
            mensagemThread.Abort();
            Thread.Sleep(1000);
            this.Show();
            string cm = "/C start C:\\hostlog\\config\\stop.bat";
            Process.Start("cmd.exe", cm);
            this.Close();
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Thread.Sleep(1000);
            this.Show();
            string cm = "/C start C:\\hostlog\\config\\restart.bat";
            Process.Start("cmd.exe", cm);
            this.Close();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cm = "/C C:\\hostlog\\config\\config.xml";
            Process.Start("cmd.exe", cm);

        }
    }
}
