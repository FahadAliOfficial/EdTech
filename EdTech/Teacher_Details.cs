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
    public partial class Teacher_Details : Form
    {
        TeacherRepo SYS;
        List<Teacher> teachers;
        public Teacher_Details(TeacherRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            LoadTeachers();
            teachers = new List<Teacher>();
          
        }

        public void LoadTeachers()
        {

            if (SYS != null)
            {

                teachers = SYS.GetAllTeachers();

                if (GridViewTeachers != null)
                {
                    GridViewTeachers.DataSource = null;
                    GridViewTeachers.DataSource = teachers;
                    GridViewTeachers.Refresh();
                }
                else
                {
                    MessageBox.Show("Data Grid is not Initialized");
                }
            }
            else
            {
                MessageBox.Show("Student Repository is not Initialized");
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            using(Add_New_Teacher res = new Add_New_Teacher(SYS))
            {
               
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadTeachers();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Update_Teacher res = new Update_Teacher(SYS))
            {

                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadTeachers();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> selectedId = new List<int>();
            if (GridViewTeachers.SelectedRows.Count > 0)
            {
                // Student selectedRecord = (Student)GrideViewStudents.SelectedRows[0].DataBoundItem;
                foreach (DataGridViewRow row in GridViewTeachers.SelectedRows)
                {
                    selectedId.Add((int)row.Cells["TeacherID"].Value);
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to delete records of {selectedId.Count} members?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SYS.RemoveTeacher(selectedId);
                    LoadTeachers();
                    GridViewTeachers.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void showall_Click(object sender, EventArgs e)
        {
            LoadTeachers();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Teacher> ss = new List<Teacher>();
            foreach (Teacher s in teachers)
            {
                if (s.Name == name.Text.ToString())
                {
                    ss.Add(s);
                }
            }
            GridViewTeachers.DataSource = null;
            GridViewTeachers.DataSource = ss;
            GridViewTeachers.Refresh();
        }
    }
}
