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
    public partial class frmdmnhanvien : Form
    {
        private DataTable tblnv;
        public frmdmnhanvien()
        {
            InitializeComponent();
        }

        private void frmdmnhanvien_Load(object sender, EventArgs e)
        {
            loaddataGridView();
            txtmanv.Enabled = false;
            btnluu.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void loaddataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblnhanvien";
            tblnv = Functions.GetDataToTable(sql); //lấy dữ liệu
            dgvnhanvien.DataSource = tblnv;
            dgvnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgvnhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgvnhanvien.Columns[2].HeaderText = "Giới tính";
            dgvnhanvien.Columns[3].HeaderText = "Địa chỉ";
            dgvnhanvien.Columns[4].HeaderText = "Điện thoại";
            dgvnhanvien.Columns[5].HeaderText = "Ngày sinh";
            dgvnhanvien.Columns[0].Width = 100;
            dgvnhanvien.Columns[1].Width = 150;
            dgvnhanvien.Columns[2].Width = 100;
            dgvnhanvien.Columns[3].Width = 150;
            dgvnhanvien.Columns[4].Width = 100;
            dgvnhanvien.Columns[5].Width = 100;
            dgvnhanvien.AllowUserToAddRows = false;
            dgvnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvnhanvien_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return;
            }
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanv.Text = dgvnhanvien.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txttennv.Text = dgvnhanvien.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            if (dgvnhanvien.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam")
                rdnam.Checked = true;
            else rdnu.Checked = true;
            txtdiachi.Text = dgvnhanvien.CurrentRow.Cells["Diachi"].Value.ToString();
            mtbdienthoai.Text = dgvnhanvien.CurrentRow.Cells["Dienthoai"].Value.ToString();
            dtpngaysinh.Value = (DateTime)dgvnhanvien.CurrentRow.Cells["Ngaysinh"].Value;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValue();
            txtmanv.Enabled = true;
            txtmanv.Focus();
        }

        private void ResetValue()
        {
            txtmanv.Text = "";
            txtmanv.Text = "";
            rdnam.Checked = false;
            rdnu.Checked = false;
            txtdiachi.Text = "";
            mtbdienthoai.Text = "";
            dtpngaysinh.Value = DateTime.Now;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmanv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanv.Focus();
                return;
            }
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mtbdienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbdienthoai.Focus();
                return;
            }

            if (rdnam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            sql = "SELECT MaNhanVien FROM tblnhanvien WHERE Manhanvien=N'" + txtmanv.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanv.Focus();
                txtmanv.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhanvien(Manhanvien,Tennhanvien,Gioitinh, Diachi,Dienthoai, Ngaysinh) VALUES (N'" + txtmanv.Text.Trim() + "',N'" + txttennv.Text.Trim() + "',N'" + gt + "',N'" + txtdiachi.Text.Trim() + "','" + mtbdienthoai.Text + "', '" + dtpngaysinh.Value + "')";
            Functions.RunSQL(sql);
            loaddataGridView();
            ResetValue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmanv.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mtbdienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbdienthoai.Focus();
                return;
            }

            if (rdnam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblnhanvien SET  Tennhanvien=N'" + txttennv.Text.Trim().ToString() +
                    "',Diachi=N'" + txtdiachi.Text.Trim().ToString() +
                    "',Dienthoai='" + mtbdienthoai.Text.ToString() + "',Gioitinh=N'" + gt +
                    "',Ngaysinh='" + dtpngaysinh.Value +
                    "' WHERE Manhanvien=N'" + txtmanv.Text + "'";
            Functions.RunSQL(sql);
            loaddataGridView();
            ResetValue();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhanvien WHERE Manhanvien=N'" + txtmanv.Text + "'";
                Functions.RunSQL(sql);
                loaddataGridView();
                ResetValue();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
