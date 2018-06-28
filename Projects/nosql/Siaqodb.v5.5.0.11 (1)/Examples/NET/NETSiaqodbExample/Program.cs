using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Sqo;

namespace Example
{
    class Program
    {
       
        static void Main(string[] args)
        {

            SiaqodbConfigurator.VerboseLevel = VerboseLevel.Warn;
            SiaqodbConfigurator.LoggingMethod = LogWarns;

            IList<IExample> examples = ExamplesBuilder.GetExamples(WriteToConsole);
            foreach (IExample example in examples)
            {
                WriteToConsole("Start example:" + example.GetType().Name + "...");
                example.Run();
                WriteToConsole("End example:" + example.GetType().Name + "...");
                WriteToConsole("----------------------------------------------");
                
            }
            WriteToConsole("Examples run finished,press Enter to continue...");
            SiaqodbFactoryExample.CloseDatabase();
            Console.ReadLine();


        }
        public static void WriteToConsole(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void LogWarns(string log, VerboseLevel level)
        {
            Debug.WriteLine(level.ToString() + ":$" + log);
        }
       
    }
    
}
