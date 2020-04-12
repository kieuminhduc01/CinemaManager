using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BanVe.Model
{
    public class Account
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime SinhNhat { get; set; }
        public string TenQuyen { get; set; }
        public string NoiLamViec { get; set; }
    }
    class AccountList
    {
        public static List<Account> GetListAccount(string tenRap)
        {
            List<Account> lstAcc = new List<Account>();
            DataTable dt = DataAccess.DAOAccount.GetAll(tenRap);
            foreach (DataRow dr in dt.Rows)
            {
                Account acc = new Account();
                acc.Email = dr["email"].ToString();
                acc.Password = dr["password"].ToString();
                acc.Ten = dr["ten"].ToString();
                acc.SDT = dr["sdt"].ToString();
                acc.DiaChi = dr["diachi"].ToString();
                acc.SinhNhat = Convert.ToDateTime(dr["sinhnhat"]).Date;
                acc.TenQuyen = dr["tenQuyen"].ToString();

                lstAcc.Add(acc);

            }
            return lstAcc;
        }
    }
}
