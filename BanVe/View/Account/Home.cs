using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanVe.View.Food;
using BanVe.View.Ve;
namespace BanVe.View.Account
{
    
    public partial class Home : Form
    {   
        string rap;
        public Home(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnBanVePhim_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuVe menu = new MenuVe(rap);
            menu.Show();
        }

   

        private void btnFood_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFoodDrink menu = new MenuFoodDrink(rap);
            menu.Show();
        }
    }
}
