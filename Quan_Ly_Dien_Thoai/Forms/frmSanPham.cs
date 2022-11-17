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
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;

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
            btnAdd.Enabled = true;
            cbPhanLoai.SelectedIndex = 0;
            txtTimKiem.Text = "";
        }

        private void LoadData()
        {
            DataTable dt = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, GiaBan, SoLuong, TGBaohanh, Anh from DienThoai");
            dgvSanPham.DataSource = dt;
            cbPhanLoai.SelectedIndex = 0;
            txtTimKiem.Text = "";
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
                LoadData();
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
            btnAdd.Enabled = false;
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
            if(cbPhanLoai.Text == "Mã HSX")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where MaHSX = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "RAM")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where Ram = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Pin")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where Pin = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Màu")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where Mau = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Hệ Điều hành")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where HeDieuHanh = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Màn hình")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where ManHinh = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Kích thước chung")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where KichThuocChung = N'" + txtTimKiem.Text + "'");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Giá nhập")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where GiaNhap = " + double.Parse(txtTimKiem.Text) + "");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Giá bán")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where Giaban = " + double.Parse(txtTimKiem.Text) + "");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "Số lượng")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where SoLuong = " + int.Parse(txtTimKiem.Text) + "");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (cbPhanLoai.Text == "TG Bảo hành")
            {
                DataTable dataID = data.ReadData("Select MaDienThoai, TenDienThoai, MaHSX, GiaNhap, " +
                    "GiaBan, SoLuong, TGBaohanh, Anh from DienThoai where TGBaoHanh = " + int.Parse(txtTimKiem.Text) + "");
                dgvSanPham.DataSource = dataID;
                if (dataID.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Excel.Application exAp = new Excel.Application();
            Excel.Workbook exBook = exAp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1

            exRange.Font.Size = 15; //Đặt cỡ chữ là 15
            //tenTruong.Font.Name = "Times new roman"; //Chọn font Times new roman
            exRange.Font.Bold = true; //Định dạng kiểu font chữ là in đậm
            exRange.Font.Color = Color.Blue; //Màu xanh da trời
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

            exSheet.Range["D3"].Font.Size = 20;
            exSheet.Range["D3"].Font.Bold = true;
            exSheet.Range["D3"].Font.Color = Color.Red;
            exSheet.Range["D3"].Value = "DANH SÁCH SẢN PHẨM";

            exSheet.Range["A6:H6"].Font.Size = 12;
            exSheet.Range["A6:H6"].Font.Bold = true;
            exSheet.Range["A6:H6"].HorizontalAlignment = HorizontalAlignment.Center;
            exSheet.Range["A6:H6"].VerticalAlignment = VerticalAlignment.Center;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["C6"].ColumnWidth = 25;
            exSheet.Range["B6"].ColumnWidth = 25;
            exSheet.Range["D6"].ColumnWidth = 12;
            exSheet.Range["E6"].ColumnWidth = 15;
            exSheet.Range["F6"].ColumnWidth = 15;
            exSheet.Range["G6"].ColumnWidth = 16;
            exSheet.Range["H6"].ColumnWidth = 15;

            // Tên mục
            exSheet.Range["B6"].Value = "Mã sản phẩm";
            exSheet.Range["C6"].Value = "Tên sản phẩm";
            exSheet.Range["D6"].Value = "Mã hãng";
            exSheet.Range["E6"].Value = "Giá nhập";
            exSheet.Range["F6"].Value = "Giá bán";
            exSheet.Range["G6"].Value = "Số lượng";
            exSheet.Range["H6"].Value = "TG bảo hành";

            int dong = 7;
            for (int i = 0; i < dgvSanPham.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["F" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[4].Value.ToString();
                exSheet.Range["G" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[5].Value.ToString();
                exSheet.Range["H" + (dong + i).ToString()].Value = dgvSanPham.Rows[i].Cells[6].Value.ToString();
            }

            exSheet.Name = "Danh sach SP";
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
