using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;

namespace WolfLib
{
    public static class Hardware
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  WebSite:
         *  http://towolf.livehost.fr/wolflib/
         *  
         **/




        // Yes, it's not hardware... But........
        public static String GetMACAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                String MACAddress = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    if (MACAddress == String.Empty)
                    {
                        if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }
                MACAddress = MACAddress.Replace(":", "");
                return MACAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        public static String GetProcessorId()
        {
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
                String Id = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    Id = mo.Properties["processorID"].Value.ToString();
                    break;
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetHDDSerialNumber()
        {
            try
            {
                ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection mcol = mangnmt.GetInstances();
                String result = "";
                foreach (ManagementObject strt in mcol)
                {
                    result += Convert.ToString(strt["VolumeSerialNumber"]);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetBoardMaker()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                return "Unknown";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Double GetRAM()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    double dblMemory;
                    if (double.TryParse(Convert.ToString(queryObj["TotalPhysicalMemory"]), out dblMemory))
                    {
                        return dblMemory / (1024 * 1024 * 1024);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
