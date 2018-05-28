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
    public partial class frmSuaKH : Form
    {
        private int idKH;
        public frmSuaKH()
        {
            InitializeComponent();
        }
        public frmSuaKH(int id)
        {
            InitializeComponent();
            idKH = id;
            DataTable dt = KhachHangControl.layThongTin(id);
            txtTenCu.Text = dt.Rows[0]["TenKH"].ToString();
            txtDiaChiCu.Text = dt.Rows[0]["DiaChi"].ToString();
            txtSDTCu.Text = dt.Rows[0]["SDT"].ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string ten = txtTenMoi.Text;
            string diachi = txtDiaChiMoi.Text;
            string sdt = txtSDTMoi.Text;
            if (kiemTra(ten, diachi, sdt))
            {
                int ketQua = 0;
                ketQua = KhachHangControl.suaDuLieu(idKH, ten, diachi, sdt);
                if (ketQua > 0)
                {
                    MessageBox.Show("thay đổi thành công");
                    this.Close();
                }
            }
        }
        private bool kiemTra(string ten, string diachi, string sdt)
        {
            return true;
        }
    }
}
