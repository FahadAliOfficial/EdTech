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
    public partial class Update_Class : Form
    {
        public Update_Class()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            class_id.Text = class_name.Text = class_section.Text = num_chairs.Text = num_rooms.Text = num_students.Text = num_tables.Text = String.Empty;
        }
    }
}
