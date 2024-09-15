using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EasyMart.Form_MainApp
{
    public partial class TransactionHistory_Form : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");
        
        // Properti untuk menerima data "Username", berasal dari AdminPage dan CustomerPage
        public string Username { get; set; }

        public TransactionHistory_Form()
        {
            InitializeComponent();
        }

        // Method untuk mendapatkan Status user berdasarkan Username
        private string GetUserStatus(string username)
        {
            string status = "";
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                string query = $"SELECT Status FROM User_Table WHERE Username = '{username}'";
                SqlCommand cmd = new SqlCommand(query, con);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    status = result.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Getting User Status: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return status;
        }

        private void LoadData(string username)
        {
            try
            {
                con.Open();

                string status = GetUserStatus(username);  // Variabel untuk menyimpan status user

                string query = "";
                if (status == "Admin")
                {
                    query = "SELECT * FROM Invoice_Table";
                }
                else
                {
                    query = $"SELECT * FROM Invoice_Table WHERE Username = '{username}'";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);  // Digunakan sebagai jembatan antara aplikasi dan database.
                DataTable dt = new DataTable();  // Menyimpan data dalam bentuk tabel dalam memori aplikasi.
                adapter.Fill(dt);  // Mengambil data dari database SQL Server dan mengisi objek DataTable dengan data tersebut.

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Inv_Code"].HeaderText = "Inv Code";
                dataGridView1.Columns["Inv_Date"].HeaderText = "Inv Date";
                dataGridView1.Columns["Username"].HeaderText = "Username";
                dataGridView1.Columns["Product_Name"].HeaderText = "Product Name";
                dataGridView1.Columns["Product_Price"].HeaderText = "Product Price (Rp.)";
                dataGridView1.Columns["Product_Image"].HeaderText = "Product Image";
                dataGridView1.Columns["Total_Price"].HeaderText = "Total Price (Rp.)";
                dataGridView1.Columns["Pay"].HeaderText = "Pay (Rp.)";
                dataGridView1.Columns["Return_Money"].HeaderText = "Return Money (Rp.)";

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Username"].Visible = false;
                dataGridView1.Columns["Product_Name"].Visible = false;
                dataGridView1.Columns["Product_Price"].Visible = false;
                dataGridView1.Columns["Product_Image"].Visible = false;
                dataGridView1.Columns["Total_Price"].Visible = false;
                dataGridView1.Columns["Pay"].Visible = false;
                dataGridView1.Columns["Return_Money"].Visible = false;
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

        private void TransactionHistory_Form_Load(object sender, EventArgs e)
        {
            LoadData(Username);
            dataGridView1.CellContentClick += dataGridView1_CellContentClick; // Event handler untuk setiap kali user mengklik cell di dalam dataGridView1, maka dataGridView1_CellContentClick akan dipanggil dan dijalankan.

            string status = GetUserStatus(Username);
            if (status == "Customer")
            {
                btDelete.Visible = false;
            }

            // Cek GetUsername
            /*string getUsername = Username;
            string status = GetUserStatus(Username);
            label3.Text = status;
            label3.Text = getUsername;*/
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
                    string status = GetUserStatus(Username);  // Variabel untuk menyimpan status user

                    string Query = "";
                    if (status == "Admin")
                    {
                        Query = "SELECT * FROM Invoice_Table WHERE Inv_Code LIKE @searchTerm";
                    }
                    else
                    {
                        Query = $"SELECT * FROM Invoice_Table WHERE Username = '{Username}' AND Inv_Code LIKE @searchTerm";
                    }

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
                LoadData(Username);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select the Invoice you want to delete first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Invoice?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string Query = "DELETE FROM Invoice_Table WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Delete Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData(Username);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int selectedID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                    con.Open();
                    string Query = "SELECT Username, Product_Name, Product_Price, Product_Image, Total_Price, Pay, Return_Money FROM Invoice_Table WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;  // Menampilkan data pada dataGridView2 ketika cell pada dataGridView1 telah di klik
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error Retrieving Data: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void btDownloadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = $"Transaction_History_{Username}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Menggunakan Package ClosedXML
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            // Menambahkan dan memberi nama pada Sheet Excel
                            var ws = wb.Worksheets.Add("Transaction History");

                            // Tambahkan judul "Transaction History" ke dalam cell A1
                            ws.Cell(1, 1).Value = "Transaction History";  
                            ws.Range("A1:H1").Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  // Gabungkan cell

                            ws.Cell(2, 1).Value = "";
                            ws.Range("A2:H2").Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  // Gabungkan cell

                            // Kolom header
                            int columnIndex = 1; // Mulai dari kolom 1 (kolom A)
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                // Abaikan kolom ID dan Product_Image
                                if (dataGridView1.Columns[i].Name != "ID" && dataGridView1.Columns[i].Name != "Product_Image")
                                {
                                    ws.Cell(3, columnIndex).Value = dataGridView1.Columns[i].HeaderText;
                                    columnIndex++;
                                }
                            }

                            // Isi data dari DataGridView1
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                columnIndex = 1; // Reset columnIndex untuk setiap baris
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    // Abaikan kolom ID dan Product_Image saat menyimpan data
                                    if (dataGridView1.Columns[j].Name != "ID" && dataGridView1.Columns[j].Name != "Product_Image")
                                    {
                                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                                        {
                                            ws.Cell(i + 4, columnIndex).Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                                        }
                                        else
                                        {
                                            // Jika nilai cell adalah null, atur nilainya menjadi string kosong
                                            ws.Cell(i + 4, columnIndex).Value = "";
                                        }
                                        columnIndex++;
                                    }
                                }
                            }

                            // Simpan Excel ke file
                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Download Excel: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDownloadPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"Transaction_History_{Username}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Menggunakan Package iTextSharp
                        Document document = new Document();
                        PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
                        document.Open();

                        // Menambahkan gambar
                        string imagePath = "C:\\Users\\chris\\Dropbox\\PC\\Downloads\\LKS_Image\\logo_1.png";
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                        image.ScaleToFit(100, 100); // Mengatur ukuran gambar (lebar, tinggi)
                        image.SpacingBefore = 20f; // Menambahkan jarak sebelum gambar
                        image.SpacingAfter = 20f; // Menambahkan jarak setelah gambar
                        image.Alignment = Element.ALIGN_CENTER; // Menengahkan gambar
                        document.Add(image);

                        // Tambahkan judul "Transaction History" ke dalam dokumen
                        Paragraph title = new Paragraph("Transaction History");
                        title.Alignment = Element.ALIGN_CENTER;
                        document.Add(title);

                        document.Add(new Paragraph("\n")); // Memberikan spasi ke bawah

                        // Code untuk menyimpan data dari DataGridView1
                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count - 2); // Karena mengabaikan kolom ID dan Product_Image
                        table.WidthPercentage = 100;

                        // Tambahkan kolom header ke dalam table
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            // Abaikan kolom ID dan Product_Image
                            if (dataGridView1.Columns[i].Name != "ID" && dataGridView1.Columns[i].Name != "Product_Image")
                            {
                                table.AddCell(new PdfPCell(new Phrase(dataGridView1.Columns[i].HeaderText)));
                            }
                        }

                        // Isi data dari DataGridView1
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                // Abaikan kolom ID dan Product_Image
                                if (dataGridView1.Columns[j].Name != "ID" && dataGridView1.Columns[j].Name != "Product_Image")
                                {
                                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                                    {
                                        table.AddCell(new PdfPCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString())));
                                    }
                                    else
                                    {
                                        // Jika nilai cell adalah null, atur nilainya menjadi string kosong
                                        table.AddCell(new PdfPCell(new Phrase("")));
                                    }
                                }
                            }
                        }

                        // Tambahkan table ke dalam dokumen
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Download PDF: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}