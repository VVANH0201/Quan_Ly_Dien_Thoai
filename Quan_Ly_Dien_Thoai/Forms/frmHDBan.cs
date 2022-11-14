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
    public partial class frmHDBan : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        public frmHDBan()
        {
            InitializeComponent();
            DataTable dtnv = connectData.ReadData("select * from NhanVien");
            CommonFunctions.FillComboBox(cbMaNV, dtnv, "MaNhanVien", "MaNhanVien");
            DataTable dtkh = connectData.ReadData("select * from KhachHang");
            CommonFunctions.FillComboBox(cbMaKH, dtkh, "MaKhachHang", "MaKhachHang");
        }
        //reset
        void ResetValue()

        {
            txtMaHD.Text = "";
            txtTenKH.Text = "";
            txtTenNV.Text = "";
            txtBSearch.Text = "";
            cbMaKH.Text = "";
            cbMaNV.Text = "";
            CbxBSearch.Text = "";
            txtMaHD.Enabled = false;
            cbMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDB.Enabled = false;
            btnBEdit.Enabled = false;
            btnBPrint.Enabled = false;
            btnBDelete.Enabled = false;
        }
        //exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //add
        private void btnBAdd_Click(object sender, EventArgs e)
        {
            if(txtTenKH.Text == "")
            {
                MessageBox.Show("Nhập đủ tên khách hàng");
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Nhập đủ tên nhân viên");
            }
            DataTable checkHDB = connectData.ReadData("select * from HoaDonBan where MaHDB='"+txtMaHD.Text+"'");
            DataTable checkKH = connectData.ReadData("select * from KhachHang where MaKhachHang='"+cbMaKH.Text+"'");
            if(checkHDB.Rows.Count > 0 && checkKH.Rows.Count>0)
            {
                MessageBox.Show("Mã hóa đơn " + txtMaHD.Text + " của khách hàng " + txtTenKH.Text + " đã có trong dữ liệu.");
                txtMaHD.Focus();
                return;
            }
            string Insert = "insert into HoaDonBan(MaHDB, MaNhanVien, MaKhachHang) values('"+txtMaHD.Text+"','"+cbMaNV.Text+"','"+cbMaKH.Text+"')"/*+ String.Format("{0:yyyy-MM-dd}", dtpHDB) + "')"*/;
            connectData.UpdateData(Insert);
            load();
            ResetValue();
        }
        //load
        void load()
        {
            DataTable dataTable = connectData.ReadData("select HoaDonBan.MaHDB, TenKhachHang, TenNhanVien,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKhachHang = KhachHang.MaKhachHang and  HoaDonBan.MaNhanVien = NhanVien.MaNhanVien");
            dgvHDB.DataSource = dataTable;
            txtMaHD.Enabled = false;
            cbMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDB.Enabled = false;
            btnBEdit.Enabled = false;
            btnBPrint.Enabled = false;
            btnBDelete.Enabled = false;
        }
        private void frmHDBan_Load(object sender, EventArgs e)
        {
            load();
            
        }
        //a new one
        
        //click data
        private void dgvHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgvHDB.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgvHDB.CurrentRow.Cells[1].Value.ToString();
            txtTenNV.Text = dgvHDB.CurrentRow.Cells[2].Value.ToString();
            btnBDelete.Enabled = true;
            btnBEdit.Enabled = true;
            btnBPrint.Enabled = true;
        }
        //cancel
        private void btnBCancel_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
        //select KH
        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = connectData.ReadData("select TenKhachHang from KhachHang where MaKhachHang='" + cbMaKH.SelectedValue + "'");
            try
            {
                txtTenKH.Text = dataTable.Rows[0]["TenKhachHang"].ToString();
            }
            catch
            { }
        }
        //select NV
        private void cbMaNV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable data = connectData.ReadData("select TenNhanVien from NhanVien where MaNhanVien='" + cbMaNV.SelectedValue + "'");
            try
            {
                txtTenNV.Text = data.Rows[0]["TenNhanVien"].ToString();
            }
            catch
            { }
        }

        private void btnBNew_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            cbMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            cbMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            dtpHDB.Enabled = true;

        }
        //xoa
        private void btnBDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connectData.UpdateData("delete from HoaDonBan where MaHDB = '" + txtMaHD.Text + "'");
                load();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("loi");
            }
        }
    }
}
