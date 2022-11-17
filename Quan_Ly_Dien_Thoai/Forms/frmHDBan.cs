using Quan_Ly_Dien_Thoai.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Dien_Thoai.From
{
    public partial class frmHDBan : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        public static string MaHDB="" ;
        public static string MaKH = "";
        public static string MaNV = "";
        public static string TenKH = "";
        public static string TenNV = "";
        public static string Ngay = "";
        public static string TongTien = "";
        DateTime dateTime;
        public frmHDBan()
        {
            InitializeComponent();
            DataTable dtnv = connectData.ReadData("select * from NhanVien");
            CommonFunctions.FillComboBox(cbMaNV, dtnv, "MaNhanVien", "MaNhanVien");
            DataTable dtkh = connectData.ReadData("select * from KhachHang");
            CommonFunctions.FillComboBox(cbMaKH, dtkh, "MaKhachHang", "MaKhachHang");
        }

        private void AddComboBox()
        {
            CbxBSearch.Items.Add("ID");
            CbxBSearch.Items.Add("Customer");
            CbxBSearch.Items.Add("Employee");
            


        }
        //load
        public void load()
        {
            DataTable dataTable = connectData.ReadData("select HoaDonBan.MaHDB, TenKhachHang, TenNhanVien,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKhachHang = KhachHang.MaKhachHang and  HoaDonBan.MaNhanVien = NhanVien.MaNhanVien");
            dgvHDB.DataSource = dataTable;
            txtMaHD.Enabled = false;
            cbMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDB.Enabled = false;
            btnBAdd.Enabled = false;
            btnBEdit.Enabled = false;
            //btnBPrint.Enabled = false;
            btnBDelete.Enabled = false;
        }
        private void frmHDBan_Load(object sender, EventArgs e)
        {
            load();
            AddComboBox();
            ResetValue();

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
            CbxBSearch.SelectedIndex = 0;
            txtMaHD.Enabled = false;
            cbMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtpHDB.Enabled = false;
            btnBAdd.Enabled = false;
            btnBEdit.Enabled = false;
            //btnBPrint.Enabled = false;
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
            if(txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập mã hóa đơn");
                return;
            }
            if(txtTenKH.Text == "")
            {
                MessageBox.Show("Nhập đủ tên khách hàng");
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Nhập đủ tên nhân viên");
                return;
            }
            DataTable checkHDB = connectData.ReadData("select * from HoaDonBan where MaHDB='"+txtMaHD.Text+"'");
            DataTable checkKH = connectData.ReadData("select * from KhachHang where MaKhachHang='"+cbMaKH.Text+"'");
            if(checkHDB.Rows.Count > 0 && checkKH.Rows.Count>0)
            {
                MessageBox.Show("Mã hóa đơn " + txtMaHD.Text + " của khách hàng " + txtTenKH.Text + " đã có trong dữ liệu.");
                txtMaHD.Focus();
                return;
            }
            dateTime = Convert.ToDateTime(dtpHDB.Value.ToLongDateString());
            string Insert = "insert into HoaDonBan(MaHDB, MaNhanVien, MaKhachHang, NgayBan) values('"+txtMaHD.Text+"','"+cbMaNV.Text+"','"+cbMaKH.Text+"','"+ String.Format("{0:MM/dd/yyyy}", dateTime) + "')";
            connectData.UpdateData(Insert);
            load();
            ResetValue();
        }

        //cancel
        private void btnBCancel_Click(object sender, EventArgs e)
        {
            load();
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
            btnBAdd.Enabled = true;
            txtMaHD.Text = "";
            txtTenKH.Text = "";
            txtTenNV.Text = "";
            cbMaKH.Text = "";
            cbMaNV.Text = "";
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

        private void btnBEdit_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("update HoaDonBan set MaKhachHang = '"+ cbMaKH.SelectedValue +"', MaNhanVien = '"+ cbMaNV.SelectedValue +"', NgayBan = '"+dtpHDB.Text +"' where MaHDB='"+txtMaHD.Text+"'");
            load();
            ResetValue();

        }
        //search
        private void btnBSearch_Click(object sender, EventArgs e)
        {
            if(txtBSearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }
            if (CbxBSearch.Text == "ID")
            {
                DataTable dataID = connectData.ReadData("select HoaDonBan.MaHDB, TenKhachHang, TenNhanVien,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKhachHang = KhachHang.MaKhachHang and  HoaDonBan.MaNhanVien = NhanVien.MaNhanVien and HoaDonBan.MaHDB like N'%"+txtBSearch.Text.Trim()+"%'");
                dgvHDB.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (CbxBSearch.Text == "Employee")
            {
                DataTable dataTenNV = connectData.ReadData("select HoaDonBan.MaHDB, TenKhachHang, TenNhanVien,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKhachHang = KhachHang.MaKhachHang and  HoaDonBan.MaNhanVien = NhanVien.MaNhanVien and TenNhanVien like N'%" + txtBSearch.Text.Trim() + "%'");
                dgvHDB.DataSource = dataTenNV;
                if (dataTenNV.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (CbxBSearch.Text == "Customer")
            {
                DataTable dataTenKH = connectData.ReadData("select HoaDonBan.MaHDB, TenKhachHang, TenNhanVien,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKhachHang = KhachHang.MaKhachHang and  HoaDonBan.MaNhanVien = NhanVien.MaNhanVien and TenKhachHang like N'%" + txtBSearch.Text.Trim() + "%'");
                dgvHDB.DataSource = dataTenKH;
                if (dataTenKH.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
        }

        private void dgvHDB_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHD = dgvHDB.CurrentRow.Cells[0].Value.ToString();
            DataTable HD = connectData.ReadData("select * from HoaDonBan where MaHDB = '" + MaHD + "'");
            cbMaKH.SelectedValue = HD.Rows[0]["MaKhachHang"].ToString();
            cbMaNV.SelectedValue = HD.Rows[0]["MaNhanVien"].ToString();
            dtpHDB.Text = HD.Rows[0]["NgayBan"].ToString();
            txtMaHD.Text = dgvHDB.CurrentRow.Cells[0].Value.ToString();
            btnBDelete.Enabled = true;
            btnBEdit.Enabled = true;
            //btnBPrint.Enabled = true;
            MaHDB = txtMaHD.Text;
            TenKH = txtTenKH.Text;
            TenNV = txtTenNV.Text;
            MaKH = cbMaKH.Text;
            MaNV = cbMaKH.Text;
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtTenNV.Enabled = false;
            cbMaNV.Enabled = true;
            cbMaKH.Enabled = true;
            dtpHDB.Enabled = true;
            TongTien = HD.Rows[0]["TongTien"].ToString();
        }

        private void dgvHDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietHDB chiTietHDB = new ChiTietHDB();
            chiTietHDB.ShowDialog();
        }
    }
}
