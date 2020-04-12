using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanVe.App_Code.Model;

namespace WebBanVe.App_Code.DataAccess
{
    public class DAO
    {
            public static SqlConnection GetConnection()
            {
            string ConnectString = ConfigurationManager.ConnectionStrings["AstralisCinema"].ToString();
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
    public class DAOphim
    {
        public static DataTable LoadAllFilm()
        {
            string sql = @"SELECT  * FROM [phim] where  trangthai like 'chua' or trangthai like 'dang'";
            return DAO.GetDataBySQLWithParameters(sql);
        }
        public static DataTable GetInfoByTitle(string phim)
        {
            string sql = @"SELECT  * FROM [phim] 
                            where  
                                    (trangthai like 'chua'
		                             or trangthai  like'dang' )
		                             and tenPhim like @phim";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;
            return DAO.GetDataBySQLWithParameters(sql,pr1);
        }
    }
    public class DAOKeHoachVe
    {
        public static DataTable LoadRapByPhim(string phim)
        {
            string sql = @"SELECT distinct [tenRap]
                          FROM [AstralisCinema].[dbo].[keHoachVe]
                          where tenPhim like @phim";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;
            return DAO.GetDataBySQLWithParameters(sql,pr1);
        }
        public static DataTable LoadAllFilmPlaying()
        {
            string sql = @"SELECT distinct dbo.phim.*
                            FROM dbo.keHoachVe INNER JOIN
                             dbo.phim ON dbo.keHoachVe.tenPhim like dbo.phim.tenPhim
				             where ngayChieu > CONVERT(DATE, GETDATE()) or ngayChieu=CONVERT(DATE, GETDATE())";
            return DAO.GetDataBySQLWithParameters(sql);
        }
        public static DataTable LoadFilmPlayingInFuture()
        {
            string sql = @"SELECT *
                          FROM [AstralisCinema].[dbo].[phim]
                          where trangThai='chua'";
            return DAO.GetDataBySQLWithParameters(sql);
        }
        public static DataTable LoadDayPlayFilm(string phim,string rap)
        {
            string sql = @"     SELECT *
                              FROM [AstralisCinema].[dbo].[keHoachVe]
                              where tenPhim like @phim and
                              (
                              ngayChieu > CONVERT(DATE, GETDATE())
                              or ngayChieu=CONVERT(DATE, GETDATE())
                              ) and
                               tenrap like @rap
                               
                         ";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;

            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql, pr1,pr2);
        }
        public static DataTable LoadSuatChieu(string phim,DateTime ngay,string rap)
        {
            string sql = @" SELECT distinct suatChieu
                        FROM [AstralisCinema].[dbo].[keHoachVe]
                        where tenPhim like @phim and 
                        ngayChieu = Convert(DATE,@ngay)
                        and tenrap like @rap
                         ";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;
            SqlParameter pr2 = new SqlParameter("@ngay", SqlDbType.NVarChar);
            pr2.Value = ngay;
            SqlParameter pr3 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr3.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql, pr1,pr2,pr3);
        }
        public static DataTable LoadKhanDai(string phim, DateTime ngay,string suatChieu,string rap)
        {
            string sql = @"	SELECT distinct khanDaiID
                        FROM [AstralisCinema].[dbo].[keHoachVe]
                        where tenPhim like @phim and 
                        ngayChieu=Convert(DATE,@ngay) and
                        suatChieu like @suatchieu and
                        tenrap like @rap    ";
            SqlParameter pr1 = new SqlParameter("@phim", SqlDbType.NVarChar);
            pr1.Value = phim;
            SqlParameter pr2 = new SqlParameter("@ngay", SqlDbType.DateTime);
            pr2.Value = ngay;
            SqlParameter pr3 = new SqlParameter("@suatchieu", SqlDbType.NVarChar);
            pr3.Value = suatChieu;

            SqlParameter pr4 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr4.Value = rap;
            return DAO.GetDataBySQLWithParameters(sql, pr1, pr2,pr3,pr4);
        }
        
    }
    public class DAOGiaVeCuaGhe
    {
        public static DataTable LoadGiaVe(string rap,string khandai,DateTime ngay,string suatchieu)
        {
            string sql = @"SELECT *
                          FROM [AstralisCinema].[dbo].[giaVeCuaGhe]
                          where tenRap like @rap and
		                        khanDaiID like @khandai and
		                        ngayChieu=CONVERT(date,@ngay) and
		                        suatchieu like @suatchieu
                        ";
            SqlParameter pr1 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr1.Value = rap;
            SqlParameter pr2 = new SqlParameter("@khandai", SqlDbType.NVarChar);
            pr2.Value = khandai;
            SqlParameter pr3 = new SqlParameter("@ngay", SqlDbType.DateTime);
            pr3.Value = ngay;
            SqlParameter pr4 = new SqlParameter("@suatchieu", SqlDbType.NVarChar);
            pr4.Value = suatchieu;
            return DAO.GetDataBySQLWithParameters(sql,pr1,pr2,pr3,pr4);
        }
        public static void ChuyenTrangThaiDa(string gheID, string rap,string khandai,string suat,DateTime ngay)
        {
            string sql = @"UPDATE [dbo].[giaVeCuaGhe]
                           SET 
                              [trangThai] = 'da'
                         WHERE gheID=@gheID and
                                tenRap=@rap and
                                khanDaiID =@khandai and
                                ngayChieu=CONVERT(DATE, @ngay) and
                                suatChieu=@suat ";

            SqlParameter pr1 = new SqlParameter("@gheID", SqlDbType.NVarChar);
            pr1.Value = gheID;

            SqlParameter pr2 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr2.Value = rap;

            SqlParameter pr3 = new SqlParameter("@khandai", SqlDbType.NVarChar);
            pr3.Value = khandai;

            SqlParameter pr4 = new SqlParameter("@suat", SqlDbType.NVarChar);
            pr4.Value = suat;
            SqlParameter pr5 = new SqlParameter("@ngay", SqlDbType.DateTime);
            pr5.Value = ngay;
            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4,pr5);

        }
    }
    public class DAOAccount
    {
        public static DataTable CheckAccount(string email,string password)
        {
            string sql = @"SELECT * 
                                FROM [AstralisCinema].[dbo].[account]
                                where   tenQuyen='nguoidung' and
		                                email = @email and
		                                account.password=@password ";
            SqlParameter pr1 = new SqlParameter("@email", SqlDbType.NVarChar);
            pr1.Value = email;

            SqlParameter pr2 = new SqlParameter("@password", SqlDbType.NVarChar);
            pr2.Value = password;

            return DAO.GetDataBySQLWithParameters(sql, pr1,pr2);
        }
       
        public static void Register(string email, string password,string name,string SDT,string diaChi,DateTime DOB)
        {
            string sql = @"INSERT INTO [dbo].[account]
                                       ([email]
                                       ,[password]
                                       ,[ten]
                                       ,[sdt]
                                       ,[diaChi]
                                       ,[sinhNhat]
                                       ,[star]
                                       ,[tenQuyen]
                                       )
                                 VALUES
                                       (@email
                                       ,@password
                                       ,@name
                                       ,@SDT
                                       ,@diaChi
                                       ,@DOB
                                       ,0
                                       ,'nguoidung'
                                       )";
            SqlParameter pr1 = new SqlParameter("@email", SqlDbType.NVarChar);
            pr1.Value = email;

            SqlParameter pr2 = new SqlParameter("@password", SqlDbType.NVarChar);
            pr2.Value = password;

            SqlParameter pr3 = new SqlParameter("@name", SqlDbType.NVarChar);
            pr3.Value = name;

            SqlParameter pr4 = new SqlParameter("@SDT", SqlDbType.NVarChar);
            pr4.Value = SDT;

            SqlParameter pr5 = new SqlParameter("@diaChi", SqlDbType.NVarChar);
            pr5.Value = diaChi;

            SqlParameter pr6 = new SqlParameter("@DOB", SqlDbType.DateTime);
            pr6.Value = DOB;

            DAO.ExecuteSQLWithParameters(sql, pr1, pr2, pr3, pr4, pr5, pr6); 
        }
    }
    public class DAOdonHangVe
    {
        public static void Insert(string tenKhach,string email, string tongTienSauDiscount, string rap)
        {
            string sql = @"INSERT INTO [dbo].[donHangVe]
                       (
                        email
                       ,[tenKhachHang]

                       ,[nhanVeRoi]
                       ,[soTienSauDiscount]
                       ,rap)
		               VALUES
                       (
                        @email
                       ,@ten
                       
                       ,0
                       ,@tienSauDiscount
                        ,@rap)";
            SqlParameter pr1 = new SqlParameter("@ten", SqlDbType.NVarChar);
            pr1.Value = tenKhach;

          
            SqlParameter pr4 = new SqlParameter("@tienSauDiscount", SqlDbType.Int);
            pr4.Value = tongTienSauDiscount;

            SqlParameter pr5 = new SqlParameter("@rap", SqlDbType.NVarChar);
            pr5.Value = rap;

            SqlParameter pr6 = new SqlParameter("@email", SqlDbType.NVarChar);
            pr6.Value = email;
            DAO.ExecuteSQLWithParameters(sql, pr1,  pr4, pr5,pr6);
        }
        public static DataTable GetSeries()
        {
            string sql = @"SELECT TOP (1) 
                              [series]
                          FROM [AstralisCinema].[dbo].[donHangVe]
                          order by donHangVeID desc";
            return DAO.GetDataBySQLWithParameters(sql);
        }
    }
    public class DAOVe
    {
        public static void Insert(GiaVeCuaGhe giaVeCuaGhe, string gheID, string giaVe)
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

}