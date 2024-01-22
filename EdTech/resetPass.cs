using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace EdTech
{
    public partial class resetPass : Form
    {
        private readonly resetPassRepo resetrepo;
        private int ID = 0;
        public resetPass()
        {
            InitializeComponent();
            password1.Enabled = false;
            password2.Enabled = false;
            resetrepo = new resetPassRepo();
        }
        private static bool IsStrongPassword(string password)
        {
            // Minimum length requirement
            if (password.Length < 8)
                return false;

            // Check for at least one uppercase letter
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Check for at least one lowercase letter
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // Check for at least one digit
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // Check for at least one special character
            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
                return false;
            // All criteria passed, password is strong
            return true;
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(username.Text) && !String.IsNullOrEmpty(phrase.Text))
            {
                List<string> errors = new List<string>();

                if (int.TryParse(phrase.Text, out _))
                {
                    errors.Add("Invalid data type for Phrase");

                }
                if (int.TryParse(username.Text, out _) )
                {
                    errors.Add("Invalid data type for User Name");

                }
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ID = resetrepo.findUser(username.Text.ToString(), phrase.Text.ToString());
                    if (ID != 0)
                    {
                        username.Enabled = false;
                        phrase.Enabled = false;
                        password1.Enabled = true;
                        password2.Enabled = true;
                        MessageBox.Show($"{ID}");
                    }
                    else
                    {
                        MessageBox.Show($"User with name: {username.Text} don't exist.");
                    }

                }


            }
            else
            {
                MessageBox.Show("Please fill both box.");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {


            if (!String.IsNullOrEmpty(password1.Text) && !String.IsNullOrEmpty(password2.Text))
            {
                if (password1.Text == password2.Text)
                {


                    if (IsStrongPassword(password1.Text.ToString()))
                    {
                        if(resetrepo.updatepass(ID, password1.Text.ToString()))
                        {
                            MessageBox.Show("You Password hass been reset.");
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("resetting your password was unsuccessful.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please type a strong Password that includes:\nA length of 8 letters.\nAtleast 1 uppercase, lowercase letter.\n1 digit and special charactor.");

                    }
                }
                else
                {
                    MessageBox.Show("Your passwords don't match.");
                }
            }
            else
            {
                MessageBox.Show("Please fill both box of password.");
            }



        }
    }
}
