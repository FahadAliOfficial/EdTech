namespace EdTech
{
    partial class Add_New_Employee
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
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            button2 = new Button();
            picture = new PictureBox();
            gender = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            qualification = new TextBox();
            label1 = new Label();
            name = new TextBox();
            id = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label8 = new Label();
            cnic = new TextBox();
            label9 = new Label();
            address = new TextBox();
            disability = new TextBox();
            label10 = new Label();
            label11 = new Label();
            cdisability = new ComboBox();
            age = new TextBox();
            label12 = new Label();
            dob = new DateTimePicker();
            status = new ComboBox();
            label14 = new Label();
            role = new TextBox();
            salary = new TextBox();
            label15 = new Label();
            pn = new TextBox();
            label16 = new Label();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.SteelBlue;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(568, 681);
            button4.Name = "button4";
            button4.Size = new Size(156, 67);
            button4.TabIndex = 104;
            button4.Text = "Close";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(406, 681);
            button3.Name = "button3";
            button3.Size = new Size(156, 67);
            button3.TabIndex = 103;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.SteelBlue;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(244, 681);
            button5.Name = "button5";
            button5.Size = new Size(156, 67);
            button5.TabIndex = 102;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SteelBlue;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(244, 209);
            button2.Name = "button2";
            button2.Size = new Size(173, 67);
            button2.TabIndex = 101;
            button2.Text = "Brows";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // picture
            // 
            picture.Image = Properties.Resources.user;
            picture.Location = new Point(45, 119);
            picture.Name = "picture";
            picture.Size = new Size(175, 157);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabIndex = 100;
            picture.TabStop = false;
            // 
            // gender
            // 
            gender.AutoCompleteCustomSource.AddRange(new string[] { "Male", "Female" });
            gender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            gender.AutoCompleteSource = AutoCompleteSource.CustomSource;
            gender.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gender.FormattingEnabled = true;
            gender.Items.AddRange(new object[] { "Male", "Female" });
            gender.Location = new Point(244, 537);
            gender.Name = "gender";
            gender.Size = new Size(257, 38);
            gender.TabIndex = 98;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(45, 589);
            label6.Name = "label6";
            label6.Size = new Size(80, 30);
            label6.TabIndex = 82;
            label6.Text = "D.O.B";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(560, 437);
            label7.Name = "label7";
            label7.Size = new Size(178, 30);
            label7.TabIndex = 81;
            label7.Text = "Martial Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(45, 535);
            label4.Name = "label4";
            label4.Size = new Size(111, 30);
            label4.TabIndex = 80;
            label4.Text = "Gender:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(45, 433);
            label5.Name = "label5";
            label5.Size = new Size(175, 30);
            label5.TabIndex = 79;
            label5.Text = "Qualification:";
            // 
            // qualification
            // 
            qualification.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            qualification.Location = new Point(244, 430);
            qualification.Name = "qualification";
            qualification.Size = new Size(257, 37);
            qualification.TabIndex = 76;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(350, 27);
            label1.Name = "label1";
            label1.Size = new Size(315, 34);
            label1.TabIndex = 0;
            label1.Text = "Employee Registration";
            // 
            // name
            // 
            name.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            name.Location = new Point(244, 377);
            name.Name = "name";
            name.Size = new Size(257, 37);
            name.TabIndex = 75;
            // 
            // id
            // 
            id.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            id.Location = new Point(244, 323);
            id.Name = "id";
            id.Size = new Size(257, 37);
            id.TabIndex = 74;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(45, 377);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 73;
            label3.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 323);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 72;
            label2.Text = "Employee ID:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(10, 783);
            panel4.Name = "panel4";
            panel4.Size = new Size(1031, 10);
            panel4.TabIndex = 71;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1041, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 718);
            panel3.TabIndex = 70;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 718);
            panel2.TabIndex = 69;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1051, 75);
            panel1.TabIndex = 68;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(45, 484);
            label8.Name = "label8";
            label8.Size = new Size(84, 30);
            label8.TabIndex = 107;
            label8.Text = "CNIC:";
            // 
            // cnic
            // 
            cnic.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cnic.Location = new Point(244, 481);
            cnic.Name = "cnic";
            cnic.Size = new Size(257, 37);
            cnic.TabIndex = 106;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(560, 485);
            label9.Name = "label9";
            label9.Size = new Size(105, 30);
            label9.TabIndex = 109;
            label9.Text = "Address";
            // 
            // address
            // 
            address.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            address.Location = new Point(759, 482);
            address.Name = "address";
            address.Size = new Size(257, 37);
            address.TabIndex = 108;
            // 
            // disability
            // 
            disability.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            disability.Location = new Point(759, 581);
            disability.Name = "disability";
            disability.Size = new Size(257, 37);
            disability.TabIndex = 108;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(560, 584);
            label10.Name = "label10";
            label10.Size = new Size(104, 30);
            label10.TabIndex = 109;
            label10.Text = "Explain:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(560, 528);
            label11.Name = "label11";
            label11.Size = new Size(118, 30);
            label11.TabIndex = 80;
            label11.Text = "Disability";
            // 
            // cdisability
            // 
            cdisability.AutoCompleteCustomSource.AddRange(new string[] { "No", "Yes" });
            cdisability.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cdisability.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cdisability.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cdisability.FormattingEnabled = true;
            cdisability.Items.AddRange(new object[] { "No", "Yes" });
            cdisability.Location = new Point(759, 530);
            cdisability.Name = "cdisability";
            cdisability.Size = new Size(257, 38);
            cdisability.TabIndex = 98;
            // 
            // age
            // 
            age.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            age.Location = new Point(759, 380);
            age.Name = "age";
            age.Size = new Size(257, 37);
            age.TabIndex = 111;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(560, 383);
            label12.Name = "label12";
            label12.Size = new Size(69, 30);
            label12.TabIndex = 110;
            label12.Text = "Age:";
            // 
            // dob
            // 
            dob.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dob.Format = DateTimePickerFormat.Short;
            dob.Location = new Point(244, 589);
            dob.Name = "dob";
            dob.Size = new Size(257, 37);
            dob.TabIndex = 112;
            // 
            // status
            // 
            status.AutoCompleteCustomSource.AddRange(new string[] { "Single", "Married", "Divorced" });
            status.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            status.AutoCompleteSource = AutoCompleteSource.CustomSource;
            status.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            status.FormattingEnabled = true;
            status.Items.AddRange(new object[] { "Single", "Married", "Divorced" });
            status.Location = new Point(759, 434);
            status.Name = "status";
            status.Size = new Size(257, 38);
            status.TabIndex = 113;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(560, 330);
            label14.Name = "label14";
            label14.Size = new Size(73, 30);
            label14.TabIndex = 110;
            label14.Text = "Role:";
            // 
            // role
            // 
            role.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            role.Location = new Point(759, 327);
            role.Name = "role";
            role.Size = new Size(257, 37);
            role.TabIndex = 111;
            // 
            // salary
            // 
            salary.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            salary.Location = new Point(759, 276);
            salary.Name = "salary";
            salary.Size = new Size(257, 37);
            salary.TabIndex = 115;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(560, 279);
            label15.Name = "label15";
            label15.Size = new Size(90, 30);
            label15.TabIndex = 114;
            label15.Text = "Salary:";
            // 
            // pn
            // 
            pn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pn.Location = new Point(759, 223);
            pn.Name = "pn";
            pn.Size = new Size(257, 37);
            pn.TabIndex = 117;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(560, 226);
            label16.Name = "label16";
            label16.Size = new Size(199, 30);
            label16.TabIndex = 116;
            label16.Text = "Phone Number:";
            // 
            // Add_New_Employee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 793);
            Controls.Add(pn);
            Controls.Add(label16);
            Controls.Add(salary);
            Controls.Add(label15);
            Controls.Add(status);
            Controls.Add(dob);
            Controls.Add(role);
            Controls.Add(age);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(disability);
            Controls.Add(label9);
            Controls.Add(address);
            Controls.Add(label8);
            Controls.Add(cnic);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(picture);
            Controls.Add(cdisability);
            Controls.Add(gender);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label11);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(qualification);
            Controls.Add(name);
            Controls.Add(id);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Add_New_Employee";
            Text = "Add_New_Employee";
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Button button3;
        private Button button5;
        private Button button2;
        private PictureBox picture;
        private ComboBox gender;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label5;
        private TextBox qualification;
        private Label label1;
        private TextBox name;
        private TextBox id;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label8;
        private TextBox cnic;
        private Label label9;
        private TextBox address;
        private TextBox disability;
        private Label label10;
        private Label label11;
        private ComboBox cdisability;
        private TextBox age;
        private Label label12;
        private DateTimePicker dob;
        private ComboBox status;
        private Label label14;
        private TextBox role;
        private TextBox salary;
        private Label label15;
        private TextBox pn;
        private Label label16;
    }
}