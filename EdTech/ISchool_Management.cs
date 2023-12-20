using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public interface ISchool_Management
    {



        //Methods for Teachers
        List<Teacher> GetAllTeachers();
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);

        //Methods for Students
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void RemoveStudent(Student student);
        void UpdateStudent(Student student);
        
        
        //Methods for Parents


        //Methods for Staff Employee


        //Methods for Attendance

        
        //Methods for Reports

        
        //Methods for Finance
        

        //Methods for Fee

        
        //Methods for Salary


        //Methods for Expense


        //Methods for Exam

        
        //Methods for Papers


        //Methods for Quizes


        //Methods for 







    }
}
