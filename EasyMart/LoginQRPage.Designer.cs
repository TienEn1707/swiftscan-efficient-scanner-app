namespace EasyMart
{
    partial class LoginQRPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginQRPage));
            this.btBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cameraScan = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCodeQR = new System.Windows.Forms.TextBox();
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btResetCam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraScan)).BeginInit();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.btBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBack.ForeColor = System.Drawing.Color.White;
            this.btBack.Location = new System.Drawing.Point(391, 365);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(170, 35);
            this.btBack.TabIndex = 55;
            this.btBack.Text = "< Back";
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 40);
            this.label1.TabIndex = 53;
            this.label1.Text = "Scan Your QR ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 461);
            this.panel1.TabIndex = 52;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EasyMart.Properties.Resources.image_4_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 461);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cameraScan
            // 
            this.cameraScan.Location = new System.Drawing.Point(368, 128);
            this.cameraScan.Name = "cameraScan";
            this.cameraScan.Size = new System.Drawing.Size(400, 200);
            this.cameraScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cameraScan.TabIndex = 56;
            this.cameraScan.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Code";
            this.label8.Visible = false;
            // 
            // tbCodeQR
            // 
            this.tbCodeQR.Location = new System.Drawing.Point(690, 424);
            this.tbCodeQR.Name = "tbCodeQR";
            this.tbCodeQR.Size = new System.Drawing.Size(78, 29);
            this.tbCodeQR.TabIndex = 37;
            this.tbCodeQR.Visible = false;
            this.tbCodeQR.TextChanged += new System.EventHandler(this.tbCodeQR_TextChanged);
            // 
            // comboCamera
            // 
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Location = new System.Drawing.Point(434, 424);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(130, 29);
            this.comboCamera.TabIndex = 36;
            this.comboCamera.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Camera";
            this.label3.Visible = false;
            // 
            // btResetCam
            // 
            this.btResetCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btResetCam.ForeColor = System.Drawing.Color.Black;
            this.btResetCam.Location = new System.Drawing.Point(579, 365);
            this.btResetCam.Name = "btResetCam";
            this.btResetCam.Size = new System.Drawing.Size(170, 35);
            this.btResetCam.TabIndex = 57;
            this.btResetCam.Text = "Reset Scanner";
            this.btResetCam.UseVisualStyleBackColor = true;
            this.btResetCam.Click += new System.EventHandler(this.btResetCam_Click);
            // 
            // LoginQRPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btResetCam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cameraScan);
            this.Controls.Add(this.tbCodeQR);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.comboCamera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "LoginQRPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyMart - Login with QR";
            this.Load += new System.EventHandler(this.LoginQRPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraScan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox cameraScan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCodeQR;
        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btResetCam;
    }
}