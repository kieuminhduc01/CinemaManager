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
   
    public partial class NhapHang : Form
    {
        string tenRap;
        public NhapHang(string tenRap)
        {
            InitializeComponent();
            this.tenRap = tenRap;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
                return;
            DataAccess.DAOthucPham.NhapHang(cbTenThucPham.SelectedValue.ToString(), Convert.ToInt32(txtSoLuong.Text),tenRap);
            MessageBox.Show("Nhập Hàng Thành Công");
        }


        private void NhapHang_Load(object sender, EventArgs e)
        {
            cbTenThucPham.DataSource = DataAccess.DAOthucPham.GetAll(tenRap);
            cbTenThucPham.ValueMember = "tenThucPham";
            cbTenThucPham.DisplayMember = "tenthucpham";

        }

        private void txtSoLuong_MouseClick(object sender, MouseEventArgs e)
        {
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
            {
                txtSoLuong.Text = string.Empty;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }
    }
}
