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
        string strConnect = "Data Source=NMC\\SQLEXPRESS;Initial Catalog=BankManagement;Integrated Security=True";
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

        public void CapNhatDuLieu(string sql, SqlParameter[] parameters)
        {
            try
            {
                // Mở kết nối CSDL
                KetNoiCSDL();

                // Tạo đối tượng SqlCommand
                using (SqlCommand sqlcommand = new SqlCommand(sql, sqlConnect))
                {
                    // Thêm các tham số vào câu lệnh nếu có
                    if (parameters != null)
                    {
                        sqlcommand.Parameters.AddRange(parameters);
                    }

                    // Thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
                    sqlcommand.ExecuteNonQuery();
                }
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
    }
}
