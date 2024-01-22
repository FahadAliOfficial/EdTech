using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Teacher:Faculity
    {
        public byte[] Photo = null;
        public int TeacherID { get; set; } = 0;
        public string Qualification { get; set; } = "";
        public int InchargeShip { get; set; } = 0;
        public Int64 CNIC { get; set; } = 0;
        public Int64 Phone_Number {  get; set; } = 0;
        public DateTime? DepartureDate { get; set; } = null;
        public string Address { get; set; } = "";
        public Teacher(byte[]p ,int id,string name, string gender,Int64 cnic, DateTime dob, 
            string disability,int age,string role, int salary, DateTime j,string qualification,
            int inchargeship,string address, Int64 pn) 
            : base(name, gender, dob, disability, age,role,salary ,j)
        {
            CNIC = cnic;
            TeacherID = id;
            Qualification = qualification;
            InchargeShip = inchargeship;
            Address = address;
            Phone_Number = pn;
            Photo = p;
        }
     
        public Teacher():base("","",DateTime.MinValue,"",0,"",0,DateTime.MinValue){}

    }
}
