namespace quản_lý_bán_hàng
{
    partial class frmdkhachhang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndong = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgvhanghoa = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.mtbdienthoai = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttenkhach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmakhach = new System.Windows.Forms.TextBox();
            this.dgvkhachhang = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.dgvhanghoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btndong);
            this.panel1.Controls.Add(this.btnluu);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 1;
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(701, 19);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(96, 32);
            this.btndong.TabIndex = 11;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(549, 19);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(96, 32);
            this.btnluu.TabIndex = 9;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(381, 19);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(96, 32);
            this.btnxoa.TabIndex = 8;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(216, 19);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(96, 32);
            this.btnsua.TabIndex = 7;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(73, 19);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(96, 32);
            this.btnthem.TabIndex = 6;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgvhanghoa
            // 
            this.dgvhanghoa.Controls.Add(this.label2);
            this.dgvhanghoa.Controls.Add(this.txtdiachi);
            this.dgvhanghoa.Controls.Add(this.mtbdienthoai);
            this.dgvhanghoa.Controls.Add(this.label1);
            this.dgvhanghoa.Controls.Add(this.label3);
            this.dgvhanghoa.Controls.Add(this.label6);
            this.dgvhanghoa.Controls.Add(this.txttenkhach);
            this.dgvhanghoa.Controls.Add(this.label5);
            this.dgvhanghoa.Controls.Add(this.txtmakhach);
            this.dgvhanghoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvhanghoa.Location = new System.Drawing.Point(0, 0);
            this.dgvhanghoa.Name = "dgvhanghoa";
            this.dgvhanghoa.Size = new System.Drawing.Size(800, 122);
            this.dgvhanghoa.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã khách hàng";
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(549, 41);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(146, 22);
            this.txtdiachi.TabIndex = 23;
            // 
            // mtbdienthoai
            // 
            this.mtbdienthoai.Location = new System.Drawing.Point(549, 87);
            this.mtbdienthoai.Mask = "(999) 000-0000";
            this.mtbdienthoai.Name = "mtbdienthoai";
            this.mtbdienthoai.Size = new System.Drawing.Size(146, 22);
            this.mtbdienthoai.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(298, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Danh mục khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Điện thoại";
            // 
            // txttenkhach
            // 
            this.txttenkhach.Location = new System.Drawing.Point(166, 84);
            this.txttenkhach.Name = "txttenkhach";
            this.txttenkhach.Size = new System.Drawing.Size(146, 22);
            this.txttenkhach.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Địa chỉ";
            // 
            // txtmakhach
            // 
            this.txtmakhach.Location = new System.Drawing.Point(166, 38);
            this.txtmakhach.Name = "txtmakhach";
            this.txtmakhach.Size = new System.Drawing.Size(146, 22);
            this.txtmakhach.TabIndex = 22;
            // 
            // dgvkhachhang
            // 
            this.dgvkhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhachhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvkhachhang.Location = new System.Drawing.Point(0, 122);
            this.dgvkhachhang.Name = "dgvkhachhang";
            this.dgvkhachhang.RowHeadersWidth = 51;
            this.dgvkhachhang.RowTemplate.Height = 24;
            this.dgvkhachhang.Size = new System.Drawing.Size(800, 257);
            this.dgvkhachhang.TabIndex = 27;
            this.dgvkhachhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhachhang_CellClick);
            // 
            // frmdkhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvkhachhang);
            this.Controls.Add(this.dgvhanghoa);
            this.Controls.Add(this.panel1);
            this.Name = "frmdkhachhang";
            this.Text = "form khách hàng";
            this.Load += new System.EventHandler(this.frmdkhachhang_Load);
            this.panel1.ResumeLayout(false);
            this.dgvhanghoa.ResumeLayout(false);
            this.dgvhanghoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhachhang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Panel dgvhanghoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.MaskedTextBox mtbdienthoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttenkhach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmakhach;
        private System.Windows.Forms.DataGridView dgvkhachhang;
    }
}