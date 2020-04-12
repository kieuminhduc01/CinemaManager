using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BanVe.Model;

namespace BanVe.DataAccess
{
    public class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConnectString = ConfigurationManager.ConnectionStrings["AstralisCinema"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectString);
            return Connection;
        }
        public static int InsertInToDatabase(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            return command.ExecuteNonQuery();
        }
        public static int ExecuteSQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            Command.Parameters.AddRange(parameters);
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }
        public static DataTable GetDataBySQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Parameters.AddRange(parameters);
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();
            dt.Load(Reader);

            Command.Connection.Close();
            return dt;
        }
    }
    
    public class DAOAccount
    {
        public static DataTable GetAll(string tenRap)
        {
            string sql = @"SELECT *  FROM [AstralisCinema].[dbo].[account]
                            where tenQuyen= 'banve' and noiLamViec=@tenrap;";

            SqlParameter pr1 = new SqlParameter("@tenrap", SqlDbType.NVarChar);
            pr1.Value = tenRap;
            return DAO.GetDataBySQLWithParameters(sql,pr1);
        }
    }
    public class DAOVe
    {
        public static DataTable GetAll(string donHangID,string rap)
        {
            string sql = @"SELECT *  FROM [ve] where donHangID=@donHangID and tenrap=@rap";
            SqlParameter pr1 = new SqlParameter("@donHangID", SqlDbType.Int);
            pr1.Value = donHangID;
            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql,pr1,pr2);
        }
        public static void Insert(GiaVeCuaGhe giaVeCuaGhe,string gheID,string giaVe)
        {
            string sql = @"declare @IDDonHang int 
                            select top (1) @IDDonHang = donHangVeID from donHangVe order by donHangVeID desc
                            print @IDDonHang
                            INSERT INTO [dbo].[ve]
                                       ([tenPhim]
                                       ,[tenRap]
                                       ,[khanDaiID]
                                       ,[ngayChieu]
                                       ,[suatChieu]
                                       ,[gheID]
                                       ,[giaVe]
                                       ,[donHangID])
                                 VALUES
                                       (@tenPhim
                                       ,@tenRap
                                       ,@khanDaiID
                                       ,getdate()
                                       ,@suatChieu
                                       ,@gheID
                                       ,@giaVe
                                       ,@IDDonHang)";
            SqlParameter pr1 = new SqlParameter("@tenPhim", SqlDbType.NVarChar);
            pr1.Value = giaVeCuaGhe.Phim;
            SqlParameter pr2 = new SqlParameter("@tenRap", SqlDbType.NVarChar);
            pr2.Value = giaVeCuaGhe.Rap;
            SqlParameter pr3 = new SqlParameter("@khanDaiID", SqlDbType.NVarChar);
            pr3.Value = giaVeCuaGhe.KhanDai;
            SqlParameter pr4 = new SqlParameter("@suatChieu", SqlDbType.NVarChar);
            pr4.Value = giaVeCuaGhe.Suat;
            SqlParameter pr5 = new SqlParameter("@gheID", SqlDbType.NVarChar);
            pr5.Value = gheID;
            SqlParameter pr6 = new SqlParameter("@giaVe", SqlDbType.Int);
            pr6.Value = giaVe;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4, pr5, pr6);
        }
    }
    public class DaoRap
    {
        public static DataTable GetAll()
        {
            string sql = @"SELECT *  FROM [rap]";
            return  DAO.GetDataBySQLWithParameters(sql);
        }
    }
    public class DAOGiaVeCuaGhe
    {
        public static DataTable GetTenPhim(string rap)
        {
            string sql = @"SELECT  DISTINCT  tenPhim
                          FROM giaVeCuaGhe
                          where ngayChieu = CONVERT(DATE, GETDATE())
                            and tenrap=@rap";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value = rap;

            return DAO.GetDataBySQLWithParameters(sql,pr1);
        }
        public static DataTable GetSuatChieu(string rap,string phim)
        {
            string sql = @"SELECT  DISTINCT  suatChieu
                              FROM giaVeCuaGhe
                              where ngayChieu = CONVERT(DATE, GETDATE())
                                and tenRap like @rap 
	                            and tenPhim like @phim";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value =rap;

            SqlParameter pr2 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr2.Value = phim;
            return DAO.GetDataBySQLWithParameters(sql, pr1,pr2);
        }
        public static DataTable GetKhanDai(string rap,string phim,string suatChieu)
        {
            string sql = @"SELECT  DISTINCT  khandaiid
                              FROM giaVeCuaGhe
                              where ngayChieu = CONVERT(DATE, GETDATE())
                                and tenRap like @rap 
	                            and tenPhim like @phim
                                and suatchieu like @suatchieu ";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value =rap;

            SqlParameter pr2 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr2.Value = phim;

            SqlParameter pr3 = new SqlParameter("@suatchieu", SqlDbType.NVarChar);
            pr3.Value = suatChieu;
            return DAO.GetDataBySQLWithParameters(sql, pr1, pr2,pr3);
        }
        public static DataTable GetGiaGhe(GiaVeCuaGhe giaVeCuaGhe)
        {
            string sql = @"SELECT gheid , giavecuaghe,trangthai
                          FROM giaVeCuaGhe
                          where ngayChieu = CONVERT(DATE, GETDATE())
                            and tenRap like @rap 
	                        and tenPhim like @phim
	                        and suatChieu like @suat
	                        and khanDaiID like @khandai";

            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value = giaVeCuaGhe.Rap;

            SqlParameter pr2 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr2.Value = giaVeCuaGhe.Phim;

            SqlParameter pr3 = new SqlParameter("@suat", SqlDbType.NVarChar);
            pr3.Value = giaVeCuaGhe.Suat;

            SqlParameter pr4 = new SqlParameter("@khandai", SqlDbType.NVarChar);
            pr4.Value = giaVeCuaGhe.KhanDai;
            return DAO.GetDataBySQLWithParameters(sql, pr1, pr2, pr3, pr4);
        }
        public static void ChuyenTrangThaiDa(string gheID,GiaVeCuaGhe giaVeCuaGhe)
        {
            string sql = @"UPDATE [dbo].[giaVeCuaGhe]
                           SET 
                              [trangThai] = 'da'
                         WHERE gheID=@gheID and
                                tenRap=@rap and
                                khanDaiID =@khandai and
                                ngayChieu=CONVERT(DATE, GETDATE()) and
                                suatChieu=@suat ";

            SqlParameter pr1 = new SqlParameter("@gheID", SqlDbType.NVarChar);
            pr1.Value = gheID;

            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = giaVeCuaGhe.Rap;

            SqlParameter pr3 = new SqlParameter("@khandai", SqlDbType.NVarChar);
            pr3.Value = giaVeCuaGhe.KhanDai;

            SqlParameter pr4 = new SqlParameter("@suat", SqlDbType.NVarChar);
            pr4.Value = giaVeCuaGhe.Suat;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4);

        }
    }
    class DAOdiscount
    {
        public static DataTable getAllDiscount()
        {
            string sql = @"SELECT * FROM [AstralisCinema].[dbo].[discount]";
            return DAO.GetDataBySQLWithParameters(sql);
        }
        public static DataTable getDiscountAvarible()
        {
            string sql = @"SELECT * FROM [AstralisCinema].[dbo].[discount]
                            where ngayHetHan>GETDATE()
								and star=0
								and loaiDiscount='F&T' or loaiDiscount='TICKET' ";
            return DAO.GetDataBySQLWithParameters(sql);
        }


    }
    class DAODonHangVe
    {
        public static void Insert(string tenKhach,string tamTinh,string maDiscount,string tongTienSauDiscount,string rap )
        {
            string sql = @"INSERT INTO [dbo].[donHangVe]
                       ([tenKhachHang]
                       ,[tongTien]
                       ,[maDiscount]
                       ,[nhanVeRoi]
                       ,[soTienSauDiscount]
                        ,rap)
		               VALUES
                       (@ten
                       ,@tamTinh
                       ,@DiscountCode
                       ,1
                       ,@tienSauDiscount
                        ,@rap)";
            SqlParameter pr1 = new SqlParameter("@ten", SqlDbType.NVarChar);
            pr1.Value = tenKhach;

            SqlParameter pr2 = new SqlParameter("@tamTinh", SqlDbType.Int);
            pr2.Value = tamTinh;

            SqlParameter pr3 = new SqlParameter("@DiscountCode", SqlDbType.NVarChar);
            pr3.Value = maDiscount;

            SqlParameter pr4= new SqlParameter("@tienSauDiscount", SqlDbType.Int);
            pr4.Value = tongTienSauDiscount;

            SqlParameter pr5 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr5.Value = rap;
            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4,pr5);
        }
        public static DataTable ThongTinDonHang(string series,string rap)
        {
            string sql = @"SELECT *  FROM [AstralisCinema].[dbo].[donHangVe]
                        where series=@series and nhanVeRoi=0 and rap=@rap";
            SqlParameter pr1 = new SqlParameter("@series", SqlDbType.NVarChar);
            pr1.Value = series;

            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql, pr1,pr2);

        } 
        public static void UpdateDaNhanVe(string series,string rap)
        {
            string sql = @"UPDATE [dbo].[donHangVe]
                           SET [nhanVeRoi] = 1
                           WHERE series=  @series and
                                rap=@rap";
            SqlParameter pr1 = new SqlParameter("@series", SqlDbType.NVarChar);
            pr1.Value = series;
            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = rap;
            DAO.ExecuteSQLWithParameters(sql, pr1,pr2);
        }
    }
    public class DAOthucPham
    {
       
        public static DataTable GetAll(string tenRap)
        {
            string sql = @"SELECT * FROM [AstralisCinema].[dbo].[thucPham] where tenrap=@rap";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value = tenRap;
            return DAO.GetDataBySQLWithParameters(sql,pr1);
        }
        public static void BanHang(string tenThucPham, int soLuong, string tenRap)
        {
            string sql = @" declare @nhapThem int
                            select @nhapThem = soLuong from thucPham where tenThucPham=@tenThucPham and tenrap=@rap
                            set @nhapThem = @nhapThem-@soluong;
                            UPDATE [dbo].[thucPham]
                            SET 
                            [soLuong] = @nhapThem
                            WHERE tenThucPham=@tenThucPham and tenrap=@rap
                             ";
            SqlParameter pr1 = new SqlParameter("@tenThucPham", SqlDbType.NVarChar);
            pr1.Value = tenThucPham;

            SqlParameter pr2 = new SqlParameter("@soluong", SqlDbType.Int);
            pr2.Value = soLuong;

            SqlParameter pr3 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr3.Value = tenRap;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3);
        }

    }

}
