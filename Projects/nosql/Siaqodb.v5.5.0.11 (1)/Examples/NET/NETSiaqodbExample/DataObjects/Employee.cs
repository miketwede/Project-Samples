using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;

namespace Example.DataObjects
{
    public class Employee 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int Age { get; set; }

    }
}
