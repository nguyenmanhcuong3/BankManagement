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
    public partial class ThongTin : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        public ThongTin()
        {
            InitializeComponent();
            /*string query = "SELECT COUNT(*) FROM KhachHang";
            int soLuongKhachHang = (int)db.ThucThiGiaTriDon(query);
            lbslkh.Text = soLuongKhachHang.ToString();

            string query1 = "SELECT COUNT(*) FROM NhanVien";
            int soLuongNhanVien = (int)db.ThucThiGiaTriDon(query1);
            lbslnv.Text = soLuongNhanVien.ToString();

            string query2 = "SELECT COUNT(*) FROM Taikhoan";
            int soLuongTaiKhoan = (int)db.ThucThiGiaTriDon(query2);
            lbsltk.Text = soLuongTaiKhoan.ToString();

            string query3 = "SELECT COUNT(*) FROM GiaoDich";
            int soLuongGiaoDich = (int)db.ThucThiGiaTriDon(query3);
            lbslgd.Text = soLuongGiaoDich.ToString();

            string query4 = "SELECT sum(SoTienGuiTietKiem) FROM TaiKhoan";
            int soLuongTienGui = (int)db.ThucThiGiaTriDon(query4);
            lbsltg.Text = soLuongTienGui.ToString();

            string query5 = "SELECT sum(SoTienVay) FROM TaiKhoan";
            int soLuongTienVay = (int)db.ThucThiGiaTriDon(query5);
            lbsltv.Text = soLuongTienVay.ToString();*/
        }

        private void ThongTin_Load(object sender, EventArgs e)
        {

        }

        private void ThongTin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
