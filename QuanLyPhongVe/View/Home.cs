using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongVe.View.AccountManager;
using QuanLyPhongVe.View.keHoachVe;

namespace QuanLyPhongVe.View
{
    public partial class Home : Form
    {
        string rap;
        public Home(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnKeHoachVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuKeHoachVe menu = new MenuKeHoachVe(rap);
            menu.Show();
           
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAccounManager menu = new MenuAccounManager(rap);
            menu.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
           this.Hide();
            Food.MenuFood menu = new Food.MenuFood(rap);
            menu.Show();
            
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKe.MenuThongKe menu = new ThongKe.MenuThongKe(rap);
            menu.Show();
        }
    }
}
