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
    public partial class frmdkhachhang : Form
    {
        DataTable tblkh;
        public frmdkhachhang()
        {
            InitializeComponent();
        }

        private void frmdkhachhang_Load(object sender, EventArgs e)
        {
            txtmakhach.Enabled = false;
            btnluu.Enabled = false;
            LoadDataGridView();
        }
        // load du lieu tu bang sql
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblkhach";
            tblkh = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvkhachhang.DataSource = tblkh; //Hiển thị vào dataGridView
            dgvkhachhang.Columns[0].HeaderText = "Mã khách";
            dgvkhachhang.Columns[1].HeaderText = "Tên khách";
            dgvkhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgvkhachhang.Columns[3].HeaderText = "Điện thoại";
            dgvkhachhang.Columns[0].Width = 100;
            dgvkhachhang.Columns[1].Width = 150;
            dgvkhachhang.Columns[2].Width = 150;
            dgvkhachhang.Columns[3].Width = 150;
            dgvkhachhang.AllowUserToAddRows = false;
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmakhach.Enabled = true;
            txtmakhach.Focus();
        }

        private void ResetValues()
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtdiachi.Text = "";
            mtbdienthoai.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
            if (txttenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhach.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (mtbdienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbdienthoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT Makhach FROM tblkhach WHERE Makhach=N'" + txtmakhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblkhach VALUES (N'" + txtmakhach.Text.Trim() +
                "',N'" + txttenkhach.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + mtbdienthoai.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmakhach.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhach.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (mtbdienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbdienthoai.Focus();
                return;
            }
            sql = "UPDATE tblkhach SET Tenkhach=N'" + txttenkhach.Text.Trim().ToString() + "',Diachi=N'" +
                txtdiachi.Text.Trim().ToString() + "',Dienthoai='" + mtbdienthoai.Text.ToString() +
                "' WHERE Makhach=N'" + txtmakhach.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakhach.Text = dgvkhachhang.CurrentRow.Cells["Makhach"].Value.ToString();
            txttenkhach.Text = dgvkhachhang.CurrentRow.Cells["Tenkhach"].Value.ToString();
            txtdiachi.Text = dgvkhachhang.CurrentRow.Cells["Diachi"].Value.ToString();
            mtbdienthoai.Text = dgvkhachhang.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhach WHERE MaKhach=N'" + txtmakhach.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
