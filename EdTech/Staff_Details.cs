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
    public partial class Staff_Details : Form
    {
        StaffRepo SYS;
        List<Staff> staff;
        public Staff_Details(StaffRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            LoadStaff();
            staff = new List<Staff>();
        }
        public void LoadStaff()
        {

            if (SYS != null)
            {

                staff = SYS.GetAllStaff();

                if (GridViewStaff != null)
                {
                    GridViewStaff.DataSource = null;
                    GridViewStaff.DataSource = staff;
                    GridViewStaff.Refresh();
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

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Add_New_Employee res = new Add_New_Employee(SYS))
            {

                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadStaff();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> selectedId = new List<int>();
            if (GridViewStaff.SelectedRows.Count > 0)
            {
                // Student selectedRecord = (Student)GrideViewStudents.SelectedRows[0].DataBoundItem;
                foreach (DataGridViewRow row in GridViewStaff.SelectedRows)
                {
                    selectedId.Add((int)row.Cells["StaffID"].Value);
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to delete records of {selectedId.Count} members?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SYS.RemoveStaffs(selectedId);
                    LoadStaff();
                    GridViewStaff.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Update_Employee res = new Update_Employee(SYS))
            {

                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadStaff();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Staff> ss = new List<Staff>();
            foreach (Staff s in staff)
            {
                if (s.Name == name.Text.ToString())
                {
                    ss.Add(s);
                }
            }
            GridViewStaff.DataSource = null;
            GridViewStaff.DataSource = ss;
            GridViewStaff.Refresh();

        }

        private void showall_Click(object sender, EventArgs e)
        {
            LoadStaff();
        }
    }
}
