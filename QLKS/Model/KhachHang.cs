using QLKS.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public KhachHang ()
        {
            MaKH = 0;
            TenKH = DiaChi = SDT = "";
        }
        public KhachHang(int manv)
        {
            MaKH = manv;
            if(MaKH == 0)
            {
                TenKH = DiaChi = SDT = "";
                return;
            }
            DataTable dt = KhachHangControl.layDuLieu(manv);
            TenKH = dt.Rows[0]["TenKH"].ToString();
            DiaChi = dt.Rows[0]["DiaChi"].ToString();
            SDT = dt.Rows[0]["SDT"].ToString();
        }
    }
}
