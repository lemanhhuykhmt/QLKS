using QLKS.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Control
{
    class NhanVienControl
    {
        public static DataTable layDanhSach()
        {
            string query = "select * from NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static DataTable layDuLieu(int ma)
        {
            string query = "select * from NhanVien where MaNV = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }
        public static int themDuLieu(string ten, string gioitinh, DateTime ngaysinh, string sdt, double luong)
        {
            string query = "exec themnv @ten , @gioi , @ngaysinh , @sdt , @luong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, gioitinh, ngaysinh, sdt, luong });
        }
        public static int xoaDuLieu(int ma)
        {
            string query = "exec xoanv @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
        }
        public static int suaDuLieu(int ma, string ten, string gioitinh, string ngaysinh, string sdt, double luong)
        {

            string query = "exec suanv @ma , @ten , @gioitinh , @ngaysinh , @sdt , @luong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, gioitinh, ngaysinh, sdt, luong });
        }
        public static DataTable timKiem(string value)
        {
            string keyword = "%" + value + "%";
            string query = "select * from NhanVien where TenNV like @ten or GioiTinh like @gioitinh";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword, keyword });
        }
        public static DataTable layThongTin(int ma)
        {
            string query = "select * from NhanVien where MaNV = @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
        }
    }
}
