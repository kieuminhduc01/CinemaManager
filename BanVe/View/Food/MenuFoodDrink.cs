using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanVe.View.Account;
namespace BanVe.View.Food
{
    public partial class MenuFoodDrink : Form
    {
        string rap;
        public MenuFoodDrink(string rap)
        {
            this.rap = rap;
            InitializeComponent();
        }

        private void btnFoodDrink_Click(object sender, EventArgs e)
        {
            pnShow.Controls.Clear();
            ThucPham dk = new ThucPham(rap) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
