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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh=new KhachHang();
            kh.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tk= new TaiKhoan();
            tk.Show();
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoanVay_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {

        }
    }
}
