using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdTech
{
    public partial class Employee_Details : Form
    {
        public Employee_Details()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Add_New_Employee res = new EdTech.Add_New_Employee()) { res.ShowDialog(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(Update_Employee res = new EdTech.Update_Employee()) { res.ShowDialog(); }
        }
    }
}
