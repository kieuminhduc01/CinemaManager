using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BanVe.Model
    
{
    public class ThucPham
    {
        public string Ten { get; set; }
        public string donVi { get; set; }
        public int soLuong { get; set; }

        public string poster { get; set; }

        public string Rap { get; set; }

        public int GiaNhap { get; set; }

        public int GiaBan { get; set; }
        

    }
    public class ThucPhamList
    {
        public static List<ThucPham> GetAll(string rap)
        {
            List<ThucPham> lstTP = new List<ThucPham>();
            foreach(DataRow dr in DataAccess.DAOthucPham.GetAll(rap).Rows)
            {
                ThucPham tp = new ThucPham();
                tp.Ten = dr["tenThucPham"].ToString();
                tp.donVi = dr["donvi"].ToString();
                tp.GiaBan =Convert.ToInt32(dr["giaBan"].ToString());
                lstTP.Add(tp);
            }
            return lstTP;
        }
    }
}
