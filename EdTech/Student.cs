using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    internal class Student:Person
    {
        public string Student_ID { get; set; } = "";
        public string Student_Session { get; set; } = "";
        public string B_Form { get; set; } = "";
        public string Father_Name { get; set; } = "";
        public int Father_Phone_Num { get; set; } = 0;
        public string F_CNIC { get; set; } = "";
        public string Mother_Name { get; set; } = "";
        public int Mother_Phone_Num { get; set; } = 0;
        public string M_CNIC { get; set; } = "";

        public string Address { get; set; } = "";

        public int Class { get; set; } = 0;
        public string Section { get; set; } = "";

        public DateTime Enrollment_Date = DateTime.MinValue;

        public Student(string name, string gender, DateTime dob, string disability,int age, string session,string bform, string fathername,int fpn, string f_cnic,string mothername, int mpn, string m_cnic, string address, int S_class, string section):base(name,gender,dob,disability,age)
        {
            Student_Session = session;
            B_Form = bform;
            Father_Name = fathername;
            Father_Phone_Num = fpn;
            F_CNIC = f_cnic;
            Mother_Name = mothername;
            Mother_Phone_Num = mpn;
            M_CNIC = m_cnic;
            Address = address;
            Class = S_class;
            Section = session;
            Enrollment_Date = DateTime.Now;

        }

    }
}
