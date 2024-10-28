using System;
using System.Collections;
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
        string str = "";
        public ThongTin()
        {
            InitializeComponent();
            try
            {
                string query = "SELECT COUNT(*) FROM KhachHang";
                int soLuongKhachHang = (int)db.ThucThiGiaTriDon(query);
                if(soLuongKhachHang != 0)
                {
                    lbslkh.Text = soLuongKhachHang.ToString();
                }
                else
                {
                    str += "Số lượng khách hàng bằng 0\n";
                }
                

                string query1 = "SELECT COUNT(*) FROM NhanVien";
                int soLuongNhanVien = (int)db.ThucThiGiaTriDon(query1);
                if (soLuongNhanVien != 0)
                {
                    lbslnv.Text = soLuongNhanVien.ToString();
                }
                else
                {
                    str += "Số lượng nhân viên bằng 0\n ";
                }
                

                string query2 = "SELECT COUNT(*) FROM Taikhoan";
                int soLuongTaiKhoan = (int)db.ThucThiGiaTriDon(query2);
                if (soLuongTaiKhoan != 0)
                {
                    lbsltk.Text = soLuongTaiKhoan.ToString();
                }
                else
                {
                    str += "Số lượng tài khoản bằng 0\n";
                }
                

                string query3 = "SELECT COUNT(*) FROM GiaoDich";
                int soLuongGiaoDich = (int)db.ThucThiGiaTriDon(query3);
                if (soLuongGiaoDich != 0)
                {
                    lbslgd.Text = soLuongGiaoDich.ToString();
                }
                else
                {
                    str += "Số lượng giao dịch bằng 0\n";
                }

                string query4 = "SELECT sum(SoTienGuiTietKiem) FROM TaiKhoan";
                int soLuongTienGui = (int)db.ThucThiGiaTriDon(query4);
                if (soLuongTienGui != 0)
                {
                    lbsltg.Text = soLuongTienGui.ToString();
                }
                else
                {
                    str += "Số lượng tiền giao dịch bằng 0\n";
                }

                string query5 = "SELECT sum(SoTienVay) FROM TaiKhoan";
                int soLuongTienVay = (int)db.ThucThiGiaTriDon(query5);
                if (soLuongTienVay != 0)
                {
                    lbsltv.Text = soLuongTienVay.ToString();
                }
                else
                {
                    str += "Số lượng tiền vay = 0";
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"Lỗi: "+str+ "");
            }

           

        }

        private void lbslkh_Click(object sender, EventArgs e)
        {

        }
    }
}
