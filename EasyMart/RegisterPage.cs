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
using BCrypt.Net;

namespace EasyMart
{
    public partial class RegisterPage : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

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
            barcodeWriter.Format = BarcodeFormat.QR_CODE;  // Untuk membuat QR
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

        private void lbLogin_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || numericAge.Value == 0 || richAddress.Text == "" || tbUsername.Text == "" || tbPassword.Text == "" || tbConPassword.Text == "")
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

                int existingUser = (int)checkUsername.ExecuteScalar(); // Mengambil hasil nilai tunggal yang dikembalikan oleh Query tersebut. Nilai ini adalah jumlah baris yang ditemukan dengan Username yang sama seperti yang dimasukkan oleh user.
                if (existingUser > 0)
                {
                    MessageBox.Show("Username has been used, please use another username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Membuat status "Customer" untuk user baru
                string User_Status = "Customer";

                cmd.Parameters.AddWithValue("@ID", User_ID);
                cmd.Parameters.AddWithValue("@Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(numericAge.Value));
                cmd.Parameters.AddWithValue("@DateOfBirth", dateBirth.Value.Date);
                cmd.Parameters.AddWithValue("@Address", richAddress.Text);
                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@Status", User_Status);

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
                using (MemoryStream ms = new MemoryStream())
                {
                    qrCode.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] qrBytes = ms.ToArray();
                    cmd.Parameters.AddWithValue("@QR_Image", qrBytes);
                }

                // Code untuk membuat Time Stamp
                DateTime CreateAt = DateTime.Now;
                cmd.Parameters.AddWithValue("@Create_At", CreateAt);
                cmd.Parameters.AddWithValue("@Update_At", CreateAt);

                cmd.ExecuteNonQuery();  // Mengeksekusi perintah SQL
                MessageBox.Show("User Data created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // MessageBox untuk Download QR ID
                DialogResult result = MessageBox.Show("Do you want to download your QR ID image? Image format (.png)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) 
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    int kode = GenerateRandomNumber();
                    saveFileDialog.Filter = "PNG Image|*.png";
                    saveFileDialog.Title = "Save QR Code Image";
                    saveFileDialog.FileName = $"QR_ID_{kode}";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Mengambil gambar QR dari database
                        byte[] qrBytes = null;
                        string query_QR = "SELECT QR_Image FROM User_Table WHERE ID = @UserID";
                        SqlCommand cmdQR = new SqlCommand(query_QR, con);
                        cmdQR.Parameters.AddWithValue("@UserID", User_ID);
                        SqlDataReader reader = cmdQR.ExecuteReader();
                        if (reader.Read())
                        {
                            qrBytes = (byte[])reader["QR_Image"];
                        }
                            
                        // Membuat gambar QR dari data byte array
                        if (qrBytes != null && qrBytes.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(qrBytes);
                            Bitmap qrImage = new Bitmap(ms);

                            // Menyimpan gambar QR ke lokasi yang dipilih
                            qrImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            MessageBox.Show("QR Code Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("QR Code image not found in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                tbName.Clear();
                richAddress.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
                tbConPassword.Clear();
                numericAge.Value = 0;
                dateBirth.Value = DateTime.Now;
                radioMan.Checked = false;
                radioWoman.Checked = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Create Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                tbPassword.PasswordChar = '\0';   // Jika checkShow ter-checklist maka hilangkan karakter sandi
                tbConPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';    // Jika checkShow tidak ter-checklist maka tunjukkan karakter sandi
                tbConPassword.PasswordChar = '•';
            }
        }
    }
}