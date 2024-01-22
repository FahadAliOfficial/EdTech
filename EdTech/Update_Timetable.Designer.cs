namespace EdTech
{
    partial class Update_Timetable
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
            endtime = new DateTimePicker();
            starttime = new DateTimePicker();
            day = new ComboBox();
            classname = new ComboBox();
            label3 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            subject = new TextBox();
            label6 = new Label();
            label2 = new Label();
            durationtime = new DateTimePicker();
            label8 = new Label();
            searchgrade = new ComboBox();
            label9 = new Label();
            searchday = new ComboBox();
            label10 = new Label();
            searchsubject = new TextBox();
            panel5 = new Panel();
            button1 = new Button();
            delete = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // endtime
            // 
            endtime.CustomFormat = "hh-mm";
            endtime.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            endtime.Format = DateTimePickerFormat.Custom;
            endtime.Location = new Point(374, 408);
            endtime.Name = "endtime";
            endtime.ShowUpDown = true;
            endtime.Size = new Size(257, 37);
            endtime.TabIndex = 109;
            // 
            // starttime
            // 
            starttime.CustomFormat = "hh-mm";
            starttime.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            starttime.Format = DateTimePickerFormat.Custom;
            starttime.Location = new Point(374, 354);
            starttime.Name = "starttime";
            starttime.ShowUpDown = true;
            starttime.Size = new Size(257, 37);
            starttime.TabIndex = 108;
            starttime.Value = new DateTime(2024, 1, 21, 14, 33, 0, 0);
            // 
            // day
            // 
            day.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            day.AutoCompleteSource = AutoCompleteSource.ListItems;
            day.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            day.FormattingEnabled = true;
            day.Location = new Point(374, 508);
            day.Name = "day";
            day.Size = new Size(257, 38);
            day.TabIndex = 111;
            // 
            // classname
            // 
            classname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            classname.AutoCompleteSource = AutoCompleteSource.ListItems;
            classname.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            classname.FormattingEnabled = true;
            classname.Location = new Point(374, 300);
            classname.Name = "classname";
            classname.Size = new Size(257, 38);
            classname.TabIndex = 107;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(175, 298);
            label3.Name = "label3";
            label3.Size = new Size(96, 30);
            label3.TabIndex = 119;
            label3.Text = "Grade:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(10, 664);
            panel4.Name = "panel4";
            panel4.Size = new Size(793, 10);
            panel4.TabIndex = 118;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(803, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 599);
            panel3.TabIndex = 117;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 599);
            panel2.TabIndex = 116;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(813, 75);
            panel1.TabIndex = 115;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 20);
            label1.Name = "label1";
            label1.Size = new Size(265, 34);
            label1.TabIndex = 0;
            label1.Text = "Update Time Table";
            // 
            // button4
            // 
            button4.BackColor = Color.SteelBlue;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(572, 566);
            button4.Name = "button4";
            button4.Size = new Size(156, 67);
            button4.TabIndex = 114;
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
            button3.Location = new Point(410, 566);
            button3.Name = "button3";
            button3.Size = new Size(156, 67);
            button3.TabIndex = 113;
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
            button5.Location = new Point(87, 566);
            button5.Name = "button5";
            button5.Size = new Size(156, 67);
            button5.TabIndex = 112;
            button5.Text = "Update";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(176, 516);
            label7.Name = "label7";
            label7.Size = new Size(67, 30);
            label7.TabIndex = 123;
            label7.Text = "Day:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(175, 408);
            label4.Name = "label4";
            label4.Size = new Size(128, 30);
            label4.TabIndex = 122;
            label4.Text = "End Time:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(175, 354);
            label5.Name = "label5";
            label5.Size = new Size(135, 30);
            label5.TabIndex = 121;
            label5.Text = "Start Time:";
            // 
            // subject
            // 
            subject.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            subject.Location = new Point(374, 459);
            subject.Name = "subject";
            subject.Size = new Size(257, 37);
            subject.TabIndex = 110;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(175, 462);
            label6.Name = "label6";
            label6.Size = new Size(108, 30);
            label6.TabIndex = 124;
            label6.Text = "Subject:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(176, 255);
            label2.Name = "label2";
            label2.Size = new Size(121, 30);
            label2.TabIndex = 120;
            label2.Text = "Duration:";
            // 
            // durationtime
            // 
            durationtime.CustomFormat = "mm";
            durationtime.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            durationtime.Format = DateTimePickerFormat.Custom;
            durationtime.Location = new Point(374, 248);
            durationtime.Name = "durationtime";
            durationtime.ShowUpDown = true;
            durationtime.Size = new Size(257, 37);
            durationtime.TabIndex = 106;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(26, 96);
            label8.Name = "label8";
            label8.Size = new Size(96, 30);
            label8.TabIndex = 119;
            label8.Text = "Grade:";
            // 
            // searchgrade
            // 
            searchgrade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchgrade.AutoCompleteSource = AutoCompleteSource.ListItems;
            searchgrade.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchgrade.FormattingEnabled = true;
            searchgrade.Location = new Point(176, 96);
            searchgrade.Name = "searchgrade";
            searchgrade.Size = new Size(167, 38);
            searchgrade.TabIndex = 107;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(390, 99);
            label9.Name = "label9";
            label9.Size = new Size(67, 30);
            label9.TabIndex = 123;
            label9.Text = "Day:";
            // 
            // searchday
            // 
            searchday.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchday.AutoCompleteSource = AutoCompleteSource.ListItems;
            searchday.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchday.FormattingEnabled = true;
            searchday.Location = new Point(492, 93);
            searchday.Name = "searchday";
            searchday.Size = new Size(156, 38);
            searchday.TabIndex = 111;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(26, 140);
            label10.Name = "label10";
            label10.Size = new Size(108, 30);
            label10.TabIndex = 124;
            label10.Text = "Subject:";
            // 
            // searchsubject
            // 
            searchsubject.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchsubject.Location = new Point(176, 150);
            searchsubject.Name = "searchsubject";
            searchsubject.Size = new Size(167, 37);
            searchsubject.TabIndex = 110;
            // 
            // panel5
            // 
            panel5.BackColor = Color.SteelBlue;
            panel5.Location = new Point(10, 201);
            panel5.Name = "panel5";
            panel5.Size = new Size(795, 10);
            panel5.TabIndex = 125;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(398, 148);
            button1.Name = "button1";
            button1.Size = new Size(250, 43);
            button1.TabIndex = 126;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // delete
            // 
            delete.BackColor = Color.SteelBlue;
            delete.FlatAppearance.BorderSize = 2;
            delete.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            delete.FlatStyle = FlatStyle.Flat;
            delete.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            delete.ForeColor = Color.White;
            delete.Location = new Point(248, 566);
            delete.Name = "delete";
            delete.Size = new Size(156, 67);
            delete.TabIndex = 113;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // Update_Timetable
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 674);
            Controls.Add(button1);
            Controls.Add(panel5);
            Controls.Add(endtime);
            Controls.Add(durationtime);
            Controls.Add(starttime);
            Controls.Add(searchday);
            Controls.Add(day);
            Controls.Add(searchgrade);
            Controls.Add(classname);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button4);
            Controls.Add(delete);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(searchsubject);
            Controls.Add(subject);
            Controls.Add(label10);
            Controls.Add(label6);
            Name = "Update_Timetable";
            Text = "Update_Timetable";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker endtime;
        private DateTimePicker starttime;
        private ComboBox day;
        private ComboBox classname;
        private Label label3;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private Button button4;
        private Button button3;
        private Button button5;
        private Label label7;
        private Label label4;
        private Label label5;
        private TextBox subject;
        private Label label6;
        private Label label2;
        private DateTimePicker durationtime;
        private Label label8;
        private ComboBox searchgrade;
        private Label label9;
        private ComboBox searchday;
        private Label label10;
        private TextBox searchsubject;
        private Panel panel5;
        private Button button1;
        private Button delete;
    }
}