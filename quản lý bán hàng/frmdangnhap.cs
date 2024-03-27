using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quản_lý_bán_hàng
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            // khai báo biến
            string tendangnhap = "", matkhau = "";

            // lấy thông tin người dùng từ textbox và gán cho các biến
            tendangnhap = textBox1.Text;
            matkhau = textBox2.Text;

            // kiem tra thong tin nguoi dung nhap vao
            if (tendangnhap.Length == 0)
            {
                MessageBox.Show("bạn cần nhập tên đăng nhập");

                // di chuyển con chuột vào textbox người dùng cần nhập thông tin
                textBox1.Focus();
                // thoát khỏi xử lý đăng nhập
                return;
            }
            if (matkhau.Length == 0)
            {
                MessageBox.Show("bạn cần nhập mật khẩu");
            }
            if (tendangnhap.Equals("hoanghuan") && matkhau.Equals("23092003"))
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("bạn đăng nhập không thành công");
            }
        }
    }
}
