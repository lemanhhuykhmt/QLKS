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
    public partial class ucPhong : UserControl
    {
        public ucPhong()
        {
            InitializeComponent();
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            dgvDanhSach.Rows.Clear();
            DataTable dt = PhongControl.layDanhSach();
            lblPhong.Text = lblPhong.Text + dt.Rows.Count.ToString();

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string trangthai = "";
                if (Convert.ToInt32(dt.Rows[i]["TrangThai"].ToString()) == 1) trangthai = "Trống";
                else trangthai = "Đang Sử Dụng";
                dgvDanhSach.Rows.Add(dt.Rows[i]["MaPhong"], dt.Rows[i]["TenPhong"], dt.Rows[i]["ViTri"], dt.Rows[i]["GiaPhong"], trangthai);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemPhong frm = new frmThemPhong();
            frm.ShowDialog();
            loadDuLieu();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int maVT = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            int id = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["colMa"].Value.ToString());
            if (e.ColumnIndex == dgvDanhSach.Columns["colSua"].Index)
            {
                frmSuaPhong frm = new frmSuaPhong(maVT);
                frm.ShowDialog();
                loadDuLieu();
            }
            else if (e.ColumnIndex == dgvDanhSach.Columns["colXoa"].Index)
            {
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa phòng này không?", "Xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    int ketQua = PhongControl.xoaDuLieu(id);
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

        private void timKiem()
        {
            string value = txtTimKiem.Text;
            if (value.Length == 0)
            {
                loadDuLieu();
                return;
            }
            dgvDanhSach.Rows.Clear();
            DataTable dt = PhongControl.timKiem(value);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string trangthai = "";
                if (Convert.ToInt32(dt.Rows[i]["TrangThai"].ToString()) == 1) trangthai = "Trống";
                else trangthai = "Đang Sử Dụng";
                dgvDanhSach.Rows.Add(dt.Rows[i]["MaPhong"], dt.Rows[i]["TenPhong"], dt.Rows[i]["ViTri"], dt.Rows[i]["GiaPhong"], trangthai);
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
