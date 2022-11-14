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
    public partial class frmNhaCungCap : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTable dt = data.ReadData("Select * from NhaCungCap");
            dgvNCC.DataSource = dt;
        }

        void ResetValue()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTimKiem.Text = "";
            cbPhanLoai.SelectedIndex = 0;
            bntAdd.Enabled = true;
            bntChange.Enabled = false;
            btnDelete.Enabled = false;
            LoadData();
        }


        private void lbMaNSX_Click(object sender, EventArgs e)
        {

        }
        // them Dữ liệu vào bảng
        private void bntAdd_Click(object sender, EventArgs e)
        {
            //check null cac textbox
            if(txtMa.Text == "")
            {
                MessageBox.Show("Bạn không được bỏ trống mã Nhà Cung Cấp");
                return;
            }
            if(txtTen.Text == "")
            {
                MessageBox.Show("Bạn không được bỏ trống tên Nhà Cung Cấp");
                return;
            }
            if(txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn không được bỏ trống địa chỉ Nhà Cung Cấp");
                return;
            }
            if(txtSDT.Text == "")
            {
                MessageBox.Show("Bạn không được bỏ trống SDT Nhà Cung Cấp");
                return;
            }
            // check trùng mã NCC
            try
            {
                string checkmaNCC = "select * from NhaCungCap where MaNCC = N'" + txtMa.Text.Trim() + "'";
                DataTable checkMa = data.ReadData(checkmaNCC);
                if (checkMa.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Nhà Cung Câp " + txtMa.Text.Trim() + " đã có. Mời bạn nhập lại");
                    txtMa.Focus();
                }

                // insert dl nhacc
                string insertNCC = "insert into NhaCungCap values('" + txtMa.Text.Trim() + "', N'" + txtTen.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + txtSDT.Text.Trim() + "')";
                data.UpdateData(insertNCC);
                //LoadData();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            cbPhanLoai.SelectedIndex = 0;
            ResetValue();
        }
        // kiểm tra chỉ cho phép nhập số nguyên vào ô SĐT
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ được nhập số nguyên");
                e.Handled = true;
            }
        }
        // xóa 1 dl khỏi bảng
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.UpdateData("delete NhaCungCap where MaNCC='" + txtMa.Text + "'");
                    //LoadData();
                    ResetValue();

                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các hóa đơn.");
                }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
            txtMa.Enabled = false;
            bntAdd.Enabled = false;
            bntChange.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void bntChange_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Khách Hàng");
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại");
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ");
                return;
            }
            try
            {
                string sqlUpdate = "update NhaCungCap set TenNCC = N'" + txtTen.Text.Trim() + "', DiaChi =  N'" + txtDiaChi.Text.Trim() + "', SoDienThoai = '" + txtSDT.Text.Trim() + "' where MaNCC = '" + txtMa.Text + "'";
                data.UpdateData(sqlUpdate);
                //LoadData();
                ResetValue();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Mời bạn nhập dữ liệu để tìm kiếm");
                return;
                txtTimKiem.Focus();
            }
            // tim kiem theo ma NCC
            if (cbPhanLoai.Text == "Mã NCC")
            {
                DataTable dt = data.ReadData("Select * from NhaCungCap where MaNCC like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvNCC.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Tên NCC")
            {
                DataTable dt = data.ReadData("Select * from NhaCungCap where TenNCC like N'%" + txtTimKiem.Text.Trim() + "%'");
                dgvNCC.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Số Điện Thoại")
            {
                DataTable dt = data.ReadData("Select * from NhaCungCap where SoDienThoai like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvNCC.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Địa Chỉ")
            {
                DataTable dt = data.ReadData("Select * from NhaCungCap where DiaChi like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvNCC.DataSource = dt;
                if (dt.Rows.Count <= 0)
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

            exSheet.Range["D4"].Font.Size = 18;
            exSheet.Range["D4"].Font.Bold = true;
            exSheet.Range["D4"].Font.Color = Color.Red;
            exSheet.Range["D4"].Value = "DANH SÁCH  NHÀ CUNG CẤP";

            exSheet.Range["A6:E6"].Font.Size = 12;
            exSheet.Range["A6:E6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["C6"].ColumnWidth = 25;
            exSheet.Range["B6"].ColumnWidth = 25;
            exSheet.Range["D6"].ColumnWidth = 25;
            exSheet.Range["E6"].ColumnWidth = 25;



            exSheet.Range["B6"].Value = "Mã Nhà Cung Cấp";
            exSheet.Range["C6"].Value = "Tên Nhà Cung Cấp";
            exSheet.Range["D6"].Value = "Địa Chỉ";
            exSheet.Range["E6"].Value = "Số Điện Thoại";

            int dong = 7;
            for (int i = 0; i < dgvNCC.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvNCC.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvNCC.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvNCC.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvNCC.Rows[i].Cells[3].Value.ToString();
            }

            exSheet.Name = "Danh sach NCC";
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
