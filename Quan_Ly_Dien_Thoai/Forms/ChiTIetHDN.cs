using Quan_Ly_Dien_Thoai.From;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class ChiTietHDN : Form
    {
        double T = 0, S = 0;
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
            label2.Text = "Tổng tiền: " + frmHDNhap.TongTien + "VND";
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
                tongtien = tongtien + double.Parse(tableT.Rows[i]["ThanhTien"].ToString());

            }
            label2.Text = "Tổng Tiền: " + tongtien.ToString();
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

        private void btnNPrint_Click(object sender, EventArgs e)
        {
            Excel.Application exAp = new Excel.Application();
            Excel.Workbook exBook = exAp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1];

            exRange.Font.Size = 15;

            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "CỬA HÀNG BÁN ĐIỆN THOẠI ...";
            // dia chi
            Excel.Range dcCuaHang = (Excel.Range)exSheet.Cells[2, 1];
            dcCuaHang.Font.Size = 12;
            dcCuaHang.Font.Bold = true;
            dcCuaHang.Font.Color = Color.Blue;
            dcCuaHang.Value = "Địa chỉ: Số 3 - Cầu Giấy - Đống Đa - Hà Nội";
            // dien thoai
            Excel.Range dtCuaHang = (Excel.Range)exSheet.Cells[3, 1];
            dtCuaHang.Font.Size = 12;
            dtCuaHang.Font.Bold = true;
            dtCuaHang.Font.Color = Color.Blue;
            dtCuaHang.Value = "Điện thoại: 0398866666";

            exSheet.Range["D4"].Font.Size = 20;
            exSheet.Range["D4"].Font.Bold = true;
            exSheet.Range["D4"].Font.Color = Color.Red;
            exSheet.Range["D4"].Value = "DANH SÁCH CHI TIẾT";



            exSheet.Range["A5"].Value = "Mã Hóa Đơn Nhập: " + txtMaHD.Text;
            exSheet.Range["A6"].Value = "Nhà Cung Cấp: " + txtMaNCC.Text + "-" + txtTenNCC.Text;

            exSheet.Range["A10:F10"].Font.Size = 10;
            exSheet.Range["A10:F10"].ColumnWidth = 10;
            exSheet.Range["A10:F10"].Font.Bold = true;
            exSheet.Range["A10"].Value = "STT";
            exSheet.Range["B10"].Value = "Tên Điện Thoại";
            exSheet.Range["C10"].Value = "Số lượng";
            exSheet.Range["D10"].Value = "Đơn giá Nhập";
            exSheet.Range["E10"].Value = "Thành tiền";
            exSheet.Range["B10"].ColumnWidth = 25;

            int dong = 11;
            for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[4].Value.ToString();
               
            }

            dong = dong + dgvChiTiet.Rows.Count;
            exSheet.Range["F" + dong.ToString()].Value = label2.Text + " đồng";

            exSheet.Range["F16"].Value = "Nhân viên lập phiếu: " + txtTenNV.Text;
            exSheet.Name = txtMaHD.Text;
            exBook.Activate();

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 Workbook|*.xls|Excel Workbook|*.xlsx|All File|*.*";
            save.FilterIndex = 2;
            if (save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName.ToLower());
            }
            exAp.Quit();
        }

        private void btnNEdit_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("update ChiTietHDN set SoLuong = " + txtSoLuong.Text + ", ThanhTien = '" + txtThanhTien.Text + "' where MaHDN='" + txtMaHD.Text + "' and MaDienThoai='" + CbMaSP.Text + "'");
            load();
            Reset();
        }
    }
}
