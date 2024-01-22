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
using System.Reflection;

namespace EdTech
{
    public partial class Add_New_Class : Form
    {
        private ClassRepo SYS;
        private List<S_Class> classes;
        public Add_New_Class(ClassRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            classes = new List<S_Class>();
            this.FormClosing += Add_New_CLass_FormClosing;
        }

        private void Add_New_CLass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                foreach (S_Class nClass in classes)
                {
                    foreach (S_Class eClass in SYS.Classes)
                    {
                        if (nClass.ClassID == eClass.ClassID)
                        {
                            MessageBox.Show($"Class with id: {nClass.ClassID} already exist");
                            e.Cancel = true;
                            return;
                        }

                    }
                }
                SYS.AddClass(classes);
                this.DialogResult = DialogResult.OK;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            id.Text = name.Text = section.Text = numchairs.Text = numrooms.Text = numstudents.Text = numtables.Text = stdcap.Text = String.Empty;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SYS.AddClass(classes);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(id.Text) && !String.IsNullOrEmpty(name.Text)
               && !String.IsNullOrEmpty(numchairs.Text) && !String.IsNullOrEmpty(numrooms.Text)
               && !String.IsNullOrEmpty(numstudents.Text) && !String.IsNullOrEmpty(numtables.Text)
            && !String.IsNullOrEmpty(section.Text) && !String.IsNullOrEmpty(stdcap.Text))
            {

                List<string> errors = new List<string>();

                if (!int.TryParse(id.Text, out _))
                {
                    errors.Add("Invalid data type for Class ID");
                }

                if (!int.TryParse(name.Text, out _))
                {
                    errors.Add("Invalid data type for Grade number:");
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
                if (!int.TryParse(stdcap.Text, out _))
                {
                    errors.Add("Invalid data type for Student Capacity");
                }
                if (int.TryParse(section.Text, out _))
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
                    foreach (S_Class cc in SYS.Classes)
                    {
                        if (cc.ClassID == Convert.ToInt32(id.Text))
                        {
                            MessageBox.Show($"Teacher with iD: {id.Text} already exits");
                            return;
                        }
                    }
                    S_Class c = new S_Class
                    {
                        ClassID = Convert.ToInt32(id.Text),
                        Grade = Convert.ToInt32(name.Text),
                        NumTables = Convert.ToInt32(numtables.Text),
                        NumChairs = Convert.ToInt32(numchairs.Text),
                        RoomNo = Convert.ToInt32(numrooms.Text),
                        NumStd = Convert.ToInt32(numstudents.Text),
                        stdCap = Convert.ToInt32(stdcap.Text),
                        Section = section.Text.ToString()
                    };
                    classes.Add(c);
                    ClearTextBoxes();

                }

            }
            else
            {
                MessageBox.Show("Please Fill all boxes");
            }
        }

        private void Add_New_Class_Load(object sender, EventArgs e)
        {

        }
    }
}
