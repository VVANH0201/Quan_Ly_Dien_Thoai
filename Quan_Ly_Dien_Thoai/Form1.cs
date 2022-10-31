using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeSidebar();
        }

        private void customizeSidebar()
        {
            panelHoaDon.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelHoaDon.Visible == true)
            {
                panelHoaDon.Visible = false;
            }
        }

        private void showSubMenu(Panel submenu)
        {
            if(submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void buttonQLHD_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHoaDon);
        }

        private void buttonHDBan_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void buttonHDNhap_Click(object sender, EventArgs e)
        {
            hideSubMenu(); 
        }

        // Kiểm tra sự tồn tại form con
        bool CheckExistForm(string formName)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == formName)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        // Active form con
        void ActiveChildForm(string formName)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == formName)
                {
                    frm.Activate();
                    break;
                }
            }
        }
    }
}
