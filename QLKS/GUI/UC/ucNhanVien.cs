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
using QLKS.GUI.Sua;

namespace QLKS.GUI.UC
{
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = NhanVienControl.layDanhSach();
            lblnhanvien.Text = lblnhanvien.Text + dt.Rows.Count.ToString();

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dgvDanhSach.Rows.Add(dt.Rows[i]["MaNV"], dt.Rows[i]["TenNV"], dt.Rows[i]["GioiTinh"], dt.Rows[i]["NgaySinh"], dt.Rows[i]["SDT"], dt.Rows[i]["Luong"]);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNV frm = new frmThemNV();
            frm.ShowDialog();
            loadDuLieu();
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int ma = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            if (e.ColumnIndex == dgvDanhSach.Columns["colSua"].Index)
            {
                frmSuaNV frm = new frmSuaNV(ma);
                frm.ShowDialog();
                loadDuLieu();
            }
            else if (e.ColumnIndex == dgvDanhSach.Columns["colXoa"].Index)
            {
                // Hiển thị hộp thoại xác nhận xóa nhân viên
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    int ketqua = NhanVienControl.xoaDuLieu(ma);
                    if (ketqua > 0)
                    {
                        loadDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Thực hiện thất bại");
                    }
                }
            }
        }
            private void timKiem()
            {
                string value = txtTimKiem.Text;
                if (value.Length == 0)
                {
                    loadDuLieu();
                    return;
                }
                dgvDanhSach.Rows.Clear();
                DataTable dt = NhanVienControl.timKiem(value);
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dgvDanhSach.Rows.Add(dt.Rows[i]["MaNV"], dt.Rows[i]["TenNV"], dt.Rows[i]["GioiTinh"], dt.Rows[i]["NgaySinh"], dt.Rows[i]["SDT"], dt.Rows[i]["Luong"]);
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
            private void btnLoad_Click(object sender, EventArgs e)
            {
                loadDuLieu();
            }
        }
    }
