namespace EdTech
{
    partial class resetPass
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
            search = new Button();
            close = new Button();
            reset = new Button();
            label1 = new Label();
            username = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label4 = new Label();
            phrase = new TextBox();
            password1 = new TextBox();
            password2 = new TextBox();
            label6 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // search
            // 
            search.BackColor = Color.SteelBlue;
            search.FlatAppearance.BorderSize = 2;
            search.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            search.FlatStyle = FlatStyle.Flat;
            search.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            search.ForeColor = Color.White;
            search.Location = new Point(447, 282);
            search.Name = "search";
            search.Size = new Size(156, 44);
            search.TabIndex = 3;
            search.Text = "Search";
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // close
            // 
            close.BackColor = Color.SteelBlue;
            close.FlatAppearance.BorderSize = 2;
            close.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            close.FlatStyle = FlatStyle.Flat;
            close.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            close.ForeColor = Color.White;
            close.Location = new Point(346, 566);
            close.Name = "close";
            close.Size = new Size(156, 67);
            close.TabIndex = 7;
            close.Text = "Close";
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // reset
            // 
            reset.BackColor = Color.SteelBlue;
            reset.FlatAppearance.BorderSize = 2;
            reset.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            reset.FlatStyle = FlatStyle.Flat;
            reset.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            reset.ForeColor = Color.White;
            reset.Location = new Point(164, 566);
            reset.Name = "reset";
            reset.Size = new Size(156, 67);
            reset.TabIndex = 6;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = false;
            reset.Click += reset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(266, 29);
            label1.Name = "label1";
            label1.Size = new Size(220, 34);
            label1.TabIndex = 0;
            label1.Text = "Reset Password";
            // 
            // username
            // 
            username.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(346, 170);
            username.Name = "username";
            username.Size = new Size(257, 37);
            username.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(80, 173);
            label2.Name = "label2";
            label2.Size = new Size(150, 30);
            label2.TabIndex = 133;
            label2.Text = "User Name:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(10, 670);
            panel4.Name = "panel4";
            panel4.Size = new Size(706, 10);
            panel4.TabIndex = 132;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(716, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 605);
            panel3.TabIndex = 131;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 605);
            panel2.TabIndex = 130;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(726, 75);
            panel1.TabIndex = 129;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(89, 395);
            label4.Name = "label4";
            label4.Size = new Size(129, 30);
            label4.TabIndex = 134;
            label4.Text = "Password:";
            // 
            // phrase
            // 
            phrase.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phrase.Location = new Point(346, 222);
            phrase.Name = "phrase";
            phrase.Size = new Size(257, 37);
            phrase.TabIndex = 2;
            // 
            // password1
            // 
            password1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            password1.Location = new Point(346, 392);
            password1.Name = "password1";
            password1.Size = new Size(257, 37);
            password1.TabIndex = 4;
            // 
            // password2
            // 
            password2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            password2.Location = new Point(346, 445);
            password2.Name = "password2";
            password2.Size = new Size(257, 37);
            password2.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(89, 448);
            label6.Name = "label6";
            label6.Size = new Size(231, 30);
            label6.TabIndex = 140;
            label6.Text = "Re-Type Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(80, 222);
            label3.Name = "label3";
            label3.Size = new Size(180, 30);
            label3.TabIndex = 134;
            label3.Text = "Secret Phrase:";
            // 
            // resetPass
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 680);
            Controls.Add(search);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(label6);
            Controls.Add(password2);
            Controls.Add(password1);
            Controls.Add(phrase);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(username);
            Controls.Add(label2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "resetPass";
            Text = "Reset_Pass";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button search;
        private Button close;
        private Button reset;
        private Label label1;
        private TextBox username;
        private Label label2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label4;
        private TextBox phrase;
        private TextBox password1;
        private TextBox password2;
        private Label label6;
        private Label label3;
    }
}