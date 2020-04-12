using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.AccountManager
{
    public partial class DangKi : Form
    {
        string noiLamViec;
        public DangKi(string noiLamViec)
        {
            InitializeComponent();
            this.noiLamViec = noiLamViec;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            
            Model.Account acc = new Model.Account();
            acc.Email = txtEmail.Text;
            acc.Password = txtPassword.Text;
            acc.Ten = txtTen.Text;
            acc.SDT = txtSDT.Text;
            acc.DiaChi = txtDiaChi.Text;
            acc.SinhNhat = dtpNgaySinh.Value.Date;
            acc.NoiLamViec = noiLamViec;
            acc.TenQuyen = "banve";
           if (!ValidateOfMe.ValidateOfMe.isPhoneNumber(ref txtSDT))
           {    
                return;
           }
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
                return;
            try
            {
                DataAccess.DAOAccount.InsertNhanVienBanVe(acc);
                MessageBox.Show("tao Account Thanh Cong!!");
            }catch(SqlException ex)
            {
                if(ex.Number == 2627)
                {
                    MessageBox.Show("Account da ton tai!!");
                }
            }
           
        }

        private void txtSDT_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSDT.Text == "Nội dung trống !"|| txtSDT.Text == "sai định dạng số điện thoại")
            {
                txtSDT.Text = String.Empty;
            }
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.Text == "Nội dung trống !")
            {
                txtEmail.Text = String.Empty;
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Nội dung trống !")
            {
                txtPassword.Text = String.Empty;
            }
        }

        private void txtTen_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTen.Text == "Nội dung trống !")
            {
                txtTen.Text = String.Empty;
            }
        }

        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDiaChi.Text == "Nội dung trống !")
            {
                txtDiaChi.Text = String.Empty;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        
    }
}
