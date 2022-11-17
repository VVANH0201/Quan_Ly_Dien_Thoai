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

namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class frmAddSanPham : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        public static string fileAnh = "";

        public frmAddSanPham()
        {
            InitializeComponent();
            DataTable dtSP = connectData.ReadData("Select * from HangSanXuat");
            CommonFunctions.FillComboBox(cbMaHSX, dtSP, "TenHSX", "MaHSX");
        }

        private void btnCF_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(txtTenDT.Text.Trim() == "")
            {
                MessageBox.Show("bạn chưa nhập tên sản phẩm");
                return;
            }
            if(txtSL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
                return;
            }
            if(txtGiaban.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá bán");
                return;
            }
            if(txtGiaNhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá nhập");
                return;
            }
            if(txtBaoHanh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thời gian bảo hành");
                return;
            }
            if(txtRAM.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông số RAM");
                return;
            }
            if(txtPin.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông số Pin");
                return;
            }
            if(txtMau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông số màu");
                return;
            }
            if(txtOS.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông số hệ điều hành");
                return;
            }
            if(txtManHinh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông số màn hình");
                return;
            }
            if(txtInch.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập kích thước chung");
                return;
            }
            if (txtMaDT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm");
                return;
            }
            else
            {
                sql = "Select * from DienThoai where MaDienThoai = N'" + txtMaDT.Text + "'";
                DataTable dt = connectData.ReadData(sql);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã sản phẩm đã trùng trong cơ sở dữ liệu");
                    return;
                }
                sql = "Insert into DienThoai values(";
                sql += "N'" + txtMaDT.Text + "', N'" + txtTenDT.Text + "', N'" + cbMaHSX.SelectedValue + "', N'" + txtRAM.Text + "', N'" + txtPin.Text + "', N'" + txtMau.Text +
                    "', N'" + txtOS.Text + "', N'" + txtManHinh.Text + "', N'" + txtInch.Text + "', " +
                    double.Parse(txtGiaNhap.Text) + ", " + double.Parse(txtGiaban.Text) + ", " + int.Parse(txtSL.Text) + 
                    ", " + int.Parse(txtBaoHanh.Text) + ", N'" + fileAnh + "')";
                connectData.UpdateData(sql);
                MessageBox.Show("Thêm mới thành công");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PNG Images|*.png|JPEG Images|*.jpg|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picBoxImage.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                //fileAnh = image[image.Length-1];
                fileAnh = image[image.Length - 2] + "//" + image[image.Length - 1];
            }

        }
    }
}
