using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BankManagement
{
    public partial class BaoCao : Form
    {
        DataReport db = new DataReport();
        string str = "";

        public BaoCao()
        {
            InitializeComponent();
            try
            {
                // Câu truy vấn và gán số liệu vào các biến
                int soLuongKhachHang = GetCount("SELECT COUNT(*) FROM KhachHang", "Số lượng khách hàng bằng 0\n");
                int soLuongGiaoDich = GetCount("SELECT COUNT(*) FROM GiaoDich", "Số lượng giao dịch bằng 0\n");
                int soLuongTienGui = GetSum("SELECT SUM(SoTienGuiTietKiem) FROM TaiKhoan", "Số lượng tiền gửi bằng 0\n");
                int soLuongTienVay = GetSum("SELECT SUM(SoTienVay) FROM TaiKhoan", "Số lượng tiền vay = 0");

                // Cập nhật giá trị cho các Label
                lbslkh.Text = soLuongKhachHang.ToString();
                lbslgd.Text = soLuongGiaoDich.ToString();
                lbsltg.Text = soLuongTienGui.ToString();
                lbsltv.Text = soLuongTienVay.ToString();

                // Vẽ hai biểu đồ
                DrawNguoiChart(soLuongKhachHang);
                DrawTienChart(soLuongTienGui, soLuongTienVay);
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

        private void DrawNguoiChart(int khachHang)
        {
            // Thiết lập biểu đồ cho thông tin về người
            chartNguoi.Series.Clear();
            Series seriesNguoi = new Series("Số liệu Người");
            seriesNguoi.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ
            seriesNguoi.Points.AddXY("Khách Hàng", khachHang);

            // Thêm series vào biểu đồ
            chartNguoi.Series.Add(seriesNguoi);

            // Thiết lập tiêu đề cho trục
            chartNguoi.ChartAreas[0].AxisX.Title = "Chức vụ";
            chartNguoi.ChartAreas[0].AxisY.Title = "Số lượng";
        }

        private void DrawTienChart(int tienGui, int tienVay)
        {
            // Thiết lập biểu đồ cho thông tin về tiền
            chartTien.Series.Clear();
            Series seriesTien = new Series("Số liệu Tiền");
            seriesTien.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ
            seriesTien.Points.AddXY("Tiền Gửi", tienGui);
            seriesTien.Points.AddXY("Tiền Vay", tienVay);

            // Thêm series vào biểu đồ
            chartTien.Series.Add(seriesTien);

            // Thiết lập tiêu đề cho trục
            chartTien.ChartAreas[0].AxisX.Title = "Loại tiền";
            chartTien.ChartAreas[0].AxisY.Title = "Số tiền";
        }

        private void ThongTin_Load(object sender, EventArgs e)
        {

        }
    }
}
