using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanVe.View.Account;
namespace BanVe.View.Ve
{
    public partial class MenuVe : Form
    {
        string rap;
        public MenuVe(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            ChonGhe dk = new ChonGhe(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            InVeOnilneBook dk = new InVeOnilneBook(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(rap);
            home.Show();
        }
    }
}
