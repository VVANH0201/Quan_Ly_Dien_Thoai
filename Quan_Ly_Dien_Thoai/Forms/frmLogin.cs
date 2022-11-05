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
    public partial class frmLogin : Form
    {
        Classes.ConnectData data = new Classes.ConnectData();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
            //txtUserName.atr
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass.PasswordChar = '*';
        }

        private void pictureBoxView_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                pictureBoxHide.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                pictureBoxView.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSignUp frmSignUp = new frmSignUp();

            frmSignUp.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "Nhập tên tài khoản")
            {
                txtUserName.Text = "";
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if(txtUserName.Text == "")
            {
                txtUserName.Text = "Nhập tên tài khoản";
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "Mật khẩu")
            {
                txtPass.Text = "";
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "Mật khẩu";
                txtPass.PasswordChar = '\0';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "" || txtUserName.Text == "Nhập tên tài khoản")
            {
                MessageBox.Show("Bạn hãy nhập tên tài khoản");
                return;
            }
            if(txtPass.Text== "" || txtPass.Text == "Mật khẩu")
            {
                MessageBox.Show("Bạn hãy nhập mật khẩu");
                return;
            }
            DataTable dataTablecheckmk = new DataTable();
            dataTablecheckmk = data.ReadData("Select * from Login where PassWord = N'" + txtPass.Text + "'");
            if(dataTablecheckmk.Rows.Count == 0)
            {
                MessageBox.Show("Nhập mật khẩu sai");
                return;
            }

            DataTable dataTable = new DataTable();
            dataTable = data.ReadData("Select * from Login where UserName = N'" + txtUserName.Text + "' and PassWord = N'" + txtPass.Text + "'");

            if(dataTable.Rows.Count > 0)
            {
                Form1 form = new Form1();
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                if (MessageBox.Show("Chưa có tài khoản. Bạn có muốn đăng ký không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmSignUp frmSignUp = new frmSignUp();

                    frmSignUp.ShowDialog();
                    this.Hide();
                }
                
            }

        }
    }
}
