using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class ThongTinKhach : Form
    {
        string taiKhoan;
        ProcessDatabase db= new ProcessDatabase();
        public ThongTinKhach(string taikhoan)
        {
            InitializeComponent();
            taiKhoan= taikhoan;
        }

        private void ThongTinKhach_Load(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtSoTaiKhoan.Enabled = false;
            txtSoDu.Enabled = false;
            txtSoCCCD.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            DataTable dbKhachHang = db.DocBang($"select * from KhachHang where TaiKhoan like '%{taiKhoan}%'");
            if(dbKhachHang.Rows.Count > 0)
            {
                DataRow row = dbKhachHang.Rows[0];

                // Gán dữ liệu từ DataTable vào các ô nhập liệu
                txtHoTen.Text = row["TenKhachHang"].ToString();
                txtSoTaiKhoan.Text = row["SoTaiKhoan"].ToString();
                txtSoDu.Text = row["SoDu"].ToString();
                txtSoCCCD.Text = row["SoCCCD"].ToString();
                txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                txtEmail.Text = row["Email"].ToString();
                string anhDaiDien = row["Anh"].ToString();
                if (!string.IsNullOrEmpty(anhDaiDien))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang", anhDaiDien);

                    try
                    {
                        if (pictureKhachHang.Image != null)
                        {
                            pictureKhachHang.Image.Dispose();
                            pictureKhachHang.Image = null;
                        }

                        using (var stream = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            pictureKhachHang.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                        pictureKhachHang.Image = null;
                    }
                }
                else
                {
                    pictureKhachHang.Image = null;
                }
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtSoDienThoai.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
        }  
    }
}
