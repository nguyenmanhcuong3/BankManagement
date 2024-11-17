using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace BankManagement
{
    internal class ProcessDatabase
    {

        public string strConnect = "Data Source=LAPTOP-HUNGVIET\\SQLEXPRESS;Initial Catalog=QlBank;Integrated Security=True;Encrypt=False";
        protected SqlConnection sqlConnect = null;

       

        protected void KetNoiCSDL()
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
        protected void DongKetNoiCSDL()
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
                KetNoiCSDL();

                SqlCommand sqlcommand = new SqlCommand(sql, sqlConnect);

                    if (parameters != null)
                    {
                        sqlcommand.Parameters.AddRange(parameters);
                    }

                    sqlcommand.ExecuteNonQuery();
                
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
        public bool CheckMnv(string MaNhanVien)
        {
            string strCon = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            SqlParameter[] parameters = { new SqlParameter("@MaNhanVien", MaNhanVien) };
            KetNoiCSDL();
            using (SqlCommand cmd = new SqlCommand(strCon, sqlConnect))
            {
                cmd.Parameters.AddRange(parameters);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
        public void ExportToExcel(string sql, string filePath)
        {
            DataTable dataTable = DocBang(sql); // Lấy dữ liệu từ database

            // Thiết lập EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                // Tạo một worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Tải dữ liệu từ DataTable vào worksheet
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                for (int col = 1; col <= dataTable.Columns.Count; col++)
                {
                    if (dataTable.Columns[col - 1].DataType == typeof(DateTime))
                    {
                        worksheet.Column(col).Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    }
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                // Lưu file Excel vào đường dẫn chỉ định
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }
        }
        public List<string> GetTenNhanVienList()
        {
            List<string> TenNhanVienList = new List<string>();

            // Giả sử bạn đã thiết lập kết nối với cơ sở dữ liệu
            string query = "SELECT TenNhanVien FROM NhanVien"; // Điều chỉnh tên bảng nếu cần
            SqlConnection conn = new SqlConnection(strConnect);
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TenNhanVienList.Add(reader["TenNhanVien"].ToString());
                }
            }

            return TenNhanVienList;
        }
    }
}
