using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace BankManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
    }

}
