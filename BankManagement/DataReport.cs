using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    internal class DataReport : ProcessDatabase
    {
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
    }
}
