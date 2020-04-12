using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.View.KeHoachVe
{
    public partial class listVe : Form
    {
        string tenRap;
        string khanDaiID = "%";
        string suatChieu = "%";
        string ngayChieu="%";
        public listVe(string tenRap)
        {
            InitializeComponent();
            this.tenRap = tenRap;
        }

        private void GridviewLoad()
        {
            dgvListKeHoachVe.Columns.Clear();
            dgvListKeHoachVe.AutoGenerateColumns = false;
            dgvListKeHoachVe.DataSource = Model.KeHoachVeList.List(tenRap,khanDaiID,suatChieu,ngayChieu);

            dgvListKeHoachVe.Columns.Add("tenPhim", "Tên Phim");
            dgvListKeHoachVe.Columns["tenPhim"].DataPropertyName = "tenphim";

            dgvListKeHoachVe.Columns.Add("tenrap", "Tên Rạp");
            dgvListKeHoachVe.Columns["tenrap"].DataPropertyName = "tenrap";

            dgvListKeHoachVe.Columns.Add("khandai", "Khán Đài");
            dgvListKeHoachVe.Columns["khandai"].DataPropertyName = "khandai";

            dgvListKeHoachVe.Columns.Add("ngayChieu", "Ngày Chiếu");
            dgvListKeHoachVe.Columns["ngayChieu"].DataPropertyName = "ngayChieu";

            dgvListKeHoachVe.Columns.Add("suatChieu", "Suất Chiếu");
            dgvListKeHoachVe.Columns["suatChieu"].DataPropertyName = "suatChieu";

            dgvListKeHoachVe.Columns.Add("loaiphim", "Loại phim");
            dgvListKeHoachVe.Columns["loaiphim"].DataPropertyName = "loaiphim";

            dgvListKeHoachVe.Columns.Add("phude", "Phụ đề");
            dgvListKeHoachVe.Columns["phude"].DataPropertyName = "phude";
            

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listVe_Load(object sender, EventArgs e)
        {
            GridviewLoad();
        }

        private void cbKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            suatChieu = cbKhungGio.SelectedItem.ToString();
            if (suatChieu == "ALL")
            {
                suatChieu = "%";
            }
            GridviewLoad();
        }

        private void cbKhanDai_SelectedIndexChanged(object sender, EventArgs e)
        {
            khanDaiID = cbKhanDai.SelectedItem.ToString();
            if (khanDaiID == "ALL")
            {
                khanDaiID = "%";
            }
            GridviewLoad();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ngayChieu = mcNgayChieu.SelectionStart.Date.ToString("yyyy-MM-dd") + "%";
            MessageBox.Show(mcNgayChieu.SelectionStart.Date.ToString("yyyy-MM-dd"));
            GridviewLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ngayChieu ="%";
            GridviewLoad();
        }
    }
}
