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
    public partial class frmdanhmucchatlieu : Form
    {
        DataTable tblcl;
        public frmdanhmucchatlieu()
        {
            InitializeComponent();
        }

        private void frmdanhmucchatlieu_Load(object sender, EventArgs e)
        {
            txtmachatlieu.Enabled = false;
            btnluu.Enabled = false;
            loaddataGridView();
            
        }
        private void loaddataGridView()
        {
            string sql;
            sql = "SELECT Machatlieu, Tenchatlieu FROM tblchatlieu";
            tblcl = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvchatlieu.DataSource = tblcl; //Nguồn dữ liệu            
            dgvchatlieu.Columns[0].HeaderText = "Mã chất liệu";
            dgvchatlieu.Columns[1].HeaderText = "Tên chất liệu";
            dgvchatlieu.Columns[0].Width = 270;
            dgvchatlieu.Columns[1].Width = 270;
            dgvchatlieu.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvchatlieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void dgvchatlieu_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmachatlieu.Focus();
                return;
            }
            if (tblcl.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmachatlieu.Text = dgvchatlieu.CurrentRow.Cells["MachatLieu"].Value.ToString();
            txttenchatlieu.Text = dgvchatlieu.CurrentRow.Cells["TenchatLieu"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtmachatlieu.Enabled = true; //cho phép nhập mới
            txtmachatlieu.Focus();
        }

        private void ResetValue()
        {
            txtmachatlieu.Text = "";
            txttenchatlieu.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmachatlieu.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmachatlieu.Focus();
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenchatlieu.Focus();
                return;
            }
            sql = "Select Machatlieu From tblchatlieu where Machatlieu=N'" + txtmachatlieu.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachatlieu.Focus();
                return;
            }

            sql = "INSERT INTO tblchatlieu VALUES(N'" +
                txtmachatlieu.Text + "',N'" + txttenchatlieu.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            loaddataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmachatlieu.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblcl.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmachatlieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblchatlieu SET Tenchatlieu=N'" +
                txttenchatlieu.Text.ToString() +
                "' WHERE Machatlieu=N'" + txtmachatlieu.Text + "'";
            Functions.RunSQL(sql);
            loaddataGridView();
            ResetValue();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
