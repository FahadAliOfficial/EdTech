using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EdTech
{
    public partial class Update_Student : Form
    {
        StudentRepo SYS;
        public Update_Student(StudentRepo sys)
        {
            InitializeComponent();
            SYS = sys;
            this.FormClosing += Update_Student_FormClosing;
        }
        private void Update_Student_FormClosing(object sender, FormClosingEventArgs e)
        { 
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchid.Text))
            {
                if (!int.TryParse(searchid.Text, out _))
                {
                    MessageBox.Show("Invalid data type for New Student ID");
                }
                else
                {
                    
                        bool c = false;
                        foreach (Student student in SYS.Students)
                        {
                            if (student.StudentID == Convert.ToInt32(searchid.Text))
                            {

                                session.Text = student.Std_Session.ToString();
                                newid.Text = student.StudentID.ToString();
                                name.Text = student.Name.ToString();
                                age.Text = student.Age.ToString();
                                disability.Text = student.Disablity.ToString();
                                dob.Text = (student.DOB).ToString();
                                gender.Text = student.Gender.ToString();
                                bform.Text = student.Std_BForm.ToString();
                                fname.Text = student.Std_FName.ToString();
                                fpn.Text = student.Std_FPhone.ToString();
                                fcnic.Text = student.Std_FCNIC.ToString();
                                mname.Text = student.Std_MName.ToString();
                                mpn.Text = student.Std_MPhone.ToString();
                                mcnic.Text = student.Std_MCNIC.ToString();
                                address.Text = student.Std_Address.ToString();
                                enrollement_date.Text = student.Std_EnrollmentDate.ToString();
                                std_class.Text = student.Std_Class.ToString();
                                section.Text = student.Std_Section.ToString();
                                byte[] photo = student.Std_Photo;

                                if (photo.Length > 0 && photo != null)
                                {
                                    using (MemoryStream stream = new MemoryStream(photo))
                                    {
                                        if (picture.Image != null)
                                        {
                                            picture.Image.Dispose();
                                        }
                                        picture.Image = Image.FromStream(stream);
                                    }
                                }
                                else
                                {
                                    picture.Image = null;

                                }
                                c = true;
                            }
                        }
                        if (!c)
                        {
                            MessageBox.Show("We were not able to locate Student");
                        }


                    
                }
            }
            else
            {
                MessageBox.Show("Please fill the Search ID Box");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFormBoxes();
        }
        private byte[] ConvertToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (img != null)
                {

                    //img.Save(ms, img.RawFormat);
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(ms, ImageFormat.Png);
                    //bmp.CopyToStream(ms, ImageFormat.Png);
                    return ms.ToArray();
                }

                return null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(newid.Text) && !String.IsNullOrEmpty(session.Text)
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
                if (!int.TryParse(newid.Text, out _))
                {
                    errors.Add("Invalid data type for New Student ID");
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


                    Student std = new Student
                    {
                        StudentID = Convert.ToInt32(newid.Text),
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

                    foreach (Student estudents in SYS.Students)
                    {
                        if (std.StudentID == estudents.StudentID)
                        {
                            MessageBox.Show($"Student with id: {std.StudentID} already exist");
                            return;
                        }

                    }

                    SYS.UpdateStudent(Convert.ToInt32(searchid.Text), std);
                    
                    MessageBox.Show($"Student with ID: {searchid.Text}, having new ID: {newid} has been updated");

                    ClearFormBoxes();

                   
                }
            }
            else
            {
                MessageBox.Show("Fill the Boxes");
            }
        }
        private void ClearFormBoxes()
        {
            searchid.Text = newid.Text = session.Text = section.Text =
                    std_class.Text = name.Text = age.Text
                    = disability.Text = dob.Text = gender.Text
                    = bform.Text = fname.Text = fpn.Text
                    = fcnic.Text = mname.Text = mpn.Text
                    = mcnic.Text = address.Text
                    = enrollement_date.Text = String.Empty;
            picture.Image = null;
            picture.Image = Image.FromFile("..\\..\\..\\Icons\\user.png");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchid.Text))
            {
                if (MessageBox.Show($"Are you sure to delete student with ID: {newid.Text}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                     List<int> id = new List<int>();
                    id.Add(Convert.ToInt32(newid.Text));
                    SYS.RemoveStudent(id);
                    ClearFormBoxes();

                }
            }
            else
            {
                MessageBox.Show("Please add value for ID");
            }


        }
    }
}
