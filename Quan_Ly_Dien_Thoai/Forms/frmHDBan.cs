using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai.From
{
    public partial class frmHDBan : Form
    {
        Classes.CommonFunctions CommonFunctions = new Classes.CommonFunctions();
        Classes.ConnectData connectData = new Classes.ConnectData();
        public frmHDBan()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void btnBAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void frmHDBan_Load(object sender, EventArgs e)
        {
            DataTable dataTable = connectData.ReadData("select HoaDonBan.MaHDB, TenKH, TenNV,NgayBan, TongTien from HoaDonBan, KhachHang, NhanVien\r\nwhere HoaDonBan.MaKH = KhachHang.MaKH and  HoaDonBan.MaNV = NhanVien.MaNV");
            dgvHDB.DataSource = dataTable;
        }
    }
}
