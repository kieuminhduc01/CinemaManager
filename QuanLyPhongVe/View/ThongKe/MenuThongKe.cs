using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.ThongKe
{
    public partial class MenuThongKe : Form
    {
        string rap;
        public MenuThongKe(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKeVeBanDuoc dk = new ThongKeVeBanDuoc(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(dk);
            dk.Show();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(rap);
            home.Show();
        }
    }
}
