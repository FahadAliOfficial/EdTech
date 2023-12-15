namespace EdTech
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Dashboard res = new EdTech.Dashboard())
            {
                res.ShowDialog();
            }
        }
    }
}