using QLKS.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class ChiTietHD
    {
        public List<Phong> ListPhong { private set; get; }
        public ChiTietHD()
        {
            ListPhong = new List<Phong>();
        }
        public ChiTietHD(int mahd)
        {
            ListPhong = new List<Phong>();
            DataTable dt = ChiTietHDControl.layDSPhongCuaHD(mahd);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Phong phong = new Phong(Convert.ToInt32(dt.Rows[i]["MaPhong"].ToString()));
                ListPhong.Add(phong);
            }
        }
        public int isContain(int maphong)
        {
            for (int i = 0; i < ListPhong.Count; ++i)
            {
                if (maphong == ListPhong[i].MaPhong)
                {
                    return i;
                }
            }
            return -1;
        }
        public void xoaPhong(int id)
        {
            int vitri = isContain(id);
            if (vitri != -1)
            {
                ListPhong.RemoveAt(vitri);
            }
        }
        public void ThemPhong(int id)
        {
            Phong p = new Phong(id);
            ListPhong.Add(p);
        }
        public double TongTien()
        {
            double tongTien = 0;
            for (int i = 0; i < ListPhong.Count; ++i)
            {
                tongTien += ListPhong[i].GiaPhong;
            }
            return tongTien;
        }
    }
}
