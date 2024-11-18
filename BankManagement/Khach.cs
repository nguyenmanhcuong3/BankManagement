using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace BankManagement
{
    public partial class Khach : Form
    {
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        string TaiKhoan;
        public Khach(string username)
        {
            InitializeComponent();
            TaiKhoan = username;
        }

        private void Khach_Load(object sender, EventArgs e)
        {
            plDiChuyen.SendToBack();
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
            KhachGuiTietKiem formTietKiem = new KhachGuiTietKiem(TaiKhoan);
            formTietKiem.TopLevel = false;
            formTietKiem.FormBorderStyle = FormBorderStyle.None;
            formTietKiem.Dock = DockStyle.Fill;


            pictureBoxKhach.Controls.Clear();


            pictureBoxKhach.Controls.Add(formTietKiem);

            formTietKiem.Show();
        }

        private void btnVayVon_Click(object sender, EventArgs e)
        {
            KhachVayVon formKhachHang = new KhachVayVon(TaiKhoan);

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBoxKhach.Controls.Clear();


            pictureBoxKhach.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất ?", "Xác nhận đăng nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                DangNhap_DangKi Login = new DangNhap_DangKi();
                Login.Show();
                this.Close();
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

        private void pcExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcExit_MouseEnter(object sender, EventArgs e)
        {
            pcExit.BackColor = System.Drawing.Color.LightGray;
            pcExit.Cursor = Cursors.Hand;
        }

        private void pcExit_MouseLeave(object sender, EventArgs e)
        {
            pcExit.BackColor = System.Drawing.Color.Transparent;
            pcExit.Cursor = Cursors.Default;
        }

        // Dung panel de thay cho thanh tieu de
        private void plDiChuyen_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void plDiChuyen_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void plDiChuyen_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
