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

namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class ChiTietHDB : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        frmHDBan frmHDBan = new frmHDBan();
        public ChiTietHDB()
        {
            InitializeComponent();
            DataTable dtsp = connectData.ReadData("select * from DienThoai");
            CommonFunctions.FillComboBox(CbMaSP, dtsp, "MaDienThoai", "MaDienThoai");
        }
        void load()
        {
            lbTitle.Text = frmHDBan.MaHDB;
            txtMaHD.Text = frmHDBan.MaHDB;
            txtTenKH.Text = frmHDBan.TenKH;
            txtTenNV.Text = frmHDBan.TenNV;
            txtMaKH.Text = frmHDBan.MaKH;
            txtMaNV.Text = frmHDBan.MaNV;
            DataTable data = connectData.ReadData("select MaHDB, TenDienThoai, ChiTietHDB.SoLuong, DonGiaBan, GiamGia, ThanhTien from ChiTietHDB, DienThoai where ChiTietHDB.MaDienThoai = DienThoai.MaDienThoai and MaHDB = '" + txtMaHD.Text + "'");
            dgvChiTiet.DataSource = data;
            btnNew.Enabled = true;
            btnBAdd.Enabled = false;
            btnBEdit.Enabled = false;
            btnBDelete.Enabled = false;
            btnBPrint.Enabled = false;
            CbMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiamGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtTenNV.Enabled = false;
            txtMaKH.Enabled = false;
            txtMaNV.Enabled = false;
            dtpHDB.Enabled = false;

        }
        void Reset()
        {
            CbMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            btnNew.Enabled = true;
            btnBAdd.Enabled = false;
            btnBEdit.Enabled = false;
            btnBDelete.Enabled = false;
            btnBPrint.Enabled = false;
            CbMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiamGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtTenNV.Enabled = false;
            txtMaKH.Enabled = false;
            txtMaNV.Enabled = false;
            dtpHDB.Enabled = false;
        }
        private void ChiTietHDB_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CbMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
        }

        private void CbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = connectData.ReadData("select * from DienThoai where MaDienThoai='" + CbMaSP.SelectedValue + "'");
                txtTenSP.Text = dataTable.Rows[0]["TenDienThoai"].ToString();
                txtDonGia.Text = dataTable.Rows[0]["GiaBan"].ToString();
            }
            catch
            {

            }
        }

       
    }
}
