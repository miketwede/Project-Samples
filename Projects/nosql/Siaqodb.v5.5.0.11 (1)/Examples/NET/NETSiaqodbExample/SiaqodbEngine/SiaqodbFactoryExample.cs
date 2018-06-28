using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sqo;

namespace Example
{
    class SiaqodbFactoryExample
    {
        public static string siaoqodbPath;
        private static Siaqodb instance;


        public static Siaqodb GetInstance()
        {
            if (instance == null)
            {
                
                //comment the line bellow to use  Starter(free) edition
                //SiaqodbConfigurator.SetLicense(@"your license key");
                siaoqodbPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"siaqodb";
                if (!Directory.Exists(siaoqodbPath))
                {
                    Directory.CreateDirectory(siaoqodbPath);
                }
                instance = new Siaqodb(siaoqodbPath);
            }
            return instance;
        }
        public static void CloseDatabase()
        {
            if (instance != null)
            {
                instance.Close();
                instance = null;
            }
        }
    }
}
