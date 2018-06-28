using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;
using System.IO;

namespace Siaqodb_PCL_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SiaqodbConfigurator.ApplyConfigurator( PortableDataLayer.DatabaseManager.GetDefaultConfig());

            string siaoqodbPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"siaqodb";
            if (!Directory.Exists(siaoqodbPath))
            {
                Directory.CreateDirectory(siaoqodbPath);
            }
            using (Siaqodb siaqodb = new Siaqodb(siaoqodbPath))
            {

                PortableDataLayer.DatabaseManager dbmanager = new PortableDataLayer.DatabaseManager(siaqodb);
                dbmanager.Run();
            }
            Console.WriteLine("Done, press enter...");
            Console.ReadLine();

        }
    }
}
