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
using System.Windows.Forms.DataVisualization.Charting;

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
                // Câu truy vấn và gán số liệu vào các biến
                int soLuongKhachHang = GetCount("SELECT COUNT(*) FROM KhachHang", "Số lượng khách hàng bằng 0\n");
                int soLuongNhanVien = GetCount("SELECT COUNT(*) FROM NhanVien", "Số lượng nhân viên bằng 0\n");
                int soLuongTaiKhoan = GetCount("SELECT COUNT(*) FROM Taikhoan", "Số lượng tài khoản bằng 0\n");
                int soLuongGiaoDich = GetCount("SELECT COUNT(*) FROM GiaoDich", "Số lượng giao dịch bằng 0\n");
                int soLuongTienGui = GetSum("SELECT SUM(SoTienGuiTietKiem) FROM TaiKhoan", "Số lượng tiền gửi bằng 0\n");
                int soLuongTienVay = GetSum("SELECT SUM(SoTienVay) FROM TaiKhoan", "Số lượng tiền vay = 0");

                // Cập nhật giá trị cho các Label
                lbslkh.Text = soLuongKhachHang.ToString();
                lbslnv.Text = soLuongNhanVien.ToString();
                lbsltk.Text = soLuongTaiKhoan.ToString();
                lbslgd.Text = soLuongGiaoDich.ToString();
                lbsltg.Text = soLuongTienGui.ToString();
                lbsltv.Text = soLuongTienVay.ToString();

                // Vẽ biểu đồ
                DrawChart(soLuongKhachHang, soLuongNhanVien, soLuongTaiKhoan, soLuongGiaoDich, soLuongTienGui, soLuongTienVay);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"Lỗi: " + str);
            }
        }

        private int GetCount(string query, string errorMessage)
        {
            int count = (int)db.ThucThiGiaTriDon(query);
            if (count == 0)
            {
                str += errorMessage;
            }
            return count;
        }

        private int GetSum(string query, string errorMessage)
        {
            int sum = (int)db.ThucThiGiaTriDon(query);
            if (sum == 0)
            {
                str += errorMessage;
            }
            return sum;
        }

        private void DrawChart(int khachHang, int nhanVien, int taiKhoan, int giaoDich, int tienGui, int tienVay)
        {
            // Thiết lập biểu đồ
            chartThongKe.Series.Clear();
            Series series = new Series("Số liệu");
            series.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ
            series.Points.AddXY("Khách Hàng", khachHang);
            series.Points.AddXY("Nhân Viên", nhanVien);
            series.Points.AddXY("Tài Khoản", taiKhoan);
            series.Points.AddXY("Giao Dịch", giaoDich);
            series.Points.AddXY("Tiền Gửi", tienGui);
            series.Points.AddXY("Tiền Vay", tienVay);

            // Thêm series vào biểu đồ
            chartThongKe.Series.Add(series);

            // Thiết lập tiêu đề cho trục
            chartThongKe.ChartAreas[0].AxisX.Title = "Loại";
            chartThongKe.ChartAreas[0].AxisY.Title = "Số lượng";
        }
    }
}
