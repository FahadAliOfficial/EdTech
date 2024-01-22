using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Staff:Faculity
    {
        public byte[] Photo = null;
        public int StaffID { get; set; } = 0;
        public Int64 CNIC { get; set; } = 0;
        public Int64 Phone_Number { get; set; } = 0;
        public DateTime? DepartureDate { get; set; } = null;
        public string Address { get; set; } = "";
        public string Qualification { get; set; } = "";
        public string Status { get; set; } = "";
        public Staff(byte[] p, int id, string name, string qua,string s, string gender, Int64 cnic, DateTime dob,
            string disability, int age, string role, int salary,DateTime jd, string address, Int64 pn, DateTime dd)
            : base(name, gender, dob, disability, age, role, salary, jd)
        {
            StaffID = id;
            CNIC = cnic;
            StaffID = id;
            Address = address;
            Phone_Number = pn;
            Photo = p;
            DepartureDate = dd;
            Qualification = qua;
            Status = s;
        }

        public Staff() : base("", "", DateTime.MinValue, "", 0, "", 0,DateTime.MinValue) { }
    }
}
