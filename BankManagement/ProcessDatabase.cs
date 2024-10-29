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
        public string strConnect = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QLBank;Integrated Security=True";
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

        public DataTable DocBang(string sql, SqlParameter[] parameters = null)
        {
            DataTable dtBang = new DataTable();
            KetNoiCSDL();
            //SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect);
            // sqldataAdapte.Fill(dtBang);
            SqlCommand cmd = new SqlCommand(sql, sqlConnect);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtBang);
            DongKetNoiCSDL();
            return dtBang;
        }

        public void CapNhatDuLieu(string sql, SqlParameter[] parameters=null)
        {
            try
            {
                // Mở kết nối CSDL
                KetNoiCSDL();

                // Tạo đối tượng SqlCommand
                SqlCommand sqlcommand = new SqlCommand(sql, sqlConnect);

                    // Thêm các tham số vào câu lệnh nếu có
                    if (parameters != null)
                    {
                        sqlcommand.Parameters.AddRange(parameters);
                    }

                    // Thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
                    sqlcommand.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi thực thi xong
                DongKetNoiCSDL();
            }
        }
        public List<string> GetMaKhachHangList()
        {
            List<string> maKhachHangList = new List<string>();

            // Giả sử bạn đã thiết lập kết nối với cơ sở dữ liệu
            string query = "SELECT MaKhachHang FROM KhachHang"; // Điều chỉnh tên bảng nếu cần
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
                        ten  = result.ToString();
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
        public bool CheckAccountExists(string username)
        { 
            string query = "SELECT COUNT(*) FROM Login WHERE username = @username";
            SqlParameter[] parameters = { new SqlParameter("@username", username) };
            KetNoiCSDL();
            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddRange(parameters);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

    }
}
