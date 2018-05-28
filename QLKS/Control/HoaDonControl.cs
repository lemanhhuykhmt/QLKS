using QLKS.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Control
{
    class HoaDonControl
    {
        public static int themDuLieu(int makh, int manv, DateTime ngaylap, int trangthai, double thanhtoan) // thêm dữ liệu vào bảng
        {
            string query = "exec themhd @manv , @makh , @ngaylap , @thanhtoan";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, makh, ngaylap, thanhtoan });
        }
        public static DataTable layDanhSach()  // lấy ra danh sách hóa đơn có tên nv, tên kh
        {
            string query = "select a.MaHD, a.TenNV, kh.TenKH, a.TrangThai, a.NgayLap, " 
                + " a.ThanhToan from(select hd.MaHD, nv.TenNV, hd.MaKH, hd.TrangThai, " 
                + " hd.NgayLap, hd.ThanhToan from HoaDon as hd left join NhanVien as nv " 
                + " on hd.MaNV = nv.MaNV) as a left join KhachHang as kh on a.MaKH = kh.MaKH";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public static DataTable layThongTin(int id) // lấy thông tin hóa đơn có id là
        {
            string query = "select a.MaHD, a.TenNV, kh.TenKH, a.TrangThai, a.NgayLap, "
                + " a.ThanhToan from(select hd.MaHD, nv.TenNV, hd.MaKH, hd.TrangThai, "
                + " hd.NgayLap, hd.ThanhToan from HoaDon as hd left join NhanVien as nv "
                + " on hd.MaNV = nv.MaNV) as a left join KhachHang as kh on a.MaKH = kh.MaKH where MaHD = @ma";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            return dt;
        }
        public static int suaThongTin(int ma, int makh, int manv, int trangthai, double thanhtoan) // sửa thông tin của hóa đơn
        {
            string query = "exec suahd @id , @manv , @makh , @thanhtoan , @trangthai";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, manv, makh, thanhtoan, trangthai });
        }
        public static int xoaThongTin(int id) // xóa thông tin hoa don ban
        {
            string query = "exec xoahd @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
        public static DataTable timKiem(object obj)
        {
            string str = "%" + obj.ToString() + "%";
            string query = "select * from (select a.MaHD, a.TenNV, kh.TenKH, a.TrangThai, " 
                + "a.NgayLap, a.ThanhToan from (select hd.MaHD, nv.TenNV, hd.MaKH, hd.TrangThai, " 
                + " hd.NgayLap, hd.ThanhToan from HoaDon as hd left join NhanVien as nv on hd.MaNV " 
                + " = nv.MaNV) as a left join KhachHang as kh on a.MaKH =  kh.MaKH) as x where " 
                + " x.TenKH like @tenkh or x.TenNV  like @tennv";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { str, str });
        }
        
       
        public static DataTable layDuLieu(int id)
        {
            string query = "select MaHD, MaKH, MaNV, NgayLap, TrangThai, ThanhToan from HoaDon where MaHD = @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        /////////////////////////////////
        //public static int themChiTietHDB(int mahdb, int masp, int soluong, double gia)
        //{
        //    string query = "exec themdsb @mahdb , @masp , @soluong , @gia";
        //    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahdb, masp, soluong, gia });
        //}
        //public static int suaChiTietHDB(int mahdb, int masp, int soluong, double gia)
        //{
        //    string query = "exec suadsb @mahdb , @masp , @soluong , @gia";
        //    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahdb, masp, soluong, gia });
        //}
        public static int xoaChiTietHD(int mahd)
        {
            string query = "exec xoacthd_all @ma";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd });
        }
        public static int layMaHDMoi()
        {
            string query = "select top(1) MaHD from HoaDon order by [MaHD] desc";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return 0;
            return Convert.ToInt32(dt.Rows[0]["MaHD"].ToString());
        }
    }
}
