using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace EasyMart.Form_MainApp
{
    public partial class AddUser_Form : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public AddUser_Form()
        {
            InitializeComponent();
        }

        // Method untuk hash password menggunakan Packages BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Method untuk membuat QR menggunakan ZXing
        private Bitmap GenerateQRCode(string data)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE; // Untuk membuat QR
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 200,
                Height = 200
            };
            return barcodeWriter.Write(data);
        }

        // Method untuk membuat nomor acak
        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 9999);
        }

        private void LoadData()
        {
            try
            {
                con.Open();
                string Query = "SELECT ID, Name, Age, DateOfBirth, Gender, Address, Username, Password, Status, QR_Image , Create_At, Update_At FROM User_Table";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Name"].HeaderText = "Name";
                dataGridView1.Columns["Age"].HeaderText = "Age";
                dataGridView1.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                dataGridView1.Columns["Gender"].HeaderText = "Gender";
                dataGridView1.Columns["Address"].HeaderText = "Address";
                dataGridView1.Columns["Username"].HeaderText = "Username";
                dataGridView1.Columns["Password"].HeaderText = "Password";
                dataGridView1.Columns["Status"].HeaderText = "Status";
                dataGridView1.Columns["QR_Image"].HeaderText = "QR Image";
                dataGridView1.Columns["Create_At"].HeaderText = "Create At";
                dataGridView1.Columns["Update_At"].HeaderText = "Update At";

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Password"].Visible = false;
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

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || numericAge.Value == 0 || richAddress.Text == "" || tbUsername.Text == "" ||
                    tbPassword.Text == "" || tbConPassword.Text == "" || comboStatus.Text == "")
                {
                    MessageBox.Show("Please fill in all the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!radioMan.Checked && !radioWoman.Checked)
                {
                    MessageBox.Show("Please select the gender first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tbPassword.Text != tbConPassword.Text)
                {
                    MessageBox.Show("The password you entered is not the same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();

                // Periksa apakah Username sudah digunakan
                SqlCommand checkUsername = new SqlCommand("SELECT COUNT(*) FROM User_Table WHERE Username = @Username", con);
                checkUsername.Parameters.AddWithValue("@Username", tbUsername.Text);

                int existingUser = (int)checkUsername.ExecuteScalar();  // Mengambil hasil nilai tunggal yang dikembalikan oleh Query tersebut. Nilai ini adalah jumlah baris yang ditemukan dengan Username yang sama seperti yang dimasukkan oleh user.
                if (existingUser > 0)
                {
                    MessageBox.Show("Username has been used, please use another Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Query = "INSERT INTO User_Table (ID, Name, Age, DateOfBirth, Gender, Address, Username, Password, Status, QR_Image, Create_At, Update_At) " +
                    "VALUES (@ID, @Name, @Age, @DateOfBirth, @Gender, @Address, @Username, @Password, @Status, @QR_Image, @Create_At, @Update_At)";
                SqlCommand cmd = new SqlCommand(Query, con);

                // Code untuk membuat ID 
                string Query_ID = "SELECT MAX(ID) FROM User_Table";
                SqlCommand cmd_ID = new SqlCommand(Query_ID, con);
                object Eksekusi_ID = cmd_ID.ExecuteScalar();
                int Make_ID = (Eksekusi_ID == DBNull.Value) ? 0 : Convert.ToInt32(Eksekusi_ID);
                int User_ID = Make_ID + 1;

                cmd.Parameters.AddWithValue("@ID", User_ID);
                cmd.Parameters.AddWithValue("@Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(numericAge.Value));
                cmd.Parameters.AddWithValue("@DateOfBirth", dateBirth.Value.Date);
                cmd.Parameters.AddWithValue("@Address", richAddress.Text);
                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@Status", comboStatus.Text);

                // Hash password menggunakan Packages BCrypt dan menyimpannya ke database
                string hashedPassword = HashPassword(tbPassword.Text);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                
                // Code untuk Radio Button
                if (radioMan.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Man");
                }
                else if (radioWoman.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Woman");
                }

                // Membuat gambar QR ID
                string qrData = User_ID.ToString();
                Bitmap qrCode = GenerateQRCode(qrData);
                MemoryStream ms = new MemoryStream();
                qrCode.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] qrBytes = ms.ToArray();
                cmd.Parameters.AddWithValue("@QR_Image", qrBytes);

                QR_image.Image = Image.FromStream(new MemoryStream(qrBytes));  // Tampilkan kode QR di pictureBox2

                // Code untuk membuat Time Stamp
                DateTime CreateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Create_At", CreateAt);
                cmd.Parameters.AddWithValue("@Update_At", CreateAt);

                cmd.ExecuteNonQuery();  // Mengeksekusi perintah SQL
                MessageBox.Show("User Data created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Clear();
                richAddress.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
                tbConPassword.Clear();
                lbCreateAt.Text = "-";
                lbUpdateAt.Text = "-";
                numericAge.Value = 0;
                dateBirth.Value = DateTime.Now;
                radioMan.Checked = false;
                radioWoman.Checked = false;
                comboStatus.Text = string.Empty;
                QR_image.Image = null;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Create Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                tbName.Text = selectedRow.Cells["Name"].Value.ToString();
                numericAge.Value = Convert.ToInt32(selectedRow.Cells["Age"].Value);
                dateBirth.Value = Convert.ToDateTime(selectedRow.Cells["DateOfBirth"].Value);
                richAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                tbUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                comboStatus.Text = selectedRow.Cells["Status"].Value.ToString();
                lbCreateAt.Text = selectedRow.Cells["Create_At"].Value.ToString();
                lbUpdateAt.Text = selectedRow.Cells["Update_At"].Value.ToString();

                // Mengambil dan menampilkan radio button
                string gender = selectedRow.Cells["Gender"].Value.ToString();
                if (gender == "Man")
                {
                    radioMan.Checked = true;
                }
                else if (gender == "Woman")
                {
                    radioWoman.Checked = true;
                }

                // Mengambil dan menampilkan gambar QR
                byte[] qrData = (byte[])selectedRow.Cells["QR_Image"].Value;
                QR_image.Image = Image.FromStream(new MemoryStream(qrData));
            }
        }

        private void dateBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            richAddress.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
            tbConPassword.Clear();
            lbCreateAt.Text = "-";
            lbUpdateAt.Text = "-";
            numericAge.Value = 0;
            dateBirth.Value = DateTime.Now;
            radioMan.Checked = false;
            radioWoman.Checked = false;
            comboStatus.Text = string.Empty;
            QR_image.Image = null;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || numericAge.Value == 0 || richAddress.Text == "" || tbUsername.Text == "" || comboStatus.Text == "")
                {
                    MessageBox.Show("Select the User Data you want to update first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!radioMan.Checked && !radioWoman.Checked)
                {
                    MessageBox.Show("Please select the gender first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tbPassword.Text != tbConPassword.Text)
                {
                    MessageBox.Show("The password you entered is not the same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Periksa apakah Username sudah digunakan
                /*SqlCommand checkUsername = new SqlCommand("SELECT COUNT(*) FROM User_Table WHERE Username = @Username", con);
                checkUsername.Parameters.AddWithValue("@Username", tbUsername.Text);
                int existingUser = (int)checkUsername.ExecuteScalar();

                if (existingUser > 0)
                {
                    MessageBox.Show("Username has been used, please use another username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                string query = "UPDATE User_Table SET Name = @Name, Age = @Age, DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Username = @Username, Status = @Status, Update_At = @Update_At WHERE ID = @ID";

                if (tbPassword.Text != "" && tbConPassword.Text != "")
                {
                    query = "UPDATE User_Table SET Name = @Name, Age = @Age, DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Username = @Username, Password = @Password, Status = @Status, Update_At = @Update_At WHERE ID = @ID";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", selectedID);
                cmd.Parameters.AddWithValue("@Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(numericAge.Value));
                cmd.Parameters.AddWithValue("@DateOfBirth", dateBirth.Value.Date);
                cmd.Parameters.AddWithValue("@Address", richAddress.Text);
                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@Status", comboStatus.Text);

                // Hash password menggunakan Packages BCrypt dan menyimpannya ke database
                if (tbPassword.Text != "" && tbConPassword.Text != "")
                {
                    string hashedPassword = HashPassword(tbPassword.Text);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                }

                // Code untuk membuat Time Stamp
                DateTime UpdateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Update_At", UpdateAt);

                // Code untuk Radio Button
                if (radioMan.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Man");
                }
                else if (radioWoman.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Woman");
                }

                cmd.ExecuteNonQuery();  // Mengeksekusi perintah SQL
                MessageBox.Show("User Data update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Clear();
                richAddress.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
                tbConPassword.Clear();
                lbCreateAt.Text = "-";
                lbUpdateAt.Text = "-";
                numericAge.Value = 0;
                dateBirth.Value = DateTime.Now;
                radioMan.Checked = false;
                radioWoman.Checked = false;
                comboStatus.Text = string.Empty;
                QR_image.Image = null;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Update Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select the User Data you want to delete first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                string selectedUsername = dataGridView1.SelectedRows[0].Cells["Username"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this User Data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Hapus data invoice berdasarkan Username (jadi ketika Akun user di hapus, maka Invoice dari user tersebut akan ikut terhapus)
                    string queryDeleteInvoice = "DELETE FROM Invoice_Table WHERE Username = @Username";
                    SqlCommand cmdDeleteInvoice = new SqlCommand(queryDeleteInvoice, con);
                    cmdDeleteInvoice.Parameters.AddWithValue("@Username", selectedUsername);
                    cmdDeleteInvoice.ExecuteNonQuery();

                    string Query = "DELETE FROM User_Table WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("User Data successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    tbName.Clear();
                    richAddress.Clear();
                    tbUsername.Clear();
                    tbPassword.Clear();
                    tbConPassword.Clear();
                    lbCreateAt.Text = "-";
                    lbUpdateAt.Text = "-";
                    numericAge.Value = 0;
                    dateBirth.Value = DateTime.Now;
                    radioMan.Checked = false;
                    radioWoman.Checked = false;
                    comboStatus.Text = string.Empty;
                    QR_image.Image = null;
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

        private void QR_image_Click(object sender, EventArgs e)
        {
           
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            if (QR_image.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                int kode = GenerateRandomNumber();
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save QR Code Image";
                saveFileDialog.FileName = $"QR_Code_{kode}";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    QR_image.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("QR Code Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No QR Code Image available to download!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                tbPassword.PasswordChar = '\0';
                tbConPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
                tbConPassword.PasswordChar = '•';
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
                    string Query = "SELECT ID, Name, Age, DateOfBirth, Gender, Address, Username, Password, Status, QR_Image, Create_At, Update_At FROM User_Table WHERE Username LIKE @searchTerm";
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

        private void AddUser_Form_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}