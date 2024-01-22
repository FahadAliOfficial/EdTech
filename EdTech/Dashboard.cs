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
        School_Management SYS;
        User user;
        public Dashboard(User user, School_Management sYS)
        {
            InitializeComponent();
            SYS = sYS;
            this.user = user;
            username.Text = user.Username;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (Student_Details res = new EdTech.Student_Details(SYS.studentRepo))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Staff_Details res = new EdTech.Staff_Details(SYS.staffRepo))
            {
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Class_Details res = new EdTech.Class_Details(SYS.classRepo))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (Teacher_Details res = new Teacher_Details(SYS.teacherRepo))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (TimeTable_Details res = new TimeTable_Details(SYS.timetableRepo))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
