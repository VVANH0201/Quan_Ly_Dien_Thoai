using Quan_Ly_Dien_Thoai.Forms;
using Quan_Ly_Dien_Thoai.From;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai
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
            //Application.Run(new frmNhanVien());
            //Application.Run(new Form1());
            //Application.Run(new frmNhanVien());
            Application.Run(new frmLogin());
        }
    }
}
