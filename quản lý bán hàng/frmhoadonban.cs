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
using COMExcel = Microsoft.Office.Interop.Excel; 

namespace quản_lý_bán_hàng
{
    public partial class frmhoadonban : Form
    {
        DataTable tblcthdb;
        public frmhoadonban()
        {
            InitializeComponent();
        }

        private void frmhoadonban_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btninhoadon.Enabled = false;
            txtmahoadonban.ReadOnly = true;
            txttennv.ReadOnly = true;
            txttenkhach.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            mtbdienthoai.ReadOnly = true;
            txttenhang.ReadOnly = true;
            txtdongiaban.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtgiamgia.Text = "0";
            txttongtien.Text = "0";
            Functions.FillCombo("SELECT Makhach, Tenkhach FROM tblkhach", cbomakhach, "Makhach", "Makhach");
            cbomakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manhanvien, Tennhanvien FROM tblnhanvien", cbomanhanvien, "Manhanvien", "Tenkhach");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mahang, Tenhang FROM tblhang", cbomahang, "Mahang", "Mahang");
            cbomahang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtmahoadonban.Text != "")
            {
                LoadInfoHoaDon();
                btninhoadon.Enabled = true;
            }
            LoadDataGridView();
        }

        // nap du lieu
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Mahang, b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia,a.Thanhtien FROM tblcthoadon AS a, tblhang AS b WHERE a.Mahdban = N'" + txtmahoadonban.Text + "' AND a.Mahang=b.Mahang";
            tblcthdb = Functions.GetDataToTable(sql);
            dgvhdbanhang.DataSource = tblcthdb;
            dgvhdbanhang.Columns[0].HeaderText = "Mã hàng";
            dgvhdbanhang.Columns[1].HeaderText = "Tên hàng";
            dgvhdbanhang.Columns[2].HeaderText = "Số lượng";
            dgvhdbanhang.Columns[3].HeaderText = "Đơn giá";
            dgvhdbanhang.Columns[4].HeaderText = "Giảm giá %";
            dgvhdbanhang.Columns[5].HeaderText = "Thành tiền";
            dgvhdbanhang.Columns[0].Width = 80;
            dgvhdbanhang.Columns[1].Width = 130;
            dgvhdbanhang.Columns[2].Width = 80;
            dgvhdbanhang.Columns[3].Width = 90;
            dgvhdbanhang.Columns[4].Width = 90;
            dgvhdbanhang.Columns[5].Width = 90;
            dgvhdbanhang.AllowUserToAddRows = false;
            dgvhdbanhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        // nap chi tiet hoa don
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT Ngayban FROM tblhoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
            dtpngayban.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT Manhanvien FROM tblhoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
            cbomanhanvien.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT Makhach FROM tblhoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
            cbomakhach.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM tblhoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text));
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btninhoadon.Enabled = false;
            btnthem.Enabled = false;
            ResetValues();
            txtmahoadonban.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtmahoadonban.Text = "";
            dtpngayban.Value = DateTime.Now;
            cbomanhanvien.Text = "";
            cbomakhach.Text = "";
            txttongtien.Text = "0";
            lblbangchu.Text = "Bằng chữ: ";
            cbomahang.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
            txttennv.Text = "";
            txttenkhach.Text = "";
            txtdiachi.Text = "";
            mtbdienthoai.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT Mahdban FROM tblhoadon WHERE Mahdban=N'" + txtmahoadonban.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
           
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cbomakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbomakhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblhoadon(MahdBan, Ngayban, Manhanvien, Makhach, Tongtien) VALUES (N'" + txtmahoadonban.Text.Trim() + "','" +
                        dtpngayban.Value + "',N'" + cbomanhanvien.SelectedValue + "',N'" +
                        cbomakhach.SelectedValue + "'," + txttongtien.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cbomahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomahang.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtgiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgiamgia.Focus();
                return;
            }
            sql = "SELECT Mahang FROM tblcthoadon WHERE Mahang=N'" + cbomahang.SelectedValue + "' AND Mahdban = N'" + txtmahoadonban.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbomahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblhang WHERE Mahang = N'" + cbomahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblcthoadon(Mahdban,Mahang,Soluong,Dongia, Giamgia,Thanhtien) VALUES(N'" + txtmahoadonban.Text.Trim() + "',N'" + cbomahang.SelectedValue + "'," + txtsoluong.Text + "," + txtdongiaban.Text + "," + txtgiamgia.Text + "," + txtthanhtien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtsoluong.Text);
            sql = "UPDATE tblhang SET Soluong =" + SLcon + " WHERE Mahang= N'" + cbomahang.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblhoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE tblhoadon SET Tongtien =" + Tongmoi + " WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
            Functions.RunSQL(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));
            ResetValuesHang();
            btnthem.Enabled = true;
            btninhoadon.Enabled = true;
        }
        // bo sung reset phan mat hang
        private void ResetValuesHang()
        {
            cbomahang.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void cbomahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomahang.Text == "")
            {
                txttenhang.Text = "";
                txtdongiaban.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT Tenhang FROM tblhang WHERE Mahang =N'" + cbomahang.SelectedValue + "'";
            txttenhang.Text = Functions.GetFieldValues(str);
            str = "SELECT Dongiaban FROM tblhang WHERE Mahang =N'" + cbomahang.SelectedValue + "'";
            txtdongiaban.Text = Functions.GetFieldValues(str);
        }

        private void cbomakhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomakhach.Text == "")
            {
                txttenkhach.Text = "";
                txtdiachi.Text = "";
                mtbdienthoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Tenkhach from tblkhach where Makhach = N'" + cbomakhach.SelectedValue + "'";
            txttenkhach.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from tblkhach where Makhach = N'" + cbomakhach.SelectedValue + "'";
            txtdiachi.Text = Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblkhach where Makhach= N'" + cbomakhach.SelectedValue + "'";
            mtbdienthoai.Text = Functions.GetFieldValues(str);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void cbomanhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

            string str;
            if (cbomanhanvien.Text == "")
                txttennv.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Tennhanvien from tblnhanvien where Manhanvien =N'" + cbomanhanvien.SelectedValue + "'";
            txttennv.Text = Functions.GetFieldValues(str);
        }

        private void cbomahdban_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Mahdban FROM tblhoadon", cbomahdban, "Mahdban", "Mahdban");
            cbomahdban.SelectedIndex = -1;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomahdban.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomahdban.Focus();
                return;
            }
            txtmahoadonban.Text = cbomahdban.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnluu.Enabled = true;
            btninhoadon.Enabled = true;
            cbomahdban.SelectedIndex = -1;
        }

        private void btninhoadon_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop B.A.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.Mahdban, a.Ngayban, a.Tongtien, b.Tenkhach, b.Diachi, b.Dienthoai, c.Tennhanvien FROM tblhoadon AS a, tblKhach AS b, tblnhanvien AS c WHERE a.Mahdban = N'" + txtmahoadonban.Text + "' AND a.Makhach = b.Makhach AND a.Manhanvien = c.Manhanvien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia, a.Thanhtien " +
                  "FROM tblcthoadon AS a , tblhang AS b WHERE a.Mahdban = N'" +
                  txtmahoadonban.Text + "' AND a.Mahang = b.Mahang";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT Mahang,Soluong FROM tblcthoadon WHERE Mahdban = N'" + txtmahoadonban.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblhang WHERE Mahang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblhang SET Soluong =" + slcon + " WHERE Mahang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblcthoadon WHERE Mahdban=N'" + txtmahoadonban.Text + "'";
                Functions.RunSQL(sql);

                //Xóa hóa đơn
                sql = "DELETE tblhoadon WHERE Mahdban=N'" + txtmahoadonban.Text + "'";
                Functions.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btninhoadon.Enabled = false;
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
