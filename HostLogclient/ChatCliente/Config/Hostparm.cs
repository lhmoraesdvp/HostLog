using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using System.Xml.Linq;
namespace ChatCliente.Config
{
  public  class Hostparm
    {
        

        
      

// pega o nó GlobalDefinitions...


        public Hostparm()
        {
            bool ipserverr = false;
            while (xmlReader.Read())
            {

                switch (xmlReader.NodeType)
                {

                    case XmlNodeType.Element:
                       if (xmlReader.Name == "ipserver")
                {
                            ipserverr = true;

                }
                        break;
                    case XmlNodeType.Text:
                        if (ipserverr == true)
                        {
                            ipserver = xmlReader.Value;
                            ipserverr = false;
                        }
                     


                        break;

                }







        }

        }
      

       public XmlDocument xmldoc = new System.Xml.XmlDocument();


        XmlTextReader xmlReader = new XmlTextReader("C:\\hostlog\\config\\config.xml");

       

        public String ipserver { get; set; }
        public int cc { get; set; }
        public String regiao { get; set; }
        public string conectiontime { get; set; }
        public int hostdevice { get; set; }

    }
}
