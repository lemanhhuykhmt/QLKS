using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.Control;
using QLKS.GUI.Them;

namespace QLKS.GUI.UC
{
    public partial class ucHoaDon : UserControl
    {
        public ucHoaDon()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = HoaDonControl.layDanhSach();
            lblHoadon.Text = lblHoadon.Text + dt.Rows.Count.ToString();

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string trangthai = "";
                if (Convert.ToInt16(dt.Rows[i]["TrangThai"].ToString()) == 1) trangthai = "Chưa Thanh Toán";
                else trangthai = "Đã Thanh Toán";
                dgvDanhSach.Rows.Add(new object[] { dt.Rows[i]["MaHD"], dt.Rows[i]["TenNV"], dt.Rows[i]["TenKH"],
                   String.Format("{0:dd/MM/yyyy}", dt.Rows[i]["NgayLap"]), trangthai });
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            frmThemHD f = new frmThemHD();
            f.ShowDialog();
            loadDuLieu();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }
        private void timKiem()
        {
            // get text
            string value = txtTimKiem.Text;
            if (value.Length == 0)
            {
                loadDuLieu();
                return;
            }
            dgvDanhSach.Rows.Clear();
            DataTable dt = HoaDonControl.timKiem(value);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string trangthai = "";
                if (Convert.ToInt16(dt.Rows[i]["TrangThai"].ToString()) == 1) trangthai = "Chưa Thanh Toán";
                else trangthai = "Đã Thanh Toán";
                dgvDanhSach.Rows.Add(new object[] { dt.Rows[i]["MaHD"], dt.Rows[i]["TenNV"], dt.Rows[i]["TenKH"],
                   String.Format("{0:dd/MM/yyyy}", dt.Rows[i]["NgayLap"]), trangthai });
            }
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Rows.Count == e.RowIndex + 1) return;

            int id = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            if (e.ColumnIndex == dgvDanhSach.Columns["colSua"].Index)
            {
                frmThemHD f = new frmThemHD(id);
                f.ShowDialog();
                loadDuLieu();
            }
            else if (e.ColumnIndex == dgvDanhSach.Columns["colXoa"].Index)
            {
                int ketQua = HoaDonControl.xoaThongTin(id);
                if (ketQua <= 0)
                {
                    MessageBox.Show("Thực hiện thất bại");
                }
                else
                {
                    loadDuLieu();
                }
            }
        }
        private void txtTimKiem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                timKiem();
            }
            else if (e.KeyValue == 27)
            {
                txtTimKiem.Text = "";
                loadDuLieu();
            }
        }
    }
}
