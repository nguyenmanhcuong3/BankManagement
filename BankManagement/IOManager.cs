
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BankManagement
{
    internal class IOManager : ProcessDatabase
    {
        public  bool AuthenticateUser(string username, string password)
        {

            DataTable dbKhachHang = DocBang("SELECT * FROM Login WHERE username='" + username + "' AND password='" + password + "'");
            return dbKhachHang.Rows.Count > 0;
        }



        public  bool RegisterUser(string maNhanVien, string username, string password, string confirmPassword, out string message)
        {


            if (!CheckMnv(maNhanVien))
            {
                message = "Mã nhân viên không tồn tại.";
                return false;
            }


            if (string.IsNullOrWhiteSpace(maNhanVien) || maNhanVien.Equals("Nhập mã nhân viên bạn muốn đăng kí"))
            {
                message = "Vui lòng nhập mã nhân viên.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(username) || username.Equals("Nhập tài khoản bạn muốn đăng kí"))
            {
                message = "Vui lòng nhập tài khoản.";
                return false;
            }


            if (password.Length < 6)
            {
                message = "Mật khẩu phải có ít nhất 6 ký tự.";
                return false;
            }

            if (password != confirmPassword)
            {
                message = "Mật khẩu và mật khẩu nhập lại không khớp. Vui lòng kiểm tra lại.";
                return false;
            }


            if (CheckAccountExists(username))
            {
                message = "Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.";
                return false;
            }

            string insertQuery = "INSERT INTO Login (MaNhanVien, username, password) VALUES (@maNhanVien, @username, @password)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@maNhanVien", maNhanVien),
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

            CapNhatDuLieu(insertQuery, parameters);
            message = "Đăng ký thành công!";
            return true;
        }
        public void ExportDataToExcel(string sql)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"; 
                saveFileDialog.DefaultExt = "xlsx"; 
                saveFileDialog.Title = "Lưu file Excel"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    ExportToExcel(sql, filePath);
                    MessageBox.Show("Xuất dữ liệu ra file Excel thành công!");
                }
            }
        }
        public static  bool IsValidCCCD(string soCCCD)
        {
            return Regex.IsMatch(soCCCD, @"^\d{12}$");
        }

        public static int TinhSoTienSauLai(decimal sotien, decimal laisuat, int kyhan)
        {
            if (sotien > 0 && laisuat > 0 && kyhan > 0)
            {

                laisuat /= 100;


                decimal sotiensenhan = sotien * (1 + laisuat * kyhan / 12);


                return (int)Math.Round(sotiensenhan, MidpointRounding.AwayFromZero);
            }


            return 0;
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^0\d{9}$");
        }
        public static string GetMaGiaoDich(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder transactionCode = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                transactionCode.Append(chars[random.Next(chars.Length)]);
            }

            return transactionCode.ToString();
        }
    }
}
