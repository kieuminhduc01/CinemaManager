using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BanVe.View.Food
{
    public partial class ThucPham : Form
    {
        string rap;
        Dictionary<string, int> tenVaSoLuong = new Dictionary<string, int>();
        
        public ThucPham(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void ThucPham_Load(object sender, EventArgs e)
        {
            lbFood.DisplayMember = "ten";
            lbFood.ValueMember = "giaban";
            lbFood.DataSource = Model.ThucPhamList.GetAll(rap);
            
        }

        private void lbFood_Click(object sender, EventArgs e)
        {  
                Label labelTen = new Label();
                Label labelGia = new Label();
                NumericUpDown num = new NumericUpDown();
                num.Value = 1;
                num.ValueChanged += Num_ValueChanged;
                labelTen.Text = lbFood.Text;
                labelGia.Text=lbFood.SelectedValue.ToString();
                flpOrder.Controls.Add(labelTen);
                flpOrder.Controls.Add(num);
                flpOrder.Controls.Add(labelGia);

                txtTongTien.Text =(Convert.ToInt32(txtTongTien.Text) +Convert.ToInt32(labelGia.Text))+"";
                
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {

            int tongTien = 0;
            for (int i = 0; i < flpOrder.Controls.Count; i = i + 3)
            {
                Label gia = flpOrder.Controls[i + 2] as Label;
                NumericUpDown numb = flpOrder.Controls[i + 1] as NumericUpDown;

                tongTien += Convert.ToInt32(gia.Text) * Convert.ToInt32(numb.Value);
                txtTongTien.Text = tongTien + "";
            }


            NumericUpDown num= sender as NumericUpDown;
            if (num.Value == 0)
            {

                int index = flpOrder.Controls.IndexOf(num);
                flpOrder.Controls.Remove(num);
                flpOrder.Controls.RemoveAt(index-1);
                flpOrder.Controls.RemoveAt(index - 1);
            }

            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           
            for(int i = 0; i < flpOrder.Controls.Count; i=i+3)
            {
                NumericUpDown num = flpOrder.Controls[i + 1] as NumericUpDown;
                int soLuong = Convert.ToInt32(num.Value);
                string Ten=flpOrder.Controls[i].Text;

                DataAccess.DAOthucPham.BanHang(Ten, soLuong, rap);
            }
            MessageBox.Show("Thanh Toan Thanh Cong!!!");
            lbFood.ClearSelected();
            flpOrder.Controls.Clear();
        }
    }
}
