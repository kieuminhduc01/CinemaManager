using QuanLyPhongVe.View.KeHoachVe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.keHoachVe
{
    public partial class MenuKeHoachVe : Form
    {
        string rap;
        public MenuKeHoachVe(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnThemHangMoi_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            TaoVe dk = new TaoVe(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            listVe dk = new listVe(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(rap);
            home.Show();
        }

        private void MenuKeHoachVe_Load(object sender, EventArgs e)
        {
            #region set full man hinh
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.WindowState = FormWindowState.Maximized;
            #endregion
        }
    }
}
