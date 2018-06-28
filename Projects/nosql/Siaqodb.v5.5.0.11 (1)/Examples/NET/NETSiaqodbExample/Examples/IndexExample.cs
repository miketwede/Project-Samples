using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo.Attributes;
using Sqo;

namespace Example
{
    class IndexExample : BaseExample, IExample
    {
        public void Run()
        {

            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            siaqodb.DropType<ClassWithIndex>();//all objects of this Type will be deleted from database
             var transaction = siaqodb.BeginTransaction();
            try
            {
               
                for (int i = 0; i < 100; i++)
                {
                    ClassWithIndex myobj = new ClassWithIndex() { MyID = i % 10, Name = "MyTest" + i.ToString() };

                    siaqodb.StoreObject(myobj, transaction);
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            
            DateTime start = DateTime.Now;
            var q = from ClassWithIndex myobj in siaqodb
                    where myobj.MyID == 8//index will be used, so very fast retrieve from DB
                    select myobj;
            int k = 0;
            foreach (ClassWithIndex obj in q)
            { 
                //do something with object
                k++;
            }
            string timeElapsed = (DateTime.Now - start).ToString();

            Log("Time elapsed to load:" + k.ToString() + " objects from 10000 stored objects filtered by index:" + timeElapsed);
        }

       
    }
    class ClassWithIndex
    {
        //values for this property are managed automatically by Siaqodb(it is autoincremented)
        //see more about OID:http://siaqodb.com/?page_id=582
        public int OID { get; set; }

        [Index]
        public int MyID { get; set; }

        public string Name { get; set; }
    }
}
