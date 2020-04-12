using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BanVe.Model
{
    public class GiaVeCuaGhe
    {
        public string GheID { get; set; }
        public string Phim { get; set; }
        public string Rap { get; set; }
        public string KhanDai { get; set; }
        public DateTime[] Ngay { get; set; }
        public string Suat { get; set; }
        public int GiaVe { get; set; }
        public string TrangThai { get; set; }
    }
    public class GiaVeCuaGheList
    {
        public static List<GiaVeCuaGhe> GetAll(GiaVeCuaGhe giave)
        {
            List<GiaVeCuaGhe> lstGia = new List<GiaVeCuaGhe>();
            DataTable dt = DataAccess.DAOGiaVeCuaGhe.GetGiaGhe(giave);
            foreach (DataRow dr in dt.Rows)
            {
                GiaVeCuaGhe acc = new GiaVeCuaGhe();
                acc.GheID = dr["gheid"].ToString();
                acc.GiaVe = Convert.ToInt32(dr["giavecuaghe"].ToString());
                acc.TrangThai = dr["trangthai"].ToString();
                lstGia.Add(acc);
               
            }
            return lstGia;
        }

    }
}
