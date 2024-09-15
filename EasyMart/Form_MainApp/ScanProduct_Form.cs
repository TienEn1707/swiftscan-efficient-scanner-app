using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace EasyMart.Form_MainApp
{
    public partial class ScanProduct_Form : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public string Username { get; set; }  // Properti untuk menerima data "Username", berasal dari CustomerPage

        // Membuat variabel untuk membuka kamera menggunakan Packages AForge 
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        public ScanProduct_Form()
        {
            InitializeComponent();
        }

        // Method untuk membuat Nomor Invoice berdasarkan tanggal dan waktu
        private string GenerateInvoiceNumber(string name)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string inv = $"INV{timestamp}_{name}";
            return inv;
        }

        // Method untuk membuka kamera menggunakan Packages AForge
        private void StartCamera()
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[comboCamera.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }

        // Method untuk menutup kamera menggunakan Packages AForge
        private void StopCamera()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
                scanProduct.Image = null;
            }
        }

        // Method untuk menampilkan kamera pada PictureBox
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            scanProduct.Image = (Bitmap)eventArgs.Frame.Clone();

            // Melakukan pemindaian barcode menggunakan Packages ZXing 
            BarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode((Bitmap)eventArgs.Frame.Clone());

            if (result != null)
            {
                tbCodeQR.Invoke(new Action(() => tbCodeQR.Text = result.ToString()));  // Barcode terdeteksi
                StopCamera();  // Hentikan kamera setelah mendeteksi barcode
            }
        }

        // Method untuk mengurangi Stock Produk
        private void DecreaseProductQuantity(string productCode)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True"))
            {
                string updateQuery = "UPDATE Product_Table SET Stock = Stock - 1 WHERE Code = @Code";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Code", productCode);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method untuk mengecek Stock Produk apakah masih tersedia
        private bool IsQuantityAvailable(string productCode)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True"))
            {
                string query = "SELECT Stock FROM Product_Table WHERE Code = @Code";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Code", productCode);
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int quantity = Convert.ToInt32(result);
                        return quantity > 0;
                    }
                    return false;
                }
            }
        }

        // Method untuk menampilkan MessageBox berupa Invoice singkat
        private void ShowPaymentReceipt(decimal totalPrice, decimal paymentAmount, decimal changeAmount)
        {
            string receipt = "\t======== RECEIPT OF PAYMENT ========\n\n";
            receipt += "\tTotal Product Price: Rp. " + totalPrice.ToString("N2") + "\n";
            receipt += "\tPayment: Rp. " + paymentAmount.ToString("N2") + "\n";
            receipt += "\tReturn Money: Rp. " + changeAmount.ToString("N2") + "\n\n";
            receipt += "\tThankyou for shopping at EasyMart! 😍💖\n\n";
            receipt += "\t==============================\n";

            MessageBox.Show(receipt, "Receipt of Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ScanProduct_Form_Load(object sender, EventArgs e)
        {
            // Mencari dan memilih perangkat tangkapan gambar secara otomatis pada ComboBox
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboCamera.Items.Add(filterInfo.Name);
            comboCamera.SelectedIndex = 0;

            tbCodeQR.TextChanged += tbCodeQR_TextChanged;  // Merupakan event handler "TextChanged" dari "tbCodeQR", merupakan tempat untuk kode QR akan ditampilkan setelah berhasil dipindai oleh kamera.
            dataGridView1.Columns.Add("Product_Name", "Product Name");
            dataGridView1.Columns.Add("Price", "Price (Rp.)");
        }

        private string selectedProductCode;  // Variabel untuk menyimpan kode Barcode Product
        private void tbCodeQR_TextChanged(object sender, EventArgs e)
        {
            // Menerima kode dari Gambar Barcode yang berhasil dipindai kamera
            if (!string.IsNullOrEmpty(tbCodeQR.Text))
            {
                selectedProductCode = tbCodeQR.Text;

                con.Open();
                string query = "SELECT * FROM Product_Table WHERE Code = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", selectedProductCode);

                SqlDataReader reader = cmd.ExecuteReader();  // Membaca data dari query SQL secara baris per baris memungkinkan pengambilan data secara bertahap tanpa memuat seluruh hasil query ke dalam memori.

                if (reader.Read())
                {
                    string productName = reader["Product_Name"].ToString();
                    string productPrice = reader["Price"].ToString();

                    // Mendapatkan byte array gambar dari database
                    byte[] imageData = (byte[])reader["Image"];
                    Image productImage;  // Mengonversi byte array ke objek Image
                    MemoryStream ms = new MemoryStream(imageData);
                    productImage = Image.FromStream(ms);

                    Product_image.Image = productImage;  // Menampilkan gambar pada kontrol PictureBox

                    dataGridView1.Rows.Clear();  // Membersihkan DataGridView sebelum menambahkan baris baru
                    dataGridView1.Rows.Add(productName, productPrice);  // Menambahkan baris baru ke DataGridView

                    tbProductPrice.Text = productPrice;  // Tetapkan harga yang diambil ke tbProductPrice
                }
                else
                {
                    MessageBox.Show("Barcode not detected! Please repeat the Barcode!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.Rows.Clear();
                    tbProductPrice.Clear();
                    tbPay.Clear();
                    tbReturnMoney.Clear();
                }

                reader.Close();
                con.Close();
            }
        }

        private void btTurnOn_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void btTurnOff_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        // Method untuk event handler tbProductPrice, agar terdapat koma "," yang dimunculkan pada 3 angka di belakang 
        private void tbProductPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbProductPrice.Text))
            {
                string value = tbProductPrice.Text.Replace(",", "");  // Menghapus karakter koma 

                if (decimal.TryParse(value, out decimal numericValue))
                {
                    tbProductPrice.Text = numericValue.ToString("N0");
                    tbProductPrice.SelectionStart = tbProductPrice.Text.Length;
                }
                else
                {
                    tbProductPrice.Text = "0";
                }
            }
        }

        private void tbPay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPay.Text))
            {
                string value = tbPay.Text.Replace(",", "");

                if (decimal.TryParse(value, out decimal numericValue))
                {
                    tbPay.Text = numericValue.ToString("N0");
                    tbPay.SelectionStart = tbPay.Text.Length;
                }
                else
                {
                    tbPay.Text = "0";
                }
            }
        }

        private void tbReturnMoney_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbReturnMoney.Text))
            {
                string value = tbReturnMoney.Text.Replace(",", "");

                if (decimal.TryParse(value, out decimal numericValue))
                {
                    tbReturnMoney.Text = numericValue.ToString("N0");
                    tbReturnMoney.SelectionStart = tbReturnMoney.Text.Length;
                }
                else
                {
                    tbReturnMoney.Text = "0";
                }
            }
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbProductPrice.Text) && !string.IsNullOrEmpty(tbPay.Text))
            {
                decimal totalPrice = Convert.ToDecimal(tbProductPrice.Text);
                decimal paymentAmount = Convert.ToDecimal(tbPay.Text);

                // Mengecek apakah nominal uang yang dimasukkan kurang dari harga product
                if (paymentAmount < totalPrice)
                {
                    MessageBox.Show("Insufficient payment. Please enter a sufficient payment amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Periksa apakah Stock Product tersedia
                    if (IsQuantityAvailable(selectedProductCode))
                    {
                        decimal changeAmount = paymentAmount - totalPrice;
                        tbReturnMoney.Text = changeAmount.ToString();

                        // Menampilkan MessageBox Invoice Singkat
                        ShowPaymentReceipt(totalPrice, paymentAmount, changeAmount);  

                        // Menambahkan Data Transaksi ke Invoice_Table
                        con.Open();

                        string Query = "INSERT INTO Invoice_Table (ID, Inv_Code, Inv_Date, Username, Product_Name, Product_Price, Product_Image, Total_Price, Pay, Return_Money) " + 
                            "VALUES (@ID, @Inv_Code, @Inv_Date, @Username, @Product_Name, @Product_Price, @Product_Image, @Total_Price, @Pay, @Return_Money)";
                        SqlCommand cmd = new SqlCommand(Query, con);

                        string Query_ID = "SELECT MAX(ID) FROM Invoice_Table";
                        SqlCommand cmd_ID = new SqlCommand(Query_ID, con);
                        object Eksekusi_ID = cmd_ID.ExecuteScalar();
                        int Make_ID = (Eksekusi_ID == DBNull.Value) ? 0 : Convert.ToInt32(Eksekusi_ID);
                        int Inv_ID = Make_ID + 1;

                        string getUsername = Username; // Menyimpan data "Username" ke dalam variabel

                        cmd.Parameters.AddWithValue("@ID", Inv_ID);
                        cmd.Parameters.AddWithValue("@Username", getUsername);

                        decimal PriceValue = decimal.Parse(tbProductPrice.Text.Replace(",", ""));  // Menghapus karakter koma 
                        cmd.Parameters.AddWithValue("@Total_Price", PriceValue);

                        decimal PayValue = decimal.Parse(tbPay.Text.Replace(",", ""));  // Menghapus karakter koma 
                        cmd.Parameters.AddWithValue("@Pay", PayValue);

                        decimal ReturnValue = decimal.Parse(tbReturnMoney.Text.Replace(",", ""));  // Menghapus karakter koma 
                        cmd.Parameters.AddWithValue("@Return_Money", ReturnValue);

                        // Membuat dan Menambahkan Invoice Code 
                        string Inv_Code = GenerateInvoiceNumber(getUsername);
                        cmd.Parameters.AddWithValue("@Inv_Code", Inv_Code);

                        // Code untuk Time Stamp
                        DateTime Inv_Date = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Inv_Date", Inv_Date);

                        // Mengambil gambar dari PictureBox
                        MemoryStream stream = new MemoryStream();
                        Product_image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = stream.ToArray();
                        stream.Close();
                        cmd.Parameters.AddWithValue("@Product_Image", pic);

                        // Tambahkan data Transaksi dari dataGridView1
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["Product_Name"].Value != null)
                            {
                                string productName = row.Cells["Product_Name"].Value.ToString();
                                string productPrice = row.Cells["Price"].Value.ToString();
                                cmd.Parameters.AddWithValue("@Product_Name", productName);
                                cmd.Parameters.AddWithValue("@Product_Price", productPrice);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.RemoveAt("@Product_Name");
                                cmd.Parameters.RemoveAt("@Product_Price");
                            }
                        }

                        tbCodeQR.Clear();
                        tbProductPrice.Clear();
                        tbPay.Clear();
                        tbReturnMoney.Clear();
                        scanProduct.Image = null;
                        Product_image.Image = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.Columns.Add("Product_Name", "Product Name");
                        dataGridView1.Columns.Add("Price", "Price (Rp.)");

                        // Mengurangi Stock Produk
                        DecreaseProductQuantity(selectedProductCode);
                    }
                    else
                    {
                        MessageBox.Show("Product is out of stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodeQR.Clear();
                        tbProductPrice.Clear();
                        tbPay.Clear();
                        tbReturnMoney.Clear();
                        scanProduct.Image = null;
                        Product_image.Image = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.Columns.Add("Product_Name", "Product Name");
                        dataGridView1.Columns.Add("Price", "Price (Rp.)");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter the payment amount and the amount of money awarded!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbCodeQR.Clear();
            tbProductPrice.Clear();
            tbPay.Clear();
            tbReturnMoney.Clear();
            scanProduct.Image = null;
            Product_image.Image = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ProductNameColumn", "Product Name");
            dataGridView1.Columns.Add("ProductPriceColumn", "Price (Rp.)");
        }
    }
}