using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortableDataLayer.Entities
{
    public class Developer : Employee
    {
        public ProgrammingLanguage DevelopIn { get; set; }
        public int YearsExperience { get; set; }
        
    }
    public enum ProgrammingLanguage{ CSharp,Java,PHP }
}
