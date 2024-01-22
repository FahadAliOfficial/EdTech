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
    public partial class TimeTable_Details : Form
    {
        TimeTableRepo SYS;
        List<TimeTable> timeTables;
        List<DayOfWeek> daysOfWeekList;
        List<int> Classes;
        public TimeTable_Details(TimeTableRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            timeTables = new List<TimeTable>();

            //for classNumber
            Classes = new List<int>();
            Classes = SYS.getClassNumbers();
            classno.DataSource = Classes;
            classno.DisplayMember = "ToString";
            classno.SelectedIndex = 0;
            //for days
            daysOfWeekList = new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
            day.DataSource = daysOfWeekList;
            day.DisplayMember = "ToString";
            day.SelectedIndex = 0;

            LoadTimetable(daysOfWeekList[0], Classes[0]);

        }

        private void LoadTimetable(DayOfWeek a, int b)
        {

            if (SYS != null)
            {
                timeTables = SYS.GetTimetableForDay(a, b);
                if (GridViewTimetable != null)
                {

                    GridViewTimetable.DataSource = null;
                    GridViewTimetable.DataSource = timeTables;
                    GridViewTimetable.Refresh();
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
            using (Add_New_Sub_Time res = new EdTech.Add_New_Sub_Time(SYS))
            {
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadTimetable(daysOfWeekList[0], Classes[0]);
                  
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (day.SelectedItem is DayOfWeek selectedDay)
            {
                LoadTimetable(selectedDay, (Convert.ToInt32(classno.Text)));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> selectedId = new List<int>();
            if (GridViewTimetable.SelectedRows.Count > 0)
            {
                // Student selectedRecord = (Student)GrideViewStudents.SelectedRows[0].DataBoundItem;
                foreach (DataGridViewRow row in GridViewTimetable.SelectedRows)
                {
                    selectedId.Add((int)row.Cells["Id"].Value);
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to delete records of {selectedId.Count} members?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SYS.RemoveTimeTable(selectedId);
                    LoadTimetable(daysOfWeekList[0], Classes[0]);
                    classno.SelectedIndex = 0;
                    day.SelectedIndex = 0;
                    GridViewTimetable.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Update_Timetable res = new EdTech.Update_Timetable(SYS))
            {
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadTimetable(daysOfWeekList[0], Classes[0]);

                }
            }
        }
    }
}
