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

namespace Quan_Ly_Dien_Thoai.Forms
{
    public partial class frmChiTietSanPham : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        frmSanPham frmSP = new frmSanPham();
        public string fileAnh = "";

        public frmChiTietSanPham()
        {
            InitializeComponent();
            DataTable dtSP = connectData.ReadData("Select * from HangSanXuat");
            CommonFunctions.FillComboBox(cbMaHSX, dtSP, "MaHSX", "MaHSX");
        }

        private void load()
        {
            //txtMaDT.Text = frmSanPham.MaSP;
            DataTable dt = new DataTable();
            dt = connectData.ReadData("Select * from DienThoai where MaDienThoai = '" + frmSanPham.MaSP + "'");
            txtMaDT.Text = frmSanPham.MaSP;
            txtTenDT.Text = dt.Rows[0]["TenDienThoai"].ToString();
            cbMaHSX.SelectedValue = dt.Rows[0]["MaHSX"].ToString();
            txtRAM.Text = dt.Rows[0]["Ram"].ToString();
            txtPin.Text = dt.Rows[0]["Pin"].ToString();
            txtOS.Text = dt.Rows[0]["HeDieuHanh"].ToString();
            txtManHinh.Text = dt.Rows[0]["ManHinh"].ToString();
            txtInch.Text = dt.Rows[0]["KichThuocChung"].ToString();
            txtGiaban.Text = dt.Rows[0]["GiaBan"].ToString();
            txtGiaNhap.Text = dt.Rows[0]["GiaNhap"].ToString();
            txtSL.Text = dt.Rows[0]["SoLuong"].ToString();
            txtBaoHanh.Text = dt.Rows[0]["TGBaoHanh"].ToString();
            txtMau.Text = dt.Rows[0]["Mau"].ToString();
            try
            {
                //picAnh.Image = Image.FromFile(Application.StartupPath + "\\Images\\Products\\" + fileAnh);
                fileAnh = dt.Rows[0]["Anh"].ToString();
                picBoxImage.Image = Image.FromFile(Application.StartupPath + "\\img\\" + fileAnh);
            }
            catch
            {
                picBoxImage.Image = null;
            }
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            load();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connectData.UpdateData("Update DienThoai set TenDienThoai = N'" + txtTenDT.Text + "', " +
                "MaHSX = N'" + cbMaHSX.SelectedValue + "', SoLuong = " + int.Parse(txtSL.Text) + ", " +
                "GiaBan = " + double.Parse(txtGiaban.Text) + ", GiaNhap = " + double.Parse(txtGiaNhap.Text) + ", TGBaoHanh = " + 
                int.Parse(txtBaoHanh.Text) + ", Anh = N'" + fileAnh + "', Ram = '" + txtRAM.Text + "', Pin = N'" +
                txtPin.Text + "', Mau = N'" + txtMau.Text + "', HeDieuHanh = N'" + txtOS.Text + "', ManHinh = N'" +
                txtManHinh.Text + "', KichThuocChung = N'" + txtInch.Text + "' where MaDienThoai = N'" + txtMaDT.Text + "'");
            load();
            this.Close();
            MessageBox.Show("Sửa thành công");
        }

    }
}
