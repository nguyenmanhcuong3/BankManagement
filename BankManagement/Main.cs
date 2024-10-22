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
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled= false;
            btnThongTin.Enabled = false;


            KhachHang kh = new KhachHang();
            kh.Show();

      
            kh.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled =   true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = false;


            TaiKhoan tk = new TaiKhoan();
            tk.Show();


            tk.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = false;


            GiaoDich gd = new GiaoDich();
            gd.Show();


            gd.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnKhoanVay_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = false;


            KhoanVay kv = new KhoanVay();
            kv.Show();


            kv.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = false;


            NhanVien nv = new NhanVien();
            nv.Show();


            nv.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
                btnTaiKhoan.Enabled = true;
                btnNhanVien.Enabled = true;
                btnThongTin.Enabled = true;
                btnKhachHang.Enabled = true;
            };
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            btnKhachHang.Enabled = false;
            btnGiaoDich.Enabled = false;
            btnKhoanVay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongTin.Enabled = false;


            ThongTin tt = new ThongTin();
            tt.Show();


            tt.FormClosed += (s, args) =>
            {
                btnGiaoDich.Enabled = true;
                btnKhoanVay.Enabled = true;
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
