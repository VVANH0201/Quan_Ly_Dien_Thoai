using Quan_Ly_Dien_Thoai.Classes;
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


namespace Quan_Ly_Dien_Thoai.From
{
    public partial class frmNhanVien : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        Classes.CommonFunctions comn = new Classes.CommonFunctions();
        public frmNhanVien()
        {
            InitializeComponent();
            DataTable dtnv = data.ReadData("select * from ChucVu");
            comn.FillComboBox(cbCV, dtnv, "TenChucVu", "MaChucVu");
        }
        void ResetValue()
        {
            txtMaNV.Text = "";
            txtTen.Text = "";
            cbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Today;
            txtDiaChi.Text = "";
            txtPhone.Text = "";
            cbCV.Text = "";
            txtTimKiem.Text = "";
            cbPhanLoai.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Enabled = true;
        }
        void LoadData()
        {
            DataTable dt = data.ReadData("select NhanVien.MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, TenChucVu from NhanVien inner join ChucVu on NhanVien.MaChucVu = ChucVu.MaChucVu");
            dgvNhanVien.DataSource = dt;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(dtpNgaySinh.Value.ToLongDateString());
            // check null
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Nhân Viên");
                return;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Nhân Viên");
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn giới tính");
                return;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại");
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ");
                return;
            }
            if (cbCV.SelectedValue == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Chức Vụ");
                return;
            }
            //check trung ma 
            DataTable checkMa = data.ReadData("Select * from NhanVien where MaNhanVien = '" + txtMaNV.Text + "'");
            if (checkMa.Rows.Count > 0)
            {
                MessageBox.Show("Mã Nhân Viên " + txtMaNV.Text + " đã tồn tại. Vui lòng nhập lại");
                txtMaNV.Focus();
                return;
            }
            // insert dl
            string sqlInsert = "insert into NhanVien values('" + txtMaNV.Text + "', N'" + txtTen.Text + "', N'" + cbGioiTinh.Text + "', N'" + String.Format("{0:MM/dd/yyyy}", dateTime) + "', N'" + txtDiaChi.Text + "', N'" + txtPhone.Text + "', N'" + cbCV.SelectedValue + "')";
            data.UpdateData(sqlInsert);
            LoadData();
            ResetValue();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ được nhập số nguyên");
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.UpdateData("delete NhanVien where MaNhanVien='" + txtMaNV.Text + "'");
                    LoadData();
                    ResetValue();

                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các hóa đơn.");
                }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            cbGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtPhone.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            //cbCV.SelectedValue = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            string s = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            DataTable dt = data.ReadData("select * from ChucVu where TenChucVu = N'" + s + "'");
            cbCV.SelectedValue = dt.Rows[0]["MaChucVu"].ToString();
            txtMaNV.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(dtpNgaySinh.Value.ToLongDateString());

            //check null
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Nhân Viên");
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn giới tính");
                return;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại");
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ");
                return;
            }
            if (cbCV.SelectedValue == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Chức vụ");
                return;
            }
            try
            {
                string sqlUpdate = "update NhanVien set TenNhanVien = N'" + txtTen.Text + "', GioiTinh = N'" + cbGioiTinh.Text + "', NgaySinh = '" + String.Format("{0:MM/dd/yyyy}", dateTime) + "', DiaChi = N'" + txtDiaChi.Text + "', SoDienThoai = '" + txtPhone.Text + "', MaChucVu = '" + cbCV.SelectedValue + "' where MaNhanVien = '" + txtMaNV.Text + "'";
                data.UpdateData(sqlUpdate);
                LoadData();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }
            if (cbPhanLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn cách tìm");
            }

            if (cbPhanLoai.Text == "Mã Nhân Viên")
            {
                DataTable dt = data.ReadData("Select * from NhanVien where MaNhanVien like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvNhanVien.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Tên Nhân Viên")
            {
                DataTable dt = data.ReadData("Select * from NhanVien where TenNhanVien like N'%" + txtTimKiem.Text.Trim() + "%'");
                dgvNhanVien.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Số Điện Thoại")
            {
                DataTable dt = data.ReadData("Select * from NhanVien where SoDienThoai like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvNhanVien.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exAp = new Excel.Application();
            Excel.Workbook exBook = exAp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1

            exRange.Font.Size = 15; //Đặt cỡ chữ là 15
            //tenTruong.Font.Name = "Times new roman"; //Chọn font Times new roman
            exRange.Font.Bold = true; //Định dạng kiểu font chữ là in đậm
            exRange.Font.Color = Color.Blue; //Màu xanh da trời
            exRange.Value = "CỬA HÀNG BÁN ĐIỆN THOẠI TEAM04";
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
            exSheet.Range["D3"].Value = "DANH SÁCH NHÂN VIÊN";

            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["C6"].ColumnWidth = 25;
            exSheet.Range["B6"].ColumnWidth = 25;
            exSheet.Range["D6"].ColumnWidth = 25;
            exSheet.Range["E6"].ColumnWidth = 25;
            exSheet.Range["F6"].ColumnWidth = 25;
            exSheet.Range["G6"].ColumnWidth = 25;
            exSheet.Range["H6"].ColumnWidth = 25;


            exSheet.Range["B6"].Value = "Mã Nhân viên";
            exSheet.Range["C6"].Value = "Tên Nhân Viên";
            exSheet.Range["D6"].Value = "Giới Tính";
            exSheet.Range["E6"].Value = "Ngày Sinh";
            exSheet.Range["F6"].Value = "Địa chỉ";
            exSheet.Range["G6"].Value = "Số Điện Thoại";
            exSheet.Range["H6"].Value = "Chức Vụ";


            int dong = 7;
            for (int i = 0; i < dgvNhanVien.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["F" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
                exSheet.Range["G" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                exSheet.Range["H" + (dong + i).ToString()].Value = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            }

            exSheet.Name = "Danh sach NV";
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