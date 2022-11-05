using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quan_Ly_Dien_Thoai.From
{
    public partial class frmSignUp : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool checkEmail(string ac)
        {
            return Regex.IsMatch(ac, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            //anh doi nay
            txtPass.PasswordChar = '\0';
            txtRePass.PasswordChar = '\0';
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            From.frmLogin frmLogin = new From.frmLogin();
            frmLogin.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkAccount(txtUserName.Text))
            {
                MessageBox.Show("Vui long nhap ten tai khoan dai tu 6-24, voi cac ky tu so, chu hoa va chu thuong");
                return;
            }
            if (!checkAccount(txtPass.Text))
            {
                MessageBox.Show("Vui long nhap mat khau dai tu 6-24, voi cac ky tu so, chu hoa va chu thuong");
                return;
            }
            if (txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Vui long xac nhan mat khau chinh xac");
                return;
            }
            if (!checkEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui long nhap dung dinh dang email");
                return;
            }

            DataTable dataTable = new DataTable();
            dataTable = data.ReadData("Select * from Login where Email =  '" +txtEmail.Text + "'");
            if(dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Email này đã được sử dụng");
                return;
            }
            try
            {
                string sql = "insert into Login values('" + txtUserName.Text + "', '" + txtPass.Text + "', '" + txtEmail.Text + "', null)";
                data.UpdateData(sql);
                MessageBox.Show("Đăng ký thành công");
            }
            catch
            {
                MessageBox.Show("Đã có tên tài khoản. Vui lòng nhập lại");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                pictureBox1.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                pictureBox2.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass.PasswordChar = '*';
        }

        private void txtRePass_Click(object sender, EventArgs e)
        {
            txtRePass.Text = "";
            txtRePass.PasswordChar = '*';
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Nhập tên tài khoản";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Nhập tên tài khoản";
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtRePass.Text == "")
            {
                txtRePass.Text = "Mật khẩu";
                txtRePass.PasswordChar = '\0';
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (txtRePass.PasswordChar == '*')
            {
                pictureBox7.BringToFront();
                txtRePass.PasswordChar = '\0';
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (txtRePass.PasswordChar == '\0')
            {
                pictureBox8.BringToFront();
                txtRePass.PasswordChar = '*';
            }
        }
    }
}
