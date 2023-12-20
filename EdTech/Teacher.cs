using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Teacher:Faculity
    {
        public string Qualification { get; set; } = "";
        public double Pending_Salary { get; set; } = 0;
        public double Bonus {  get; set; } = 0;
        public bool InchargeShip { get; set; } = false;
        public DateTime DepartureDate { get; set; } = DateTime.MaxValue;
        public Teacher(string name, string gender, DateTime dob, string disability, int age, string role, double salary,string qualification,bool inchargeship) : base(name, gender, dob, disability, age,role,salary)
        {
            Qualification = qualification;
            InchargeShip = inchargeship;
        }
    }
}
