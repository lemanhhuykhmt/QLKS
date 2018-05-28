using QLKS.ExtendModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Control
{
    class ChiTietHDControl
    {
        public static DataTable layDSPhongCuaHD(int mahd) // lấy danh sách vt có trong pn
        {
            string query = "select ct.MaPhong from "
                + " ChiTietHD as ct where ct.MaHD = @mahd";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { mahd });
        }
        public static int themChiTiet(int mahd, int maphong)
        {
            string query = "exec themcthd @mahd , @maphong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, maphong });
        }
    }
}
