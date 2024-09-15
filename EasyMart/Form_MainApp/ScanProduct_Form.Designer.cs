namespace EasyMart.Form_MainApp
{
    partial class ScanProduct_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scanProduct = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            this.btPay = new System.Windows.Forms.Button();
            this.btTurnOff = new System.Windows.Forms.Button();
            this.btTurnOn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Product_image = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbProductPrice = new System.Windows.Forms.TextBox();
            this.tbReturnMoney = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCodeQR = new System.Windows.Forms.TextBox();
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scanProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // scanProduct
            // 
            this.scanProduct.Location = new System.Drawing.Point(27, 53);
            this.scanProduct.Name = "scanProduct";
            this.scanProduct.Size = new System.Drawing.Size(471, 250);
            this.scanProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.scanProduct.TabIndex = 186;
            this.scanProduct.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 466);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 183;
            this.label5.Text = "Rp.";
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.Gray;
            this.btClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClear.Location = new System.Drawing.Point(27, 559);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(331, 47);
            this.btClear.TabIndex = 182;
            this.btClear.Text = "CLEAR FORM";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btPay
            // 
            this.btPay.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPay.Location = new System.Drawing.Point(27, 506);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(331, 47);
            this.btPay.TabIndex = 181;
            this.btPay.Text = "Pay For The Product";
            this.btPay.UseVisualStyleBackColor = false;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // btTurnOff
            // 
            this.btTurnOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btTurnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTurnOff.Location = new System.Drawing.Point(268, 309);
            this.btTurnOff.Name = "btTurnOff";
            this.btTurnOff.Size = new System.Drawing.Size(230, 40);
            this.btTurnOff.TabIndex = 180;
            this.btTurnOff.Text = "Turn Off the Scanner";
            this.btTurnOff.UseVisualStyleBackColor = false;
            this.btTurnOff.Click += new System.EventHandler(this.btTurnOff_Click);
            // 
            // btTurnOn
            // 
            this.btTurnOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btTurnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTurnOn.Location = new System.Drawing.Point(27, 309);
            this.btTurnOn.Name = "btTurnOn";
            this.btTurnOn.Size = new System.Drawing.Size(230, 40);
            this.btTurnOn.TabIndex = 179;
            this.btTurnOn.Text = "Turn On the Scanner";
            this.btTurnOn.UseVisualStyleBackColor = false;
            this.btTurnOn.Click += new System.EventHandler(this.btTurnOn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 21);
            this.label4.TabIndex = 178;
            this.label4.Text = "Return Money :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(208, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 1);
            this.panel3.TabIndex = 176;
            // 
            // Product_image
            // 
            this.Product_image.Location = new System.Drawing.Point(383, 403);
            this.Product_image.Name = "Product_image";
            this.Product_image.Size = new System.Drawing.Size(390, 203);
            this.Product_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Product_image.TabIndex = 174;
            this.Product_image.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 21);
            this.label12.TabIndex = 173;
            this.label12.Text = "Product Image :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 163;
            this.label1.Text = "Product List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(523, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(250, 296);
            this.dataGridView1.TabIndex = 188;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 189;
            this.label6.Text = "Scanner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 193;
            this.label2.Text = "Rp.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 192;
            this.label3.Text = "Payment :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(208, 447);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 1);
            this.panel1.TabIndex = 190;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(178, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 17);
            this.label7.TabIndex = 197;
            this.label7.Text = "Rp.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 21);
            this.label8.TabIndex = 196;
            this.label8.Text = "Total Product Price :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(208, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 1);
            this.panel2.TabIndex = 194;
            // 
            // tbProductPrice
            // 
            this.tbProductPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbProductPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProductPrice.ForeColor = System.Drawing.Color.White;
            this.tbProductPrice.Location = new System.Drawing.Point(208, 375);
            this.tbProductPrice.Name = "tbProductPrice";
            this.tbProductPrice.ReadOnly = true;
            this.tbProductPrice.Size = new System.Drawing.Size(150, 22);
            this.tbProductPrice.TabIndex = 198;
            this.tbProductPrice.TextChanged += new System.EventHandler(this.tbProductPrice_TextChanged);
            // 
            // tbReturnMoney
            // 
            this.tbReturnMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbReturnMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbReturnMoney.ForeColor = System.Drawing.Color.White;
            this.tbReturnMoney.Location = new System.Drawing.Point(208, 463);
            this.tbReturnMoney.Name = "tbReturnMoney";
            this.tbReturnMoney.ReadOnly = true;
            this.tbReturnMoney.Size = new System.Drawing.Size(150, 22);
            this.tbReturnMoney.TabIndex = 199;
            this.tbReturnMoney.TextChanged += new System.EventHandler(this.tbReturnMoney_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 21);
            this.label9.TabIndex = 203;
            this.label9.Text = "Code";
            this.label9.Visible = false;
            // 
            // tbCodeQR
            // 
            this.tbCodeQR.Location = new System.Drawing.Point(420, 15);
            this.tbCodeQR.Name = "tbCodeQR";
            this.tbCodeQR.Size = new System.Drawing.Size(78, 29);
            this.tbCodeQR.TabIndex = 202;
            this.tbCodeQR.Visible = false;
            this.tbCodeQR.TextChanged += new System.EventHandler(this.tbCodeQR_TextChanged);
            // 
            // comboCamera
            // 
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Location = new System.Drawing.Point(225, 15);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(130, 29);
            this.comboCamera.TabIndex = 201;
            this.comboCamera.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 21);
            this.label10.TabIndex = 200;
            this.label10.Text = "Camera";
            this.label10.Visible = false;
            // 
            // tbPay
            // 
            this.tbPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbPay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPay.ForeColor = System.Drawing.Color.White;
            this.tbPay.Location = new System.Drawing.Point(208, 419);
            this.tbPay.Name = "tbPay";
            this.tbPay.Size = new System.Drawing.Size(150, 22);
            this.tbPay.TabIndex = 204;
            this.tbPay.TextChanged += new System.EventHandler(this.tbPay_TextChanged);
            // 
            // ScanProduct_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(784, 616);
            this.Controls.Add(this.tbPay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCodeQR);
            this.Controls.Add(this.comboCamera);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbReturnMoney);
            this.Controls.Add(this.tbProductPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.scanProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btPay);
            this.Controls.Add(this.btTurnOff);
            this.Controls.Add(this.btTurnOn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Product_image);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ScanProduct_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan Product Form";
            this.Load += new System.EventHandler(this.ScanProduct_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scanProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox scanProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btPay;
        private System.Windows.Forms.Button btTurnOff;
        private System.Windows.Forms.Button btTurnOn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox Product_image;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbProductPrice;
        private System.Windows.Forms.TextBox tbReturnMoney;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCodeQR;
        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPay;
    }
}