using QLKS.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Control
{
    class PhongControl
    {
        public static DataTable layDanhSach()
        {
            string query = "select * from Phong";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static DataTable layDuLieu(int ma)
        {
            string query = "select * from Phong where MaPhong = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }
        public static int themDuLieu(string ten, string vitri, double gia)
        {
            string query = "exec themphong @ten , @vitri , @gia";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, vitri, gia });
        }
        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoaphong @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
        }
        public static int suaDuLieu(int ma, string ten, string vitri, double gia, int trangthai)
        {
            string query = "exec suaphong @ma , @ten , @vitri , @gia , @trangthai";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, vitri, gia, trangthai });
        }
        public static DataTable timKiem(string value)
        {
            string keyword = "%" + value + "%";
            string query = "select * from Phong where TenPhong like @ten or ViTri like @vitri";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword, keyword });
        }
        public static DataTable layThongTin(int ma)
        {
            string query = "select * from Phong where MaPhong = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }

        public static DataTable layDanhSachPhongTrong()
        {
            string query = "select * from Phong where TrangThai = 1";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
