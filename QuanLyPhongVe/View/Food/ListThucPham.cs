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
    public partial class ListThucPham : Form
    {
        string tenRap;
        public ListThucPham(string tenRap)
        {
            InitializeComponent();
            this.tenRap = tenRap;
        }

        private void ListThucPham_Load(object sender, EventArgs e)
        {
            dgvShow.Columns.Clear();
            dgvShow.AutoGenerateColumns = false;
            dgvShow.DataSource = DataAccess.DAOthucPham.GetAll(tenRap);

            dgvShow.Columns.Add("tenthucpham", "Tên Thực Phẩm");
            dgvShow.Columns["tenthucpham"].DataPropertyName = "tenthucpham";

            dgvShow.Columns.Add("donvi", "Đơn Vị");
            dgvShow.Columns["donvi"].DataPropertyName = "donvi";

            dgvShow.Columns.Add("soluong", "Số Lượng");
            dgvShow.Columns["soluong"].DataPropertyName = "soluong";

            dgvShow.Columns.Add("gianhap", "Mua Vào");
            dgvShow.Columns["gianhap"].DataPropertyName = "gianhap";


            dgvShow.Columns.Add("giaban", "Bán Ra");
            dgvShow.Columns["giaban"].DataPropertyName = "giaban";
        }
    }
}
