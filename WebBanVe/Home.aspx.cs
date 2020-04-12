using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanVe.App_Code.DataAccess;

namespace WebBanVe
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptPaging.DataSource = DAOKeHoachVe.LoadAllFilmPlaying();
                rptPaging.DataBind();
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
    }
}