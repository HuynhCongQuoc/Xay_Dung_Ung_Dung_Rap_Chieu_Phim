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

namespace BaoCao.View
{
    public partial class CONGVIEC : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Rapphim ctr_cv = new Control_Rapphim();
        Control_Rapphim ctr_Manv = new Control_Rapphim();
        Control_Rapphim ctr_Mapb = new Control_Rapphim();
        ConnectSQL con = new ConnectSQL();
        DataSet ds;
        string table = "CONGVIEC";
        public CONGVIEC()
        {
            InitializeComponent();
        }
        void load_combobox_MaNV()
        {
            DataTable dt = ctr_Manv.select("Nhanvien");
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";
        }
        void load_combobox_MaPB()
        {
            DataTable dt = ctr_Mapb.select("Phongban");
            cbMaPB.DataSource = dt;
            cbMaPB.DisplayMember = "MaPB";
            cbMaPB.ValueMember = "MaPB";
        }
        // Load danh sách
        void loadDTG()
        {
            DataTable dtSV = ctr_cv.select(table);
            dgDanhsach.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        private void CONGVIEC_Load(object sender, EventArgs e)
        {
            loadDTG();
            load_combobox_MaNV();
            load_combobox_MaPB();
        }

        private void dgDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDanhsach.CurrentRow != null)
            {
                txtMacv.Text = dgDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTencv.Text = dgDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtDiadiemCV.Text = dgDanhsach.CurrentRow.Cells[2].Value.ToString();
                cbMaNV.Text = dgDanhsach.CurrentRow.Cells[3].Value.ToString();
                cbMaPB.Text = dgDanhsach.CurrentRow.Cells[4].Value.ToString();
                dpThoigianBD.Text = dgDanhsach.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void tRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRANGCHU cn = new TRANGCHU();
            cn.Show();
            this.Hide();
        }

        private void cbMaPBV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadDTG();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "TENCV", "*" + txtTimkiem.Text + "*");
            (dgDanhsach.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Congviec newcv = new Congviec();
                newcv.MaCV = txtMacv.Text;
                newcv.TenCV = txtTencv.Text;
                newcv.DiadiemCV = txtDiadiemCV.Text;
                newcv.MaNV = cbMaNV.SelectedValue.ToString();
                newcv.MaPB = cbMaPB.SelectedValue.ToString();
                newcv.ThoigianBD = DateTime.Parse(dpThoigianBD.Text);
                if (!ctr_cv.Themcongviec(newcv, table))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    ctr_cv.Delete(table, txtMacv.Text);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại.", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Congviec newcv = new Congviec();
                newcv.TenCV = txtTencv.Text;
                newcv.DiadiemCV = txtDiadiemCV.Text;
                newcv.MaNV = cbMaNV.SelectedValue.ToString();
                newcv.MaPB = cbMaPB.SelectedValue.ToString();
                newcv.ThoigianBD = DateTime.Parse(dpThoigianBD.Text);
                ctr_cv.Suacongviec(table, txtMacv.Text, newcv);
                MessageBox.Show("Sửa thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại.", "Thông báo");
            }
        }
    }
}
