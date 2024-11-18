using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace BankManagement
{
    public partial class frmMain : Form
    {
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public frmMain()
        {
            InitializeComponent();
            plDiChuyen.SendToBack();
        }

        private void plDiChuyen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
             QLKhachHang formKhachHang = new QLKhachHang();

            formKhachHang.TopLevel = false; 
            formKhachHang.FormBorderStyle = FormBorderStyle.None; 
            formKhachHang.Dock = DockStyle.Fill; 

            
            pictureBox2.Controls.Clear();

 
            pictureBox2.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnQLGiaoDich_Click(object sender, EventArgs e)
        {
            GiaoDich formKhachHang = new GiaoDich();

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBox2.Controls.Clear();


            pictureBox2.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnQLTietKiem_Click(object sender, EventArgs e)
        {
            QLTietKiem formKhachHang = new QLTietKiem();

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBox2.Controls.Clear();


            pictureBox2.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnQLKhoanVay_Click(object sender, EventArgs e)
        {
            QlKhoanVay formKhachHang = new QlKhoanVay();

            formKhachHang.TopLevel = false;
            formKhachHang.FormBorderStyle = FormBorderStyle.None;
            formKhachHang.Dock = DockStyle.Fill;


            pictureBox2.Controls.Clear();


            pictureBox2.Controls.Add(formKhachHang);

            formKhachHang.Show();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            BaoCao formBaocao = new BaoCao();
            formBaocao.TopLevel = false;
            formBaocao.FormBorderStyle = FormBorderStyle.None;
            formBaocao.Dock = DockStyle.Fill;


            pictureBox2.Controls.Clear();


            pictureBox2.Controls.Add(formBaocao);

            formBaocao.Show();
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

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            pcExit.BackColor = System.Drawing.Color.LightGray;
            pcExit.Cursor = Cursors.Hand;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
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
