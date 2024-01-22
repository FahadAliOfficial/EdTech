using System.Data.SqlClient;
namespace EdTech
{
    public partial class Login : Form
    {
        UserRepo userrepo;
        School_Management s;
        public Login(School_Management s)
        {
            InitializeComponent();
            this.s = s;
            userrepo = new UserRepo();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((!String.IsNullOrEmpty(username.Text) && !String.IsNullOrEmpty(password.Text)))
            {

                User u = userrepo.GetUser(username.Text.ToString(), password.Text.ToString());
                if (u != null)
                {
                    using (Dashboard res = new EdTech.Dashboard(u, s))
                    {
                        this.Hide();
                        res.ShowDialog();
                        if (res.DialogResult == DialogResult.OK)
                        {
                            this.Show();
                        }
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            using(resetPass res = new EdTech.resetPass())
            {
                res.ShowDialog();
            }
        }
    }
}