using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Linq;
using ChatCliente.Config;

namespace ChatCliente
{
    public class Conn
    {
        StreamWriter writertxt;
        public IPAddress enderecoIP;
        public TcpClient tcpServidor;
        public StreamWriter stwEnviador;
        Hostprop hostprop = new Hostprop();
        public Boolean Conectado = false;
        public Hostprop GetHostprop()
        {
            return hostprop;
        }
        public void InicializaConexao()
        {
            try
            {
                // Trata o endereço IP informado em um objeto IPAdress
                enderecoIP = IPAddress.Parse(hostprop.hostip);
                MessageBox.Show(enderecoIP.ToString());
                // Inicia uma nova conexão TCP com o servidor chat
                tcpServidor = new TcpClient();
                tcpServidor.Connect(enderecoIP, 2502);

                // AJuda a verificar se estamos conectados ou não
                Conectado = true;




                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(hostprop.hostmac);
                stwEnviador.Flush();






            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro na conexão com servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void txtset(List<string> cc)
        {
            
            writertxt = new StreamWriter("C:\\hostlog\\config\\config.xml");
            writertxt.Write("<xml>");
            writertxt.WriteLine("<ccs>");
            for (int i = 0; i < cc.Count(); i++)
            {
                string icc = "";
                string ccname = "";
                int j = 0;
                do {

                    icc = icc + cc[i][j];
                    j++;
                } while (cc[i][j] != '!');
                j++;
                writertxt.WriteLine("<cc>");
                writertxt.WriteLine("<ccid>"+icc +"</ccid>");
              
                do
                {
                    ccname = ccname + cc[i][j];
                    j++;
                } while (cc[i][j] != '!');
                j++;
                writertxt.WriteLine("<ccname>" +ccname+"</ccname");
                writertxt.WriteLine("</cc>");

            }

            writertxt.Write("</xml>");
            writertxt.Flush();

        }

        public void FechaConexao()
        {

            // Habilita e desabilita os controles apropriados no formulario


            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            tcpServidor.Close();
        }




        public void comunica()
        {


            string data = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToLongTimeString();
            if (Conectado == true)
            {


                stwEnviador.WriteLine(hostprop.hostname + "!!" + hostprop.hostip + "!!" + "1" + "!!" + hostprop.hostso + "!!" + data + "!!" + hostprop.hostuser + "!!" + hostprop.hostserial + "!!" + hostprop.hosthdmemory + "!!" + hostprop.hosthdmermoryfree + "!!" + hostprop.hostram + "!!" + hostprop.hostprocessador + "core" + "!!" + "SP" + "!!" + hostprop.hostmac + "!!" + "BR" + "!!" + "4" + "!!");
                stwEnviador.Flush();
            }
        }
    }
}
;



