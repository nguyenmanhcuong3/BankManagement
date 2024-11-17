using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class Khach : Form
    {
        string TaiKhoan;
        public Khach(string username)
        {
            InitializeComponent();
            TaiKhoan = username;
        }

        private void Khach_Load(object sender, EventArgs e)
        {

        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnGiaoDich.Enabled = enabled;
            btnTietKiem.Enabled = enabled;
            btnVayVon.Enabled = enabled;
            btnThongTin.Enabled = enabled;
        }

        // Phương thức để tô màu đỏ nút đang được chọn

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ThongTinKhach formKhachHang = new ThongTinKhach(TaiKhoan);

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBoxKhach.Controls.Clear();


            pictureBoxKhach.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            KhachGiaoDich formKhachHang = new KhachGiaoDich(TaiKhoan);

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBoxKhach.Controls.Clear();


            pictureBoxKhach.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnTietKiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVayVon_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất ?", "Xác nhận đăng nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                DangNhap_DangKi Login = new DangNhap_DangKi();
                Login.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
