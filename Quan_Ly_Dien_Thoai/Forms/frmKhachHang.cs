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
    public partial class frmKhachHang : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        void ResetValue()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtPhone.Text = "";
            txtTimKiem.Text = "";
            cbPhanLoai.SelectedIndex = -1;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo,
             // MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValue();
        }
        void LoadData()
        {
            DataTable dt = data.ReadData("Select * from KhachHang");
            dgvKhachHang.DataSource = dt;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // check null
            if(txtMa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Khách Hàng");
                return;
            }
            if(txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Khách Hàng");
                return;
            } 
            if(txtPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại");
                return;
            }
            if(txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ");
                return;
            }
            //check trung ma 
            DataTable checkMa = data.ReadData("Select * from KhachHang where MaKhachHang = '" + txtMa.Text + "'");
            if(checkMa.Rows.Count > 0)
            {
                MessageBox.Show("Mã khách hàng " + txtMa.Text + " đã tồn tại. Vui lòng nhập lại");
                txtMa.Focus();
                return;
            }
            // insert dl
            string sqlInsert = "insert into KhachHang values('" + txtMa.Text + "', N'" + txtTen.Text + "', '" + txtPhone.Text + "', N'" + txtDiaChi.Text + "')";
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
                    data.UpdateData("delete KhachHang where MaKhachHang='" + txtMa.Text + "'");
                    LoadData();
                    ResetValue();
                    
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các hóa đơn.");
                }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtMa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //check null
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Khách Hàng");
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
            try
            {
                string sqlUpdate = "update KhachHang set TenKhachHang = N'" + txtTen.Text + "', SDT = '" + txtPhone.Text + "',DiaChiKH =  N'" + txtDiaChi.Text + "' where MaKhachHang = '" + txtMa.Text + "'";
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
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }
            if(cbPhanLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn cách tìm");
            }

            if (cbPhanLoai.Text == "Mã Khách Hàng")
            {
                DataTable dt = data.ReadData("Select * from KhachHang where MaKhachHang like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvKhachHang.DataSource = dt;
                if(dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Tên Khách Hàng")
            {
                DataTable dt = data.ReadData("Select * from KhachHang where TenKhachHang like N'%" + txtTimKiem.Text.Trim() + "%'");
                dgvKhachHang.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Số Điện Thoại")
            {
                DataTable dt = data.ReadData("Select * from KhachHang where SDT like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvKhachHang.DataSource = dt;
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
            exSheet.Range["D3"].Value = "DANH SÁCH KHÁCH HÀNG";

            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["C6"].ColumnWidth = 25;
            exSheet.Range["B6"].ColumnWidth = 25;
            exSheet.Range["D6"].ColumnWidth = 25;
            exSheet.Range["E6"].ColumnWidth = 25;



            exSheet.Range["B6"].Value = "Mã Khách Hàng";
            exSheet.Range["C6"].Value = "Tên Khách Hàng";
            exSheet.Range["D6"].Value = "Số Điện Thoại";
            exSheet.Range["E6"].Value = "Địa chỉ";

            int dong = 7;
            for (int i = 0; i < dgvKhachHang.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvKhachHang.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
            }

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
