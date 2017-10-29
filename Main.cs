﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    public class Main
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  
         **/

        private static String VERSION = "1.0.5";

        // Get version
        public static String getVersion()
        {
            return VERSION;
        }

        // Get lasted version
        public static String getLastedVersion()
        {
            try
            {
                return Web.downloadString("https://dl.dropboxusercontent.com/s/lt15uyw6ibnphg8/lastedVersion.txt?dl=0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
