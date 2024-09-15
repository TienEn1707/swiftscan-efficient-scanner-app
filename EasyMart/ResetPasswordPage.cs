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
using System.Xml.Linq;
using BCrypt.Net;

namespace EasyMart
{
    public partial class ResetPasswordPage : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public ResetPasswordPage()
        {
            InitializeComponent();
        }

        // Method untuk hash password menggunakan Packages BCrypt
        private string HashPassword(string password) 
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUsername.Text == "" || tbNewPassword.Text == "" || tbConPassword.Text == "")
                {
                    MessageBox.Show("Please fill in all the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbNewPassword.Text != tbConPassword.Text)
                {
                    MessageBox.Show("The password you entered is not the same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                string query = "UPDATE User_Table SET Password = @Password, Update_At = @Update_At WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);

                // Hash password menggunakan Packages BCrypt sebelum menyimpannya ke database
                string hashedPassword = HashPassword(tbNewPassword.Text);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);

                // Code untuk membuat Time Stamp
                DateTime Update_At = DateTime.Now;
                cmd.Parameters.AddWithValue("@Update_At", Update_At);

                int rowsAffected = cmd.ExecuteNonQuery();   // Menampung jumlah baris yang berhasil diperbarui, jika Query berhasil dieksekusi maka nilai rowsAffected akan lebih besar dari 0, menunjukkan baris yang berhasil diperbarui. Jika tidak, nilainya sama dengan 0.
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Reset password successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUsername.Clear();
                    tbNewPassword.Clear();
                    tbConPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Username not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Reset Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                tbNewPassword.PasswordChar = '\0';  // Jika checkShow ter-checklist maka hilangkan karakter sandi
                tbConPassword.PasswordChar = '\0';
            }
            else
            {
                tbNewPassword.PasswordChar = '•';   // Jika checkShow tidak ter-checklist maka tunjukkan karakter sandi
                tbConPassword.PasswordChar = '•';
            }
        }

        private void ResetPasswordPage_Load(object sender, EventArgs e)
        {

        }
    }
}