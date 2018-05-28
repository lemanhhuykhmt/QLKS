using QLKS.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class HoaDon
    {
        public int MaHD { get; set; }
        public NhanVien NV { get; set; }
        public KhachHang KH { get; set; }
        public DateTime NgayLap { get; set; }
        public double ThanhToan { get; set; }
        public int TrangThai { get; set; }
        public ChiTietHD ChiTiet { private set; get; }
        public HoaDon()
        {
            MaHD = 0;
            NV = new NhanVien();
            KH = new KhachHang();
            NgayLap = DateTime.Now;
            ThanhToan = 0;
            TrangThai = 1;
            ChiTiet = new ChiTietHD();
        }
        public HoaDon(int mahd)
        {
            MaHD = mahd;
            if(mahd == 0)
            {
                NV = new NhanVien();
                KH = new KhachHang();
                NgayLap = DateTime.Now;
                ThanhToan = 0;
                TrangThai = 1;
                ChiTiet = new ChiTietHD();
                return;
            }
            DataTable dt = HoaDonControl.layDuLieu(mahd);
            NV = new NhanVien(Convert.ToInt32(dt.Rows[0]["MaNV"].ToString()));
            KH = new KhachHang(Convert.ToInt32(dt.Rows[0]["MaKH"].ToString()));
            NgayLap = DateTime.Parse(dt.Rows[0]["NgayLap"].ToString());
            ThanhToan = double.Parse(dt.Rows[0]["ThanhToan"].ToString());
            TrangThai = Convert.ToInt32(dt.Rows[0]["TrangThai"].ToString());
            ChiTiet = new ChiTietHD(mahd);
        }

        public double TinhThanhToan()
        {
            ThanhToan = ChiTiet.TongTien();
            return ThanhToan;
        }
    }
}
