using QLKS.Control;
using QLKS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.GUI.Them
{
    public partial class frmThemHD : Form
    {
        private HoaDon HD;
        public frmThemHD()
        {
            InitializeComponent();
            HD = new HoaDon();
            loadDanhSachPhong();
            loadDSKH();
            loadDSNV();
            ckbNgayLap.Checked = true;
            ckbNgayLap.Visible = false;
        }
        public frmThemHD(int id)
        {
            InitializeComponent();
            HD = new HoaDon(id);
            loadDanhSachPhong();
            loadDSKH();
            loadDSNV();
            loadChiTietHD();
            loadKH();
            loadNV();
            loadTrangThai();
            loadNgayLap();
            loadThanhToan();
            ckbNgayLap.Checked = false;
            dtpNgayLap.Enabled = false;
        }

        private void loadDanhSachPhong()
        {
            dgvDanhSachPhong.Rows.Clear();
            DataTable dt = PhongControl.layDanhSachPhongTrong();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                int vitri = HD.ChiTiet.isContain(Convert.ToInt32(dt.Rows[i][0].ToString()));
                if (vitri != -1) // nếu phong có trong HD
                {
                    continue;
                }
                dgvDanhSachPhong.Rows.Add(new object[] { dt.Rows[i]["MaPhong"], dt.Rows[i]["TenPhong"], dt.Rows[i]["GiaPhong"] });
            }

        }

        private void loadChiTietHD()
        {
            dgvChiTiet.Rows.Clear();
            for (int i = 0; i < HD.ChiTiet.ListPhong.Count; ++i)
            {
                dgvChiTiet.Rows.Add(new object[] {
                    HD.ChiTiet.ListPhong[i].MaPhong,
                    HD.ChiTiet.ListPhong[i].TenPhong,
                    HD.ChiTiet.ListPhong[i].GiaPhong });
                dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 2].Tag = HD.ChiTiet.ListPhong[i].MaPhong;
                //dgvChiTiet.Rows.Add()
            }
        }


        private void loadDSNV()
        {
            DataTable dt = NhanVienControl.layDanhSach();
            List<NhanVien> list = new List<NhanVien>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                list.Add(new NhanVien
                {
                    MaNV = Convert.ToInt32(dt.Rows[i]["MaNV"].ToString()),
                    TenNV = dt.Rows[i]["TenNV"].ToString(),
                    GioiTinh = dt.Rows[i]["GioiTinh"].ToString(),
                    NgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString()),
                    SDT = dt.Rows[0]["SDT"].ToString(),
                    Luong = double.Parse(dt.Rows[0]["Luong"].ToString())
            });
            }
            cbNhanVien.DataSource = list;
            cbNhanVien.DisplayMember = "TenNV";
        }
        private void loadNV()
        {
            DataTable dt = HoaDonControl.layDuLieu(HD.MaHD);
            HD.NV = new NhanVien(dt.Rows[0]["MaNV"].ToString().Length == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["MaNV"].ToString()));
            if (HD.NV.TenNV.Length > 0)
            {
                cbNhanVien.Text = HD.NV.TenNV;
                return;
            }
        }
        private void loadDSKH()
        {
            DataTable dt = KhachHangControl.layDanhSach();
            List<KhachHang> list = new List<KhachHang>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                list.Add(new KhachHang
                {
                    MaKH = Convert.ToInt32(dt.Rows[i]["MaKH"].ToString()),
                    TenKH = dt.Rows[i]["TenKH"].ToString(),
                    DiaChi = dt.Rows[0]["DiaChi"].ToString(),
                    SDT = dt.Rows[0]["SDT"].ToString()
                });
            }
            cbKhachHang.DataSource = list;
            cbKhachHang.DisplayMember = "TenKH";
        }
        private void loadKH()
        {
            DataTable dt = HoaDonControl.layDuLieu(HD.MaHD);
            HD.KH = new KhachHang(dt.Rows[0]["MaKH"].ToString().Length == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["MaKH"].ToString()));
            if (HD.KH.TenKH.Length > 0)
            {
                cbKhachHang.Text = HD.KH.TenKH;
                return;
            }
        }
        private void loadTrangThai()
        {
            cbTrangThai.SelectedIndex = HD.TrangThai - 1;
        }
        private void loadNgayLap()
        {
            dtpNgayLap.Text = HD.NgayLap.ToShortDateString();
        }
        private void loadThanhToan()
        {
            HD.TinhThanhToan();
            txtThanhToan.Text = HD.ThanhToan.ToString();
        }


        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvChiTiet.Columns["colXoa"].Index)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                HD.ChiTiet.xoaPhong(Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Tag));
                loadDanhSachPhong();
                loadChiTietHD();
                loadThanhToan();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        { // còn thiếu lưu các thông tin khác
            if (HD.MaHD == 0) // neu la hd moi
            {
                int ketqua = HoaDonControl.themDuLieu(HD.KH.MaKH, HD.NV.MaNV, HD.NgayLap, HD.TrangThai, HD.ThanhToan);
                if (ketqua <= 0)
                {
                    return;
                } //
                ketqua = 0;
                // lay ma hoa don vua nhap
                HD.MaHD = HoaDonControl.layMaHDMoi();
                if (HD.MaHD == 0) return;
                for (int i = 0; i < HD.ChiTiet.ListPhong.Count; ++i)
                {
                    ketqua += ChiTietHDControl.themChiTiet(HD.MaHD, HD.ChiTiet.ListPhong[i].MaPhong);
                }
                if (ketqua > 0)
                {
                    MessageBox.Show("them thanh cong");
                    this.Close();
                }
            }
            else // neu hd cu
            {
                //sua
                string ngaylap = "";
                if (ckbNgayLap.Checked == true)
                {
                    ngaylap = HD.NgayLap.ToShortTimeString();
                }
                HoaDonControl.suaThongTin(HD.MaHD, HD.KH.MaKH, HD.NV.MaNV, HD.TrangThai, HD.ThanhToan);

                // xoa het chitiet cu
                HoaDonControl.xoaChiTietHD(HD.MaHD);
                //
                int ketqua = 0;
                for (int i = 0; i < HD.ChiTiet.ListPhong.Count; ++i)
                {
                    ketqua += ChiTietHDControl.themChiTiet(HD.MaHD, HD.ChiTiet.ListPhong[i].MaPhong);
                    if(HD.TrangThai == 1)
                    {
                        PhongControl.suaDuLieu(HD.ChiTiet.ListPhong[i].MaPhong, "", "", -1, 2);
                    }

                }
                if (ketqua > 0)
                {
                    MessageBox.Show("sua thanh cong");
                    this.Close();
                }
            }
        }


        private void dgvDanhSachPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDanhSachPhong.Columns["colChon"].Index)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                int row = e.RowIndex;
                int id = Convert.ToInt32(dgvDanhSachPhong.Rows[row].Cells["colMa"].Value);
                HD.ChiTiet.ThemPhong(id);// thêm sp vào chi tiết sp
                //giảm số lượng
                dgvDanhSachPhong.Rows.RemoveAt(row);
                loadChiTietHD();
                loadThanhToan();
            }
        }

        private void ckbNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgayLap.Enabled = ckbNgayLap.Checked;
        }

        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            HD.NV = cbNhanVien.SelectedValue as NhanVien;
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            HD.KH = cbKhachHang.SelectedValue as KhachHang;
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            HD.TrangThai = cbTrangThai.SelectedIndex + 1;
        }
    }
}
