namespace EdTech
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            username = new ComboBox();
            password = new TextBox();
            reset = new Label();
            button1 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(116, 86);
            label1.Name = "label1";
            label1.Size = new Size(561, 39);
            label1.TabIndex = 0;
            label1.Text = "Transformative Solutions for Schools";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(328, 188);
            label2.Name = "label2";
            label2.Size = new Size(99, 38);
            label2.TabIndex = 1;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(116, 272);
            label3.Name = "label3";
            label3.Size = new Size(196, 39);
            label3.TabIndex = 2;
            label3.Text = "User Name:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(116, 368);
            label4.Name = "label4";
            label4.Size = new Size(172, 39);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            // 
            // username
            // 
            username.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            username.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            username.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(343, 272);
            username.Name = "username";
            username.Size = new Size(311, 38);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            password.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            password.Location = new Point(343, 375);
            password.Name = "password";
            password.Size = new Size(311, 37);
            password.TabIndex = 2;
            // 
            // reset
            // 
            reset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            reset.AutoSize = true;
            reset.Cursor = Cursors.Hand;
            reset.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            reset.ForeColor = Color.White;
            reset.Location = new Point(492, 435);
            reset.Name = "reset";
            reset.Size = new Size(162, 23);
            reset.TabIndex = 7;
            reset.Text = "Reset Password";
            reset.Click += reset_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(240, 516);
            button1.Name = "button1";
            button1.Size = new Size(311, 60);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(701, 12);
            button5.Name = "button5";
            button5.Size = new Size(74, 48);
            button5.TabIndex = 11;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(787, 742);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(reset);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox username;
        private TextBox password;
        private Label reset;
        private Button button1;
        private Button button5;
    }
}