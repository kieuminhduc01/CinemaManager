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
    public partial class ListAccount : Form
    {
        string rap;
        public ListAccount(string rap)
        {
            InitializeComponent();
            this.rap = rap;
        }

        private void ListAccount_Load(object sender, EventArgs e)
        {
            dgvShow.AutoGenerateColumns = false;
            dgvShow.DataSource = DataAccess.DAOAccount.GetAllBanVe(rap);

            dgvShow.Columns.Add("email", "Email");
            dgvShow.Columns["email"].DataPropertyName = "email";

            dgvShow.Columns.Add("password", "Mật Khẩu");
            dgvShow.Columns["password"].DataPropertyName = "password";

            dgvShow.Columns.Add("ten", "Tên Nhân Viên");
            dgvShow.Columns["ten"].DataPropertyName = "ten";

            dgvShow.Columns.Add("sdt", "Số Điện Thoại");
            dgvShow.Columns["sdt"].DataPropertyName = "sdt";

            dgvShow.Columns.Add("diachi", "Địa chỉ");
            dgvShow.Columns["diachi"].DataPropertyName = "diachi";

            dgvShow.Columns.Add("sinhnhat", "Ngày Sinh");
            dgvShow.Columns["sinhnhat"].DataPropertyName = "sinhnhat";

        }
    }
}
