using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BankManagement
{
    internal class ProcessDatabase
    {
        string strConnect = "Data Source=NMC\\SQLEXPRESS;Initial Catalog=QLBanknew;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnect = null;

        private void KetNoiCSDL()
        {
            if (sqlConnect == null)
            {
                sqlConnect = new SqlConnection(strConnect);

           
            }
            if (sqlConnect.State != ConnectionState.Open)
            {

                sqlConnect = new SqlConnection(strConnect);

                sqlConnect.Open();
            }
        }
        private void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
            sqlConnect.Dispose();
        }

        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect);
            sqldataAdapte.Fill(dtBang);
            DongKetNoiCSDL();
            return dtBang;
        }

        public void CapNhatDuLieu(string sql, SqlParameter[] parameters=null)
        {
            try
            {
                KetNoiCSDL();
                using (SqlCommand sqlcommand = new SqlCommand(sql, sqlConnect))
                {
                    if (parameters != null)
                    {
                        sqlcommand.Parameters.AddRange(parameters);
                    }
                    sqlcommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                DongKetNoiCSDL();
            }
        }
        public List<string> GetMaKhachHangList()
        {
            List<string> maKhachHangList = new List<string>();

            // Giả sử bạn đã thiết lập kết nối với cơ sở dữ liệu
            string query = "SELECT MaKhachHang FROM KhachHang"; // Điều chỉnh tên bảng nếu cần
            using (SqlConnection conn = new SqlConnection(strConnect))
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
        // Kiểm tra tên nhân viên có tồn tại không
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
        // lấy mã nhân viên từ tên nhân viên
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
        public object ThucThiGiaTriDon(string query, SqlParameter[] parameters = null)
        {
            object ketQua = null;
            KetNoiCSDL();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    // Thực thi câu truy vấn và trả về giá trị đơn
                    ketQua = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                DongKetNoiCSDL();
            }

            return ketQua;
        }

    }
}
