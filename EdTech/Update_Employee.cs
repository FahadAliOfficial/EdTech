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
    public partial class Update_Employee : Form
    {
        public Update_Employee()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emp_designation.Text = emp_dob.Text = emp_gender.Text = emp_id.Text = emp_name.Text = emp_status.Text = father_name.Text = cnic.Text = emp_address.Text = string.Empty;
        }
    }
}
