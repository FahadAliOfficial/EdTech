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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Students res = new EdTech.Students())
            {
                res.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(Employee_Details res = new EdTech.Employee_Details()) { res.ShowDialog(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Class_Details res = new EdTech.Class_Details()) { res.ShowDialog(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
