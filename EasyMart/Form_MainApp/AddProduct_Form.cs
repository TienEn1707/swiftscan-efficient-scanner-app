using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyMart.Form_MainApp
{
    public partial class AddProduct_Form : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");
        
        public AddProduct_Form()
        {
            InitializeComponent();
        }

        // Method untuk membuat QR menggunakan ZXing
        private Bitmap GenerateBarcode(string data)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128;  // Untuk membuat Barcode
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 200,
                Height = 100
            };
            return barcodeWriter.Write(data);
        }

        // Method untuk membuat nomor acak
        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        private void LoadData()
        {
            try
            {
                con.Open();
                string Query = "SELECT ID, Product_Name, Image, Category, Stock, Price, Code, Barcode, Create_At, Update_At FROM Product_Table";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Product_Name"].HeaderText = "Product Name";
                dataGridView1.Columns["Image"].HeaderText = "Product Image";
                dataGridView1.Columns["Category"].HeaderText = "Product Category";
                dataGridView1.Columns["Stock"].HeaderText = "Stock";
                dataGridView1.Columns["Price"].HeaderText = "Price (Rp.)";
                dataGridView1.Columns["Code"].HeaderText = "Code";
                dataGridView1.Columns["Barcode"].HeaderText = "Barcode";
                dataGridView1.Columns["Create_At"].HeaderText = "Create At";
                dataGridView1.Columns["Update_At"].HeaderText = "Update At";

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Code"].Visible = false;
                dataGridView1.Columns["Category"].Visible = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Load Data: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoadComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT ID, Product_Category FROM Product_Category_Table";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboCategory.DataSource = dt;
                comboCategory.DisplayMember = "Product_Category";
                comboCategory.ValueMember = "ID";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Load ComboBox: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddProduct_Form_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                tbName.Text = selectedRow.Cells["Product_Name"].Value.ToString();
                comboCategory.SelectedValue = selectedRow.Cells["Category"].Value;  // Tetapkan nilai ComboBox
                numericStock.Value = Convert.ToInt32(selectedRow.Cells["Stock"].Value);
                tbPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                lbCreateAt.Text = selectedRow.Cells["Create_At"].Value.ToString();
                lbUpdateAt.Text = selectedRow.Cells["Update_At"].Value.ToString();

                // Mengambil dan menampilkan gambar Product
                byte[] imageData = (byte[])selectedRow.Cells["Image"].Value;
                Product_image.Image = Image.FromStream(new MemoryStream(imageData));

                // Mengambil dan menampilkan gambar Barcode
                byte[] qrData = (byte[])selectedRow.Cells["Barcode"].Value;
                Barcode_image.Image = Image.FromStream(new MemoryStream(qrData));
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Product_image.Image = new Bitmap(openFileDialog.FileName);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Choose Image: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericStock_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            if (Barcode_image.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                int kode = GenerateRandomNumber();
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save Barcode Image";
                saveFileDialog.FileName = $"QR_Code_{kode}";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Barcode_image.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Barcode Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No Barcode Image available to download!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || comboCategory.Text == "" || tbPrice.Text == "" || Product_image.Image == null)
                {
                    MessageBox.Show("Please fill in all the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int CategoryID = (int)comboCategory.SelectedValue;  // Menyimpan data ComboBox pada variabel

                // Periksa apakah Nama Product sudah digunakan
                SqlCommand checkName = new SqlCommand("SELECT COUNT(*) FROM Product_Table WHERE Product_Name = @Product_Name", con);
                checkName.Parameters.AddWithValue("@Product_Name", tbName.Text);

                int existingName = (int)checkName.ExecuteScalar();
                if (existingName > 0)
                {
                    MessageBox.Show("Product Name has been used, please use another Product Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Query = "INSERT INTO Product_Table (ID, Product_Name, Image, Category, Stock, Price, Code, Barcode, Create_At, Update_At) " +
                    "VALUES (@ID, @Product_Name, @Image, @Category, @Stock, @Price, @Code, @Barcode, @Create_At, @Update_At)";
                SqlCommand cmd = new SqlCommand(Query, con);

                // Code untuk membuat ID 
                string Query_ID = "SELECT MAX(ID) FROM Product_Table";
                SqlCommand cmd_ID = new SqlCommand(Query_ID, con);
                object Eksekusi_ID = cmd_ID.ExecuteScalar();
                int Make_ID = (Eksekusi_ID == DBNull.Value) ? 0 : Convert.ToInt32(Eksekusi_ID);
                int Product_ID = Make_ID + 1;

                cmd.Parameters.AddWithValue("@ID", Product_ID);
                cmd.Parameters.AddWithValue("@Product_Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Category", CategoryID);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(numericStock.Value));

                decimal PriceValue = decimal.Parse(tbPrice.Text.Replace(",", ""));  // Menghapus karakter koma 
                cmd.Parameters.AddWithValue("@Price", PriceValue);

                // Code untuk membuat kode secara acak
                int kode = GenerateRandomNumber();
                cmd.Parameters.AddWithValue("@Code", kode);

                // Code untuk membuat Time Stamp
                DateTime CreateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Create_At", CreateAt);
                cmd.Parameters.AddWithValue("@Update_At", CreateAt);

                // Mengambil gambar dari PictureBox
                MemoryStream stream = new MemoryStream();
                Product_image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                stream.Close();
                cmd.Parameters.AddWithValue("@Image", pic);

                // Membuat gambar Barcode
                string BarcodeData = kode.ToString();
                Bitmap Barcode = GenerateBarcode(BarcodeData);
                MemoryStream ms = new MemoryStream();
                Barcode.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] BarcodeBytes = ms.ToArray();
                cmd.Parameters.AddWithValue("@Barcode", BarcodeBytes);

                Barcode_image.Image = Image.FromStream(new MemoryStream(BarcodeBytes));  // Tampilkan Barcode di pictureBox2

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Clear();
                tbPrice.Clear();
                numericStock.Value = 0;
                comboCategory.Text = string.Empty;
                Product_image.Image = null;
                Barcode_image.Image = null;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Tombol Create: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
                LoadComboBox();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            tbPrice.Clear();
            numericStock.Value = 0;
            comboCategory.Text = string.Empty;
            Product_image.Image = null;
            Barcode_image.Image = null;
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPrice.Text))
            {
                string value = tbPrice.Text.Replace(",", "");  // Menghapus karakter koma 

                if (decimal.TryParse(value, out decimal numericValue))
                {
                    tbPrice.Text = numericValue.ToString("N0");
                    tbPrice.SelectionStart = tbPrice.Text.Length;
                }
                else
                {
                    tbPrice.Text = "0";
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || comboCategory.Text == "" || tbPrice.Text == "" || Product_image.Image == null)
                {
                    MessageBox.Show("Please fill in all the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int CategoryID = (int)comboCategory.SelectedValue;
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Periksa apakah Nama Product sudah digunakan
                /*SqlCommand checkName = new SqlCommand("SELECT COUNT(*) FROM Product_Table WHERE Product_Name = @Product_Name", con);
                checkName.Parameters.AddWithValue("@Product_Name", tbName.Text);
                int existingName = (int)checkName.ExecuteScalar();

                if (existingName > 0)
                {
                    MessageBox.Show("Product Name has been used, please use another Product Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                string query = "UPDATE Product_Table SET Product_Name = @Product_Name, Image = @Image, Category = @Category, Stock = @Stock, Price = @Price, Update_At = @Update_At WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", selectedID);
                cmd.Parameters.AddWithValue("@Product_Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Category", CategoryID);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(numericStock.Value));

                decimal PriceValue = decimal.Parse(tbPrice.Text.Replace(",", ""));  // Menghapus karakter koma 
                cmd.Parameters.AddWithValue("@Price", PriceValue);

                // Code untuk membuat Time Stamp
                DateTime UpdateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Update_At", UpdateAt);

                // Perbarui gambar
                if (Product_image.Image != null)
                {
                    // Mengambil gambar dari PictureBox
                    MemoryStream stream = new MemoryStream();
                    Product_image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    stream.Close();
                    cmd.Parameters.AddWithValue("@Image", pic);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Clear();
                tbPrice.Clear();
                numericStock.Value = 0;
                comboCategory.Text = string.Empty;
                Product_image.Image = null;
                Barcode_image.Image = null;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Update Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
                LoadComboBox();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select the Product you want to delete first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string Query = "DELETE FROM Product_Table WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    tbName.Clear();
                    tbPrice.Clear();
                    numericStock.Value = 0;
                    comboCategory.Text = string.Empty;
                    Product_image.Image = null;
                    Barcode_image.Image = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Delete Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // Variabel untuk menyimpan nilai dari TextBox dan menghapus spasi di awal dan di akhir (text kosong)
            string searchTerm = tbSearch.Text.Trim();

            if (searchTerm != "")
            {
                try
                {
                    con.Open();
                    string Query = "SELECT ID, Product_Name, Image, Category, Stock, Price, Code, Barcode, Create_At, Update_At FROM Product_Table WHERE Product_Name LIKE @searchTerm";
                    SqlCommand cmd = new SqlCommand(Query, con);

                    // Menambahkan wildcard '%' untuk mencari ID yang mengandung teks pencarian
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error Searching Data: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                LoadData();
            }
        }
    }
}