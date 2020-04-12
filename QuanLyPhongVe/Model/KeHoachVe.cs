using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongVe.DataAccess;
namespace QuanLyPhongVe.Model
{
    public class KeHoachVe
    {
        public string TenPhim { get; set; }
        public string TenRap { get; set; }
        public string KhanDai { get; set; }
        public DateTime NgayChieu { get; set; }
        public string SuatChieu { get; set; }

        public string LoaiPhim { get; set; }
        public bool PhuDe { get; set; }
    }
    public class KeHoachVeList
    {
        public static List<KeHoachVe> List(string tenRap,string khanDaiID,string suatChieu,string ngayChieu)
        {
            List<KeHoachVe> lstKeHoachVe = new List<KeHoachVe>();

            DataTable dt = DAOkeHoachVe.GetAll(tenRap,khanDaiID,suatChieu,ngayChieu);

            foreach (DataRow dr in dt.Rows)
            {
                KeHoachVe kh = new KeHoachVe();
                kh.TenPhim = dr["tenphim"].ToString();
                kh.TenRap = dr["tenrap"].ToString();
                kh.KhanDai = dr["khanDaiID"].ToString();
                kh.NgayChieu = Convert.ToDateTime(dr["ngaychieu"].ToString());
                kh.SuatChieu = dr["suatchieu"].ToString();
                kh.LoaiPhim = dr["loaiphim"].ToString();
                kh.PhuDe = Convert.ToBoolean(dr["phude"].ToString());
                lstKeHoachVe.Add(kh);
            }

            return lstKeHoachVe;
        }
    }
}
