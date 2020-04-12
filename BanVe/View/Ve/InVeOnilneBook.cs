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
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace BanVe.View.Ve
{
    
    public partial class InVeOnilneBook : Form
    {
        string rap;
        public InVeOnilneBook(String rap)
        {
            InitializeComponent();
            this.rap = rap;
        }
        
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
            DataTable tb= DAODonHangVe.ThongTinDonHang(txtSeries.Text,rap);
            txtEmail.Text = tb.Rows[0]["email"].ToString();
            txtTenKhach.Text = tb.Rows[0]["tenkhachhang"].ToString();
            string donHangID = tb.Rows[0]["donhangVeid"].ToString();
            dgvVe.DataSource = DAOVe.GetAll(donHangID,rap);
            }catch(Exception exx)
            {
                MessageBox.Show("mã số không tồn tại hoặc đã được sử dụng");
            }
            
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            if (ValidateOfMe.ValidateOfMe.isHaveEmptyTextBox(ref pnCheck))
                return;
            DataTable tb = DAODonHangVe.ThongTinDonHang(txtSeries.Text, rap);
           
            string donHangID = tb.Rows[0]["donhangVeid"].ToString();
            DataTable tbVe = DAOVe.GetAll(donHangID,rap);

            #region In Dãy vé
            string Ve = "";
            foreach (DataRow dr in tbVe.Rows)
            {
                Ve += "Phim  :  " + dr["tenphim"].ToString()+"\r\n"+
                      "Rap  :  "+ rap+ "\r\n" +
                      "khan dai :  " +dr["khandaiid"].ToString()+ "\r\n" +
                        "Ngay Chieu : " + dr["ngaychieu"].ToString()+ "\r\n" +
                        "Suat Chieu :  "+ dr["suatchieu"].ToString() + "\r\n" +
                        "So Ghe :  "+dr["gheid"].ToString() + "\r\n" +
                        "Gia ve :  "+dr["giave"].ToString() + "\r\n" 
                        ;
            }
            
           
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "DPF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A6.Rotate());

                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        Paragraph a = new Paragraph(Ve);

                        doc.Add(new iTextSharp.text.Paragraph(a));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { doc.Close(); }
                }
            }
            #endregion
            try//update da nhan ve
            {
                DAODonHangVe.UpdateDaNhanVe(txtSeries.Text, rap);
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            MessageBox.Show("In vé thành công ;>");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSeries_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void txtSeries_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtSeries.Text== "Nội dung trống !")
            {
                txtSeries.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
