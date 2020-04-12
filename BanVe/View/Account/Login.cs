using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BanVe.View.Account
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //check show password
            if (!ckbShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        bool checkUserNameAndPassWord()
        {
            foreach (Model.Account acc in Model.AccountList.GetListAccount(cbRap.SelectedValue.ToString()))
            {
                if (acc.TenQuyen.Equals("banve") && acc.Email == txtUserName.Text && acc.Password == txtPassword.Text)
                {
                    MessageBox.Show("dng nhap");
                    return true;
                }
                

            }

            return false;
        }

        private void ckbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShow.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cbRap.DataSource = DataAccess.DaoRap.GetAll();
            cbRap.DisplayMember = "tenrap";
            cbRap.ValueMember = "tenrap";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
            {
                return;
            }

            if (!checkUserNameAndPassWord())
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu bị sai!");
            }
            else
            {
                this.Hide();
                Home menu = new Home(cbRap.SelectedValue.ToString());
                menu.Show();
            }
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text.Equals("Nội dung trống !"))
            {
                txtUserName.Text = string.Empty;
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text.Equals("Nội dung trống !"))
            {
                txtPassword.Text = string.Empty;
            }
        }
    }
}
