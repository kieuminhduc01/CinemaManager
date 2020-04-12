using QuanLyPhongVe.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongVe.Model
{
    public class Ghe
    {
        public string GheID { get; set; }
        public string LoaiGhe { get; set; }
    }
    class GheList
    {
        public static List<Ghe> ListAllGhe()
        {
            List<Ghe> lstGhe = new List<Ghe>();

            DataTable dt = DAOghe.GetAll();

            foreach(DataRow dr in dt.Rows)
            {
                Ghe g = new Ghe();
                g.GheID = dr["gheID"].ToString();
                g.LoaiGhe = dr["loaiGhe"].ToString();
                lstGhe.Add(g);
            }
            
            return lstGhe;
        }
    }
}
