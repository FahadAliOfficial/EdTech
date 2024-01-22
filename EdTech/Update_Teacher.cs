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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Drawing.Imaging;
using System.Reflection;

namespace EdTech
{
    public partial class Update_Teacher : Form
    {
        TeacherRepo SYS;
        public Update_Teacher(TeacherRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            this.FormClosing += Update_Teacher_FormClosing;
            disability.Enabled = false;
            cdisability.SelectedIndexChanged += cdisability_Enabled;
            cdeparturedate.CheckedChanged += cdeparturedate_CheckedChanged;

        }
        private void cdisability_Enabled(object sender, EventArgs e)
        {
            if (cdisability.SelectedItem != null && cdisability.SelectedItem.ToString() == "Yes")
            {
                disability.Enabled = true;
            }
            else
            {
                disability.Enabled = false;
            }
        }
        private void Update_Teacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void cdeparturedate_CheckedChanged(object sender, EventArgs e)
        {
            if (cdeparturedate.Checked)
            {
                departuredate.Enabled = true;
            }
            else
            {
                departuredate.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(searchid.Text))
            {

                if (!int.TryParse(searchid.Text, out _))
                {
                    MessageBox.Show("Invalid data type for New Teacheer ID");

                }

                else
                {

                    bool c = false;
                    foreach (Teacher tt in SYS.Teachers)
                    {
                        if (tt.TeacherID == Convert.ToInt32(searchid.Text))
                        {

                            newid.Text = tt.TeacherID.ToString();
                            name.Text = tt.Name.ToString();
                            age.Text = tt.Age.ToString();
                            gender.Text = tt.Gender.ToString();
                            cnic.Text = tt.CNIC.ToString();
                            if (disability.Text != null)
                            {
                                cdisability.Enabled = true;
                                cdisability.SelectedIndex = 1;
                                disability.Text = tt.Disablity;
                            }
                            else
                            {
                                cdisability.SelectedIndex = 0;
                            }
                            dob.Text = tt.DOB.ToString();
                            role.Text = tt.Role.ToString();
                            qualification.Text = tt.Qualification.ToString();
                            inchargeship.Text = tt.InchargeShip.ToString();
                            address.Text = tt.Address.ToString();
                            pn.Text = tt.Phone_Number.ToString();
                            joiningdate.Text = tt.Joining_Date.ToString();
                            if (tt.DepartureDate == null)
                            {
                                cdeparturedate.Checked = false;
                                departuredate.Enabled = false;
                            }
                            else
                            {
                                cdeparturedate.Checked = true;
                                departuredate.Enabled = true;
                                departuredate.Value = tt.DepartureDate.Value;
                            }
                            byte[] photo = tt.Photo;

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
                        MessageBox.Show("We were not able to locate the Teacher");
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(newid.Text) && !String.IsNullOrEmpty(cnic.Text)
              && !String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(age.Text)
              && !String.IsNullOrEmpty(dob.Text)
              && !String.IsNullOrEmpty(gender.Text) 
              && !String.IsNullOrEmpty(qualification.Text) && !String.IsNullOrEmpty(address.Text)
              && !String.IsNullOrEmpty(pn.Text))
            {

                List<string> errors = new List<string>();


                if (!int.TryParse(newid.Text, out _))
                {
                    errors.Add("Invalid data type for New ID");
                }

                if (int.TryParse(name.Text, out _))
                {
                    errors.Add("Invalid data type for Name");
                }

                if (!int.TryParse(age.Text, out _))
                {
                    errors.Add("Invalid data type for Age");
                }

                if (int.TryParse(disability.Text, out _))
                {
                    errors.Add("Invalid data type for Disability");
                }

                if (int.TryParse(gender.Text, out _) || !gender.Items.Contains(gender.Text))
                {
                    errors.Add("Invalid data for Gender");
                }

                if (!long.TryParse(cnic.Text, out _))
                {
                    errors.Add("Invalid data type for Cnic");
                }

                if (!long.TryParse(pn.Text, out _))
                {
                    errors.Add("Invalid data type for Phone Number");
                }

                if (int.TryParse(role.Text, out _))
                {
                    errors.Add("Invalid data type for Role");
                }

                if (int.TryParse(qualification.Text, out _))
                {
                    errors.Add("Invalid data type for Qualification");
                }

                if (!int.TryParse(inchargeship.Text, out _) || !inchargeship.Items.Contains(Convert.ToInt32(inchargeship.Text)))
                {
                    errors.Add("Invalid data for InchargerShip");
                }

                if (int.TryParse(address.Text, out _))
                {
                    errors.Add("Invalid data type for Address");
                }


                if (errors.Count > 0)
                {
                    // Display individual error messages
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] img = ConvertToByte(picture.Image);


                    Teacher t = new Teacher
                    {
                        TeacherID = Convert.ToInt32(newid.Text),
                        Name = name.Text.ToString(),
                        Age = Convert.ToInt32(age.Text),
                        Gender = gender.Text.ToString(),
                        CNIC = Convert.ToInt64(cnic.Text),
                        Disablity = disability.Text.ToString(),
                        DOB = Convert.ToDateTime(dob.Text),
                        Role = role.Text.ToString(),
                        Qualification = qualification.Text.ToString(),
                        InchargeShip = Convert.ToInt32(inchargeship.Text),
                        Address = address.Text.ToString(),
                        Phone_Number = Convert.ToInt64(pn.Text),
                        Photo = img,
                        Joining_Date = Convert.ToDateTime(joiningdate.Text),
                        DepartureDate = DateTime.TryParse(departuredate.Text.ToString(), out var dd) ? (DateTime?)dd : null

                    };
                    foreach (Teacher teacher in SYS.Teachers)
                    {
                        if (t.TeacherID == teacher.TeacherID && searchid.Text != newid.Text)
                        {
                            MessageBox.Show($"Teacher with iD: {newid.Text} already exits");
                            return;
                        }
                    }
                    SYS.UpdateTeacher(Convert.ToInt32(searchid.Text), t);
                    MessageBox.Show($"Teacher with ID: {searchid.Text}, having new ID: {newid} has been updated");
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Please Fill all boxes.");
            }
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
        private void ClearTextBoxes()
        {
            searchid.Text = newid.Text = name.Text = age.Text = cnic.Text = disability.Text = dob.Text =
                role.Text =  qualification.Text = address.Text = pn.Text = String.Empty;

            gender.SelectedIndex = inchargeship.SelectedIndex = 0;
            //disability.Enabled = false;
            picture.Image = null;
            picture.Image = Image.FromFile("..\\..\\..\\Icons\\user.png");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(newid.Text))
            {
                if (MessageBox.Show($"Are you sure to delete Teacher with new Id: {newid.Text}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<int> id = new List<int>();
                    foreach (Teacher tt in SYS.Teachers)
                    {
                        if (Convert.ToInt32(tt.TeacherID) == Convert.ToInt32(newid.Text))
                        {
                            id.Add(Convert.ToInt32(tt.TeacherID));
                            SYS.RemoveTeacher(id);
                        }
                    }
                    if (id.Count == 0)
                    {
                        MessageBox.Show($"Teacher With ID: {newid.Text} don't exists.");
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
