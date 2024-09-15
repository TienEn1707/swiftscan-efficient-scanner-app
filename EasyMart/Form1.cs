using EasyMart.Form_MainApp;
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
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyMart
{
    public partial class Form1 : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        // Method untuk Placeholder pada TextBox, didapatkan dari = Klik 1x textbox nya > Properties > Event (gambar petir) > Cari "Enter" dan "Leave" > klik 2x
        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Username")
            {
                tbUsername.Clear();
                tbUsername.ForeColor = Color.White;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Gray;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Clear();
                tbPassword.PasswordChar = '•';
                tbPassword.ForeColor = Color.White; 
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                tbPassword.Text = "Password";
                tbPassword.PasswordChar = '\0'; 
                tbPassword.ForeColor = Color.Gray; 
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            new RegisterPage().Show();
            this.Hide();
        }

        private void btQR_Click(object sender, EventArgs e)
        {
            new LoginQRPage().Show();
            this.Hide();
        }

        private void lbReset_Click(object sender, EventArgs e)
        {
            new ResetPasswordPage().Show();
            this.Hide();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUsername.Text == "" || tbPassword.Text == "")
                {
                    MessageBox.Show("Please fill in your Username and Password first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                string query = "SELECT * FROM User_Table WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Username", tbUsername.Text);

                SqlDataReader reader = command.ExecuteReader();  // Membaca data dari query SQL secara baris per baris memungkinkan pengambilan data secara bertahap tanpa memuat seluruh hasil query ke dalam memori.

                if (reader.HasRows)  // Memeriksa apakah query SQL yang dijalankan untuk mencari data user berdasarkan ID dari kode QR berhasil menemukan data user atau tidak.
                {
                    while (reader.Read())
                    {
                        string hashedPassword = reader.GetString(reader.GetOrdinal("Password"));  // Mendapatkan nilai dari kolom "Password" dan disimpan dalam variabel.

                        // Verifikasi password menggunakan Packages BCrypt
                        if (BCrypt.Net.BCrypt.Verify(tbPassword.Text, hashedPassword))
                        {
                            string StatusID = reader.GetString(reader.GetOrdinal("Status"));  // Mendapatkan nilai dari kolom "Status" dan disimpan dalam variabel.
                            string NameID = reader.GetString(reader.GetOrdinal("Name")); 
                            string UsernameID = reader.GetString(reader.GetOrdinal("Username")); 
                            OpenAppropriateForm(StatusID, NameID, UsernameID); 
                        }
                        else
                        {
                            MessageBox.Show("Username or Password is incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            tbUsername.Text = "Username";
                            tbUsername.ForeColor = Color.Gray;

                            tbPassword.Text = "Password";
                            tbPassword.PasswordChar = '\0';
                            tbPassword.ForeColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username and Password are incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    tbUsername.Text = "Username";
                    tbUsername.ForeColor = Color.Gray;

                    tbPassword.Text = "Password";
                    tbPassword.PasswordChar = '\0';
                    tbPassword.ForeColor = Color.Gray;
                }

                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Login Button: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void OpenAppropriateForm(String Status, string Name, string Username)
        {
            switch (Status)
            {
                case "Admin":
                    AdminPage admin = new AdminPage();
                    admin.SetWelcomeLabel(Name);  // Mengirimkan data "Name" ke AdminPage untuk Label Welcome
                    admin.SetUsername(Username);  // Mengirimkan data "Username" ke AdminPage
                    admin.Show();
                    this.Hide();
                    break;

                case "Employee":
                    EmployeePage employee = new EmployeePage();
                    employee.SetWelcomeLabel(Name);
                    employee.Show();
                    this.Hide();
                    break;

                case "Customer":
                    CustomerPage customer = new CustomerPage();
                    customer.SetWelcomeLabel(Name);
                    customer.SetUsername(Username); 
                    customer.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Unknown status!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                tbPassword.PasswordChar = '\0';  // Jika checkShow ter-checklist maka hilangkan karakter sandi
            }
            else
            {
                tbPassword.PasswordChar = '•';  // Jika checkShow tidak ter-checklist maka tunjukkan karakter sandi
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}