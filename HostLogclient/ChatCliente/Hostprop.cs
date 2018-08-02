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
namespace ChatCliente
{
    public class Hostprop
    {
        string User = SystemInformation.UserName;
        string Domain = SystemInformation.UserDomainName;
        IPAddress[] ip;
        string winnt = "";

        //---------------------------
        public string hostname = "";
        public string hostuser = "";
        public string hostmac = "";
        public string hostip = "";
        public string hostserial = "";
        public string hostso = "";
        public string hostprocessador = "";
        public string hosthdmemory = "";
        public string hosthdmermoryfree = "";
        public string hostram = "";
        //----------------------------------
        public Hostprop()
        {
            winnt = GetWindowsVersion().ToString();
            //----------------------
            getip();
            getmac();
            getserial();
            hostprocessador = getprocessador();
            hostname = SystemInformation.ComputerName;
            hostuser = Domain + "\\" + User;
            hostso = winversion(winnt);
            hosthdmemory = gethdtotal();
            hosthdmermoryfree = gethdlivre();
            hostram = getram();

            //---------------------------------
        }
        private static string getram()
        {
            ManagementObjectSearcher s4 = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");

            string resp = "0";
            foreach (ManagementObject mo in s4.Get())
                resp = Convert.ToString(mo["Capacity"]);

            double memoriaRam = Convert.ToDouble(resp);
            decimal memoriaRamTotal = Convert.ToDecimal(memoriaRam / 1024 / 1024 / 1024);
            return memoriaRamTotal.ToString() + "  GB";
        }
        private static string gethdlivre()
        {

            string ret = "Não localizado";
            ObjectQuery Query = new ObjectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {

                long freeSpace = Convert.ToInt64(WniPART["FreeSpace"]) / 1024 / 1024 / 1024;



                ret = freeSpace.ToString() + " - GB";


            }

            return ret;

        }
        private static string gethdtotal()
        {
            string ret = "Não localizado";
            ObjectQuery Query = new ObjectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {

                long size = Convert.ToInt64(WniPART["Size"]) / 1024 / 1024 / 1024;



                ret = size.ToString() + " - GB";


            }

            return ret;
        }
        public string getprocessador()
        {
            string ret = "Não Localizado";
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            foreach (ManagementObject mo in s2.Get())
            {

                ret = ("" + mo["Name"]).ToString();

            }
            return ret;

        }
        public string getserial()
        {



            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM  Win32_BaseBoard");

            foreach (ManagementObject objManagemnet in objMOS.Get())
            {
                try
                {


                    hostserial = objManagemnet.GetPropertyValue("SerialNumber").ToString();

                }
                catch (Exception ex)
                {
                    hostserial = "Não localizado";
                }
            }

            return hostserial;
        }
        public string getmac()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String enderecoMAC = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    // retorna endereço MAC do primeiro cartão
                    if (enderecoMAC == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        enderecoMAC = adapter.GetPhysicalAddress().ToString();
                    }
                }
                hostmac = enderecoMAC;
                return hostmac;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private WindowsVersion GetWindowsVersion()
        {
            Version winVersion = Environment.OSVersion.Version;
            switch (winVersion.Major)
            {
                case 1:
                    return WindowsVersion.Windows_1_01;
                case 2:
                    switch (winVersion.Minor)
                    {
                        case 3:
                            return WindowsVersion.Windows_2_03;
                        case 10:
                            return WindowsVersion.Windows_2_10;
                        case 11:
                            return WindowsVersion.Windows_2_11;
                        default:
                            return WindowsVersion.None;
                    }
                case 3:
                    switch (winVersion.Minor)
                    {
                        case 0:
                            return WindowsVersion.Windows_3_0;
                        case 1:
                            return WindowsVersion.Windows_for_Workgroups_3_1;
                        case 2:
                            return WindowsVersion.Windows_3_2;
                        case 5:
                            return WindowsVersion.Windows_NT_3_5;
                        case 11:
                            return WindowsVersion.Windows_for_Workgroups_3_11;
                        case 51:
                            return WindowsVersion.Windows_NT_3_51;
                        default:
                            return WindowsVersion.None;
                    }
                case 4:
                    switch (winVersion.Minor)
                    {
                        case 0:
                            switch (winVersion.Build)
                            {
                                case 950:
                                    return WindowsVersion.Windows_95;
                                case 1381:
                                    return WindowsVersion.Windows_NT_4_0;
                                default:
                                    return WindowsVersion.None;
                            }
                        case 10:
                            switch (winVersion.Build)
                            {
                                case 1998:
                                    return WindowsVersion.Windows_98;
                                case 2222:
                                    return WindowsVersion.Windows_98_SE;
                                default:
                                    return WindowsVersion.None;
                            }
                        case 90:
                            return WindowsVersion.Windows_Me;
                        default:
                            return WindowsVersion.None;
                    }
                case 5:
                    switch (winVersion.Minor)
                    {
                        case 0:
                            return WindowsVersion.Windows_2000;
                        case 1:
                            return WindowsVersion.Windows_XP;
                        case 2:
                            return WindowsVersion.Windows_Server_2003;
                        default:
                            return WindowsVersion.None;
                    }
                case 6:
                    switch (winVersion.Minor)
                    {
                        case 0:
                            return WindowsVersion.Windows_Vista;
                        case 1:
                            return WindowsVersion.Windows_7;
                        case 2:
                            if (winVersion.Build.ToString() == "9200")
                            {
                                return WindowsVersion.Windows_10;
                            }
                            else
                            {
                                return WindowsVersion.Windows_8;
                            }

                        default:
                            return WindowsVersion.None;
                    }
                default:
                    return WindowsVersion.None;
            }



        }
        public string winversion(string v)
        {

            string vi = "";

            for (int i = 0; i < v.Count(); i++)
            {
                if (v[i] != '_')
                {
                    vi = vi + v[i];
                }
                else
                {
                    vi = vi + " ";
                }
            }
            return vi;

        }
        public void getip()
        {
            ip = Dns.GetHostAddresses(Dns.GetHostName()); ;
            if (ip != null)
            {
                hostip = ip[3].ToString();
            }
        }
        public enum WindowsVersion
        {
            None = 0,
            Windows_1_01,
            Windows_2_03,
            Windows_2_10,
            Windows_2_11,
            Windows_3_0,
            Windows_for_Workgroups_3_1,
            Windows_for_Workgroups_3_11,
            Windows_3_2,
            Windows_NT_3_5,
            Windows_NT_3_51,
            Windows_95,
            Windows_NT_4_0,
            Windows_98,
            Windows_98_SE,
            Windows_2000,
            Windows_Me,
            Windows_XP,
            Windows_Server_2003,
            Windows_Vista,
            Windows_Home_Server,
            Windows_7,
            Windows_8,
            Windows_10,
        }

    }
}




