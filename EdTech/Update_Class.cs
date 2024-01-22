using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace EdTech
{
    public partial class Update_Class : Form
    {
        ClassRepo SYS;
        public Update_Class(ClassRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            this.FormClosing += Update_Classes_FormClosing;
        }

        private void Update_Classes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void ClearTextBoxes()
        {
            searchid.Text = newid.Text = name.Text = stdcap.Text = numchairs.Text = numrooms.Text = numstudents.Text = numtables.Text = section.Text = String.Empty;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(newid.Text) && !String.IsNullOrEmpty(name.Text)
               && !String.IsNullOrEmpty(numchairs.Text) && !String.IsNullOrEmpty(numrooms.Text)
               && !String.IsNullOrEmpty(numstudents.Text) && !String.IsNullOrEmpty(numtables.Text)
            && !String.IsNullOrEmpty(stdcap.Text) && !String.IsNullOrEmpty(section.Text))
            {

                List<string> errors = new List<string>();

                if (!int.TryParse(newid.Text, out _))
                {
                    errors.Add("Invalid data type for Class ID");
                }

                if (!int.TryParse(name.Text, out _))
                {
                    errors.Add("Invalid data type for Grade");
                }
                if (!int.TryParse(numtables.Text, out _))
                {
                    errors.Add("Invalid data type for Tables");
                }
                if (!int.TryParse(numchairs.Text, out _))
                {
                    errors.Add("Invalid data type for Chairs");
                }
                if (!int.TryParse(numrooms.Text, out _))
                {
                    errors.Add("Invalid data type for Room");
                }
                if (!int.TryParse(numstudents.Text, out _))
                {
                    errors.Add("Invalid data type for No of Students");
                }
                if (int.TryParse(section.Text, out _))
                {
                    errors.Add("Invalid data type for Student Capacity");
                }
                if (!int.TryParse(stdcap.Text, out _))
                {
                    errors.Add("Invalid data type for Section");
                }

                if (errors.Count > 0)
                {
                    // Display individual error messages
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    S_Class c = new S_Class
                    {
                        ClassID = Convert.ToInt32(newid.Text),
                        Grade = Convert.ToInt32(name.Text),
                        NumTables = Convert.ToInt32(numtables.Text),
                        NumChairs = Convert.ToInt32(numchairs.Text),
                        RoomNo = Convert.ToInt32(numrooms.Text),
                        NumStd = Convert.ToInt32(numstudents.Text),
                        stdCap = Convert.ToInt32(stdcap.Text),
                        Section = section.Text.ToString()
                    };

                    foreach (S_Class eClass in SYS.Classes)
                    {
                        if (c.ClassID == eClass.ClassID)
                        {
                            MessageBox.Show($"Class with id: {c.ClassID} already exist");
                            return;
                        }

                    }
                    SYS.UpdateClass(Convert.ToInt32(searchid.Text), c);

                    ClearTextBoxes();

                }

            }
            else
            {
                MessageBox.Show("Please Fill all boxes");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchid.Text))
            {
                if (!int.TryParse(searchid.Text, out _))
                {
                    MessageBox.Show("Invalid data type for Class Search ID");
                }
                else
                {
                    {
                        bool c = false;
                        foreach (S_Class cc in SYS.Classes)
                        {
                            if (cc.ClassID == Convert.ToInt32(searchid.Text))
                            {

                                newid.Text = cc.ClassID.ToString();
                                name.Text = cc.Grade.ToString();
                                numtables.Text = cc.NumTables.ToString();
                                numchairs.Text = cc.NumChairs.ToString();
                                numrooms.Text = cc.RoomNo.ToString();
                                numstudents.Text = cc.NumStd.ToString();
                                section.Text = cc.Section.ToString();
                                stdcap.Text = cc.stdCap.ToString();
                                c = true;
                            }
                        }
                        if (!c)
                        {
                            MessageBox.Show("We were not able to locate the class");
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill the Search ID Box");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchid.Text))
            {
                if (MessageBox.Show($"Are you sure to delete student with ID: {searchid.Text}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<int> id = new List<int>();
                    id.Add(Convert.ToInt32(newid.Text));
                    SYS.RemoveClass(id);
                    ClearTextBoxes();

                }
            }
            else
            {
                MessageBox.Show("Please add value for search ID");
            }

        }
    }
}
