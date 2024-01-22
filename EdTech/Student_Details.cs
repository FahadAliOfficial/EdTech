using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdTech
{
    public partial class Student_Details : Form
    {

        StudentRepo SYS;
        List<Student> students;
        List<int> sGrades;
        public Student_Details(StudentRepo s)
        {
            InitializeComponent();
            SYS = s;
            students = new List<Student>();
            sGrades = new List<int>();
            sGrades = SYS.getClassNumbers();
            grade.DataSource = sGrades;
            grade.DisplayMember = "ToString";
            grade.SelectedIndex = 0;
            LoadStudents();
            this.FormClosing += Student_Details_Closing;


        }
        private void Student_Details_Closing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void LoadStudents()
        {
            if (SYS != null)
            {

                students = SYS.GetAllStudents();

                if (GrideViewStudents != null)
                {
                    GrideViewStudents.DataSource = null;
                    GrideViewStudents.DataSource = students;
                    GrideViewStudents.Refresh();
                }
                else
                {
                    MessageBox.Show("Data Grid is not Initialized");
                }
            }
            else
            {
                MessageBox.Show("Student Repository is not Initialized");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Add_New_Student res = new EdTech.Add_New_Student(SYS))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadStudents();
                    this.Show();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Update_Student res = new EdTech.Update_Student(SYS))
            {
                this.Hide();
                res.ShowDialog();
                if (res.DialogResult == DialogResult.OK)
                {
                    LoadStudents();
                    this.Show();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> selectedId = new List<int>();
            if (GrideViewStudents.SelectedRows.Count > 0)
            {
                // Student selectedRecord = (Student)GrideViewStudents.SelectedRows[0].DataBoundItem;
                foreach (DataGridViewRow row in GrideViewStudents.SelectedRows)
                {
                    selectedId.Add((int)row.Cells["Student_ID"].Value);
                }
                DialogResult result = MessageBox.Show($"Are you sure you want to delete records of {selectedId.Count} members?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SYS.RemoveStudent(selectedId);
                    LoadStudents();
                    GrideViewStudents.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Student> ss = new List<Student>();

            foreach (Student s in students)
            {
                if (s.Name == name.Text.ToString() && s.Std_Class.ToString() == grade.SelectedValue.ToString())
                {
                    ss.Add(s);
                }
            }
            GrideViewStudents.DataSource = null;
            GrideViewStudents.DataSource = ss;
            GrideViewStudents.Refresh();

        }

        private void showall_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Subscribe to the PrintPage event
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            // Open the print preview dialog
            using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
            {
                printPreviewDialog.Document = printDocument1;
                printPreviewDialog.ShowDialog();
            }

            // Unsubscribe from the PrintPage event to avoid multiple subscriptions
            printDocument1.PrintPage -= printDocument1_PrintPage;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up printing dimensions based on A4 size
            int pageWidth = (int)e.PageSettings.PrintableArea.Width;
            int pageHeight = (int)e.PageSettings.PrintableArea.Height;

            // Set background color for the entire page
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Calculate the number of rows that fit into the printable area
            int rowsPerPage = pageHeight / GrideViewStudents.RowTemplate.Height;

            // Calculate the total width required for all columns
            int totalWidth = 0;
            foreach (DataGridViewColumn col in GrideViewStudents.Columns)
            {
                totalWidth += col.Width;
            }

            // Calculate the scaling factor to fit the content on the page
            float scale = Math.Min(pageWidth / totalWidth, 1f);

            // Calculate the adjusted row height
            int adjustedRowHeight = (int)(GrideViewStudents.RowTemplate.Height * scale);

            // Initialize coordinates
            int xPos = 0;
            int yPos = 0;

            // Print column names
            foreach (DataGridViewColumn col in GrideViewStudents.Columns)
            {
                int colWidth = (int)(col.Width * scale);

                Rectangle cellRect = new Rectangle(xPos, yPos, colWidth, adjustedRowHeight);
                e.Graphics.FillRectangle(Brushes.LightGray, cellRect);
                e.Graphics.DrawRectangle(Pens.Black, cellRect);
                e.Graphics.DrawString(col.HeaderText, GrideViewStudents.Font, Brushes.Black, cellRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                xPos += colWidth;
            }

            // Move to the next line
            yPos += adjustedRowHeight;

            // Print data
            foreach (DataGridViewRow row in GrideViewStudents.Rows)
            {
                xPos = 0;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    int colWidth = (int)(GrideViewStudents.Columns[cell.ColumnIndex].Width * scale);

                    Rectangle cellRect = new Rectangle(xPos, yPos, colWidth, adjustedRowHeight);
                    e.Graphics.DrawRectangle(Pens.Black, cellRect);
                    e.Graphics.DrawString(cell.FormattedValue.ToString(), GrideViewStudents.Font, Brushes.Black, cellRect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });

                    xPos += colWidth;
                }

                // Move to the next line
                yPos += adjustedRowHeight;
            }
        }




    }
}
