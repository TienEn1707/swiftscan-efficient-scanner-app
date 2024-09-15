namespace EasyMart.Form_MainApp
{
    partial class AddProduct_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericStock = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btClear = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btUpload = new System.Windows.Forms.Button();
            this.btDownload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Barcode_image = new System.Windows.Forms.PictureBox();
            this.Product_image = new System.Windows.Forms.PictureBox();
            this.lbUpdateAt = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lbCreateAt = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 338);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 21);
            this.label12.TabIndex = 144;
            this.label12.Text = "Product Image :";
            // 
            // comboCategory
            // 
            this.comboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.comboCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboCategory.ForeColor = System.Drawing.Color.White;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(186, 382);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(150, 29);
            this.comboCategory.TabIndex = 139;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 21);
            this.label11.TabIndex = 138;
            this.label11.Text = "Product Category :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(186, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 1);
            this.panel2.TabIndex = 137;
            // 
            // numericStock
            // 
            this.numericStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.numericStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericStock.ForeColor = System.Drawing.Color.White;
            this.numericStock.Location = new System.Drawing.Point(186, 428);
            this.numericStock.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericStock.Name = "numericStock";
            this.numericStock.Size = new System.Drawing.Size(150, 29);
            this.numericStock.TabIndex = 135;
            this.numericStock.ValueChanged += new System.EventHandler(this.numericStock_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 134;
            this.label2.Text = "Product Name :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(186, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 1);
            this.panel1.TabIndex = 133;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.ForeColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(186, 338);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 22);
            this.tbName.TabIndex = 132;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(186, 459);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(150, 1);
            this.panel9.TabIndex = 130;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(27, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(899, 250);
            this.dataGridView1.TabIndex = 109;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 108;
            this.label1.Text = "Product List";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(648, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 21);
            this.label10.TabIndex = 107;
            this.label10.Text = "Search Product :";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Location = new System.Drawing.Point(776, 47);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(150, 1);
            this.panel11.TabIndex = 106;
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.ForeColor = System.Drawing.Color.White;
            this.tbSearch.Location = new System.Drawing.Point(776, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(150, 22);
            this.tbSearch.TabIndex = 105;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 147;
            this.label3.Text = "Product Stock :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 150;
            this.label4.Text = "Product Price :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(186, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 1);
            this.panel3.TabIndex = 148;
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.Gray;
            this.btClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClear.Location = new System.Drawing.Point(185, 604);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(151, 60);
            this.btClear.TabIndex = 154;
            this.btClear.Text = "CLEAR FORM";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelete.Location = new System.Drawing.Point(26, 604);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(151, 60);
            this.btDelete.TabIndex = 153;
            this.btDelete.Text = "DELETE DATA";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUpdate.Location = new System.Drawing.Point(185, 538);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(151, 60);
            this.btUpdate.TabIndex = 152;
            this.btUpdate.Text = "UPDATE DATA";
            this.btUpdate.UseVisualStyleBackColor = false;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btCreate
            // 
            this.btCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCreate.Location = new System.Drawing.Point(26, 538);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(151, 60);
            this.btCreate.TabIndex = 151;
            this.btCreate.Text = "CREATE DATA";
            this.btCreate.UseVisualStyleBackColor = false;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(156, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 155;
            this.label5.Text = "Rp.";
            // 
            // btUpload
            // 
            this.btUpload.BackColor = System.Drawing.Color.Gray;
            this.btUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUpload.Location = new System.Drawing.Point(384, 604);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(232, 60);
            this.btUpload.TabIndex = 156;
            this.btUpload.Text = "Upload Image";
            this.btUpload.UseVisualStyleBackColor = false;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // btDownload
            // 
            this.btDownload.BackColor = System.Drawing.Color.Gray;
            this.btDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDownload.Location = new System.Drawing.Point(636, 604);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(290, 60);
            this.btDownload.TabIndex = 159;
            this.btDownload.Text = "Download Barcode (.jpg)";
            this.btDownload.UseVisualStyleBackColor = false;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(632, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 21);
            this.label6.TabIndex = 157;
            this.label6.Text = "Product Barcode :";
            // 
            // Barcode_image
            // 
            this.Barcode_image.Location = new System.Drawing.Point(636, 366);
            this.Barcode_image.Name = "Barcode_image";
            this.Barcode_image.Size = new System.Drawing.Size(290, 232);
            this.Barcode_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Barcode_image.TabIndex = 158;
            this.Barcode_image.TabStop = false;
            // 
            // Product_image
            // 
            this.Product_image.Location = new System.Drawing.Point(384, 366);
            this.Product_image.Name = "Product_image";
            this.Product_image.Size = new System.Drawing.Size(232, 232);
            this.Product_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Product_image.TabIndex = 145;
            this.Product_image.TabStop = false;
            // 
            // lbUpdateAt
            // 
            this.lbUpdateAt.AutoSize = true;
            this.lbUpdateAt.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAt.Location = new System.Drawing.Point(453, 30);
            this.lbUpdateAt.Name = "lbUpdateAt";
            this.lbUpdateAt.Size = new System.Drawing.Size(11, 13);
            this.lbUpdateAt.TabIndex = 165;
            this.lbUpdateAt.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(382, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 164;
            this.label15.Text = "Update At :";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Location = new System.Drawing.Point(456, 46);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(100, 1);
            this.panel12.TabIndex = 163;
            // 
            // lbCreateAt
            // 
            this.lbCreateAt.AutoSize = true;
            this.lbCreateAt.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreateAt.Location = new System.Drawing.Point(251, 31);
            this.lbCreateAt.Name = "lbCreateAt";
            this.lbCreateAt.Size = new System.Drawing.Size(11, 13);
            this.lbCreateAt.TabIndex = 162;
            this.lbCreateAt.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(185, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 161;
            this.label13.Text = "Create At :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(254, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 1);
            this.panel4.TabIndex = 160;
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.ForeColor = System.Drawing.Color.White;
            this.tbPrice.Location = new System.Drawing.Point(185, 478);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(150, 22);
            this.tbPrice.TabIndex = 166;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // AddProduct_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(949, 676);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.lbUpdateAt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.lbCreateAt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.Barcode_image);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Product_image);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.numericStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddProduct_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product Form";
            this.Load += new System.EventHandler(this.AddProduct_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Product_image;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.PictureBox Barcode_image;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUpdateAt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lbCreateAt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbPrice;
    }
}