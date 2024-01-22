using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace EdTech
{
    public partial class Delete_Student : Form
    {
        StudentRepo SYS;
        private List<Student> std;
        public Delete_Student(StudentRepo sys)
        {
            InitializeComponent();
            SYS = sys;
            std = new List<Student>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            
        }

        
        private void clearAllforms()
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
