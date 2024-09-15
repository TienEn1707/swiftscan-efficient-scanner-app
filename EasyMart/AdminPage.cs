﻿using EasyMart.Form_MainApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EasyMart
{
    public partial class AdminPage : Form
    {

        // Membuat variabel untuk event handler Button dan Form, serta variabel username untuk menyimpan data "Username"
        private Button currentButton;
        private Form activeForm;
        private string username;

        public AdminPage()
        {
            InitializeComponent();
            timer1.Start();
        }

        // Method untuk menerima data "Name" dari Login Page dan menampilkan data tersebut pada Label
        public void SetWelcomeLabel(string userName)
        {
            lbNameTop.Text = "(ADMIN) - Welcome, " + userName;
        }

        // Method untuk menerima data "Username" dari Login Page dan menyimpan data tersebut pada variabel
        public void SetUsername(string username)
        {
            this.username = username;
        }

        // Method untuk menentukan warna
        private Color SelectThemeColor()
        {
            return Color.Orange;
        }

        // Method untuk memberikan warna pada Button ketika di klik
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        // Method untuk memberikan warna pada Button ketika tidak di klik
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Black;
                    previousBtn.ForeColor = Color.White;
                }
            }
        }

        // Method untuk menampilkan Forms pada panelDekstop
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            lbTimeTop.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");  // Menampilkan Tanggal dan Waktu pada Label
            OpenChildForm(new AddUser_Form(), button1);  // Menampilkan Forms pada panelDekstop secara otomatis ketika Form di buka
        }

        private void lbTimeTop_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimeTop.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");  // Menampilkan Tanggal dan Waktu pada Label
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddUser_Form(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddProduct_Form(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddCategoryProduct_Form(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransactionHistory_Form Transaction = new TransactionHistory_Form();
            Transaction.Username = username;  // Mengirimkan data "Username" ke TransactionHistory_Form
            OpenChildForm(Transaction, sender);  // Menampilkan Forms pada panelDekstop, "sender" adalah sebuah objek yang mmemberitahukan bahwa itu adalah sebuah Button dengan nama "button4"
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);  // Memberikan warna pada button ketika di klik, "sender" adalah sebuah objek yang mmemberitahukan bahwa itu adalah sebuah Button dengan nama "button5"
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new Form1().Show();
                this.Close();
            }
        }
    }
}