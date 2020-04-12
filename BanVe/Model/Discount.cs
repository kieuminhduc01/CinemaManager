using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BanVe.Model
{
   public class Discount
    {
        public int TuoiTu { get; set; }
        public int TuoiDen { get; set; }
        public int Star { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayHetHan { get; set; }
        public int soTienDuocGiam { get; set; }
        public string loaiDiscount { set; get; }
        public string maDiscount { get; set; }
        public string luaTuoi
        {
            get { return TuoiTu + " đến " + TuoiDen; }
        }
        
        
    }
    class DiscountList
    {
        public static List<Discount> GetListDiscount()
        {
            List<Discount> discountList = new List<Discount>();
            DataTable dt = DataAccess.DAOdiscount.getAllDiscount();

            foreach (DataRow dr in dt.Rows)
            {
                Discount dis = new Discount();

                dis.Star = Convert.ToInt32(dr["star"]);
                dis.ngayBatDau = Convert.ToDateTime(dr["ngayBatDau"]).Date;
                dis.ngayHetHan = Convert.ToDateTime(dr["ngayHetHan"]).Date;
                dis.soTienDuocGiam = Convert.ToInt32(dr["soTienDuocGiam"]);
                dis.loaiDiscount = dr["loaiDiscount"].ToString();
                dis.maDiscount = dr["maDiscount"].ToString();
                string[] tuDen = dr["luaTuoi"].ToString().Split('-');
                dis.TuoiTu = Convert.ToInt32(tuDen[0]);
                dis.TuoiDen = Convert.ToInt32(tuDen[1]);

                Console.WriteLine(dis.maDiscount);

                discountList.Add(dis);

            }
            return discountList;
        }
        public static Discount getDiscountByID(string discountID)
        {
            foreach(Discount item in GetListDiscount())
            {
                if(item.maDiscount.Equals(discountID, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }
        public static List<Discount> GetListDiscountByAge(int cusAge)
        {
            List<Discount> discountList = new List<Discount>();
            DataTable dt = DataAccess.DAOdiscount.getDiscountAvarible();

            foreach (DataRow dr in dt.Rows)
            {
                Discount dis = new Discount();
                
                dis.soTienDuocGiam = Convert.ToInt32(dr["soTienDuocGiam"]);  
                dis.maDiscount = dr["maDiscount"].ToString();
                string[] tuDen = dr["luaTuoi"].ToString().Split('-');
                dis.TuoiTu = Convert.ToInt32(tuDen[0]);
                dis.TuoiDen = Convert.ToInt32(tuDen[1]);

                if(dis.TuoiTu<=cusAge&&cusAge<=dis.TuoiDen)
                {
                    discountList.Add(dis);
                }
                

            }
            return discountList;
        }
    }
    
   
}
