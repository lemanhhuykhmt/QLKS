using QLKS.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public double Luong { get; set; }

        public NhanVien()
        {
            MaNV = 0;
            TenNV = GioiTinh = SDT ="";
            NgaySinh = DateTime.Now;
            Luong = 0;
        }
        public NhanVien(int manv)
        {
            MaNV = manv;
            if(manv == 0)
            {
                MaNV = 0;
                TenNV = GioiTinh = SDT = "";
                NgaySinh = DateTime.Now;
                Luong = 0;
                return;
            }
            DataTable dt = NhanVienControl.layThongTin(manv);
            TenNV = dt.Rows[0]["TenNV"].ToString();
            GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            NgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            SDT = dt.Rows[0]["SDT"].ToString();
            Luong = double.Parse(dt.Rows[0]["Luong"].ToString());
        }
    }
}
