using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.AccountManager
{
    public partial class MenuAccounManager : Form
    {
        string rap;
        public MenuAccounManager(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            DangKi dk = new DangKi(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(dk);
            dk.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(rap);
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            AccountManager.ListAccount ds = new ListAccount(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnShow.Controls.Add(ds);
            ds.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuAccounManager_Load(object sender, EventArgs e)
        {
            #region set full man hinh
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.WindowState = FormWindowState.Maximized;
            #endregion
        }
    }
}
