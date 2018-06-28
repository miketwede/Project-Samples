using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortableDataLayer.Entities;
using Sqo;

namespace PortableDataLayer
{
    public class DatabaseManager
    {
        ISiaqodb siaqodb;
        public DatabaseManager(ISiaqodb siaqodb)
        {
            this.siaqodb = siaqodb;
        }
        public static Configurator GetDefaultConfig()
        {
            Configurator config = new Configurator();
           //uncomment line bellow to set a license

           // config.SetLicense(@"put your license key(trial or definitive) here");
            return config;
        }
        public void Run()
        {
            //clear all objects of Type Company created by previous run of this example
            siaqodb.DropType<Company>();
            Insert();
            LoadAndUpdate();
            Delete();


        }


        private void Insert()
        {
            Company company = CreateCompany("FirstCompany");
            siaqodb.StoreObject(company);

            Company company2 = CreateCompany("SecondCompany");
            siaqodb.StoreObject(company2);



        }

        private void LoadAndUpdate()
        {

            var query = from Company comp in siaqodb
                        where comp.Name.StartsWith("First")
                        select comp;
           //Following companies has name that starts with 'First' string
            foreach (var e in query)
            {
                e.Address = "Address changed";
                siaqodb.StoreObject(e);//update will occur
            }
            siaqodb.Flush();

            //load all objects of type Company from DB
            IObjectList<Company> allCompanies = siaqodb.LoadAll<Company>();
            foreach (Company comp in allCompanies)
            {
                //see address of FirstCompany is updated
            }

        }
        private void Delete()
        {

            IObjectList<Company> allCompanies = siaqodb.LoadAll<Company>();

            //delete object in database( in memory will still be available until GC will take it)
            siaqodb.Delete(allCompanies[0]);

            int count = siaqodb.Count<Company>();

        }
        private Company CreateCompany(string companyName)
        {
            Company company = new Company();
            company.Name = companyName;
            company.Phone = "233-204-235";
            company.Address = "Street of SimpleCompany, nr.1";
            return company;
        }

    }

}
