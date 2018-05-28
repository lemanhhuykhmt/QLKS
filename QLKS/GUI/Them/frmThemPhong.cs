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
    public partial class frmThemPhong : Form
    {
        public frmThemPhong()
        {
            InitializeComponent();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string vitri = txtViTri.Text;
            double gia = double.Parse(txtGia.Text);
            if (kiemTraDuLieu(ten, vitri, gia))
            {
                int ketqua = PhongControl.themDuLieu(ten, vitri, gia);
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
        private bool kiemTraDuLieu(string ten, string vitri, double gia)
        {
            return true;
        }
    }
}
