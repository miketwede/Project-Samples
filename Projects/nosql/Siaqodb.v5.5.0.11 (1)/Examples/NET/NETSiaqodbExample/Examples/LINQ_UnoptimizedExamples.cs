using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.DataObjects;
using Sqo;

namespace Example
{
    class LINQ_UnoptimizedExamples : BaseExample, IExample
    {
        

        public void Run()
        {
            //there are cases when queries cannot be optimized by Siaqodb engine
            //and in this case, query still runs correct, but all objects of queried Type are loaded in memory and there it is applied LINQ to objects
            this.Where_UnoptimizedUsingStringMethods();
            this.Where_UnoptimizedUsingLocalMethod();
            this.Where_UnoptimizedUsingUnaryOperator();
        }
        public void Where_UnoptimizedUsingStringMethods()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            //this query run Unoptimized, problem is Length property of String
            //siaqodb can only handle optimized following String methods:StartsWith,EndsWith and Contains
            //all other String methods/properties for object members result in a unoptimized query
            var query = from Company c in siaqodb
                        where c.Phone.Length == 3
                        select c;
            //now all Company objects are loaded from database and query fall in LINQ to objects
            foreach (Company c in query)
            { 
                //do something with c
            }
            // !!! Important: if those String methods are used for a local variable and NOT to a member of a stored object
            //query run optimized so:
            string d = "test";
            var queryOptimized = from Company c in siaqodb
                                    where c.Name == d.Substring(2)
                                    select c;

            //the above query run optimized 
            foreach (Company c in queryOptimized)
            {
                //do something with c
            }


        }
        public int TestMet(int t)
        {
            return t + 1;
        }
        public void Where_UnoptimizedUsingLocalMethod()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            //this query run Unoptimized, problem is TestMet method that get a member of a storable object
            //as argument
            var query = from Employee e in siaqodb
                        where TestMet(e.Age) == 30
                        select e;
            //now all Employee objects are loaded from database and query fall in LINQ to objects
            foreach (Employee e in query)
            {
                //do something with e
            }
            //!!! Important: queries that use Methods that are called with arguments that ARE NOT members of stored objects run Optmized
            //next query run optimized
            var queryOptimized = from Employee e in siaqodb
                        where e.Age == TestMet(30)
                        select e;
            foreach (Employee e in queryOptimized)
            {
                //do something with e
            }

            
        }
        public void Where_UnoptimizedUsingUnaryOperator()
        {

            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            for (int i = 0; i < 10; i++)
            {
                BoolAndIntExample e = new BoolAndIntExample() { SomeBool = i % 2 == 0, SomeInt = i };
                siaqodb.StoreObject(e);
            }

            //this query run Unoptimized, problem is !(Not) operator 
            var query = from BoolAndIntExample e in siaqodb
                        where e.SomeInt>5 && !e.SomeBool
                        select e;
            //now all Employee objects are loaded from database and query fall in LINQ to objects
            foreach (BoolAndIntExample e in query)
            {
                //do something with e
            }

            //to optimize query above, just use Equal operator:
            var queryOptimized = from BoolAndIntExample e in siaqodb
                        where e.SomeInt > 5 && e.SomeBool==false
                        select e;

            foreach (BoolAndIntExample e in query)
            {
                //do something with e
            }
        }

        class BoolAndIntExample
        {
            public int OID { get; set; }
            
            public int SomeInt { get; set; }
            public bool SomeBool { get; set; }
        }
       
    }
}
