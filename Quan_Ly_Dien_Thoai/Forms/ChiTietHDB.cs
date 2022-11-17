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
using Excel = Microsoft.Office.Interop.Excel;

namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class ChiTietHDB : Form
    {
        double T = 0, S = 0;
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
            T = Double.Parse(frmHDBan.TongTien);
            DataTable data = connectData.ReadData("select MaHDB, TenDienThoai, ChiTietHDB.SoLuong, DonGiaBan, GiamGia, ThanhTien from ChiTietHDB, DienThoai where ChiTietHDB.MaDienThoai = DienThoai.MaDienThoai and MaHDB = '" + txtMaHD.Text + "'");
            dgvChiTiet.DataSource = data;
            btnNew.Enabled = true;
            btnBAdd.Enabled = false;
            btnBEdit.Enabled = false;
            btnBDelete.Enabled = false;
            btnBPrint.Enabled = true;
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
            label17.Text = "Tổng tiền: " + frmHDBan.TongTien;
        }

        private void btnBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBCancel_Click(object sender, EventArgs e)
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
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            CbMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
            btnBAdd.Enabled = true;
            
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

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double sl, dg, gg, tt;
            try
            {
                if (txtGiamGia.Text.Trim() == "")
                    gg = 0;
                else
                    gg = double.Parse(txtGiamGia.Text);
                if (txtSoLuong.Text.Trim() == "")
                    sl = 0;
                else
                    sl = double.Parse(txtSoLuong.Text);
                dg = double.Parse(txtDonGia.Text);
                tt = dg * sl * (1 - gg / 100);
                txtThanhTien.Text = tt.ToString();
            }
            catch { }
        }

        private void btnBAdd_Click(object sender, EventArgs e)
        {
            int slcon, soluong;
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
            slcon = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            soluong = int.Parse(txtSoLuong.Text);
            if (slcon < soluong)
            {
                MessageBox.Show("ko con hang" + txtTenSP);
                txtSoLuong.Focus();
                return;
            }
            connectData.UpdateData("insert into ChiTietHDB values('" + txtMaHD.Text + "','" + CbMaSP.SelectedValue + "'," + (int)soluong + ",'" +txtDonGia.Text+ "','"+ txtGiamGia.Text + "','" + txtThanhTien.Text + "')");
            DataTable tableT = connectData.ReadData("select * from ChiTietHDB where MaHDB = '" + txtMaHD.Text + "'");
            for (int i = 0; i < tableT.Rows.Count; i++)
            {
                tongtien = tongtien + double.Parse(tableT.Rows[i]["ThanhTien"].ToString());

            }
            label17.Text = "Tổng Tiền: " + tongtien.ToString();
            load();
            frmHDBan.load();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnBEdit.Enabled = true;
            btnBDelete.Enabled = true;
            btnBAdd.Enabled = false;
            btnNew.Enabled = false;
            CbMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
            string tenSp = dgvChiTiet.CurrentRow.Cells[1].Value.ToString();
            string mahdb = dgvChiTiet.CurrentRow.Cells[0].Value.ToString();
            DataTable dataTable = connectData.ReadData("select MaHDB, ChiTietHDB.MaDienThoai, ChiTietHDB.SoLuong, DonGiaBan, GiamGia,ThanhTien from ChiTietHDB, DienThoai where ChiTietHDB.MaDienThoai = DienThoai.MaDienThoai and TenDienThoai = '"+tenSp+"' and MaHDB = '" + mahdb + "'");
            CbMaSP.SelectedValue = dataTable.Rows[0]["MaDienThoai"].ToString();
            txtSoLuong.Text = dgvChiTiet.CurrentRow.Cells[2].Value.ToString();
            txtGiamGia.Text = dgvChiTiet.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnBDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connectData.UpdateData("delete from ChiTietHDB where MaDienThoai = '" + CbMaSP.SelectedValue + "'");
                load();
                Reset();
            }
            catch
            {
                MessageBox.Show("loi");
            }
        }

        private void btnBEdit_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("update ChiTietHDB set SoLuong = " + txtSoLuong.Text + ", GiamGia = '" + txtGiamGia.Text + "', ThanhTien = '" +txtThanhTien.Text+ "' where MaHDB='" + txtMaHD.Text + "' and MaDienThoai='"+CbMaSP.Text+"'");
            load();
            Reset();
        }

        private void btnBPrint_Click(object sender, EventArgs e)
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
            exSheet.Range["D4"].Value = "DANH SÁCH CHI TIẾT HDB";



            exSheet.Range["A5"].Value = "Mã Hóa Đơn Bán: " + txtMaHD.Text;
            exSheet.Range["A6"].Value = "Khách hàng: " + txtMaKH.Text + "-" + txtTenKH.Text;


            exSheet.Range["A10:F10"].Font.Size = 10;
            exSheet.Range["A10:F10"].ColumnWidth = 10;
            exSheet.Range["A10:F10"].Font.Bold = true;
            exSheet.Range["A10"].Value = "STT";
            exSheet.Range["B10"].Value = "Tên Điện Thoại";
            exSheet.Range["C10"].Value = "Số lượng";
            exSheet.Range["D10"].Value = "Đơn giá bán";
            exSheet.Range["E10"].Value = "Giảm giá";
            exSheet.Range["F10"].Value = "Thành tiền";
            exSheet.Range["B10"].ColumnWidth = 25;

            int dong = 11;
            for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[4].Value.ToString();
                exSheet.Range["F" + (dong + i).ToString()].Value = dgvChiTiet.Rows[i].Cells[5].Value.ToString();
            }

            dong = dong + dgvChiTiet.Rows.Count;
            exSheet.Range["F" + dong.ToString()].Value = label17.Text + " đồng";

            exSheet.Range["F16"].Value = "Nhân viên lập phiếu: " + txtTenNV.Text;
            exSheet.Name = "Danh sach KH";
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
    }
}
