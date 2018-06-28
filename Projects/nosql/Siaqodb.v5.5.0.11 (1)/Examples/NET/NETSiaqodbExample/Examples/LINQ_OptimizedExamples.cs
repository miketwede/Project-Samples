using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;
using Example.DataObjects;

namespace Example
{
    class LINQ_OptimizedExamples : BaseExample, IExample
    {
        //siaqodb engine can optimize queries to database for following Extension methods:
        //Any<T>(…)
        //Count<T>(…)
        //First<T>(…)
        //FirstOrDefault<T>(…)
        //Last<T>(…)
        //LastOrDefault(…)
        //Single<T>(…)
        //SingleOrDefault(…)
        //Take<T>(…)
        //Skip<T>(…)
        //Where<T>(…)

        public void Run()
        {
            this.Select();
            this.SelectOnlySomeProperties();
            this.Any();
            this.Count();
            this.First();
            this.FirstOrDefault();
            this.Last();
            this.LastOrDefault();
            this.Single();
            this.SingleOrDefault();
            this.Where();

            this.PaginationWith_Skip_Take();
            
        }
        public void Select()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            for (int i = 0; i < 30; i++)
            {
                Developer deve = new Developer() { Age = 18 + i, FirstName = "Devo" + i.ToString(), LastName = "None" };
                siaqodb.StoreObject(deve);
            }
            var query = from Company c in siaqodb
                        select c;
            //same query written using lambda expression arguments
            var q2 = siaqodb.Query<Company>().Select(c => c);

            foreach (Company c in query)
            { 
                //do something with c object
            }
        }
        public void SelectOnlySomeProperties()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            
            //the query will NOT create any Company objects,
            //it will read ONLY that 2 properties values and anonymous Type will be created with that values
            //so query is optimal
            var query = from Company c in siaqodb
                        select new { Name=c.Name,Phone=c.Phone};

            //same query written using lambda expression arguments
            var q2 = siaqodb.Query<Company>().Select(c => new { Name=c.Name,Phone=c.Phone});

            foreach (var c in query)
            {
                //do something with c object
            }
        }
        public void Where()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            //this query run optimized-> only Developers objects will be created that match the condition
            //it does not matter how complex your WHERE is, it will run OPTIMIZED except some cases: see LINQ_UnOptimizedExamples
            var query = from Developer emp in siaqodb
                        where emp.Age > 20 && emp.HireDate < new DateTime(2008, 1, 1)
                        select emp;

            //same query written in other way using lambda expression arguments
            var q2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20 && emp.HireDate < new DateTime(2008, 1, 1));

            foreach (Developer c in query)
            {
                //do something with c object
            }
        }
        public void First()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            try
            {
                //this query run optimized-> only first Developer object will be created and read from database that match the condition,otherwise InvalidOperationException is thrown
                Developer first = (from Developer emp in siaqodb
                                  where emp.Age > 20
                                  select emp).First();

                //same query written in other way using lambda expression arguments
                Developer first2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).First();

                // or similar-> also run optimized:
                Developer first3 = siaqodb.Query<Developer>().First(emp => emp.Age > 20);
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }

        }
        public void FirstOrDefault()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            //this query run optimized-> only first Developer object will be created and read from database that match the condition
            Developer first = (from Developer emp in siaqodb
                         where emp.Age > 20
                         select emp).FirstOrDefault();  

            //same query written in other way using lambda expression arguments
            Developer first2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20 ).FirstOrDefault();
            
            // or similar-> also run optimized:
            Developer first3 = siaqodb.Query<Developer>().FirstOrDefault(emp => emp.Age > 20);
            
          
        }
        public void Count()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            // to count all objects stored in db of a certain Type:
            int nrObjects = siaqodb.Count<Developer>();

            //count all objects that match a condition
            //-> will run optimized, so NO object is created, the engine only counts objects stored
            int nrObjects2 = (from Developer e in siaqodb
                             where e.Age > 20
                             select e).Count();

            //same query written in other way using lambda expression arguments
            int nrObjects3 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).Count();

            //similar query->same result -> also optimized
            int nrObjects4 = siaqodb.Query<Developer>().Count(emp => emp.Age > 20);

        }
        public void Any()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            //check if exists at least one object that match the condition
            //run optimized-> create only first fetched object if exists
            bool exists = (from Developer e in siaqodb
                           where e.Age > 20
                           select e).Any();
           
            //same query written in other way using lambda expression arguments
            bool exists2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).Any();
            
            //similar query->same result -> also optimized
            bool exists3 = siaqodb.Query<Developer>().Any(emp => emp.Age > 20);
        }
        public void Last()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            try
            {
                //this query run optimized-> only last Developer object will be created and read from database that match the condition,otherwise InvalidOperationException is thrown
                Developer last = (from Developer emp in siaqodb
                                  where emp.Age > 20
                                  select emp).Last();

                //same query written in other way using lambda expression arguments
                Developer last2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).Last();

                // or similar-> also run optimized:
                Developer last3 = siaqodb.Query<Developer>().Last(emp => emp.Age > 20);
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }
        }
        public void LastOrDefault()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();


            //this query run optimized-> only last Developer object will be created and read from database that match the condition
            Developer last = (from Developer emp in siaqodb
                             where emp.Age > 20
                             select emp).LastOrDefault();

            //same query written in other way using lambda expression arguments
            Developer last2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).LastOrDefault();

            // or similar-> also run optimized:
            Developer last3 = siaqodb.Query<Developer>().LastOrDefault(emp => emp.Age > 20);

        }
        public void Single()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            try
            {

                //this query run optimized-> only one Developer object will be created and read from database
                //AND ONLY if is only one object that match the condition, otherwise InvalidOperationException is thrown 
                Developer single = (from Developer emp in siaqodb
                                 where emp.Age > 20
                                 select emp).Single();

                //same query written in other way using lambda expression arguments
                Developer single2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).Single();

                // or similar-> also run optimized:
                Developer single3 = siaqodb.Query<Developer>().Single(emp => emp.Age > 20);
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }

        }
        public void SingleOrDefault()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            try
            {

                //this query run optimized-> only one Developer object will be created and read from database IF EXISTS and IF is the only one in database that match the condition,
                //if not exists return null, if there are MANY InvalidOperationException is thrown 
                Developer single = (from Developer emp in siaqodb
                                   where emp.Age > 20
                                   select emp).SingleOrDefault();

                //same query written in other way using lambda expression arguments
                Developer single2 = siaqodb.Query<Developer>().Where(emp => emp.Age > 20).SingleOrDefault();

                // or similar-> also run optimized:
                Developer single3 = siaqodb.Query<Developer>().SingleOrDefault(emp => emp.Age > 20);
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }

        }
        public void PaginationWith_Skip_Take()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

            //if you need pagination in your application you can use Skip/Take methods 
            //in optimized way to pull only needed objects from DB
            //bellow query only pull and create 10 objects
            var query = (from Developer emp in siaqodb
                         where emp.Age>20
                         select emp).Skip(10).Take(10);

            foreach (var c in query)
            {
                //do something with c object
            }
        }
    }
}
