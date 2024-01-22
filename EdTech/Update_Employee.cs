using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EdTech
{
    public partial class Update_Employee : Form
    {
        StaffRepo SYS;
        public Update_Employee(StaffRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            this.FormClosing += Add_Update_Staff_FormClosing;
            disability.Enabled = false;
            cdisability.SelectedIndexChanged += cdisability_Enabled;
            cdeparturedate.CheckedChanged += cdeparturedate_CheckedChanged;
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
        private void Add_Update_Staff_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.DialogResult = DialogResult.OK;

            }
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


        private void ClearTextBoxes()
        {
            searchid.Text = id.Text = name.Text = qualification.Text = cnic.Text = pn.Text = salary.Text =
                 role.Text = age.Text = address.Text = disability.Text =
                 String.Empty;
            gender.SelectedIndex = status.SelectedIndex = cdisability.SelectedIndex = 0;
            picture.Image = null;
            disability.Enabled = false;
            picture.Image = null;
            picture.Image = Image.FromFile("..\\..\\..\\Icons\\user.png");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(id.Text) && !String.IsNullOrEmpty(cnic.Text)
            && !String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(age.Text)
            && !String.IsNullOrEmpty(dob.Text)
            && !String.IsNullOrEmpty(gender.Text) && !String.IsNullOrEmpty(salary.Text)
            && !String.IsNullOrEmpty(qualification.Text) && !String.IsNullOrEmpty(address.Text)
            && !String.IsNullOrEmpty(pn.Text))
            {

                List<string> errors = new List<string>();

                if (cdisability.SelectedItem != null && cdisability.SelectedItem.ToString() == "Yes" && disability.Text == "")
                {
                    errors.Add("Please tell us about your disability.");
                }
                if (!int.TryParse(id.Text, out _))
                {
                    errors.Add("Invalid data type for ID");
                }

                if (int.TryParse(name.Text, out _))
                {
                    errors.Add("Invalid data type for Name");
                }

                if (!int.TryParse(age.Text, out _))
                {
                    errors.Add("Invalid data type for Age");
                }
                if (!cdisability.Items.Contains(cdisability.Text))
                {
                    errors.Add("Invalid data for Disability");
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

                if (int.TryParse(status.Text, out _) || !status.Items.Contains(status.Text))
                {
                    errors.Add("Invalid data for Status");
                }

                if (int.TryParse(address.Text, out _))
                {
                    errors.Add("Invalid data type for Address");
                }
                if (!int.TryParse(salary.Text, out _))
                {
                    errors.Add("Invalid data type for Salary");
                }

                if (errors.Count > 0)
                {
                    // Display individual error messages
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] img = ConvertToByte(picture.Image);
                   
                    Staff t = new Staff
                    {
                        StaffID = Convert.ToInt32(id.Text),
                        Name = name.Text.ToString(),
                        Age = Convert.ToInt32(age.Text),
                        Gender = gender.Text.ToString(),
                        CNIC = Convert.ToInt64(cnic.Text),
                        Disablity = disability.Text.ToString(),
                        DOB = Convert.ToDateTime(dob.Text),
                        Role = role.Text.ToString(),
                        Salary = Convert.ToInt32(salary.Text),
                        Qualification = qualification.Text.ToString(),
                        Status = (status.Text).ToString(),
                        Address = address.Text.ToString(),
                        Phone_Number = Convert.ToInt64(pn.Text),
                        Photo = img,
                        DepartureDate = DateTime.TryParse(departuredate.Text.ToString(), out var dd) ? (DateTime?)dd : null,
                        Joining_Date = Convert.ToDateTime(joiningdate.Text),


                    };
                    foreach (Staff s in SYS.Staffs)
                    {
                        if (s.StaffID == t.StaffID && id.Text != searchid.Text)
                        {
                            MessageBox.Show($"Staff member with iD: {id.Text} already exits");
                            return;
                        }
                    }

                    SYS.UpdateStaff(Convert.ToInt32(searchid.Text), t);
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
                    ///img.Save(ms, img.RawFormat);
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }

                return null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
                    foreach (Staff tt in SYS.Staffs)
                    {
                        if (tt.StaffID == Convert.ToInt32(searchid.Text))
                        {

                            id.Text = tt.StaffID.ToString();
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
                            salary.Text = tt.Salary.ToString();
                            qualification.Text = tt.Qualification.ToString();
                            status.Text = tt.Status.ToString();
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
                        MessageBox.Show("We were not able to locate the Employee");
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(id.Text))
            {
                if (MessageBox.Show($"Are you sure to delete Employee with new Id: {id.Text}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<int> ids = new List<int>();
                    foreach (Staff tt in SYS.Staffs)
                    {
                        if (Convert.ToInt32(tt.StaffID) == Convert.ToInt32(id.Text))
                        {
                            ids.Add(Convert.ToInt32(tt.StaffID));
                            SYS.RemoveStaffs(ids);
                        }
                    }
                    if (ids.Count == 0)
                    {
                        MessageBox.Show($"Teacher With ID: {id.Text} don't exists.");
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
