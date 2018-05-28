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

namespace QLKS.GUI.Them
{
    public partial class frmThemKH : Form
    {
        public frmThemKH()
        {
            InitializeComponent();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            if (kiemTraDuLieu(ten, diachi, sdt))
            {
                int ketqua = KhachHangControl.themDuLieu(ten, diachi, sdt);
                if (ketqua > 0)
                {
                    MessageBox.Show("thêm thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                }
            }
        }
        private bool kiemTraDuLieu(string ten, string diachi, string sdt)
        {
            return true;
        }
    }
}
