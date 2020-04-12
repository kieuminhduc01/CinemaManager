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
    public partial class MenuFood : Form
    {
        string rap;
        public MenuFood(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            NhapHang dk = new NhapHang(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void btnThemHangMoi_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            ThemThucPhamMoi dk = new ThemThucPhamMoi(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            ListThucPham dk = new ListThucPham(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(rap);
            home.Show();
        }

        private void MenuFood_Load(object sender, EventArgs e)
        {
            #region set full man hinh
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.WindowState = FormWindowState.Maximized;
            #endregion
        }
    }
}
