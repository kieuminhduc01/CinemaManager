using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanVe.App_Code.DataAccess;
using WebBanVe.App_Code.Model;
namespace WebBanVe
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (Session["accSession"] == null)
                {
                    btnAccount.ImageUrl = "~/images/unknowPerson.PNG";
                }
                else
                {
                    btnAccount.ImageUrl = "~/images/person.PNG";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int soAccount = DAOAccount.CheckAccount(txtEmailLog.Text, txtPasswordLog.Text).Rows.Count;
            if (soAccount == 1)
            {
                AccountModel acc = new AccountModel();
                txtEmailacc.Text = acc.Email = txtEmailLog.Text;
                acc.Password = txtPasswordLog.Text;
                txtNameacc.Text=acc.Ten = DAOAccount.CheckAccount(txtEmailLog.Text, txtPasswordLog.Text).Rows[0]["ten"].ToString();
               txtSdtacc.Text= acc.SDT = DAOAccount.CheckAccount(txtEmailLog.Text, txtPasswordLog.Text).Rows[0]["sdt"].ToString();
                txtDiaChiacc.Text=acc.DiaChi = DAOAccount.CheckAccount(txtEmailLog.Text, txtPasswordLog.Text).Rows[0]["diachi"].ToString();
               txtNgaySinhacc.Text= acc.SinhNhat = DAOAccount.CheckAccount(txtEmailLog.Text, txtPasswordLog.Text).Rows[0]["sinhnhat"].ToString();
                Session["accSession"] = acc;
                btnAccount.ImageUrl = "~/images/person.PNG";
            }
            else
            {
                
                Response.Write("<script>alert('Tên tài khoản hoặc mật khẩu sai!!!');</script>");
            }
            {
                
            }
        }

        protected void btnSign_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DAOAccount.Register(txtEmailSign.Text, txtPasswordSign.Text, txtName.Text, txtSDT.Text, txtDiaChi.Text, Convert.ToDateTime(txtDOB.Text));
                Response.Write("<script>alert('Đăng kí thành công rồi bạn ơi =))');</script>");
            }
            catch(FormatException ex)
            {
                Response.Write("<script>alert('Xay Ra Loi');</script>");
            }
           
        }
    }
}