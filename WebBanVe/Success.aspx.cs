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
    public partial class WebForm2 : System.Web.UI.Page
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

                AccountModel acc = Session["accSession"] as AccountModel;
                ten.Text =acc.Ten ;
                GiaVeCuaGhe giaVe = Session["giaVe"] as GiaVeCuaGhe;
                phim.Text = giaVe.Phim;
                rap.Text = giaVe.Rap;
                suatchieu.Text = giaVe.Suat;
                khandai.Text = giaVe.KhanDai;
                tien.Text = giaVe.TongTien;

                string ghe="";
                Dictionary<string, int> lstGheDangChon = Session["lstGheDangChon"] as Dictionary<string, int>;
                foreach (KeyValuePair<string, int> item in lstGheDangChon)
                {
                    ghe += "  " + item.Key;
                }
                dsGhe.Text = ghe;

                series.Text = DAOdonHangVe.GetSeries().Rows[0][0].ToString();
            }
        }
    }
}