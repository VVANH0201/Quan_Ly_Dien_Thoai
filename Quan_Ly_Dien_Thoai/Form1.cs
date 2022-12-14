using Quan_Ly_Dien_Thoai.Forms;
using Quan_Ly_Dien_Thoai.From;
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
        Classes.TaiKhoan tk = new Classes.TaiKhoan();
        public Form1()
        {
            InitializeComponent();
            customizeSidebar();
            tk = Classes.StaticClass._tk;
            labelUsername.Text = tk.Tentk1;
        }
        private void PhanQuyen()
        {
            if (tk.Quyen == "1")
            {
                btnNhanVien.Enabled = true;

            }
            else
            {
                btnNhanVien.Enabled = false;
                btnNhanVien.Hide();
                btnThongKe.Hide();
            }
        }

        private void customizeSidebar()
        {
            panelHoaDon.Visible = false;
            panelSanPham.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelHoaDon.Visible == true)
            {
                panelHoaDon.Visible = false;
            }
            if(panelSanPham.Visible == true)
            {
                panelSanPham.Visible = false;
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

        private Form activeForm = null;
        private void openChildForm(Form formChild)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(formChild);
            panelChildForm.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();           
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSanPham);
        }

        private void btnTTSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSanPham());
            //hideSubMenu();
            labelTitle.Text = "Thông tin Sản phẩm";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnTTHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHang());
            //hideSubMenu();
            labelTitle.Text = "Thông tin Hãng";
        }

        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang());
            hideSubMenu();
            labelTitle.Text = "Thông tin Khách hàng";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHoaDon);
        }

        private void btnHDNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHDNhap());
            //hideSubMenu();
            labelTitle.Text = "Thông tin Hóa đơn nhập";
        }

        private void btnHDBan_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHDBan());
            //hideSubMenu();
            labelTitle.Text = "Thông tin Hóa đơn bán";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());
            hideSubMenu();
            labelTitle.Text = "Thông tin Nhân viên";
        }

        private void btnTTNhaCungCap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhaCungCap());
            //hideSubMenu();
            labelTitle.Text = "Thông tin Nhà cung cấp";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKe());
            hideSubMenu();
            labelTitle.Text = "Thống kê báo cáo";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelUsername.Text = tk.Tentk1;
            PhanQuyen();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void controlBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
