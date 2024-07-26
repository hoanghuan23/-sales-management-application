namespace quản_lý_bán_hàng
{
    partial class frmdhanghoa
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
            this.txtanh = new System.Windows.Forms.TextBox();
            this.txtmahang = new System.Windows.Forms.TextBox();
            this.txttenhang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdongiaban = new System.Windows.Forms.TextBox();
            this.la = new System.Windows.Forms.Label();
            this.btnmo = new System.Windows.Forms.Button();
            this.picanh = new System.Windows.Forms.PictureBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtdongianhap = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.cbochatlieu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgvhanghoa = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picanh)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhanghoa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtanh
            // 
            this.txtanh.Location = new System.Drawing.Point(395, 38);
            this.txtanh.Multiline = true;
            this.txtanh.Name = "txtanh";
            this.txtanh.Size = new System.Drawing.Size(211, 99);
            this.txtanh.TabIndex = 23;
            // 
            // txtmahang
            // 
            this.txtmahang.Location = new System.Drawing.Point(166, 38);
            this.txtmahang.Name = "txtmahang";
            this.txtmahang.Size = new System.Drawing.Size(146, 22);
            this.txtmahang.TabIndex = 22;
            // 
            // txttenhang
            // 
            this.txttenhang.Location = new System.Drawing.Point(166, 66);
            this.txttenhang.Name = "txttenhang";
            this.txttenhang.Size = new System.Drawing.Size(146, 22);
            this.txttenhang.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ảnh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(381, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Danh mục hàng hóa";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtdongiaban);
            this.panel1.Controls.Add(this.la);
            this.panel1.Controls.Add(this.btnmo);
            this.panel1.Controls.Add(this.picanh);
            this.panel1.Controls.Add(this.txtghichu);
            this.panel1.Controls.Add(this.txtdongianhap);
            this.panel1.Controls.Add(this.txtsoluong);
            this.panel1.Controls.Add(this.cbochatlieu);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtanh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txttenhang);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtmahang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 241);
            this.panel1.TabIndex = 25;
            // 
            // txtdongiaban
            // 
            this.txtdongiaban.Location = new System.Drawing.Point(166, 182);
            this.txtdongiaban.Name = "txtdongiaban";
            this.txtdongiaban.Size = new System.Drawing.Size(146, 22);
            this.txtdongiaban.TabIndex = 37;
            // 
            // la
            // 
            this.la.AutoSize = true;
            this.la.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la.Location = new System.Drawing.Point(35, 182);
            this.la.Name = "la";
            this.la.Size = new System.Drawing.Size(87, 18);
            this.la.TabIndex = 36;
            this.la.Text = "Đơn giá bán";
            // 
            // btnmo
            // 
            this.btnmo.Location = new System.Drawing.Point(475, 143);
            this.btnmo.Name = "btnmo";
            this.btnmo.Size = new System.Drawing.Size(66, 23);
            this.btnmo.TabIndex = 35;
            this.btnmo.Text = "Mở";
            this.btnmo.UseVisualStyleBackColor = true;
            this.btnmo.Click += new System.EventHandler(this.btnmo_Click);
            // 
            // picanh
            // 
            this.picanh.Location = new System.Drawing.Point(612, 12);
            this.picanh.Name = "picanh";
            this.picanh.Size = new System.Drawing.Size(346, 223);
            this.picanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picanh.TabIndex = 34;
            this.picanh.TabStop = false;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(395, 169);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(211, 32);
            this.txtghichu.TabIndex = 33;
            // 
            // txtdongianhap
            // 
            this.txtdongianhap.Location = new System.Drawing.Point(166, 152);
            this.txtdongianhap.Name = "txtdongianhap";
            this.txtdongianhap.Size = new System.Drawing.Size(146, 22);
            this.txtdongianhap.TabIndex = 30;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(166, 124);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(146, 22);
            this.txtsoluong.TabIndex = 29;
            // 
            // cbochatlieu
            // 
            this.cbochatlieu.FormattingEnabled = true;
            this.cbochatlieu.Items.AddRange(new object[] {
            "vải cotton",
            "vải kaki",
            "vải jean",
            "vải nỉ",
            "vải len"});
            this.cbochatlieu.Location = new System.Drawing.Point(166, 94);
            this.cbochatlieu.Name = "cbochatlieu";
            this.cbochatlieu.Size = new System.Drawing.Size(146, 24);
            this.cbochatlieu.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Chất liệu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Đơn giá nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnhienthi);
            this.panel2.Controls.Add(this.btnluu);
            this.panel2.Controls.Add(this.btndong);
            this.panel2.Controls.Add(this.btntimkiem);
            this.panel2.Controls.Add(this.btnxoa);
            this.panel2.Controls.Add(this.btnsua);
            this.panel2.Controls.Add(this.btnthem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 60);
            this.panel2.TabIndex = 26;
            // 
            // btnhienthi
            // 
            this.btnhienthi.Location = new System.Drawing.Point(736, 16);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(96, 32);
            this.btnhienthi.TabIndex = 19;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.UseVisualStyleBackColor = true;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(475, 16);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(96, 32);
            this.btnluu.TabIndex = 18;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(853, 16);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(96, 32);
            this.btndong.TabIndex = 17;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(612, 16);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(96, 32);
            this.btntimkiem.TabIndex = 15;
            this.btntimkiem.Text = "tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(319, 16);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(96, 32);
            this.btnxoa.TabIndex = 14;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(166, 16);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(96, 32);
            this.btnsua.TabIndex = 13;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(26, 16);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(96, 32);
            this.btnthem.TabIndex = 12;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgvhanghoa
            // 
            this.dgvhanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhanghoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvhanghoa.Location = new System.Drawing.Point(0, 241);
            this.dgvhanghoa.Name = "dgvhanghoa";
            this.dgvhanghoa.RowHeadersWidth = 51;
            this.dgvhanghoa.RowTemplate.Height = 24;
            this.dgvhanghoa.Size = new System.Drawing.Size(961, 228);
            this.dgvhanghoa.TabIndex = 27;
            this.dgvhanghoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhanghoa_CellClick);
            // 
            // frmdhanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 529);
            this.Controls.Add(this.dgvhanghoa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmdhanghoa";
            this.Text = "Danh mục khách hàng";
            this.Load += new System.EventHandler(this.frmdhanghoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picanh)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhanghoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtanh;
        private System.Windows.Forms.TextBox txtmahang;
        private System.Windows.Forms.TextBox txttenhang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvhanghoa;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.ComboBox cbochatlieu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtdongianhap;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Button btnmo;
        private System.Windows.Forms.PictureBox picanh;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.TextBox txtdongiaban;
        private System.Windows.Forms.Label la;
        private System.Windows.Forms.Button btnhienthi;
    }
}