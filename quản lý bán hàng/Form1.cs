using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quản_lý_bán_hàng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   

        private void mnunhanvien_Click(object sender, EventArgs e)
        {
            frmdmnhanvien frm = new frmdmnhanvien();
            frm.ShowDialog();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            frmdkhachhang frm = new frmdkhachhang();
            frm.ShowDialog();
        }

        private void mnuhanghoa_Click(object sender, EventArgs e)
        {
            frmdhanghoa frm = new frmdhanghoa();
            frm.ShowDialog();
        }

        private void mnuhoadonban_Click(object sender, EventArgs e)
        {
            frmhoadonban frm = new frmhoadonban();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }
         
        private void mnuthoat_Click(object sender, EventArgs e)
        {
                Class.Functions.Disconnect(); //Đóng kết nối
                Application.Exit(); //Thoát
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbanhang fr = new frmbanhang();
            fr.ShowDialog();
        }


        private void mnuchatlieu_Click(object sender, EventArgs e)
        {
            frmdanhmucchatlieu fr = new frmdanhmucchatlieu();
            fr.ShowDialog();
        }
    }
}
