using QLKS.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class Phong
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string ViTri { get; set; }
        public double GiaPhong { get; set; }
        public int TrangThai { get; set; }
        
        public Phong ()
        {
            MaPhong = 0;
            TenPhong = ViTri = "";
            GiaPhong = 0;
            TrangThai = 1;
        }
        public Phong (int maphong)
        {
            MaPhong = maphong;
            if (maphong == 0)
            {
                TenPhong = ViTri = "";
                GiaPhong = 0;
                TrangThai = 1;
                return;
            }
            DataTable dt = PhongControl.layDuLieu(maphong);
            TenPhong = dt.Rows[0]["TenPhong"].ToString();
            ViTri = dt.Rows[0]["ViTri"].ToString();
            GiaPhong = double.Parse(dt.Rows[0]["GiaPhong"].ToString());
            TrangThai = Convert.ToInt16(dt.Rows[0]["TrangThai"]);
        }
    }
}
