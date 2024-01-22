using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Person
    {
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime? DOB { get; set; } = null;
        public int Age { get; set; } = 0;
        public string Disablity { get; set; } = "";
        public Person(string name,string gender,DateTime dob, string disability,int age) { Name = name;Gender = gender; DOB = dob; Disablity = disability; Age = age; }
        
        public Person() { }
    }
}
