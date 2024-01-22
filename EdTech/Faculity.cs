using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Faculity:Person
    {
            public string Role { get; set; } = "";
            public int Salary { get; set; } = 0;
            public DateTime? Joining_Date { get; set; } = null;

        public Faculity(string name, string gender, 
            DateTime dob, string disability,
            int age, string role, int salary, DateTime j)
            :base(name,gender,dob,disability,age) 
        {
            Role = role;
            Salary = salary;
            Joining_Date = j;
        }
       
    }
}
