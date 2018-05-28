using QLKS.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Control
{
    class KhachHangControl
    {
        public static DataTable layDanhSach()
        {
            string query = "select * from KhachHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static DataTable layDuLieu(int ma)
        {
            string query = "select * from KhachHang where MaKH = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }
        public static int themDuLieu(string ten, string diachi, string sdt)
        {
            string query = "exec themkh @ten , @diachi , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, diachi, sdt });
        }
        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoakh @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
        }
        public static int suaDuLieu(int ma, string ten, string diachi, string sdt)
        {

            string query = "exec suakh @ma , @ten , @diachi , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, diachi, sdt });
        }
        public static DataTable timKiem(string value)
        {
            string keyword = "%" + value + "%";
            string query = "select * from KhachHang where TenNV like @ten or DiaChi like @diachi";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword, keyword });
        }
        public static DataTable layThongTin(int ma)
        {
            string query = "select * from KhachHang where MaKH = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }
    }
}
