using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public interface iStudentRepo
    {
        public List<Student> GetAllStudents();
        public void AddStudent(List<Student> students);
        public void AddStudent(Student std);
        //public void RemoveStudent(List<Student> student);
        public void RemoveStudent(List<int> s);
        public void UpdateStudent(int id, Student student);

        public List<int> getClassNumbers();


    }
}
