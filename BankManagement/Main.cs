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

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = true;
            btnTaiKhoan.Enabled = true;
            btnNhanVien.Enabled= true;
            btnThongTin.Enabled = true;

            KhachHang kh = new KhachHang();
            kh.TopLevel = false;  
            kh.FormBorderStyle = FormBorderStyle.None;  
            kh.Dock = DockStyle.Fill;  
            panelMain.Controls.Clear();  
            panelMain.Controls.Add(kh);  
            kh.Show();

            kh.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled =   true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = true;
            btnGiaoDich.Enabled = true;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = true;
            btnThongTin.Enabled = true;

            TaiKhoan tk = new TaiKhoan();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tk);
            tk.Show();

            tk.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = true;
            btnGiaoDich.Enabled = false;
            btnTaiKhoan.Enabled = true;
            btnNhanVien.Enabled = true;
            btnThongTin.Enabled = true;


            GiaoDich tk = new GiaoDich();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tk);
            tk.Show();


            tk.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        
        

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = true;
            btnGiaoDich.Enabled = true;
            btnTaiKhoan.Enabled = true;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = true;

            NhanVien tk = new NhanVien();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tk);
            tk.Show();


            tk.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = true;
            btnGiaoDich.Enabled = true;
            btnTaiKhoan.Enabled = true;
            btnNhanVien.Enabled = true;
            btnThongTin.Enabled = false;


            ThongTin tk = new ThongTin();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tk);
            tk.Show();


            tk.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
