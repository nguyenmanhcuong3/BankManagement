using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    internal class DataTransaction : IOManager
    {
        public List<string> GetSoTaiKhoanList(int sotaikhoan)
        {
            List<string> soTaiKhoanList = new List<string>();

            string query = "SELECT SoTaiKhoan FROM KhachHang WHERE SoTaiKhoan != @SoTaiKhoan";

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", sotaikhoan); // Thêm tham số vào câu truy vấn

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soTaiKhoanList.Add(reader["SoTaiKhoan"].ToString());
                    }
                }
            }

            return soTaiKhoanList;
        }

        public string GetTenKhachHangByTSoTaiKhoan(string soTaiKhoan)
        {
            string tenKhachHang = string.Empty;
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TenKhachHang FROM KhachHang WHERE SoTaiKhoan = @SoTaiKhoan", connection);
                command.Parameters.AddWithValue("@SoTaiKhoan", soTaiKhoan);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    tenKhachHang = result.ToString();
                }
            }
            return tenKhachHang;
        }
        


        public  int GetSoTaiKhoanByTaiKhoan(string taikhoan)
        {
            int sotaikhoan = 0; 
            string query = "select SoTaiKhoan from KhachHang where TaiKhoan = @taikhoan";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", taikhoan);

                    object result = cmd.ExecuteScalar(); 
                    if (result != null && int.TryParse(result.ToString(), out int parsedValue))
                    {
                        sotaikhoan = parsedValue; 
                    }
                }
            }

            return sotaikhoan;
        }

        public string GetTenNhanVienByMa(string maNhanVien)
        {
            string ten = string.Empty;
            string query = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        ten = result.ToString();
                    }
                }
            }
            return ten;
        }
        public int GetSoDuByTSoTaiKhoan(int soTaiKhoan)
        {
            int soDu = 0;

            using (SqlConnection connection = new SqlConnection(strConnect))
            {

                connection.Open();


                string query = "SELECT SoDu FROM KhachHang WHERE SoTaiKhoan = @SoTaiKhoan";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@SoTaiKhoan", soTaiKhoan);


                    object result = command.ExecuteScalar();


                    if (result != null && int.TryParse(result.ToString(), out soDu))
                    {
                        return soDu;
                    }
                }

            }

            return soDu;
        }
    }
}
