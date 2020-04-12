using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QuanLyPhongVe.Model;

namespace QuanLyPhongVe.DataAccess
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
    public class DAOkeHoachVe
    {
        public static void InsertKeHoachVe(KeHoachVe keHoach)
        {
            string sql = @"INSERT INTO [dbo].[keHoachVe]
                               ([tenPhim]
                               ,[tenRap]
                               ,[khanDaiID]
                               ,[ngayChieu]
                               ,[suatChieu]
                               ,[loaiPhim]
                               ,[phuDe])
                         VALUES
                               (@tenPhim
                               ,@tenRap
                               ,@khanDaiID
                               ,@ngayChieu
                               ,@suatChieu
                               ,@loaiPhim
                               ,@phuDe)";
            SqlParameter pr1 = new SqlParameter("@tenPhim", SqlDbType.NVarChar);
            pr1.Value = keHoach.TenPhim;

            SqlParameter pr2 = new SqlParameter("@tenRap", SqlDbType.NVarChar);
            pr2.Value = keHoach.TenRap;

            SqlParameter pr3 = new SqlParameter("@khanDaiID", SqlDbType.NVarChar);
            pr3.Value = keHoach.KhanDai;

            SqlParameter pr4 = new SqlParameter("@ngayChieu", SqlDbType.DateTime);
            pr4.Value = keHoach.NgayChieu;

            SqlParameter pr5 = new SqlParameter("@suatChieu", SqlDbType.NVarChar);
            pr5.Value = keHoach.SuatChieu;

            SqlParameter pr6 = new SqlParameter("@loaiPhim", SqlDbType.NVarChar);
            pr6.Value = keHoach.LoaiPhim;

            SqlParameter pr7 = new SqlParameter("@phuDe", SqlDbType.Bit);
            pr7.Value = keHoach.PhuDe;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4, pr5, pr6, pr7);
        }
        public static DataTable GetAll(string tenRap, string khanDaiID, string suatChieu, string ngayChieu)
        {
            string sql = @"SELECT *  FROM [AstralisCinema].[dbo].[keHoachVe] where tenrap like @tenRap
                                            and khanDaiID like @khanDaiID 
                                            and suatchieu like @suatChieu 
                                             and CONVERT(VARCHAR(25), ngayChieu, 126) LIKE @ngayChieu";
            SqlParameter pr1 = new SqlParameter("@tenRap", SqlDbType.NVarChar);
            pr1.Value = tenRap;

            SqlParameter pr2 = new SqlParameter("@khanDaiID", SqlDbType.NVarChar);
            pr2.Value = khanDaiID;

            SqlParameter pr3 = new SqlParameter("@suatChieu", SqlDbType.NVarChar);
            pr3.Value = suatChieu;

            SqlParameter pr4 = new SqlParameter("@ngayChieu", SqlDbType.NVarChar);
            pr4.Value = ngayChieu;

            return DAO.GetDataBySQLWithParameters(sql, pr1, pr2, pr3, pr4);
        }
    }
    public class DAOGiaVeCuaGhe
    {
        public static void InsertGiaVeCuaGhe(KeHoachVe keHoach, Ghe ghe, int giaGhe)
        {
            string sql = @"INSERT INTO [dbo].[giaVeCuaGhe]
                               ([gheID]
                               ,[tenPhim]
                               ,[tenRap]
                               ,[khanDaiID]
                               ,[ngayChieu]
                               ,[suatChieu]
                               ,[giaVeCuaGhe]
                               ,[trangThai])
                         VALUES
                               (@gheID
                               ,@tenPhim
                               ,@tenRap
                               ,@khanDaiID
                               ,@ngayChieu
                               ,@suatChieu
                               ,@giaVeCuaGhe
                               ,'chua')";

            SqlParameter pr1 = new SqlParameter("@tenPhim", SqlDbType.NVarChar);
            pr1.Value = keHoach.TenPhim;

            SqlParameter pr2 = new SqlParameter("@tenRap", SqlDbType.NVarChar);
            pr2.Value = keHoach.TenRap;

            SqlParameter pr3 = new SqlParameter("@khanDaiID", SqlDbType.NVarChar);
            pr3.Value = keHoach.KhanDai;

            SqlParameter pr4 = new SqlParameter("@ngayChieu", SqlDbType.DateTime);
            pr4.Value = keHoach.NgayChieu;

            SqlParameter pr5 = new SqlParameter("@suatChieu", SqlDbType.NVarChar);
            pr5.Value = keHoach.SuatChieu;

            SqlParameter pr6 = new SqlParameter("@giaVeCuaGhe", SqlDbType.Int);
            pr6.Value = giaGhe;

            SqlParameter pr7 = new SqlParameter("@gheID", SqlDbType.NVarChar);
            pr7.Value = ghe.GheID;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4, pr5, pr6, pr7);
        }
    }
    public class DAOghe
    {
        public static DataTable GetAll()
        {
            string sql = @"SELECT * FROM ghe";
            return DAO.GetDataBySQLWithParameters(sql);
        }
    }
    public class DAOphim
    {
        public static DataTable LoadAllFilm()
        {
            string sql = @"SELECT  * FROM [phim] where  trangthai='chua' or trangthai='dang'";
            return DAO.GetDataBySQLWithParameters(sql);
        }
        public static void UpdateDa(string phim)
        {
            string sql = @"UPDATE [dbo].[phim]
                               SET 
                                  [trangThai] = 'dang'
                             WHERE tenPhim=@phim";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;
             DAO.ExecuteSQLWithParameters(sql, pr1);
        }
    }
    public class DAOthucPham
    {
        public static void Insert(ThucPham tp)
        {
            string sql = @"INSERT INTO [dbo].[thucPham]
                           ([tenThucPham]
                           ,[donVi]
                           ,[soLuong]
                           
                           ,[tenRap]
                           ,[giaNhap]
                           ,[giaBan])
                     VALUES
                           (@tenThucPham
                           ,@donVi
                           ,@soLuong
                           ,@tenRap
                           ,@giaNhap
                           ,@giaBan)";
            SqlParameter pr1 = new SqlParameter("@tenThucPham", SqlDbType.NVarChar);
            pr1.Value = tp.Ten;

            SqlParameter pr2 = new SqlParameter("@donVi", SqlDbType.NVarChar);
            pr2.Value = tp.donVi;

            SqlParameter pr3 = new SqlParameter("@soLuong", SqlDbType.Int);
            pr3.Value = tp.soLuong;



            SqlParameter pr5 = new SqlParameter("@tenRap", SqlDbType.NVarChar);
            pr5.Value = tp.Rap;

            SqlParameter pr6 = new SqlParameter("@giaNhap", SqlDbType.Int);
            pr6.Value = tp.GiaNhap;

            SqlParameter pr7 = new SqlParameter("@giaBan", SqlDbType.Int);
            pr7.Value = tp.GiaBan;


            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr5, pr6, pr7);
        }
        public static DataTable GetAll(string tenRap)
        {
            string sql = @"SELECT * FROM [AstralisCinema].[dbo].[thucPham] where [tenRap] = @rap";
            SqlParameter pr7 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr7.Value = tenRap;
            return DAO.GetDataBySQLWithParameters(sql,pr7);
        }
        public static void NhapHang(string tenThucPham, int soLuong, string tenRap)
        {
            string sql = @" declare @nhapThem int
                            select @nhapThem = soLuong from thucPham where tenThucPham=@tenThucPham and tenrap=@rap
                            set @nhapThem = @nhapThem+@soluong;
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
    public class DAOAccount
    {
        public static void InsertNhanVienBanVe(Account acc)
        {
            string sql = @"INSERT INTO [dbo].[account]
                                   ([email]
                                   ,[password]
                                   ,[ten]
                                   ,[sdt]
                                   ,[diaChi]
                                   ,[sinhNhat]
                                   ,[tenQuyen]
                                   ,[noiLamViec])
                             VALUES
                                   (@email
                                   ,@password
                                   ,@ten
                                   ,@sdt
                                   ,@diaChi
                                   ,@sinhNhat
                                   ,@tenQuyen
                                   ,@noiLamViec)";
            SqlParameter pr1 = new SqlParameter("@email", SqlDbType.NVarChar);
            pr1.Value = acc.Email;

            SqlParameter pr2 = new SqlParameter("@password", SqlDbType.NVarChar);
            pr2.Value = acc.Password;

            SqlParameter pr3 = new SqlParameter("@ten", SqlDbType.NVarChar);
            pr3.Value = acc.Ten;



            SqlParameter pr4 = new SqlParameter("@sdt", SqlDbType.NVarChar);
            pr4.Value = acc.SDT;

            SqlParameter pr5 = new SqlParameter("@diaChi", SqlDbType.NVarChar);
            pr5.Value = acc.DiaChi;

            SqlParameter pr6 = new SqlParameter("@sinhNhat", SqlDbType.DateTime);
            pr6.Value = acc.SinhNhat;

            SqlParameter pr7 = new SqlParameter("@tenQuyen", SqlDbType.NVarChar);
            pr7.Value = acc.TenQuyen;

            SqlParameter pr8 = new SqlParameter("@noiLamViec", SqlDbType.NVarChar);
            pr8.Value = acc.NoiLamViec;
            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4, pr5, pr6, pr7, pr8);
        }
        public static DataTable GetAll(string tenRap)
        {
            string sql = @"SELECT *  FROM [AstralisCinema].[dbo].[account]
                            where tenQuyen= 'quanlyrap' and noiLamViec=@tenrap;";

            SqlParameter pr1 = new SqlParameter("@tenrap", SqlDbType.NVarChar);
            pr1.Value = tenRap;
            return DAO.GetDataBySQLWithParameters(sql, pr1);
        }
        public static DataTable GetAllBanVe(string tenRap)
        {
            string sql = @"SELECT *  FROM [AstralisCinema].[dbo].[account]
                            where tenQuyen= 'banve' and noiLamViec=@tenrap;";

            SqlParameter pr1 = new SqlParameter("@tenrap", SqlDbType.NVarChar);
            pr1.Value = tenRap;
            return DAO.GetDataBySQLWithParameters(sql, pr1);
        }
    }
    public class DAOVe
    {
        public static DataTable GetAll(string rap)
        {
            string sql = @"SELECT * FROM ve where tenrap=@rap";
            SqlParameter pr1 = new SqlParameter("@tenrap", SqlDbType.NVarChar);
            pr1.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql, pr1);
        }
    }
    public class DaoRap
    {
        public static DataTable GetAll()
        {
            string sql = @"SELECT *  FROM [rap]";
            return DAO.GetDataBySQLWithParameters(sql);
        }
    }
    public class DAODoanhThu
    {
        public static DataTable GetDoanhThu(string rap, DateTime tu, DateTime den)
        {
            string sql = @"SELECT  [tenPhim]
                                  ,SUM([giaVe] ) as doanhThu
                                  ,COUNT(gheID) as sove
                              FROM [AstralisCinema].[dbo].[ve]
                              where tenrap=@rap
		                            and ngayChieu between @tu and @den
                              group by tenPhim";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value = rap;
            SqlParameter pr2 = new SqlParameter("@tu", SqlDbType.Date);
            pr2.Value = tu;
            SqlParameter pr3 = new SqlParameter("@den", SqlDbType.Date);
            pr3.Value = den;
            return DAO.GetDataBySQLWithParameters(sql, pr1, pr2, pr3);
        }
    }


}
