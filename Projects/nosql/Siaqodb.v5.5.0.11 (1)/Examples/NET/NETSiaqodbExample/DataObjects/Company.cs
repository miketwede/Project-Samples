using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;

namespace Example.DataObjects
{
    public class Company
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        
        public List<Employee> Employees { get; set; }

    }
}
