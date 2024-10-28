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
        public ThongTin()
        {
            InitializeComponent();
            string query = "SELECT COUNT(*) FROM KhachHang";
            int soLuongKhachHang = (int)db.ThucThiGiaTriDon(query);
            lbslkh.Text = soLuongKhachHang.ToString();


        }
    }
}
