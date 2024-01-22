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
using System.Xml.Linq;

namespace EdTech
{
    public partial class Add_New_Sub_Time : Form
    {
        TimeTableRepo SYS;
        List<TimeTable> timetables;
        public Add_New_Sub_Time(TimeTableRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            timetables = new List<TimeTable>();
            //for classNumber
            List<int> Classes = new List<int>();
            Classes = SYS.getClassNumbers();
            classname.DataSource = Classes;
            classname.DisplayMember = "ToString";
            classname.SelectedIndex = 0;
            //for days
            List<DayOfWeek> daysOfWeekList = new List<DayOfWeek>
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
            this.FormClosing += Add_New_Timetable_FormClosing;
        }
        private void Add_New_Timetable_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if (e.CloseReason == CloseReason.UserClosing)
            {
               
                SYS.AddTimetableEntry(timetables);
                this.DialogResult = DialogResult.OK;

            }*/
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(classname.Text) && !String.IsNullOrEmpty(day.Text)
                && !String.IsNullOrEmpty(starttime.Text) && !String.IsNullOrEmpty(endtime.Text)
                && !String.IsNullOrEmpty(subject.Text))
            {
                List<string> errors = new List<string>();
                DayOfWeek selectedDay = (DayOfWeek)day.SelectedItem;

                if (!int.TryParse(classname.Text, out _))
                {
                    errors.Add("Invalid data type for Class Name");
                }

                if (int.TryParse(subject.Text, out _))
                {
                    errors.Add("Invalid data type for subject");
                }

                if (day.SelectedItem is not DayOfWeek _)
                {
                    errors.Add("Invalid data type for day");
                }

              
                int sTime = (Convert.ToInt32(starttime.Value.ToString("hh")) * 60) + Convert.ToInt32(starttime.Value.ToString("mm"));
                int eTime = (Convert.ToInt32(endtime.Value.ToString("hh")) * 60) + Convert.ToInt32(endtime.Value.ToString("mm"));

                if (eTime <= sTime)
                {
                    errors.Add("End time must be greater than start time");
                }

                // Assuming durationtime is another DateTimePicker for duration

                if ((eTime - sTime) != Convert.ToInt32(durationtime.Value.ToString("mm")) )
                {
                    errors.Add("Class Duration is not correct");
                }

                if (errors.Count > 0)
                {
                    // Display individual error messages
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TimeSpan startTime = starttime.Value.TimeOfDay;
                    TimeSpan endTime = endtime.Value.TimeOfDay;
                    startTime = new TimeSpan(startTime.Hours, startTime.Minutes, 0);
                    endTime = new TimeSpan(endTime.Hours, endTime.Minutes, 0);
                    
                    foreach (TimeTable tt in SYS.TimeTables)
                    {
                        if (startTime == tt.StartTime && day.Text == tt.Day.ToString() && classname.Text == tt.CGrade.ToString())
                        {
                            MessageBox.Show($"The start time {tt.StartTime}is already in use till  {tt.EndTime}");
                            return;
                        }
                        if(subject.Text == tt.Subject.ToString() && day.Text == tt.Day.ToString() && classname.Text == tt.CGrade.ToString())
                        {
                            MessageBox.Show($"Time Table for subject: {subject.Text} has already assigned for: {tt.Day.ToString()}");
                            return;
                        }

                    }
                    TimeTable t = new TimeTable
                    {
                        Subject = subject.Text.ToString(),
                        CGrade = Convert.ToInt32(classname.Text),
                        EndTime = endTime,
                        StartTime = startTime,
                        Day = selectedDay
                    };
                    timetables.Add(t);
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the boxes");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SYS.AddTimetableEntry(timetables);
            this.Close();
        }
        private void ClearTextBoxes()
        {
            subject.Text = classname.Text = endtime.Text = starttime.Text = day.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}

