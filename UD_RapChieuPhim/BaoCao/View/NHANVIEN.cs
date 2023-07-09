using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoCao.Control;
using BaoCao.Model;
using System.Data.SqlClient;

namespace BaoCao.View
{
    public partial class NHANVIEN : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Rapphim ctr_nv = new Control_Rapphim();
        ConnectSQL con = new ConnectSQL();
        DataSet ds;
        SqlDataReader reader;
        string table = "Nhanvien";

        public NHANVIEN()
        {
            InitializeComponent();
        }
        // Load combobox MaPBV
        void load_combobox_MAPBV()
        {
            DataTable dt = ctr_nv.select("PHONGBANVE");
            cbMaPBV.DataSource = dt;
            cbMaPBV.DisplayMember = "MaPBV";
            cbMaPBV.ValueMember = "MaPBV";
        }
        // Load nhân viên theo MaPBV
        void load_Nhanvien_MaPBV()
        {
            DataTable dt = ctr_nv.TruyVanTheoBang("NHANVIEN", "PHONGBANVE", "MaPBV", cbMaPBV.SelectedValue.ToString());
            dgDanhsach.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            for (int i = 7; i < dgDanhsach.Columns.Count; i++)
                dgDanhsach.Columns[i].Visible = false;
        }
        void loadDTG()
        {
            DataTable dtSV = ctr_nv.select(table);
            dgDanhsach.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        private void tRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRANGCHU tc = new TRANGCHU();
            tc.Show();
            this.Hide();
        }

        // load form
        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadDTG();
            load_combobox_MAPBV();
        }
        private void dgDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDanhsach.CurrentRow != null)
            {
                txtManv.Text = dgDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtHoten.Text = dgDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtNgaysinh.Text = dgDanhsach.CurrentRow.Cells[2].Value.ToString();
                txtGioitinh.Text = dgDanhsach.CurrentRow.Cells[3].Value.ToString();
                txtLuong.Text = dgDanhsach.CurrentRow.Cells[4].Value.ToString();
                txtDiachi.Text = dgDanhsach.CurrentRow.Cells[5].Value.ToString();
                cbMaPBV.Text = dgDanhsach.CurrentRow.Cells[6].Value.ToString();
            }
        }
        // Button Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Nhanvien newnv = new Nhanvien();
                newnv.MaNV = txtManv.Text;
                newnv.HotenNV = txtHoten.Text;
                newnv.Ngaysinh = DateTime.Parse(txtNgaysinh.Text);
                newnv.Phai = txtGioitinh.Text;
                newnv.Luong = int.Parse(txtLuong.Text);
                newnv.Diachi = txtDiachi.Text;
                newnv.MaPBV = cbMaPBV.SelectedValue.ToString();
                if (!ctr_nv.Themnhanvien(newnv, table))
                {
                    MessageBox.Show("Trùng mã !", "Thông báo");
                }
                else
                    MessageBox.Show("Thêm thành công !", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Thông báo");
            }
        }
        // Button Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    ctr_nv.Delete("Nhanvien", txtManv.Text);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại.", "Thông báo");
            }

        }

        // button Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Nhanvien newnv = new Nhanvien();
                newnv.HotenNV = txtHoten.Text;
                newnv.Ngaysinh = DateTime.Parse(txtNgaysinh.Text);
                newnv.Phai = txtGioitinh.Text;
                newnv.Luong = int.Parse(txtLuong.Text);
                newnv.Diachi = txtDiachi.Text;
                newnv.MaPBV = cbMaPBV.SelectedValue.ToString();
                ctr_nv.SuaNV("NHANVIEN", txtManv.Text, newnv);
                MessageBox.Show("Sửa thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại.", "Thông báo");
            }
        }

        private void cbMaPBV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            load_Nhanvien_MaPBV();
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "HOTENNV", "*" + txtTimkiem.Text + "*");
            (dgDanhsach.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
        private void btnTimkiem_Click_1(object sender, EventArgs e)
        {
            load_Nhanvien_MaPBV();
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            loadDTG();
        }
    }
}
