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
        public string GetTenKhachHangByMa(string maKhachHang)
        {
            string tenKhachHang = string.Empty;
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TenKhachHang FROM KhachHang WHERE MaKhachHang = @maKhachHang", connection);
                command.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    tenKhachHang = result.ToString();
                }
            }
            return tenKhachHang;
        }
        public bool CheckNhanVienByTen(string tenNhanVien)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE TenNhanVien = @tenNhanVien AND ChucVu = 'Nhan Vien'";
            SqlParameter[] parameters = { new SqlParameter("@tenNhanVien", tenNhanVien) };

            KetNoiCSDL();
            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddRange(parameters);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
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
    }
}
