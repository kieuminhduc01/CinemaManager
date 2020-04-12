using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebBanVe.App_Code.DataAccess;
using WebBanVe.App_Code.Model;

namespace WebBanVe
{
    public partial class FilmDetail : System.Web.UI.Page
    {
        List<DateTime> DaysPlay = new List<DateTime>();
       
        string phim;
        string rap;
        Dictionary<string, int> lstGheDangChon;
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

                rap = "%";
                phim = Request.QueryString["phim"];
                #region bin list rap
                rblRap.DataSource = DAOKeHoachVe.LoadRapByPhim(phim);
                rblRap.DataTextField = "tenRap";
                rblRap.DataValueField = "tenRap";
                rblRap.DataBind();
                Session["lstGheDangChon"] = new Dictionary<string, int>();
                #endregion
            }
            rptPaging.DataSource = DAOphim.GetInfoByTitle(Request.QueryString["phim"]);
            rptPaging.DataBind();
            BinSpecialDayToCalendar();
            lstGheDangChon = Session["lstGheDangChon"] as Dictionary<string, int>;
            try
            {
                HienGiaVe();
            }
            catch (Exception ex) { }
            if (IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#rblRap';", true);
            }


        }
        protected void BinSpecialDayToCalendar()
        {
            foreach (DataRow dr in DAOKeHoachVe.LoadDayPlayFilm(Request.QueryString["phim"], rblRap.SelectedValue).Rows)
            {
                DaysPlay.Add(Convert.ToDateTime(dr["ngaychieu"].ToString()));

            }

        }
        protected void cPickDate_DayRender(object sender, DayRenderEventArgs e)
        {

            if (DaysPlay.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.Green;
                e.Cell.Font.Bold = true;
            }
            else
            {
                e.Day.IsSelectable = false;
            }
        }
        protected void LoadKhungGio(string phim, DateTime ngay, string rap)
        {

            rbSuat.DataSource = DAOKeHoachVe.LoadSuatChieu(phim, ngay, rap);
            rbSuat.DataTextField = "suatchieu";
            rbSuat.DataValueField = "suatchieu";
            rbSuat.DataBind();
            int a = rbSuat.Items.Count;
        }
        protected void cPickDate_SelectionChanged(object sender, EventArgs e)
        {

            LoadKhungGio(Request.QueryString["phim"], cPickDate.SelectedDate, rblRap.SelectedValue);

        }

        protected void rbSuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbKhanDai.DataSource = DAOKeHoachVe.LoadKhanDai(Request.QueryString["phim"], cPickDate.SelectedDate, rbSuat.SelectedValue, rblRap.SelectedValue);
            rbKhanDai.DataTextField = "khanDaiID";
            rbKhanDai.DataValueField = "khanDaiID";
            rbKhanDai.DataBind();

        }

        protected void rblRap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["accSession"] == null)
            {
                Response.Write("<script>alert('Đăng Nhập Cái Đã Bạn Ơi');</script>");
                Response.Redirect("/Account.aspx");
            }
        }
        protected int GiaGhe(string gheID)
        {
            int soDauGhe = Convert.ToInt32(gheID.Substring(0, 1));

            if (soDauGhe < 3)
            {
                return Convert.ToInt32(txtPhoThong.Text);
            }
            else if (soDauGhe < 6)
            {
                return Convert.ToInt32(txtVIP.Text);
            }
            else if (soDauGhe < 9)
            {
                return Convert.ToInt32(txtDeluxe.Text);
            }

            return Convert.ToInt32(txtSwitchBox.Text);

        }
        protected void HienGiaVe()
        {
            try
            {
                txtPhoThong.Text = GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[0].GiaVe.ToString();
                txtVIP.Text = GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[30].GiaVe.ToString();
                txtDeluxe.Text = GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[60].GiaVe.ToString();
                txtSwitchBox.Text = GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[88].GiaVe.ToString();
            }
            catch (Exception ex) { }
        }
        protected void rbSuat_Load(object sender, EventArgs e)
        {
            try
            {
                if (rbKhanDai.SelectedIndex != -1)
                {
                    int count = 0;
                    Table myTable = new Table();
                    for (int r = 0; r < 10; r++)
                    {
                        TableRow tableRow = new TableRow();
                        for (int c = 0; c < 9; c++)
                        {
                            TableCell cell = new TableCell();
                            Button btn = new Button();
                            btn.Text = GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[count].GheID;
                            btn.Click += new EventHandler(btn_Click);
                            btn.ForeColor = Color.White;
                            btn.Height = 30;
                            btn.Width = 30;
                            #region Set Mau Ghe

                            if (GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[count].TrangThai == "da")
                            {
                                btn.BackColor = System.Drawing.Color.Gray;
                                btn.Enabled = false;
                            }
                            else
                            {
                                int dauSoGhe = Convert.ToInt32(GiaVeCuaGheList.GetAll(rblRap.SelectedValue, rbKhanDai.SelectedValue, cPickDate.SelectedDate, rbSuat.SelectedValue)[count].GheID.Substring(0, 1));
                                if (dauSoGhe < 3)
                                    btn.BackColor = System.Drawing.Color.FromArgb(64, 86, 141);
                                else if (dauSoGhe < 6)
                                    btn.BackColor = System.Drawing.Color.FromArgb(0, 132, 255);
                                else if (dauSoGhe < 9)
                                    btn.BackColor = System.Drawing.Color.FromArgb(254, 101, 80);
                                else if (dauSoGhe == 9)
                                    btn.BackColor = System.Drawing.Color.FromArgb(208, 67, 35);

                            }

                            #endregion
                            cell.Controls.Add(btn);
                            //Add the cell to the current row.
                            tableRow.Cells.Add(cell);

                            //    if (c == 5)
                            //    {
                            //        // This is the final column, add the row
                            //       
                            //    }
                            count++;
                        }
                        myTable.Rows.Add(tableRow);
                    }
                    Label lbScreen = new Label();
                    lbScreen.Text = "Screen";
                    lbScreen.BackColor = Color.Gold;
                    lbScreen.ForeColor = Color.White;
                    lbScreen.Width = 270;
                    pnGhe.Controls.Add(lbScreen);
                    pnGhe.Controls.Add(myTable);
                }

            }
            catch (Exception ex) { }
        }
        int TamTinh()
        {
            int tong = 0;
            try
            {
                foreach (KeyValuePair<string, int> item in lstGheDangChon)
                            {
                                tong += item.Value;

                            }
            }catch(Exception ex) { }
            
            return tong;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            if (btn.BackColor != Color.Orange)
            {
                 btn.BackColor = Color.Orange;
                lstGheDangChon.Add(btn.Text, GiaGhe(btn.Text));
   
            }
            else if(btn.BackColor == Color.Orange)
            {
               
                int dausSoGhe = Convert.ToInt32(btn.Text.Substring(0, 1));
                if (dausSoGhe < 3)
                    btn.BackColor = Color.FromArgb(64, 86, 141);
                else if (dausSoGhe < 6)
                    btn.BackColor = Color.FromArgb(0, 132, 255);
                else if (dausSoGhe < 9)
                    btn.BackColor = Color.FromArgb(254, 101, 80);
                else if (dausSoGhe == 9)
                    btn.BackColor = Color.FromArgb(208, 67, 35);
                lstGheDangChon.Remove(btn.Text);
            } 
            txtTamTinh.Text = TamTinh() + "";
          
        }
        void InsertVe()
        {
            GiaVeCuaGhe giaVe = new GiaVeCuaGhe();
            giaVe.Rap = rblRap.SelectedValue;
            giaVe.Phim = Request.QueryString["phim"];
            giaVe.Suat = rbSuat.SelectedValue;
            giaVe.KhanDai = rbKhanDai.SelectedValue;

            foreach (KeyValuePair<string, int> item in lstGheDangChon)
            {
                DAOVe.Insert(giaVe, item.Key, item.Value.ToString());
            }

        }
        void InputToSession() 
        {
            GiaVeCuaGhe giaVe = new GiaVeCuaGhe();
            giaVe.Rap = rblRap.SelectedValue;
            giaVe.Phim = Request.QueryString["phim"];
            giaVe.Suat = rbSuat.SelectedValue;
            giaVe.KhanDai = rbKhanDai.SelectedValue;
            giaVe.TongTien = txtTamTinh.Text;
            Session["giaVe"] = giaVe;
            Session["ngay"] = cPickDate.SelectedDate.ToString();
        }
        protected void btnDatVe_Click(object sender, EventArgs e)
        {

       
            InputToSession();
            Response.Redirect("/Momo.aspx");
        }
    }
}