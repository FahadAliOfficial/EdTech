using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Student:Person
    {
        public int StudentID { get; set; } = -1;
        public int Std_Session { get; set; } = -1;
        public Int64 Std_BForm { get; set; } = -1;
        public string Std_FName { get; set; } = "";
        public Int64 Std_FPhone { get; set; } = -1;
        public Int64 Std_FCNIC { get; set; } = -1;
        public string Std_MName { get; set; } = "";
        public Int64 Std_MPhone { get; set; } = -1;
        public Int64 Std_MCNIC { get; set; } = -1;

        public string Std_Address { get; set; } = "";

        public int Std_Class { get; set; } = -1;
        public string Std_Section { get; set; } = "";
        public byte[] Std_Photo { get; set; } = null;
        public DateTime Std_EnrollmentDate { get; set; } = DateTime.MinValue;

        public Student(byte[] p,int id, string name, string gender, DateTime dob,
            string disability,int age, int session,Int64 bform, 
            string fathername,Int64 fpn, Int64 f_cnic,string mothername, 
            Int64 mpn, Int64 m_cnic, string address, int S_class, string section, DateTime e)
            :base(name,gender,dob,disability,age)
        {
            StudentID = id;
            Std_Session = session;
            Std_BForm = bform;
            Std_FName = fathername;
            Std_FPhone = fpn;
            Std_FCNIC = f_cnic;
            Std_MName = mothername;
            Std_MPhone = mpn;
            Std_MCNIC = m_cnic;
            Std_Address = address;
            Std_Class = S_class;
            Std_Section = section;
            Std_EnrollmentDate = e;
            Std_Photo = p;

        }
        public Student():base("","",DateTime.MinValue,"",0) { }

    }
}
