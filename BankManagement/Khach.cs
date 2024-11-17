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
        private void ShowFormInPanel(Form formToShow, Button activeButton)
        {
            // Đặt tất cả các nút thành Enabled
            SetButtonsEnabled(true);
            activeButton.Enabled = false;

            // Tô màu đỏ cho nút đã chọn
            HighlightButton(activeButton);

            // Cấu hình form và thêm vào panel
            formToShow.TopLevel = false;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Dock = DockStyle.Fill;
            panelKhach.Controls.Clear();
            panelKhach.Controls.Add(formToShow);
            formToShow.Show();

            // Bật lại tất cả các nút khi form đóng
            formToShow.FormClosed += (s, args) => SetButtonsEnabled(true);
        }
        private void SetButtonsEnabled(bool enabled)
        {
            btnGiaoDich.Enabled = enabled;
            btnTietKiem.Enabled = enabled;
            btnVayVon.Enabled = enabled;
            btnThongTin.Enabled = enabled;
        }

        // Phương thức để tô màu đỏ nút đang được chọn
        private void HighlightButton(Button selectedButton)
        {
            // Đặt lại màu cho tất cả các nút về màu mặc định
            btnGiaoDich.BackColor = SystemColors.Control;
            btnTietKiem.BackColor = SystemColors.Control;
            btnVayVon.BackColor = SystemColors.Control;
            btnThongTin.BackColor = SystemColors.Control;

            // Tô màu đỏ cho nút được chọn
            selectedButton.BackColor = System.Drawing.Color.Red;


        }
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ThongTinKhach(), btnThongTin);
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KhachGiaoDich(), btnGiaoDich);
        }

        private void btnTietKiem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KhachGuiTietKiem(TaiKhoan), btnTietKiem);
        }

        private void btnVayVon_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KhachVayVon(), btnVayVon);
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
