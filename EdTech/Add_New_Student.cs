using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EdTech
{
    public partial class Add_New_Student : Form
    {
        private StudentRepo SYS;
        private List<Student> students;
        public Add_New_Student(StudentRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            students = new List<Student>();
            this.FormClosing += Add_New_Student_FormClosing;
        }
        private void Add_New_Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                foreach(Student nStudent in students)
                {
                    foreach(Student eStudents in SYS.Students)
                    {
                        if(nStudent.StudentID == eStudents.StudentID)
                        {
                            MessageBox.Show($"Student with id: {nStudent.StudentID} already exist");
                            e.Cancel = true;
                            return;
                        }
                        
                    }
                }
                    this.DialogResult = DialogResult.OK;
                    SYS.AddStudent(students);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            SYS.AddStudent(students);
            this.Close();


            
        }

        private void button5_Click(object sender, EventArgs e)
        {


            if (!String.IsNullOrEmpty(id.Text) && !String.IsNullOrEmpty(session.Text)
                && !String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(age.Text)
                && !String.IsNullOrEmpty(disability.Text) && !String.IsNullOrEmpty(dob.Text)
                && !String.IsNullOrEmpty(gender.Text) && !String.IsNullOrEmpty(bform.Text)
                && !String.IsNullOrEmpty(fname.Text) && !String.IsNullOrEmpty(fpn.Text)
                && !String.IsNullOrEmpty(fcnic.Text) && !String.IsNullOrEmpty(mname.Text)
                && !String.IsNullOrEmpty(mpn.Text) && !String.IsNullOrEmpty(mcnic.Text)
                && !String.IsNullOrEmpty(address.Text) && !String.IsNullOrEmpty(enrollement_date.Text)
                && !String.IsNullOrEmpty(std_class.Text) && !String.IsNullOrEmpty(section.Text))
            {

                List<string> errors = new List<string>();

                if (!int.TryParse(session.Text, out _))
                {
                    errors.Add("Invalid data type for Student Session");
                }
                if (!int.TryParse(id.Text, out _))
                {
                    errors.Add("Invalid data type for Student ID");
                }

                if (int.TryParse(name.Text, out _))
                {
                    errors.Add("Invalid data type for Student Name");
                }

                if (!int.TryParse(age.Text, out _))
                {
                    errors.Add("Invalid data type for Age");
                }

                if (int.TryParse(disability.Text, out _))
                {
                    errors.Add("Invalid data type for Disability");
                }

                if (int.TryParse(gender.Text, out _))
                {
                    errors.Add("Invalid data type for Gender");
                }

                if (!long.TryParse(bform.Text, out _))
                {
                    errors.Add("Invalid data type for BForm");
                }

                if (int.TryParse(fname.Text, out _))
                {
                    errors.Add("Invalid data type for Father's Name");
                }

                if (!long.TryParse(fpn.Text, out _))
                {
                    errors.Add("Invalid data type for Father's Phone Number");
                }

                if (!long.TryParse(fcnic.Text, out _))
                {
                    errors.Add("Invalid data type for Father's CNIC");
                }

                if (int.TryParse(mname.Text, out _))
                {
                    errors.Add("Invalid data type for Mother's Name");
                }

                if (!long.TryParse(mpn.Text, out _))
                {
                    errors.Add("Invalid data type for Mother's Phone Number");
                }

                if (!long.TryParse(mcnic.Text, out _))
                {
                    errors.Add("Invalid data type for Mother's CNIC");
                }

                if (int.TryParse(address.Text, out _))
                {
                    errors.Add("Invalid data type for Address");
                }

                if (!int.TryParse(std_class.Text, out _))
                {
                    errors.Add("Invalid data type for Class");
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
                    byte[] img = ConvertToByte(picture.Image);
                    foreach (Student student in SYS.Students)
                    {
                        if (student.StudentID == Convert.ToInt32(id.Text))
                        {
                            MessageBox.Show($"Student with iD: {id.Text} already exits");
                            return;
                        }
                    }


                    Student std = new Student
                    {
                        StudentID = Convert.ToInt32(id.Text),
                        Std_Session = Convert.ToInt32(session.Text),
                        Name = name.Text.ToString(),
                        Age = Convert.ToInt32(age.Text),
                        Disablity = disability.Text.ToString(),
                        DOB = Convert.ToDateTime(dob.Text),
                        Gender = gender.Text.ToString(),
                        Std_BForm = Convert.ToInt64(bform.Text),
                        Std_FName = fname.Text.ToString(),
                        Std_FPhone = Convert.ToInt64(fpn.Text),
                        Std_FCNIC = Convert.ToInt64(fcnic.Text),
                        Std_MName = mname.Text.ToString(),
                        Std_MPhone = Convert.ToInt64(mpn.Text),
                        Std_MCNIC = Convert.ToInt64(mcnic.Text),
                        Std_Address = address.Text.ToString(),
                        Std_EnrollmentDate = Convert.ToDateTime(enrollement_date.Text),
                        Std_Class = Convert.ToInt32(std_class.Text),
                        Std_Section = section.Text.ToString(),
                        Std_Photo = img

                    };

                    students.Add(std);
                    ClearFormBoxes();
                }

            }
            else
            {
                MessageBox.Show("Please Fill all boxes");
            }


        }
    

        private byte[] ConvertToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (img != null)
                {
                    ///img.Save(ms, img.RawFormat);
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }

                    return null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearFormBoxes();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void ClearFormBoxes()
        {
            id.Text = session.Text = section.Text =
                std_class.Text = name.Text = age.Text
                = disability.Text = dob.Text = gender.Text
                = bform.Text = fname.Text = fpn.Text
                = fcnic.Text = mname.Text = mpn.Text
                = mcnic.Text = address.Text
                = enrollement_date.Text = String.Empty;
            picture.Image = null;
            picture.Image = Image.FromFile("..\\..\\..\\Icons\\user.png");
        }
    }
}
