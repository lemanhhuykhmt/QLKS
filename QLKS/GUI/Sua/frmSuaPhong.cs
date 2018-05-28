using QLKS.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.GUI.Sua
{
    public partial class frmSuaPhong : Form
    {
        private int maphong;
        public frmSuaPhong()
        {
            InitializeComponent();
        }
        public frmSuaPhong(int id)
        {
            InitializeComponent();
            maphong = id;
            DataTable dt = PhongControl.layThongTin(id);
            txtTenCu.Text = dt.Rows[0]["TenPhong"].ToString();
            txtViTriCu.Text = dt.Rows[0]["ViTri"].ToString();
            txtGiaCu.Text = dt.Rows[0]["GiaPhong"].ToString();
            string trangthai = "";
            if (Convert.ToInt32(dt.Rows[0]["TrangThai"].ToString()) == 1) trangthai = "Chưa Sử Dụng";
            else trangthai = "Đang Sử Dụng";
            txtTrangThai.Text = trangthai;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string ten = txtTenMoi.Text;
            string vitri = txtViTriMoi.Text;
            double gia;
            if (txtGiaMoi.Text.Length == 0) gia = 0;
            else  gia = double.Parse(txtGiaMoi.Text);
            int trangthai = cbTrangThai.SelectedIndex + 1;
            if (kiemTra(ten, vitri, gia))
            {
                int ketQua = 0;
                ketQua = PhongControl.suaDuLieu(maphong, ten, vitri, gia, trangthai);
                if (ketQua > 0)
                {
                    MessageBox.Show("thay đổi thành công");
                    this.Close();
                }
            }
        }
        private bool kiemTra(string ten, string vitri, double gia)
        {
            return true;
        }
    }
}
