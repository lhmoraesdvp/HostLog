using System.Windows.Forms;
using System.Net;
using System;

namespace ChatServidor
{
    public partial class Form1 : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);

        public Form1()
        {
            InitializeComponent();
            ip = Dns.GetHostAddresses(Dns.GetHostName());
            try
            {
              
                string hostip = ip[3].ToString();
                txtIP.Text = hostip;
            }catch(Exception ex)
            {
                string hostip = ip[1].ToString();
                txtIP.Text = hostip;
            }
          
        }

        IPAddress[] ip;
        private void btnAtender_Click(object sender, System.EventArgs e)
        {
          

            if (txtIP.Text==string.Empty)
            {
                MessageBox.Show("Informe o endereço IP.");
                txtIP.Focus();
                return;
            }

            try
            {

                // Analisa o endereço IP do servidor informado no textbox
                IPAddress enderecoIP = IPAddress.Parse(txtIP.Text);

                // Cria uma nova instância do objeto ChatServidor
                HostLogserver mainServidor = new HostLogserver(enderecoIP);

                // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                HostLogserver.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                // Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                // Mostra que nos iniciamos o atendimento para conexões
                txtLog.AppendText("Monitorando as conexões...\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão : " + ex.Message);
            }
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Chama o método que atualiza o formulário
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            txtLog.AppendText(strMensagem + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
