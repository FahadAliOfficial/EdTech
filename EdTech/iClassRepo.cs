using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    internal interface iClassRepo
    {
        public List<S_Class> GetAllClasses();
        public void AddClass(List<S_Class> C);

        public void RemoveClass(List<int> C);
        public void UpdateClass(int id, S_Class C);

    }
}
