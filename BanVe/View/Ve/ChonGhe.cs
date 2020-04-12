using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanVe.DataAccess;
using BanVe.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BanVe.View.Ve
{
    public partial class ChonGhe : Form
    {
        Dictionary<string, int> lstGheDangChon = new Dictionary<string, int>();
        string rap;
        public ChonGhe(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void ChonGhe_Load(object sender, EventArgs e)
        {
            lbTenPhim.DataSource = DAOGiaVeCuaGhe.GetTenPhim(rap);
            lbTenPhim.DisplayMember = "tenPhim";
            lbTenPhim.ValueMember = "tenPhim";
        }

        private void lbTenPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSuatChieu.DisplayMember = "suatChieu";
            lbSuatChieu.ValueMember = "suatChieu";
            lbSuatChieu.DataSource = DAOGiaVeCuaGhe.GetSuatChieu(rap, lbTenPhim.SelectedValue.ToString());
        }

        private void lbSuatChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbKhanDai.DisplayMember = "khandaiid";
            lbKhanDai.ValueMember = "khandaiid";
            lbKhanDai.DataSource = DAOGiaVeCuaGhe.GetKhanDai(rap, lbTenPhim.SelectedValue.ToString(),lbSuatChieu.SelectedValue.ToString());
        }
        void GiaTungLoaiGhe(GiaVeCuaGhe giaVe)
        {
             txtPhoThong.Text = GiaVeCuaGheList.GetAll(giaVe)[0].GiaVe.ToString();
             txtVIP.Text = GiaVeCuaGheList.GetAll(giaVe)[30].GiaVe.ToString();
             txtDeluxe.Text = GiaVeCuaGheList.GetAll(giaVe)[60].GiaVe.ToString();
             txtSwitchBox.Text = GiaVeCuaGheList.GetAll(giaVe)[88].GiaVe.ToString();
        }
        void HienGhe(GiaVeCuaGhe giaVe)
        {
            tlpGhe.Controls.Clear();
            int count = 0;
            for(int i = 0; i < tlpGhe.RowCount; i++)
            {
                for(int j = 0; j < tlpGhe.ColumnCount; j++)
                {
                    Label lbGhe = new Label();
                   
                    lbGhe.AutoSize = false;
                    lbGhe.Dock = DockStyle.Fill;
                    lbGhe.TextAlign = ContentAlignment.MiddleCenter;
                    
                   
                    lbGhe.BorderStyle = BorderStyle.FixedSingle;
                    lbGhe.Text =GiaVeCuaGheList.GetAll(giaVe)[count].GheID;
                    #region Set Mau Ghe
                    if (GiaVeCuaGheList.GetAll(giaVe)[count].TrangThai=="chua")
                        lbGhe.BackColor = Color.White;
                    if (GiaVeCuaGheList.GetAll(giaVe)[count].TrangThai == "da")
                        lbGhe.BackColor = Color.Gray;
                    #endregion
                    lbGhe.Click += LbGhe_Click;
                    tlpGhe.Controls.Add(lbGhe, j, i);
                    count++;
                }
            }
        }
        int GiaGhe(string gheID)
        {
            int soDauGhe = Convert.ToInt32(gheID.Substring(0,1));

            if (soDauGhe < 3)
            {
                return Convert.ToInt32(txtPhoThong.Text);
            }
            else if(soDauGhe < 6)
            {
                return Convert.ToInt32(txtVIP.Text);
            }
            else if (soDauGhe < 9)
            {
                return Convert.ToInt32(txtDeluxe.Text);
            }

            return Convert.ToInt32(txtSwitchBox.Text);

        }
        int TamTinh()
        {
            int tong = 0;
            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {
                tong +=item.Value;
                
            }
            return tong;
        }
        private void LbGhe_Click(object sender, EventArgs e)
        {
            Label lbGhe = sender as Label;
            //chọn ghế
            if (lbGhe.BackColor == Color.White)
            {
                lbGhe.BackColor = Color.Orange;
                lstGheDangChon.Add(lbGhe.Text, GiaGhe(lbGhe.Text));
            }
            //bỏ chọn ghế
            else if (lbGhe.BackColor == Color.Orange)
            {
                lbGhe.BackColor = Color.White;
                lstGheDangChon.Remove(lbGhe.Text);
            }
            //cảnh báo ghế không được chọn
            else if (lbGhe.BackColor == Color.Gray)
            {
                MessageBox.Show("Ghế Này Đã Được Đặt Trước!!");
            }
            txtTamTinh.Text = TamTinh()+"";
            txtSoTienThanhToan.Text = TamTinh()+"";
        }
        private void Reset()
        {
            txtTamTinh.Text = "0";
            txtPhoThong.Text = "0";
            txtVIP.Text = "0";
            txtDeluxe.Text = "0";
            txtSwitchBox.Text = "0";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtGiam.Text = "0";
            txtSoTienThanhToan.Text = "0";
           
            lstGheDangChon.Clear();
            tlpGhe.Controls.Clear();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            Reset();
            try
            {
             GiaVeCuaGhe giaVe=new GiaVeCuaGhe();
                        giaVe.Rap = rap;
                        giaVe.Phim = lbTenPhim.SelectedValue.ToString();
                        giaVe.Suat = lbSuatChieu.SelectedValue.ToString();
                        giaVe.KhanDai = lbKhanDai.SelectedValue.ToString();
                        GiaTungLoaiGhe(giaVe);
                        HienGhe(giaVe);
            }catch(Exception ex)
            {
                MessageBox.Show("Chưa chọn đủ các đề mục");
            }
           
        }

        private void btnShowDiscount_Click(object sender, EventArgs e)
        {
            lbDiscount.DisplayMember = "maDiscount";
            lbDiscount.ValueMember = "soTienDuocGiam";
            lbDiscount.DataSource = DiscountList.GetListDiscountByAge(DateTime.Now.Year-dpkNamSinh.Value.Year);
           
        }

        private void lbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtGiam.Text = lbDiscount.SelectedValue.ToString();
            try { 
                txtSoTienThanhToan.Text = Convert.ToInt32(txtTamTinh.Text) - Convert.ToInt32(txtGiam.Text)+"";
                }   catch(Exception ex)
            {
                MessageBox.Show("Chọn ghế đã bạn ơi @@ ");
            }
         }
           

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void InsertVe()
        {
            GiaVeCuaGhe giaVe = new GiaVeCuaGhe();
            giaVe.Rap = rap;
            giaVe.Phim = lbTenPhim.SelectedValue.ToString();
            giaVe.Suat = lbSuatChieu.SelectedValue.ToString();
            giaVe.KhanDai = lbKhanDai.SelectedValue.ToString();

            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {

                DAOVe.Insert(giaVe, item.Key, item.Value.ToString());

            }
           
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref pnInfor))
                return;
            
            #region InsertDonHangVe
            GiaVeCuaGhe giaVe = new GiaVeCuaGhe();
            giaVe.Rap = rap;
            giaVe.Suat = lbSuatChieu.SelectedValue.ToString();
            giaVe.KhanDai = lbKhanDai.SelectedValue.ToString();
            DAODonHangVe.Insert(txtTenKhach.Text,
                                txtTamTinh.Text,
                                lbDiscount.Text,
                                txtSoTienThanhToan.Text,
                                rap);
            #endregion
            #region update Trạng thái của ghế

            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {
                DAOGiaVeCuaGhe.ChuyenTrangThaiDa(item.Key,giaVe);
              

            }
            
            #endregion
            string dsGhe = "";
            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {

                dsGhe += item.Key+"    ";

            }
            
            #region In Hóa Đơn
            string HoaDon ="Anh / Chi : " + txtTenKhach.Text + "\r\n" +
                            "dia chi : " + txtDiaChi.Text + "\r\n" +
                            "Phim : " + lbTenPhim.Text + "\r\n" +
                            "suat chieu  :  " + lbSuatChieu.Text + "\r\n" +
                            "khan dai   :  " + txtDiaChi.Text + "\r\n" +
                            "tam tinh   :  " + txtTamTinh.Text + "\r\n" +
                            "Disocunt  :  " + lbDiscount.Text + "\r\n" +
                            "giam   :   " + txtGiam.Text + "\r\n" +
                            "tong tien   :   " + txtSoTienThanhToan.Text + "\r\n" +
                            "ghe da chon   :  " + dsGhe;
            using (SaveFileDialog sfd=new SaveFileDialog() { Filter="DPF file|*.pdf",ValidateNames=true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A6.Rotate());
                   
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        Paragraph a = new Paragraph(HoaDon);
                        
                        doc.Add(new iTextSharp.text.Paragraph(a));

                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    finally { doc.Close(); }
                }
            }
            #endregion
            InsertVe();
            MessageBox.Show("Đã Đặt xong ghế");
            Reset();//set default cho form
        }

        private void txtTenKhach_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTenKhach.Text == "Nội dung trống !")
                txtTenKhach.Text="";
        }

        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDiaChi.Text == "Nội dung trống !")
                txtDiaChi.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
