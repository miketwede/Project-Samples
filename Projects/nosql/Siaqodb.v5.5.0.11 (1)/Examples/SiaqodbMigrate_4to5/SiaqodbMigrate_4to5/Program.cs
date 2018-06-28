using Sqo;
using Sqo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaqodbMigrate_4to5
{
    class Program
    {
        static void Main(string[] args)
        {
            //in the folder ..\..\database\ there it is saved Company objects with Siaqodb 4.X
            //Now we'll migrate those objects to Siaqodb 5.0
            Sqo.Siaqodb siaqodb5 = new Sqo.Siaqodb(@"..\..\database\");
            siaqodb5.DropType<Company>();

            SiaqodbUtil.Migrate(siaqodb5);


            var all5 = siaqodb5.LoadAll<Company>();
            if (all5.Count == 10)
            {
                Console.WriteLine("All objects are migrated to Siaqodb 5.0 database.");
                
            }
            else
            {
                Console.WriteLine("Something wrong with the migration process or you imported twice or more.");
            }
            siaqodb5.Close();

            //you can still see Siaqodb 4.X objects by using Dotissi namespace
            //This is just for backward compatibility, it should not be used for other scopes
            Dotissi.Siaqodb siaqodb4 = new Dotissi.Siaqodb(@"..\..\database\");
           
            var all4 = siaqodb4.LoadAll<Company>();
            if (all4.Count == 10)
            {
                Console.WriteLine("All objects of Siaqodb 4.X are still here... ");

            }
            else
            {
                Console.WriteLine("Something wrong and Siaqodb4.X objects cannot be find anymore.");
            }
            Console.ReadLine();
        }
    }
    public class Company
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
