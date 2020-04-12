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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GiaVeCuaGhe giaGhe = Session["giaVe"] as GiaVeCuaGhe;
                tongTien.Text = giaGhe.TongTien;
            }
        }
        void InsertVe()
        {
            GiaVeCuaGhe giaGhe=Session["giaVe"] as GiaVeCuaGhe;
            Dictionary<string, int> lstGheDangChon = Session["lstGheDangChon"] as Dictionary<string, int>;


            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {
                DAOVe.Insert(giaGhe, item.Key, item.Value.ToString());
            }

        }
        void InsertOrder()
        {
            AccountModel acc = Session["accSession"] as AccountModel;
            GiaVeCuaGhe giaGhe = Session["giaVe"] as GiaVeCuaGhe;
            DAOdonHangVe.Insert(acc.Ten, acc.Email, giaGhe.TongTien, giaGhe.Rap);
            Dictionary<string, int> lstGheDangChon = Session["lstGheDangChon"] as Dictionary<string, int>;
            DateTime ngay = Convert.ToDateTime(Session["ngay"]);
            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {
                DAOGiaVeCuaGhe.ChuyenTrangThaiDa(item.Key, giaGhe.Rap, giaGhe.KhanDai, giaGhe.Suat, ngay);

            }

            InsertVe();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertOrder();
            Response.Redirect("/Success.aspx");
        }
    }
}