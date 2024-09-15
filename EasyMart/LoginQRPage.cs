using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using EasyMart.Form_MainApp;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EasyMart
{
    public partial class LoginQRPage : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMart_DB;Integrated Security=True");
        
        // Membuat variabel untuk membuka kamera menggunakan Packages AForge 
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        public LoginQRPage()
        {
            InitializeComponent();
        }

        // Method untuk membuka kamera menggunakan Packages AForge
        private void StartCamera()
        {
            if (filterInfoCollection != null && filterInfoCollection.Count > 0)
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[comboCamera.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
            }
        }

        // Method untuk menutup kamera menggunakan Packages AForge
        private void StopCamera()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
                cameraScan.Image = null;
            }
        }

        // Method untuk menampilkan kamera pada PictureBox
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            cameraScan.Image = (Bitmap)eventArgs.Frame.Clone();

            // Melakukan pemindaian QR menggunakan Packages ZXing
            BarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode((Bitmap)eventArgs.Frame.Clone());

            if (result != null)
            {
                tbCodeQR.Invoke(new Action(() => tbCodeQR.Text = result.Text));   // QR terdeteksi
                StopCamera();  // Hentikan kamera setelah mendeteksi QR
            }
        }

        private void ScanQR_Load(object sender, EventArgs e)
        {
            // Mencari dan memilih perangkat tangkapan gambar secara otomatis pada ComboBox
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (filterInfoCollection.Count > 0)
            {
                foreach (FilterInfo filterInfo in filterInfoCollection)
                    comboCamera.Items.Add(filterInfo.Name);

                comboCamera.SelectedIndex = 0;  // Pilih perangkat pertama
                StartCamera();  // Mulai kamera
            }
            else
            {
                MessageBox.Show("No video input devices found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbCodeQR.TextChanged += tbCodeQR_TextChanged;   // Merupakan event handler "TextChanged" dari "tbCodeQR", merupakan tempat untuk kode QR akan ditampilkan setelah berhasil dipindai oleh kamera.
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            StopCamera();
            this.Hide();
        }

        private void LoginQRPage_Load(object sender, EventArgs e)
        {
            ScanQR_Load(null, EventArgs.Empty);   // Membuka kamera secara otomatis ketika Form di buka.
        }

        private void tbCodeQR_TextChanged(object sender, EventArgs e)
        {
            // Menerima kode dari Gambar QR yang berhasil dipindai kamera
            if (!string.IsNullOrEmpty(tbCodeQR.Text))
            {
                con.Open();
                string query = "SELECT * FROM User_Table WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@ID", tbCodeQR.Text);

                SqlDataReader reader = command.ExecuteReader();  // Membaca data dari query SQL secara baris per baris memungkinkan pengambilan data secara bertahap tanpa memuat seluruh hasil query ke dalam memori.

                if (reader.HasRows)  // Memeriksa apakah query SQL yang dijalankan untuk mencari data user berdasarkan ID dari kode QR berhasil menemukan data user atau tidak.
                {
                    reader.Read();
                    string StatusID = reader.GetString(reader.GetOrdinal("Status"));  // Mendapatkan nilai dari kolom "Status" dan disimpan dalam variabel.
                    string NameID = reader.GetString(reader.GetOrdinal("Name"));
                    string UsernameID = reader.GetString(reader.GetOrdinal("Username"));
                    OpenAppropriateForm(StatusID, NameID, UsernameID);
                    tbCodeQR.Clear();
                }
                else
                {
                    MessageBox.Show("User not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbCodeQR.Clear();
                }
                reader.Close();
                tbCodeQR.Clear();
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

        private void btResetCam_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[comboCamera.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }
    }
}