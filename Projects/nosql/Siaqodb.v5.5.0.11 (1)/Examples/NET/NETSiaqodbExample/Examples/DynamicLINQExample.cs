using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Example.DataObjects;
using Sqo;

namespace Example
{
    class DynamicLINQExample : BaseExample, IExample
    {


        public void Run()
        {

            Siaqodb siaqodb= SiaqodbFactoryExample.GetInstance();
            // example:dynamic filter depending what user choose in the UI
            // once it is needed to filter by FirstName and another time by FirstName AND Age
            //we will pick random cases
            int val = DateTime.Now.Second % 2;
            
            //declare predicate
            Expression<Func<Employee, bool>> predicate = null;
            if (val == 1)
            { 
                //build a predicate to filter only by FirstName
                predicate = employee => employee.FirstName.Contains("Emp");
                
                Log("Predicate with only FirstName is activated");
            }
            else if (val == 0)
            {
                //build a predicate to filter by FirstName and Age
                predicate = employee => employee.FirstName.Contains("Emp") && employee.Age > 20;
                
                Log("Predicate with FirstName and Age is activated");
            }

            var q = siaqodb.Query<Employee>().Where(predicate).Select(e => e);

            foreach (Employee emp in q)
            { 
                //do something with employee
            }
        }

        
    }
}
