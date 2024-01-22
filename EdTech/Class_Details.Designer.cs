namespace EdTech
{
    partial class Class_Details
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel6 = new Panel();
            GridViewClasses = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            panel5 = new Panel();
            button5 = new Button();
            label1 = new Label();
            button4 = new Button();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            button6 = new Button();
            label2 = new Label();
            showall = new Button();
            name = new TextBox();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridViewClasses).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Controls.Add(GridViewClasses);
            panel6.Location = new Point(12, 243);
            panel6.Name = "panel6";
            panel6.Size = new Size(1105, 418);
            panel6.TabIndex = 20;
            // 
            // GridViewClasses
            // 
            GridViewClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridViewClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewClasses.Dock = DockStyle.Fill;
            GridViewClasses.Location = new Point(0, 0);
            GridViewClasses.Name = "GridViewClasses";
            GridViewClasses.RowHeadersWidth = 62;
            GridViewClasses.RowTemplate.Height = 33;
            GridViewClasses.Size = new Size(1105, 418);
            GridViewClasses.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(583, 88);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(256, 64);
            button3.TabIndex = 18;
            button3.Text = "Delete Class";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SteelBlue;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(304, 88);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(256, 64);
            button2.TabIndex = 17;
            button2.Text = "Update Class";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(30, 88);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(256, 64);
            button1.TabIndex = 16;
            button1.Text = "Add Class";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(12, 171);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 10);
            panel1.TabIndex = 15;
            // 
            // panel5
            // 
            panel5.BackColor = Color.SteelBlue;
            panel5.Controls.Add(button5);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(12, 0);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1105, 72);
            panel5.TabIndex = 14;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(1031, 12);
            button5.Name = "button5";
            button5.Size = new Size(74, 48);
            button5.TabIndex = 10;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(455, 19);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(184, 34);
            label1.TabIndex = 4;
            label1.Text = "Class Details";
            // 
            // button4
            // 
            button4.BackColor = Color.SteelBlue;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(861, 88);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(116, 64);
            button4.TabIndex = 19;
            button4.Text = "Print";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(12, 661);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1105, 9);
            panel4.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1117, 0);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(12, 670);
            panel3.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(12, 670);
            panel2.TabIndex = 11;
            // 
            // button6
            // 
            button6.BackColor = Color.SteelBlue;
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(986, 196);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(123, 34);
            button6.TabIndex = 21;
            button6.Text = "Search";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(595, 200);
            label2.Name = "label2";
            label2.Size = new Size(187, 21);
            label2.TabIndex = 22;
            label2.Text = "Search Class By Grade:";
            // 
            // showall
            // 
            showall.BackColor = Color.SteelBlue;
            showall.FlatAppearance.BorderSize = 2;
            showall.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            showall.FlatStyle = FlatStyle.Flat;
            showall.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point);
            showall.ForeColor = Color.White;
            showall.Location = new Point(30, 203);
            showall.Margin = new Padding(4, 3, 4, 3);
            showall.Name = "showall";
            showall.Size = new Size(123, 34);
            showall.TabIndex = 29;
            showall.Text = "Show All";
            showall.UseVisualStyleBackColor = false;
            showall.Click += showall_Click;
            // 
            // name
            // 
            name.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            name.Location = new Point(785, 196);
            name.Name = "name";
            name.Size = new Size(180, 32);
            name.TabIndex = 23;
            // 
            // Class_Details
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 670);
            Controls.Add(showall);
            Controls.Add(name);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(panel6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(button4);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Class_Details";
            Text = "Class_Details";
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridViewClasses).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel6;
        private DataGridView GridViewClasses;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel1;
        private Panel panel5;
        private Button button5;
        private Label label1;
        private Button button4;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Button button6;
        private Label label2;
        private Button showall;
        private TextBox name;
    }
}