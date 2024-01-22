using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace EdTech
{
    public class School_Management
    {
        private readonly string connectionstring = "Data Source=DESKTOP-C3NF4Q2\\SQLEXPRESS;Initial Catalog=EdTech;Integrated Security=True;";


        public TeacherRepo teacherRepo;
        public StudentRepo studentRepo;
        public StaffRepo staffRepo;
        public ClassRepo classRepo;
        public TimeTableRepo timetableRepo;
        public School_Management()
        {
            
            studentRepo = new StudentRepo(connectionstring);
            teacherRepo = new TeacherRepo(connectionstring);
            staffRepo = new StaffRepo(connectionstring);
            classRepo = new ClassRepo(connectionstring); 
            timetableRepo = new TimeTableRepo(connectionstring);
        }
    }

}


