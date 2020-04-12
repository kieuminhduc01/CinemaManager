using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongVe.ValidateOfMe
{
    class ValidateOfMe
    {
        public static void inputOnlyNumber(ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
     
        public static bool isHaveEmptyTextBox(ref Panel panel)
        {
            bool isError = false;
            foreach (Control a in panel.Controls)
            {
                if (a is TextBox)
                {
                    if (a.Text == string.Empty || a.Text == "Nội dung trống !")
                    {
                        a.Text = "Nội dung trống !";
                        isError = true;
                    }
                }
            }
            return isError;
        }
        
        public static bool isPhoneNumber(ref TextBox tb)
        {
            if (!Regex.IsMatch(tb.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("sai");
                tb.Text = "sai định dạng số điện thoại";
                return false;
            }
           
            return true;
            
        }
    
    }
}
