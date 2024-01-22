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
    public partial class Update_Timetable : Form
    {
        TimeTableRepo SYS;
        public Update_Timetable(TimeTableRepo sYS)
        {
            InitializeComponent();
            this.FormClosing += Update_Timetable_FormClosing;
            SYS = sYS;
            List<int> Classes = new List<int>();
            Classes = SYS.getClassNumbers();
            classname.DataSource = searchgrade.DataSource = Classes;
            classname.DisplayMember = searchgrade.DisplayMember = "ToString";
            classname.SelectedIndex = searchgrade.SelectedIndex = 0;


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
            day.DataSource = searchday.DataSource = daysOfWeekList;
            day.DisplayMember = searchday.DisplayMember = "ToString";
            day.SelectedIndex = searchday.SelectedIndex = 0;
        }
        private void Update_Timetable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void ClearTextBoxes()
        {
            searchsubject.Text = subject.Text = endtime.Text = starttime.Text = string.Empty;
            searchgrade.SelectedIndex = 0;
            searchday.SelectedIndex = 0;
            classname.SelectedIndex = 0;
            day.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(searchday.Text) && !String.IsNullOrEmpty(searchgrade.Text)
                 && !String.IsNullOrEmpty(searchsubject.Text))
            {
                List<string> errors = new List<string>();


                if (!int.TryParse(searchgrade.Text, out _))
                {
                    errors.Add("Invalid data type for Class Grade");
                }

                if (int.TryParse(searchsubject.Text, out _))
                {
                    errors.Add("Invalid data type for subject");
                }

                if (searchday.SelectedItem is not DayOfWeek _)
                {
                    errors.Add("Invalid data type for day");
                }

                if (errors.Count > 0)
                {
                    // Display individual error messages
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    {
                        bool c = false;
                        foreach (TimeTable tt in SYS.TimeTables)
                        {
                            if (tt.CGrade == Convert.ToInt32(searchgrade.Text)
                                && tt.Day.ToString() == searchday.Text
                                && tt.Subject.ToString() == searchsubject.Text)
                            {

                                subject.Text = tt.Subject.ToString();
                                classname.Text = tt.CGrade.ToString();
                                endtime.Text = tt.EndTime.ToString();
                                starttime.Text = tt.StartTime.ToString();
                                day.Text = tt.Day.ToString();
                                c = true;
                            }
                        }
                        if (!c)
                        {
                            MessageBox.Show("We were not able to locate the Timetable");
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill the Search ID Box");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(classname.Text) && !String.IsNullOrEmpty(day.Text)
                 && !String.IsNullOrEmpty(starttime.Text) && !String.IsNullOrEmpty(endtime.Text)
                 && !String.IsNullOrEmpty(subject.Text))
            {
                List<string> errors = new List<string>();

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

                if ((eTime - sTime) != Convert.ToInt32(durationtime.Value.ToString("mm")))
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
                        if ((startTime == tt.StartTime && day.Text == tt.Day.ToString() && classname.Text == tt.CGrade.ToString())
                            && (searchsubject.Text != tt.Subject.ToString() && subject.Text != tt.Subject.ToString()))
                        {
                            MessageBox.Show($"The start time {tt.StartTime}is already in use till  {tt.EndTime}");
                            return;
                        }


                    }
                    TimeTable t = new TimeTable
                    {
                        Subject = subject.Text.ToString(),
                        CGrade = Convert.ToInt32(classname.Text),
                        EndTime = endTime,
                        StartTime = startTime,
                        Day = (DayOfWeek)day.SelectedItem

                    };
                    if (Enum.TryParse<DayOfWeek>(searchday.Text, true, out DayOfWeek dayOfWeek))
                    {
                        // Now you can use 'dayOfWeek' as the argument
                        SYS.UpdateTimetable(dayOfWeek, Convert.ToInt32(searchgrade.Text), searchsubject.Text.ToString(), t);
                    }
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the boxes");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(searchday.Text)
                && !String.IsNullOrEmpty(searchgrade.Text)
                && !String.IsNullOrEmpty(searchsubject.Text))
            {
                if (MessageBox.Show($"Are you sure to delete Time Table of grade: {searchgrade.Text} for day: {searchday.Text}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<int> id = new List<int>();
                    foreach (TimeTable tt in SYS.TimeTables)
                    {
                        if (tt.CGrade.ToString() == classname.Text && tt.Day.ToString() == day.Text && tt.Subject.ToString() == subject.Text)
                        {
                            id.Add(Convert.ToInt32(tt.Id));
                            SYS.RemoveTimeTable(id);
                        }
                    }
                    if (id.Count == 0)
                    {
                        MessageBox.Show($"TimeTable don't Exists.");
                    }
                    else
                    {
                        ClearTextBoxes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all boxes.");
            }
        }
    }
}
