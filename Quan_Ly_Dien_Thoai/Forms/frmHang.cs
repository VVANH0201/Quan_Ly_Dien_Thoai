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
    public partial class frmHang : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public frmHang()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            DataTable dt = data.ReadData("Select * from HangSanXuat");
            dgvHangSX.DataSource = dt;
        }

        void ResetValues()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtTimKiem.Text = "";
            bntAdd.Enabled = true;
            bntChange.Enabled = false;
            btnDelete.Enabled = false;
            cbPhanLoai.SelectedIndex = 0;
        }
        private void frmHang_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValues();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            //Check null
            if(txtMa.Text == "")
            {
                MessageBox.Show("Chưa nhập Mã Hãng Sản Xuất");
                return;
            }
            if(txtTen.Text == "")
            {
                MessageBox.Show("Chưa Nhập tên Hãng Sản Xuất");
                return;
            }
            // check trung ma
            DataTable checkMa = data.ReadData("Select * from HangSanXuat where MaHSX = '" + txtMa.Text.Trim() + "'");
            if (checkMa.Rows.Count > 0)
            {
                MessageBox.Show("Mã hãng sản xuất " + txtMa.Text + " đã tồn tại. Vui lòng nhập lại");
                txtMa.Focus();
                return;
            }
            // insert DL
            try
            {
                string sqlInsert = "insert into HangSanXuat values('" + txtMa.Text.Trim() + "', N'" + txtTen.Text.Trim() + "')";
                data.UpdateData(sqlInsert);
                LoadData();
                ResetValues();
            }
            catch
            {

            }
        }

        private void bntChange_Click(object sender, EventArgs e)
        {
            // check null
            if(txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên Hãng Sản Xuất");
                return;
            }
            // update
            try
            {
                string sqlUpdate = "Update HangSanXuat set TenHSX = N'" + txtTen.Text.Trim() + "' where MaHSX = '" + txtMa.Text.Trim() + "'";
                data.UpdateData(sqlUpdate);
                LoadData();
                ResetValues();
            }
            catch
            {
                MessageBox.Show("Lỗi Kết Nối");
            }
        }


        private void dgvHangSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvHangSX.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvHangSX.CurrentRow.Cells[1].Value.ToString();
            txtMa.Enabled = false;
            bntAdd.Enabled = false;
            bntChange.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    data.UpdateData("delete HangSanXuat where MaHSX='" + txtMa.Text.Trim() + "'");
                    LoadData();
                    ResetValues();
                }
                catch
                {
                    MessageBox.Show("Lỗi Kết Nối");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetValues();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu để tìm kiếm");
                return;
            }

            if (cbPhanLoai.Text == "Mã HSX")
            {
                DataTable dt = data.ReadData("Select * from HangSanXuat where MaHSX like '%" + txtTimKiem.Text.Trim() + "%'");
                dgvHangSX.DataSource = dt;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }

            if (cbPhanLoai.Text == "Tên HSX")
            {
                DataTable dt = data.ReadData("Select * from HangSanXuat where TenHSX like N'%" + txtTimKiem.Text.Trim() + "%'");
                dgvHangSX.DataSource = dt;
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
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1

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
            exSheet.Range["D4"].Value = "DANH SÁCH HÃNG SẢN XUẤT";

            exSheet.Range["A6:C6"].Font.Size = 12;
            exSheet.Range["A6:C6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["C6"].ColumnWidth = 25;
            exSheet.Range["B6"].ColumnWidth = 25;

            exSheet.Range["B6"].Value = "Mã Hãng Sản Xuất";
            exSheet.Range["C6"].Value = "Tên Hãng Sản Xuất";

            int dong = 7;
            for (int i = 0; i < dgvHangSX.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvHangSX.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvHangSX.Rows[i].Cells[1].Value.ToString();
            }

            exSheet.Name = "Danh sach HangSX";
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





























        private void label1_Click(object sender, EventArgs e)
        {

            //ok roi nhe
            //chac co the dc

            //co the

        }

        private void lbMaKH_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
