using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class frmSanPham : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public static String MaSP = "";

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void Resetvalue()
        {
            cbPhanLoai.SelectedIndex = -1;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadData()
        {
            DataTable dt = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, GiaBan, SoLuong, TGBaohanh, Anh from DienThoai");
            dgvSanPham.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            Resetvalue();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSanPham frmAddSP = new frmAddSanPham();
            frmAddSP.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmChiTietSanPham chitietSanPham = new frmChiTietSanPham();
            chitietSanPham.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                data.UpdateData("delete from DienThoai where MaDienThoai = '" + MaSP + "'");
            }
            catch
            {
                MessageBox.Show("loi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            Resetvalue();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaSP = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }
            if(cbPhanLoai.Text == "Mã Điện thoại")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where MaDienThoai = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if(dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if(cbPhanLoai.Text == "Tên Điện thoại")
            {
                DataTable dataName = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where TenDienThoai = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataName;
                if (dataName.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

        }
    }
}
