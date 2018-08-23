using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using System.Diagnostics;

using System.Xml.Linq;
namespace ChatCliente.Config
{
  public  class Hostparm
    {
        

        
      

// pega o nó GlobalDefinitions...


        public Hostparm()
        {
            bool ipserverr = false;
            bool centro = false;
            bool cidd = false;
            bool ccentro = false;
            bool disp = false;
            bool dip = false;

            while (xmlReader.Read())
            {

                switch (xmlReader.NodeType)
                {

                    case XmlNodeType.Element:
                       if (xmlReader.Name == "ipserver")
                {
                            ipserverr = true;

                }
                        if (xmlReader.Name == "centro")
                        {
                            centro= true;

                        }
                        if (xmlReader.Name == "ccentro")
                        {
                            centro = true;

                        }
                        if (xmlReader.Name == "cid")
                        {
                            cidd = true;

                        }
                        if (xmlReader.Name == "disp")
                        {
                            disp = true;

                        }
                        if (xmlReader.Name == "dip")
                        {
                            dip = true;

                        }
                        break;
                    case XmlNodeType.Text:
                        if (ipserverr == true)
                        {
                            ipserver = xmlReader.Value;
                            ipserverr = false;
                        }
                        if (cidd== true)
                        {
                            cid = Convert.ToInt32( xmlReader.Value);
                           cidd = false;
                        }
                        if (ccentro== true)
                        {
                            listcentro.Add(xmlReader.Value);
                            listcentro.Add("-");
                            ccentro = false;
                        }
                        if (disp == true)
                        {
                           dispositivos.Add(xmlReader.Value);
                        
                            disp = false;
                        }
                        if (dip == true)
                        {
                            dispositivos.Add(xmlReader.Value);
                            dispositivo = xmlReader.Value;
                       
                            dip = false;
                        }
                        if (centro == true)
                        {
                            try
                            {
                                cc = Convert.ToInt32(xmlReader.Value);
                                listcentro.Add(xmlReader.Value);
                                centro = false;

                            }catch(Exception ex)
                            {

                                Thread.Sleep(10000);
                                System.Diagnostics.Process pr = new Process();
                                pr.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                pr.StartInfo.UseShellExecute = false;
                                pr.StartInfo.CreateNoWindow = true;
                                pr.StartInfo.FileName = "cmd.exe";
                                pr.StartInfo.Arguments = "/C start C:\\hostlog\\config\\stop.exe";

                                pr.Start();

                            }

                        }


                        break;

                
                        
                    

                }







        }

        }
      

       public XmlDocument xmldoc = new System.Xml.XmlDocument();


        XmlTextReader xmlReader = new XmlTextReader("C:\\hostlog\\config\\config.xml");

       

        public String ipserver { get; set; }
        public int cc { get; set; }
        public int cid { get; set; }
        public String regiao { get; set; }
        public string conectiontime { get; set; }
        public int hostdevice { get; set; }
        public string dispositivo { get; set; }
        public List<string> listcentro = new List<string>();
        public List<string> dispositivos = new List<string>();
    }
}
