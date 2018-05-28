namespace QLKS.GUI
{
    partial class frmChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPhieuXuat = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnCuaHang = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPhieuXuat);
            this.groupBox1.Controls.Add(this.btnPhieuNhap);
            this.groupBox1.Controls.Add(this.btnCuaHang);
            this.groupBox1.Controls.Add(this.btnNCC);
            this.groupBox1.Controls.Add(this.btnNhanVien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 633);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa Chọn";
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Location = new System.Drawing.Point(6, 279);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Size = new System.Drawing.Size(197, 43);
            this.btnPhieuXuat.TabIndex = 2;
            this.btnPhieuXuat.Text = "Phiếu Mượn";
            this.btnPhieuXuat.UseVisualStyleBackColor = true;
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Location = new System.Drawing.Point(6, 204);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(197, 43);
            this.btnPhieuNhap.TabIndex = 2;
            this.btnPhieuNhap.Text = "Phiếu Mượn";
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            // 
            // btnCuaHang
            // 
            this.btnCuaHang.Location = new System.Drawing.Point(3, 139);
            this.btnCuaHang.Name = "btnCuaHang";
            this.btnCuaHang.Size = new System.Drawing.Size(197, 43);
            this.btnCuaHang.TabIndex = 2;
            this.btnCuaHang.Text = "Phiếu Mượn";
            this.btnCuaHang.UseVisualStyleBackColor = true;
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(3, 90);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(197, 43);
            this.btnNCC.TabIndex = 0;
            this.btnNCC.Text = "Sách";
            this.btnNCC.UseVisualStyleBackColor = true;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(3, 41);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(197, 43);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "Độc Giả";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 633);
            this.panel1.TabIndex = 5;
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNoiDung.Location = new System.Drawing.Point(209, 0);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(938, 633);
            this.pnlNoiDung.TabIndex = 6;
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNoiDung);
            this.Name = "frmChinh";
            this.Text = "frmChinh";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPhieuXuat;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Button btnCuaHang;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNoiDung;
    }
}