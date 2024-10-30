using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        // Phương thức để hiển thị form trong panel và cập nhật trạng thái nút
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
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formToShow);
            formToShow.Show();

            // Bật lại tất cả các nút khi form đóng
            formToShow.FormClosed += (s, args) => SetButtonsEnabled(true);
        }

        // Phương thức để đặt Enabled cho các nút
        private void SetButtonsEnabled(bool enabled)
        {
            btnKhachHang.Enabled = enabled;
            btnGiaoDich.Enabled = enabled;
            btnTaiKhoan.Enabled = enabled;
            btnNhanVien.Enabled = enabled;
            btnThongTin.Enabled = enabled;
        }

        // Phương thức để tô màu đỏ nút đang được chọn
        private void HighlightButton(Button selectedButton)
        {
            // Đặt lại màu cho tất cả các nút về màu mặc định
            btnKhachHang.BackColor = SystemColors.Control;
            btnGiaoDich.BackColor = SystemColors.Control;
            btnTaiKhoan.BackColor = SystemColors.Control;
            btnNhanVien.BackColor = SystemColors.Control;
            btnThongTin.BackColor = SystemColors.Control;

            // Tô màu đỏ cho nút được chọn
            selectedButton.BackColor = Color.Red;
            
           
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KhachHang(), btnKhachHang);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new TaiKhoan(), btnTaiKhoan);
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new GiaoDich(), btnGiaoDich);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new NhanVien(), btnNhanVien);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ThongTin(), btnThongTin);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.H)
            {
                button1_Click(this, new LinkLabelLinkClickedEventArgs(null));
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
