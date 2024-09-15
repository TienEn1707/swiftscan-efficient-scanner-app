namespace EasyMart
{
    partial class RegisterPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPage));
            this.lbLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btCreate = new System.Windows.Forms.Button();
            this.checkShow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbConPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.richAddress = new System.Windows.Forms.RichTextBox();
            this.radioMan = new System.Windows.Forms.RadioButton();
            this.radioWoman = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.numericAge = new System.Windows.Forms.NumericUpDown();
            this.dateBirth = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAge)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogin.Font = new System.Drawing.Font("Nirmala UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.ForeColor = System.Drawing.Color.Orange;
            this.lbLogin.Location = new System.Drawing.Point(628, 594);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(53, 21);
            this.lbLogin.TabIndex = 31;
            this.lbLogin.Text = "Login";
            this.lbLogin.Click += new System.EventHandler(this.lbLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 594);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Already Have an Account?";
            // 
            // btCreate
            // 
            this.btCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCreate.ForeColor = System.Drawing.Color.Black;
            this.btCreate.Location = new System.Drawing.Point(482, 539);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(170, 35);
            this.btCreate.TabIndex = 26;
            this.btCreate.Text = "Create Account";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // checkShow
            // 
            this.checkShow.AutoSize = true;
            this.checkShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkShow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkShow.Location = new System.Drawing.Point(599, 487);
            this.checkShow.Name = "checkShow";
            this.checkShow.Size = new System.Drawing.Size(118, 21);
            this.checkShow.TabIndex = 23;
            this.checkShow.Text = "Show Password";
            this.checkShow.UseVisualStyleBackColor = true;
            this.checkShow.CheckedChanged += new System.EventHandler(this.checkShow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(498, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "REGISTER";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 661);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EasyMart.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(567, 480);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 1);
            this.panel4.TabIndex = 34;
            // 
            // tbConPassword
            // 
            this.tbConPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbConPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbConPassword.ForeColor = System.Drawing.Color.White;
            this.tbConPassword.Location = new System.Drawing.Point(567, 452);
            this.tbConPassword.Name = "tbConPassword";
            this.tbConPassword.PasswordChar = '•';
            this.tbConPassword.Size = new System.Drawing.Size(150, 22);
            this.tbConPassword.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Confirm Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Password :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(567, 436);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(150, 1);
            this.panel5.TabIndex = 37;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.ForeColor = System.Drawing.Color.White;
            this.tbPassword.Location = new System.Drawing.Point(567, 408);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(150, 22);
            this.tbPassword.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 21);
            this.label5.TabIndex = 41;
            this.label5.Text = "Username :";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(567, 392);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 1);
            this.panel6.TabIndex = 40;
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUsername.ForeColor = System.Drawing.Color.White;
            this.tbUsername.Location = new System.Drawing.Point(567, 364);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(150, 22);
            this.tbUsername.TabIndex = 39;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(567, 348);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(150, 1);
            this.panel7.TabIndex = 43;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(567, 320);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 22);
            this.textBox4.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 45;
            this.label7.Text = "Address :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 48;
            this.label8.Text = "Gender :";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(567, 279);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(150, 1);
            this.panel8.TabIndex = 47;
            // 
            // richAddress
            // 
            this.richAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.richAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richAddress.ForeColor = System.Drawing.Color.White;
            this.richAddress.Location = new System.Drawing.Point(567, 291);
            this.richAddress.Name = "richAddress";
            this.richAddress.Size = new System.Drawing.Size(150, 55);
            this.richAddress.TabIndex = 49;
            this.richAddress.Text = "";
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioMan.Location = new System.Drawing.Point(567, 248);
            this.radioMan.Name = "radioMan";
            this.radioMan.Size = new System.Drawing.Size(59, 25);
            this.radioMan.TabIndex = 50;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "Man";
            this.radioMan.UseVisualStyleBackColor = true;
            // 
            // radioWoman
            // 
            this.radioWoman.AutoSize = true;
            this.radioWoman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioWoman.Location = new System.Drawing.Point(634, 248);
            this.radioWoman.Name = "radioWoman";
            this.radioWoman.Size = new System.Drawing.Size(83, 25);
            this.radioWoman.TabIndex = 51;
            this.radioWoman.TabStop = true;
            this.radioWoman.Text = "Woman";
            this.radioWoman.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 21);
            this.label6.TabIndex = 57;
            this.label6.Text = "Age :";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(567, 195);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(150, 1);
            this.panel9.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(417, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 21);
            this.label9.TabIndex = 54;
            this.label9.Text = "Date of Birth :";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Location = new System.Drawing.Point(567, 239);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(150, 1);
            this.panel10.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(417, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 21);
            this.label10.TabIndex = 60;
            this.label10.Text = "Name :";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Location = new System.Drawing.Point(567, 151);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(150, 1);
            this.panel11.TabIndex = 59;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.ForeColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(567, 123);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 22);
            this.tbName.TabIndex = 58;
            // 
            // numericAge
            // 
            this.numericAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.numericAge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericAge.ForeColor = System.Drawing.Color.White;
            this.numericAge.Location = new System.Drawing.Point(567, 164);
            this.numericAge.Name = "numericAge";
            this.numericAge.Size = new System.Drawing.Size(150, 29);
            this.numericAge.TabIndex = 61;
            // 
            // dateBirth
            // 
            this.dateBirth.CalendarForeColor = System.Drawing.Color.White;
            this.dateBirth.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.dateBirth.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateBirth.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dateBirth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirth.Location = new System.Drawing.Point(567, 208);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Size = new System.Drawing.Size(150, 29);
            this.dateBirth.TabIndex = 62;
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.dateBirth);
            this.Controls.Add(this.numericAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.radioWoman);
            this.Controls.Add(this.radioMan);
            this.Controls.Add(this.richAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tbConPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.checkShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "RegisterPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyMart - Register";
            this.Load += new System.EventHandler(this.RegisterPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.CheckBox checkShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbConPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RichTextBox richAddress;
        private System.Windows.Forms.RadioButton radioMan;
        private System.Windows.Forms.RadioButton radioWoman;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.NumericUpDown numericAge;
        private System.Windows.Forms.DateTimePicker dateBirth;
    }
}