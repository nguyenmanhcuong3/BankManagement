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
        public List<string> GetMaKhachHangList()
        {
            List<string> maKhachHangList = new List<string>();

            string query = "SELECT MaKhachHang FROM KhachHang";
            SqlConnection conn = new SqlConnection(strConnect);
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    maKhachHangList.Add(reader["MaKhachHang"].ToString());
                }
            }

            return maKhachHangList;
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
        
        public string GetMaNhanVienByTen(string tenNhanVien)
        {
            string maNhanVien = string.Empty;
            string query = "SELECT MaNhanVien FROM NhanVien WHERE TenNhanVien = @TenNhanVien";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenNhanVien", tenNhanVien);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        maNhanVien = result.ToString();
                    }
                }
            }
            return maNhanVien;
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
        public string LaySoTaiKhoan(string username)
        {
            string query = "SELECT SoTaiKhoan FROM KhachHang WHERE TaiKhoan = @username";
            SqlParameter[] parameters = {
        new SqlParameter("@username", username)
    };

            System.Data.DataTable result = DocBang(query, parameters); // DocBang là phương thức để đọc dữ liệu từ CSDL
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["SoTaiKhoan"].ToString();
            }
            return string.Empty;
        }

    }
}
