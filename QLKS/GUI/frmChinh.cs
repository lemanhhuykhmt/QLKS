using QLKS.GUI.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.GUI
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {           
            pnlNoiDung.Controls.Clear();
            ucNhanVien frm = new ucNhanVien();
            frm.Size = new Size(pnlNoiDung.Width, pnlNoiDung.Height);
            frm.Visible = true;
            pnlNoiDung.Controls.Add(frm);
        }
    }
}
