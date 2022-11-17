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
    public partial class frmThongKe : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cbThang.SelectedIndex = 10;
            cbNam.SelectedIndex = 0;
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = cbThang.Text;
            string s2 =cbNam.Text;
            if(s1 != "" && s2 != ""){
                DataTable dt1 = data.ReadData("select * from tk_sospban("+ s1 + "," + s2 + ")");
                string slsp = dt1.Rows[0][0].ToString();
                lbsoluongspban.Text = slsp;

                // doanh thu trong thang

                DataTable dt2 = data.ReadData("select * from Sum_Total(" + s1 + "," + s2 + ")");
                string sumdoanhthu = dt2.Rows[0][0].ToString();
                lbdoanhthu.Text = sumdoanhthu + "VND";

                // tong hanh nhap trong thang
                DataTable dt3 = data.ReadData("select * from Tk_sumslhangnhap(" + s1 + "," + s2 + ")");
                string slhangnhap = dt3.Rows[0][0].ToString();
                lbhangnhap.Text = slhangnhap;

                // tong so hdb trong thang

                DataTable dt4 = data.ReadData("select * from Tk_sohdb(" + s1 + "," + s2 + ")");
                string sumhdb = dt4.Rows[0][0].ToString();
                lbsohdb.Text = sumhdb;



                DataTable dt5 = data.ReadData("select * from Thong_ke_sp_ban(" + s2 + ")");
                chart1.DataSource = dt5;
                chart1.Series["Series1"].XValueMember = "TenDienThoai";
                chart1.Series["Series1"].YValueMembers = "SoLuong";

                DataTable dt6 = data.ReadData("select * from TongDoanhThu(" + s2 + ")");
                chart2.DataSource = dt6;
                chart2.Series["Doanh thu"].XValueMember = "Thang";
                chart2.Series["Doanh thu"].YValueMembers = "TongDoanhThu";
                chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            }
            //DataTable dt1 = data.ReadData("select * from tk_sospban( "+s1 + ",2022)");
            //string slsp = dt1.Rows[0][0].ToString();
            //lbsoluongspban.Text = slsp ;
            if(lbsoluongspban.Text == "")
            {
                lbsoluongspban.Text = "0";

            }
            if(lbdoanhthu.Text == "")
            {
                lbdoanhthu.Text = "0 VND";
            }
            if (lbhangnhap.Text == "")
            {
                lbhangnhap.Text = "0";

            }
            if (lbsohdb.Text == "")
            {
                lbsohdb.Text = "0";
            }
        }
    }
}
