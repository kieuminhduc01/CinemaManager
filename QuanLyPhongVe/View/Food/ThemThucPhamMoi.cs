using QuanLyPhongVe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.Food
{
    /// <summary>
    ///check null ở các ô nhập
    ///tự mất null ở các ô nhập khi click chuôj
    ///check giá bán cao hơn giá nhập
    /// </summary>
    public partial class ThemThucPhamMoi : Form
    { 
        string tenRap;
        public ThemThucPhamMoi(string tenRap)
        {
            InitializeComponent();
            this.tenRap = tenRap;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
                return;
            ThucPham tp = new ThucPham();
            tp.Ten = txtTenThucPham.Text;
            tp.donVi = txtDonVi.Text;
            tp.soLuong = 0;
            tp.GiaNhap = Convert.ToInt32(txtGiaNhap.Text);
            tp.GiaBan = Convert.ToInt32(txtGiaBan.Text);
            if(tp.GiaNhap > tp.GiaBan)
            {
                MessageBox.Show("Bạn có chắc giá nhập cao hơn giá bán không???","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Question);            
            }
            tp.Rap = tenRap;
            DataAccess.DAOthucPham.Insert(tp);
            MessageBox.Show("Tạo Thành Công!!!");
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        private void txtTenThucPham_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTenThucPham.Text == "Nội dung trống !")
            {
                txtTenThucPham.Text = string.Empty;
            }
        }

        private void txtDonVi_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDonVi.Text == "Nội dung trống !")
            {
                txtDonVi.Text = string.Empty;
            }
        }

        private void txtGiaNhap_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtGiaNhap.Text== "Nội dung trống !")
            {
                txtGiaNhap.Text = string.Empty;
            }
        }

        private void txtGiaBan_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtGiaBan.Text == "Nội dung trống !")
            {
                txtGiaBan.Text = string.Empty;
            }
        }
    }
}
