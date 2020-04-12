using QuanLyPhongVe.DataAccess;
using QuanLyPhongVe.Model;
using QuanLyPhongVe.ValidateOfMe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View
{
    public partial class TaoVe : Form
    {
        string tenRap;
        public TaoVe(string tenRap)
        {
            InitializeComponent();
            this.tenRap = tenRap;
            this.cbTenPhim.DisplayMember = "tenphim";
            this.cbTenPhim.ValueMember = "tenphim";
            this.cbTenPhim.DataSource = DataAccess.DAOphim.LoadAllFilm();

            cbKhungGio.SelectedIndex = 0;
            cbKhanDai.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        Model.KeHoachVe taoKeHoach()
        {

            Model.KeHoachVe keHoach = new Model.KeHoachVe();
            keHoach.TenPhim = cbTenPhim.Text;
            keHoach.TenRap = tenRap;
            keHoach.KhanDai = cbKhanDai.Text;
            keHoach.NgayChieu = mcNgayChieu.SelectionRange.Start.Date;
            keHoach.SuatChieu = cbKhungGio.Text;
            if (rb2D.Checked == true)
            {
                keHoach.LoaiPhim = "2D";
            }
            else if (rb3D.Checked == true)
            {
                keHoach.LoaiPhim = "3D";
            }


            if (ckbPhuDe.Checked == true)
            {
                keHoach.PhuDe = true;
            }
            else
                keHoach.PhuDe = false;
            return keHoach;
        }
        private void taoGiaGhe()
        {
            foreach (Ghe ghe in GheList.ListAllGhe())
            {
                if (ghe.LoaiGhe.ToLower() == "phothong")
                {
                    DAOGiaVeCuaGhe.InsertGiaVeCuaGhe(taoKeHoach(), ghe, Convert.ToInt32(txtPhoThong.Text));
                }

                if (ghe.LoaiGhe.ToLower() == "vip")
                {
                    DAOGiaVeCuaGhe.InsertGiaVeCuaGhe(taoKeHoach(), ghe, Convert.ToInt32(txtVIP.Text));
                }

                if (ghe.LoaiGhe.ToLower() == "deluxe")
                {
                    DAOGiaVeCuaGhe.InsertGiaVeCuaGhe(taoKeHoach(), ghe, Convert.ToInt32(txtDeluxe.Text));
                }

                if (ghe.LoaiGhe.ToLower() == "switchbox")
                {
                    DAOGiaVeCuaGhe.InsertGiaVeCuaGhe(taoKeHoach(), ghe, Convert.ToInt32(txtSwitchbox.Text));
                }

            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {

            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref panel1))
                return;
            try {
                    DAOkeHoachVe.InsertKeHoachVe(taoKeHoach());
                    taoGiaGhe();
                    MessageBox.Show("Tạo kế hoạch vé thành công rồi nha!!!");
                }
            catch(Exception ex) 
            { 
                MessageBox.Show("Kế Hoanch Vé Này Bị Trùng Lặp!!!"); 
            }
            DAOphim.UpdateDa(cbTenPhim.SelectedValue+"");
           
        }

        private void txtPhoThong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        private void txtVIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        private void txtDeluxe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        private void txtSwitchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOfMe.ValidateOfMe.inputOnlyNumber(ref e);
        }

        private void txtSwitchbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSwitchbox.Text == "Nội dung trống !")
            {
                txtSwitchbox.Text = string.Empty;
            }
        }

        private void txtPhoThong_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPhoThong.Text == "Nội dung trống !")
            {
                txtPhoThong.Text = string.Empty;
            }
        }

        private void txtVIP_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtVIP.Text == "Nội dung trống !")
            {
                txtVIP.Text = string.Empty;
            }
        }

        private void txtDeluxe_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDeluxe.Text == "Nội dung trống !")
            {
                txtDeluxe.Text = string.Empty;
            }
        }
    }
}
