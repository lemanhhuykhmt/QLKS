﻿using System;
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
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = KhachHangControl.layDanhSach();
            lblCountCustomer.Text = lblCountCustomer.Text + dt.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dgvDanhSach.Rows.Add(new object[] { false, dt.Rows[i]["MaKH"], dt.Rows[i]["TenKH"], dt.Rows[i]["DiaChi"], dt.Rows[i]["SDT"] });
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            frmThemKH f = new frmThemKH();
            f.ShowDialog();
            loadDuLieu();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ketQua = 0;
            for (int i = 0; i < dgvDanhSach.Rows.Count - 1; ++i)
            {
                if (Convert.ToBoolean(dgvDanhSach.Rows[i].Cells["colCheck"].Value.ToString()))
                {
                    ketQua += KhachHangControl.xoaDuLieu(Convert.ToInt32(dgvDanhSach.Rows[i].Cells["colMa"].Value.ToString()));
                }
            }
            if (ketQua > 0)
            {
                MessageBox.Show("xóa thành công " + ketQua);
                loadDuLieu();
            }
            else
            {
                MessageBox.Show("xóa thất bại");
            }
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
            DataTable dt = KhachHangControl.timKiem(value);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dgvDanhSach.Rows.Add(new object[] { false, dt.Rows[i]["MaKH"], dt.Rows[i]["TenKH"], dt.Rows[i]["DiaChi"], dt.Rows[i]["SDT"] });
            }
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Rows.Count == e.RowIndex + 1) return;

            int id = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            if (e.ColumnIndex == dgvDanhSach.Columns["colSua"].Index)
            {
                frmSuaKH f = new frmSuaKH(id);
                f.ShowDialog();
                loadDuLieu();
            }
            else if (e.ColumnIndex == dgvDanhSach.Columns["colXoa"].Index)
            {
                // Hiển thị hộp thoại xác nhận xóa khách hàng
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    int ketQua = KhachHangControl.xoaDuLieu(id);
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
