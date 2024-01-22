using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    internal interface iTeacherRepo
    {
        public List<int> getClassNumbers();
        public List<Teacher> GetAllTeachers();
        public void AddTeacher(List<Teacher> t);
        public void AddTeacher(Teacher tec);
        public void RemoveTeacher(List<int> t);
        public void UpdateTeacher(int id, Teacher t);
    }
}
