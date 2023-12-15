using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    internal class Faculity:Person
    {
        public string Role { get; set; } = "";
        public double Salary = 0;
        public DateTime Joinging_Date { get; set; } = DateTime.MinValue;

        public Faculity(string name, string gender, DateTime dob, string disability, int age, string role, double salary):base(name,gender,dob,disability,age) 
        {
            Role = role;
            Salary = salary;
            Joinging_Date = DateTime.Now;
        }
    }
}
