using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdTech
{
    public partial class Add_New_Employee : Form
    {
        StaffRepo SYS;
        List<Staff> staffs;
        public Add_New_Employee(StaffRepo sYS)
        {
            InitializeComponent();
            SYS = sYS;
            staffs = new List<Staff>();
            disability.Enabled = false;
            cdisability.SelectedIndexChanged += cdisability_Enabled;
            this.FormClosing += Add_New_Staff_FormClosing;
        }
        private void ClearTextBoxes()
        {
            id.Text = name.Text = qualification.Text = cnic.Text = pn.Text = salary.Text =
                role.Text = age.Text = address.Text = disability.Text =
                String.Empty;
            gender.SelectedIndex = status.SelectedIndex = cdisability.SelectedIndex = 0;
            picture.Image = null;
            disability.Enabled = false;
            picture.Image = null;
            picture.Image = Image.FromFile("..\\..\\..\\Icons\\user.png");
        }
        private void Add_New_Staff_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                SYS.AddStaff(staffs);
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
        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SYS.AddStaff(staffs);
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                    foreach (Staff s in SYS.Staffs)
                    {
                        if (s.StaffID == Convert.ToInt32(id.Text))
                        {
                            MessageBox.Show($"Staff member with iD: {id.Text} already exits");
                            return;
                        }
                    }

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
                        
                        Joining_Date = DateTime.Now,

                    };
                    staffs.Add(t);
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Please Fill all boxes.");
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
    }
}
