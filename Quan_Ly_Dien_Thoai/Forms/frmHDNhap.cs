using Quan_Ly_Dien_Thoai.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai.From
{
    public partial class frmHDNhap : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        DateTime dateTime;
        public static string MaHDB = "";
        public static string MaNCC = "";
        public static string MaNV = "";
        public static string TenNCC = "";
        public static string TenNV = "";
        public static string Ngay = "";
        public frmHDNhap()
        {
            InitializeComponent();
            DataTable dtnv = connectData.ReadData("select * from NhanVien");
            CommonFunctions.FillComboBox(cbMaNV, dtnv, "MaNhanVien", "MaNhanVien");
            DataTable dtncc = connectData.ReadData("select * from NhaCungCap");
            CommonFunctions.FillComboBox(cbMaNCC, dtncc, "MaNCC", "MaNCC");
        }
        public void load()
        {
            DataTable dataTable = connectData.ReadData("select HoaDonNhap.MaHDN, TenNCC, TenNhanVien, NgayNhap, TongTienNhap from HoaDonNhap, NhaCungCap, NhanVien\r\nwhere HoaDonNhap.MaNCC = NhaCungCap.MaNCC and HoaDonNhap.MaNhanVien = NhanVien.MaNhanVien");
            dgvHDN.DataSource = dataTable;
            txtMaHD.Enabled = false;
            cbMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDN.Enabled = false;
            btnNAdd.Enabled = false;
            btnNEdit.Enabled = false;
            //btnBPrint.Enabled = false;
            btnNDelete.Enabled = false;
        }
        private void AddComboBox()
        {
            CbxNSearch.Items.Add("ID");
            CbxNSearch.Items.Add("Supplier");
            CbxNSearch.Items.Add("Employee");
        }
        private void frmHDNhap_Load(object sender, EventArgs e)
        {
            load();
            AddComboBox();
        }
        void ResetValue()

        {
            txtMaHD.Text = "";
            txtTenNCC.Text = "";
            txtTenNV.Text = "";
            txtNSearch.Text = "";
            cbMaNCC.Text = "";
            cbMaNV.Text = "";
            CbxNSearch.Text = "";
            txtMaHD.Enabled = false;
            cbMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDN.Enabled = false;
            btnNAdd.Enabled = false;
            btnNEdit.Enabled = false;
            //btnBPrint.Enabled = false;
            btnNDelete.Enabled = false;
        }

        private void btnNExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connectData.UpdateData("delete from HoaDonNhap where MaHDN = '" + txtMaHD.Text + "'");
                load();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("loi");
            }
        }

        private void btnNCancel_Click(object sender, EventArgs e)
        {
            load();
            ResetValue();
        }

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = connectData.ReadData("select TenNCC from NhaCungCap where MaNCC='" + cbMaNCC.SelectedValue + "'");
            try
            {
                txtTenNCC.Text = dataTable.Rows[0]["TenNCC"].ToString();
            }
            catch
            { }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = connectData.ReadData("select TenNhanVien from NhanVien where MaNhanVien='" + cbMaNV.SelectedValue + "'");
            try
            {
                txtTenNV.Text = data.Rows[0]["TenNhanVien"].ToString();
            }
            catch
            { }
        }

        private void btnNNew_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            cbMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            cbMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            dtpHDN.Enabled = true;
            btnNAdd.Enabled = true;
            txtMaHD.Text = "";
            txtTenNCC.Text = "";
            txtTenNV.Text = "";
            cbMaNCC.Text = "";
            cbMaNV.Text = "";
        }

        private void btnNAdd_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập mã hóa đơn");
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Nhập đủ tên nhà cung cấp");
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Nhập đủ tên nhân viên");
                return;
            }
            DataTable checkHDB = connectData.ReadData("select * from HoaDonNhap where MaHDN='" + txtMaHD.Text + "'");
            DataTable checkNCC = connectData.ReadData("select * from NhaCungCap where MaNCC='" + cbMaNCC.Text + "'");
            if (checkHDB.Rows.Count > 0 && checkNCC.Rows.Count > 0)
            {
                MessageBox.Show("Mã hóa đơn " + txtMaHD.Text + " của nhà cung cấp " + txtTenNCC.Text + " đã có trong dữ liệu.");
                txtMaHD.Focus();
                return;
            }
            dateTime = Convert.ToDateTime(dtpHDN.Value.ToLongDateString());
            string Insert = "insert into HoaDonNhap(MaHDN, MaNhanVien, MaNCC, NgayNhap, TongTienNhap) values('" + txtMaHD.Text + "','" + cbMaNV.Text + "','" + cbMaNCC.Text + "','" + String.Format("{0:MM/dd/yyyy}", dateTime) + "', 0.0)";
            connectData.UpdateData(Insert);
            load();
            ResetValue();
        }

        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHD = dgvHDN.CurrentRow.Cells[0].Value.ToString();
            DataTable HD = connectData.ReadData("select * from HoaDonNhap where MaHDN = '" + MaHD + "'");
            cbMaNCC.SelectedValue = HD.Rows[0]["MaNCC"].ToString();
            cbMaNV.SelectedValue = HD.Rows[0]["MaNhanVien"].ToString();
            dtpHDN.Text = HD.Rows[0]["NgayNhap"].ToString();
            txtMaHD.Text = dgvHDN.CurrentRow.Cells[0].Value.ToString();
            btnNDelete.Enabled = true;
            btnNEdit.Enabled = true;
            //btnBPrint.Enabled = true;
            MaHDB = txtMaHD.Text;
            TenNCC = txtTenNCC.Text;
            TenNV = txtTenNV.Text;
            MaNCC = cbMaNCC.Text;
            MaNV = cbMaNV.Text;
            Ngay = dtpHDN.Text;
            txtMaHD.Enabled = false;
            txtTenNCC.Enabled = false;
            txtTenNV.Enabled = false;
            cbMaNV.Enabled = true;
            cbMaNCC.Enabled = true;
            dtpHDN.Enabled = true;
        }

        private void btnNEdit_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("update HoaDonNhap set MaNCC = '" + cbMaNCC.SelectedValue + "', MaNhanVien = '" + cbMaNV.SelectedValue + "', NgayNhap = '" + dtpHDN.Text + "' where MaHDN='" + txtMaHD.Text + "'");
            load();
            ResetValue();
        }

        private void btnNSearch_Click(object sender, EventArgs e)
        {
            if (txtNSearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }
            if (CbxNSearch.Text == "ID")
            {
                DataTable dataID = connectData.ReadData("select HoaDonNhap.MaHDN, TenNCC, TenNhanVien,NgayNhap, TongTienNhap from HoaDonNhap, NhaCungCap, NhanVien\r\nwhere HoaDonNhap.MaNCC = NhaCungCap.MaNCC and  HoaDonNhap.MaNhanVien = NhanVien.MaNhanVien and HoaDonNhap.MaHDN like N'%" + txtNSearch.Text.Trim() + "%'");
                dgvHDN.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (CbxNSearch.Text == "Employee")
            {
                DataTable dataTenNV = connectData.ReadData("select HoaDonNhap.MaHDN, TenNCC, TenNhanVien,NgayNhap, TongTienNhap from HoaDonNhap, NhaCungCap, NhanVien\r\nwhere HoaDonNhap.MaNCC = NhaCungCap.MaNCC and HoaDonNhap.MaNhanVien = NhanVien.MaNhanVien and TenNhanVien like N'%" + txtNSearch.Text.Trim() + "%'");
                dgvHDN.DataSource = dataTenNV;
                if (dataTenNV.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (CbxNSearch.Text == "Supplier")
            {
                DataTable dataTenKH = connectData.ReadData("select HoaDonNhap.MaHDN, TenNCC, TenNhanVien,NgayNhap, TongTienNhap from HoaDonNhap, NhaCungCap, NhanVien\r\nwhere HoaDonNhap.MaNCC = NhaCungCap.MaNCC and HoaDonNhap.MaNhanVien = NhanVien.MaNhanVien and TenNCC like N'%" + txtNSearch.Text.Trim() + "%'");
                dgvHDN.DataSource = dataTenKH;
                if (dataTenKH.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
        }

        private void dgvHDN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietHDN chiTietHDN = new ChiTietHDN();
            chiTietHDN.ShowDialog();
        }
    }
}
