using EasyMart.Form_MainApp;    // Code untuk menampilkan Form yang berasal dari Folder lain, versi mudah, cukup ketik code "Application.Run(new ScanProduct_Form());"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMart
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(new Form_MainApp.ScanProduct_Form());    // Code untuk menampilkan Form yang berasal dari Folder lain
            Application.Run(new Form1());
        }
    }
}