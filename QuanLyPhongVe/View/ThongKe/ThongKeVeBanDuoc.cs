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
    public partial class ThongKeVeBanDuoc : Form
    {
        string rap;
        public ThongKeVeBanDuoc(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dpkTu.Value.Date > dpkDen.Value.Date)
            {
                MessageBox.Show(@"Không được để ngày Từ lới hơn ngày đến");
            }
            chart1.DataSource=DataAccess.DAODoanhThu.GetDoanhThu(rap, dpkTu.Value.Date, dpkDen.Value.Date);
            chart1.Series["DoanhThu"].XValueMember = "tenPhim";
            chart1.Series["DoanhThu"].YValueMembers = "doanhThu";
            //chart1.Series["SoVe"].XValueMember = "tenPhim";
            //chart1.Series["SoVe"].YValueMembers = "sove";
            chart1.DataBind();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
