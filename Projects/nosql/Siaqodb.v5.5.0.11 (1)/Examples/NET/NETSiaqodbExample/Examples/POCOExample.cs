using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;

namespace Example
{
    class POCOExample : BaseExample, IExample
    {

        public void Run()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            siaqodb.DropType<POCOSimple>();

            //define an Index in POCO way (not by an attribute)
            SiaqodbConfigurator.AddIndex("ID", typeof(POCOSimple));

            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            for (int i = 0; i < 100; i++)
            {
                POCOSimple ps = new POCOSimple();

                if (i % 2 == 0)
                {
                    ps.ID = id1;
                }
                else { ps.ID = id2; }

                siaqodb.StoreObject(ps);
            }

            DateTime start = DateTime.Now;

            var q = from POCOSimple ps in siaqodb
                    where ps.ID==id1
                    select ps;
            int k = 0;
            foreach (POCOSimple pocoSimple in q)
            {
                //do something with object    
                k++;
            }

            string timeElapsed = (DateTime.Now - start).ToString();
            Log("Time elapsed to get:" + k.ToString() + " objects by index filtered, is:" + timeElapsed);
            

        }

    }
    /// <summary>
    /// Siaqodb version 3.6+ can store POCO objects( not need anymore to have OID or to implement ISqoDataObject or inherit from SqoDataObject - all are optional now)
    /// </summary>
    public class POCOSimple
    {
       

        public Guid ID { get; set; }

        public string Name { get; set; }

    }
    
}
