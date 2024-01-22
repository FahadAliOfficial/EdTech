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
    public partial class Class_Details : Form
    {
        ClassRepo SYS;
        List<S_Class> classes;

        public Class_Details(ClassRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            classes = new List<S_Class>();
            LoadClasses();
            this.FormClosing += Student_Details_Closing;
        }
        private void Student_Details_Closing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void LoadClasses()
        {
            if (SYS != null)
            {

                classes = SYS.GetAllClasses();

                if (GridViewClasses != null)
                {
                    GridViewClasses.DataSource = null;
                    GridViewClasses.DataSource = classes;
                    GridViewClasses.Refresh();
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
            using (Add_New_Class res = new EdTech.Add_New_Class(SYS))
            {
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadClasses();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Update_Class res = new EdTech.Update_Class(SYS))
            {
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadClasses();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<S_Class> cc = new List<S_Class>();
            foreach (S_Class c in classes)
            {
                if (c.Grade.ToString() == name.Text.ToString())
                {
                    cc.Add(c);
                }
            }
            GridViewClasses.DataSource = null;
            GridViewClasses.DataSource = cc;
            GridViewClasses.Refresh();
        }

        private void showall_Click(object sender, EventArgs e)
        {
            LoadClasses();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> selectedId = new List<int>();
            if (GridViewClasses.SelectedRows.Count > 0)
            {
                // Student selectedRecord = (Student)GrideViewStudents.SelectedRows[0].DataBoundItem;
                foreach (DataGridViewRow row in GridViewClasses.SelectedRows)
                {
                    selectedId.Add((int)row.Cells["ClassID"].Value);
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to delete records of {selectedId.Count} members?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SYS.RemoveClass(selectedId);
                    LoadClasses();
                    GridViewClasses.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }
    }
}
