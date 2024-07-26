using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using quản_lý_bán_hàng.Class;

namespace quản_lý_bán_hàng
{
    public partial class frmdhanghoa : Form
    {
        DataTable tblh; // bang hang
        public frmdhanghoa()
        {
            InitializeComponent();
        }

        private void frmdhanghoa_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblchatlieu";
            txtmahang.Enabled = false;
            btnluu.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cbochatlieu, "Machatlieu", "Tenchatlieu");
            cbochatlieu.SelectedIndex = -1;
            ResetValues();
        }

        // phuong thuc nap du lieu
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblhang";
            tblh = Functions.GetDataToTable(sql);
            dgvhanghoa.DataSource = tblh;
            dgvhanghoa.Columns[0].HeaderText = "Mã hàng";
            dgvhanghoa.Columns[1].HeaderText = "Tên hàng";
            dgvhanghoa.Columns[2].HeaderText = "Chất liệu";
            dgvhanghoa.Columns[3].HeaderText = "Số lượng";
            dgvhanghoa.Columns[4].HeaderText = "Đơn giá nhập";
            dgvhanghoa.Columns[5].HeaderText = "Đơn giá bán";
            dgvhanghoa.Columns[6].HeaderText = "Ảnh";
            dgvhanghoa.Columns[7].HeaderText = "Ghi chú";
            dgvhanghoa.Columns[0].Width = 80;
            dgvhanghoa.Columns[1].Width = 140;
            dgvhanghoa.Columns[2].Width = 80;
            dgvhanghoa.Columns[3].Width = 80;
            dgvhanghoa.Columns[4].Width = 80;
            dgvhanghoa.Columns[5].Width = 80;
            dgvhanghoa.Columns[6].Width = 300;
            dgvhanghoa.Columns[7].Width = 100;
            dgvhanghoa.AllowUserToAddRows = false;
            dgvhanghoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtmahang.Text = "";
            txttenhang.Text = "";
            cbochatlieu.Text = "";
            txtsoluong.Text = "0";
            txtdongianhap.Text = "0";
            txtdongiaban.Text = "0";
            txtsoluong.Enabled = true;
            txtdongianhap.Enabled = false;
            txtdongiaban.Enabled = false;
            txtanh.Text = "";
            picanh.Image = null;
            txtghichu.Text = "";
        }

        private void dgvhanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaChatLieu;
            string sql;
            if(btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (tblh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahang.Text = dgvhanghoa.CurrentRow.Cells["Mahang"].Value.ToString();
            txttenhang.Text = dgvhanghoa.CurrentRow.Cells["Tenhang"].Value.ToString();
            MaChatLieu = dgvhanghoa.CurrentRow.Cells["Machatlieu"].Value.ToString();
            sql = "SELECT Tenchatlieu FROM tblchatlieu WHERE Machatlieu=N'" + MaChatLieu + "'";
            cbochatlieu.Text = Functions.GetFieldValues(sql);
            txtsoluong.Text = dgvhanghoa.CurrentRow.Cells["Soluong"].Value.ToString();
            txtdongianhap.Text = dgvhanghoa.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtdongiaban.Text = dgvhanghoa.CurrentRow.Cells["Dongiaban"].Value.ToString();
            sql = "SELECT Anh FROM tblhang WHERE MaHang=N'" + txtmahang.Text + "'";
            txtanh.Text = Functions.GetFieldValues(sql);
            picanh.Image = Image.FromFile(txtanh.Text);
            sql = "SELECT Ghichu FROM tblhang WHERE Mahang = N'" + txtmahang.Text + "'";
            txtghichu.Text = Functions.GetFieldValues(sql);
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmahang.Enabled = true;
            txtmahang.Focus();
            txtsoluong.Enabled = true;
            txtdongianhap.Enabled = true;
            txtdongiaban.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;
            }
            if (cbochatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbochatlieu.Focus();
                return;
            }
            if (txtanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnmo.Focus();
                return;
            }
            sql = "SELECT Mahang FROM tblHang WHERE Mahang=N'" + txtmahang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            sql = "INSERT INTO tblhang(Mahang,Tenhang,Machatlieu,Soluong,Dongianhap, Dongiaban,Anh,Ghichu) VALUES(N'"
                + txtmahang.Text.Trim() + "',N'" + txttenhang.Text.Trim() +
                "',N'" + cbochatlieu.SelectedValue.ToString() +
                "'," + txtsoluong.Text.Trim() + "," + txtdongianhap.Text +
                "," + txtdongiaban.Text + ",'" + txtanh.Text + "',N'" + txtghichu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmahang.Enabled = false;
        }

        private void btnmo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picanh.Image = Image.FromFile(dlgOpen.FileName);
                picanh.SizeMode = PictureBoxSizeMode.Zoom;
                txtanh.Text = dlgOpen.FileName;
                
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;
            }
            if (cbochatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbochatlieu.Focus();
                return;
            }
            if (txtanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtanh.Focus();
                return;
            }
            sql = "UPDATE tblhang SET Tenhang=N'" + txttenhang.Text.Trim().ToString() +
                "',Machatlieu=N'" + cbochatlieu.SelectedValue.ToString() +
                "',Soluong=" + txtsoluong.Text +
                ",Anh='" + txtanh.Text + "',Ghichu=N'" + txtghichu.Text + "' WHERE Mahang=N'" + txtmahang.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblhang WHERE Mahang=N'" + txtmahang.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmahang.Text == "") && (txttenhang.Text == "") && (cbochatlieu.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblhang WHERE 1=1";
            if (txtmahang.Text != "")
                sql += " AND Mahang LIKE N'%" + txtmahang.Text + "%'";
            if (txttenhang.Text != "")
                sql += " AND Tenhang LIKE N'%" + txttenhang.Text + "%'";
            if (cbochatlieu.Text != "")
                sql += " AND Machatlieu LIKE N'%" + cbochatlieu.SelectedValue + "%'";
            tblh = Functions.GetDataToTable(sql);
            if (tblh.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblh.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvhanghoa.DataSource = tblh;
            ResetValues();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang,Tenhang,Machatlieu,Soluong,Dongianhap,Dongiaban,Anh,Ghichu FROM tblhang";
            tblh = Functions.GetDataToTable(sql);
            dgvhanghoa.DataSource = tblh;
        }

       
    }
}
