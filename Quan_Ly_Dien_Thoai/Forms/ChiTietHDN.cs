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
    public partial class ChiTietHDN : Form
    {
        double T = 0;
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        frmHDNhap frmHDNhap = new frmHDNhap();
        public ChiTietHDN()
        {
            InitializeComponent();
            DataTable dtsp = connectData.ReadData("select * from DienThoai");
            CommonFunctions.FillComboBox(CbMaSP, dtsp, "MaDienThoai", "MaDienThoai");
        }
        void load()
        {
            lbTitle.Text = frmHDNhap.MaHDB;
            txtMaHD.Text = frmHDNhap.MaHDB;
            txtTenNCC.Text = frmHDNhap.TenNCC;
            txtTenNV.Text = frmHDNhap.TenNV;
            txtMaNCC.Text = frmHDNhap.MaNCC;
            txtMaNV.Text = frmHDNhap.MaNV;
            dtpHDN.Text = frmHDNhap.Ngay;
            DataTable data = connectData.ReadData("select MaHDN, TenDienThoai, ChiTietHDN.SoLuong, DonGiaNhap, ThanhTien from ChiTietHDN, DienThoai where ChiTietHDN.MaDienThoai = DienThoai.MaDienThoai and MaHDN = '" + txtMaHD.Text + "'");
            dgvChiTiet.DataSource = data;
            btnNew.Enabled = true;
            btnNAdd.Enabled = false;
            btnNEdit.Enabled = false;
            btnNDelete.Enabled = false;
            btnNPrint.Enabled = true;
            CbMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaHD.Enabled = false;
            txtTenNCC.Enabled = false;
            txtTenNV.Enabled = false;
            txtMaNCC.Enabled = false;
            txtMaNV.Enabled = false;
            dtpHDN.Enabled = false;

        }
        void Reset()
        {
            CbMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            btnNew.Enabled = true;
            btnNAdd.Enabled = false;
            btnNEdit.Enabled = false;
            btnNDelete.Enabled = false;
            btnNPrint.Enabled = false;
            CbMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaHD.Enabled = false;
            txtTenNCC.Enabled = false;
            txtTenNV.Enabled = false;
            txtMaNCC.Enabled = false;
            txtMaNV.Enabled = false;
            dtpHDN.Enabled = false;
        }
        private void ChiTietHDN_Load(object sender, EventArgs e)
        {
            load();
            label2.Text = "Tổng tiền:" + T.ToString();
        }

        private void btnNExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNCancel_Click(object sender, EventArgs e)
        {
            Reset();
            txtSoLuong.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CbMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            CbMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            btnNAdd.Enabled = true;
        }

        private void CbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = connectData.ReadData("select * from DienThoai where MaDienThoai='" + CbMaSP.SelectedValue + "'");
                txtTenSP.Text = dataTable.Rows[0]["TenDienThoai"].ToString();
                txtDonGia.Text = dataTable.Rows[0]["GiaNhap"].ToString();
            }
            catch
            {

            }
        }

        private void btnNAdd_Click(object sender, EventArgs e)
        {
            int slht, soluong;
            double tongtien = 0;
            if (CbMaSP.SelectedValue == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm");
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn cần nhập số lượng");

            }
            DataTable dt = connectData.ReadData("select * from DienThoai where MaDienThoai='" + CbMaSP.SelectedValue + "'");
            slht = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            soluong = int.Parse(txtSoLuong.Text);
            connectData.UpdateData("insert into ChiTietHDN values('" + txtMaHD.Text + "','" + CbMaSP.SelectedValue + "'," + (int)soluong + ",'" + txtDonGia.Text + "','" + txtThanhTien.Text + "')");
            DataTable tableT = connectData.ReadData("select * from ChiTietHDN where MaHDN = '" + txtMaHD.Text + "'");
            for (int i = 0; i < tableT.Rows.Count; i++)
            {
                T = T + double.Parse(tableT.Rows[i]["ThanhTien"].ToString());

            }
            label2.Text = "Tổng Tiền: " + T.ToString();
            load();
            frmHDNhap.load();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double sl, dg, tt;
            try
            {
                if (txtSoLuong.Text.Trim() == "")
                    sl = 0;
                else
                    sl = double.Parse(txtSoLuong.Text);
                dg = double.Parse(txtDonGia.Text);
                tt = dg * sl;
                txtThanhTien.Text = tt.ToString();
            }
            catch { }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNEdit.Enabled = true;
            btnNDelete.Enabled = true;
            btnNAdd.Enabled = false;
            btnNew.Enabled = false;
            CbMaSP.Enabled = false;
            txtSoLuong.Enabled = true;
            string tenSp = dgvChiTiet.CurrentRow.Cells[1].Value.ToString();
            string mahdn = dgvChiTiet.CurrentRow.Cells[0].Value.ToString();
            DataTable dataTable = connectData.ReadData("select MaHDN, ChiTietHDN.MaDienThoai, ChiTietHDN.SoLuong, DonGiaNhap, ThanhTien from ChiTietHDN, DienThoai where ChiTietHDN.MaDienThoai = DienThoai.MaDienThoai and TenDienThoai = '" + tenSp + "' and MaHDN = '" + mahdn + "'");
            CbMaSP.SelectedValue = dataTable.Rows[0]["MaDienThoai"].ToString();
            txtSoLuong.Text = dgvChiTiet.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnNDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connectData.UpdateData("delete from ChiTietHDN where MaDienThoai = '" + CbMaSP.SelectedValue + "'");
                load();
                Reset();
            }
            catch
            {
                MessageBox.Show("loi");
            }
        }

        private void btnNEdit_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("update ChiTietHDN set SoLuong = " + txtSoLuong.Text + ", ThanhTien = '" + txtThanhTien.Text + "' where MaHDN='" + txtMaHD.Text + "' and MaDienThoai='" + CbMaSP.Text + "'");
            load();
            Reset();
        }
    }
}
