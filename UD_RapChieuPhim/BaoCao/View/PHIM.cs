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
    public partial class PHIM : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Rapphim ctr_Phim = new Control_Rapphim();
        Control_Rapphim ctr_MaPC = new Control_Rapphim();
        ConnectSQL con = new ConnectSQL();
        DataSet ds;
        string table = "Lichchieu";
        public PHIM()
        {
            InitializeComponent();
        }
        // Load combobox Mã phòng chiếu
        void load_combobox_MaPC()
        {
            DataTable dt = ctr_MaPC.select("PHONGCHIEU");
            cbMaPC.DataSource = dt;
            cbMaPC.DisplayMember = "MaPC";
            cbMaPC.ValueMember = "MaPC";
        }
        // Load danh sách theo MaPC
        void Load_Danhsach_PhongChieu()
        {
            DataTable dt = ctr_Phim.TruyVanTheoBang("LICHCHIEU", "PHONGCHIEU", "MaPC", cbMaPC.SelectedValue.ToString());
            dgDanhsach.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            for (int i = 5; i < dgDanhsach.Columns.Count; i++)
                dgDanhsach.Columns[i].Visible = false;
        }
        // Load danh sách
        void AddHeader()
        {
            dgDanhsach.Columns.Clear();
            dgDanhsach.Columns.Add("MaLC", "Mã lịch chiếu");
            dgDanhsach.Columns[0].DataPropertyName = "MALC";
            dgDanhsach.Columns.Add("Tenphim", "Tên phim");
            dgDanhsach.Columns[1].DataPropertyName = "TENPHIM";
            dgDanhsach.Columns.Add("Ngaychieu", "Ngày chiếu");
            dgDanhsach.Columns[2].DataPropertyName = "NGAYCHIEU";
            dgDanhsach.Columns.Add("Giochieu", "Giờ chiếu");
            dgDanhsach.Columns[3].DataPropertyName = "GIOCHIEU";
            dgDanhsach.Columns.Add("MaPC", "Mã phòng chiếu");
            dgDanhsach.Columns[4].DataPropertyName = "MAPC";
        }
        void loadDTG()
        {
            DataTable dtSV = ctr_Phim.select(table);
            dgDanhsach.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        void loadAllNhanvien()
        {
            AddHeader();
            loadDTG();
        }
        private void tRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRANGCHU tc = new TRANGCHU();
            tc.Show();
            this.Hide();
        }
        // Load form tổng
        private void Phim_Load(object sender, EventArgs e)
        {
            loadAllNhanvien();
            load_combobox_MaPC();
        }

        private void dgDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDanhsach.CurrentRow != null)
            {
                txtMaLC.Text = dgDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTenphim.Text = dgDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtNgaychieu.Text = dgDanhsach.CurrentRow.Cells[2].Value.ToString();
                txtGiochieu.Text = dgDanhsach.CurrentRow.Cells[3].Value.ToString();
                cbMaPC.Text = dgDanhsach.CurrentRow.Cells[4].Value.ToString();
            }
        }
        // Button thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Phim newph = new Phim();
                newph.MaLC = txtMaLC.Text;
                newph.Tenphim = txtTenphim.Text;
                newph.Ngaychieu = DateTime.Parse(txtNgaychieu.Text);
                newph.Giochieu = DateTime.Parse(txtGiochieu.Text);
                newph.MaPC = cbMaPC.SelectedValue.ToString();
                if (!ctr_Phim.Themphim(newph, table))
                {
                    MessageBox.Show("Trùng mã !", "Thông báo");
                }
                else
                    MessageBox.Show("Thêm thành công !", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại !", "Thông báo");
            }
        }
        // button tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            Load_Danhsach_PhongChieu();
        }
        // button Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    ctr_Phim.Delete(table, txtMaLC.Text);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                }
                ;
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo");
            }
        }
        //button Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Phim newphim = new Phim();
                newphim.Tenphim = txtTenphim.Text;
                newphim.Ngaychieu = DateTime.Parse(txtNgaychieu.Text);
                newphim.Giochieu = DateTime.Parse(txtGiochieu.Text);
                newphim.MaPC = cbMaPC.SelectedValue.ToString();
                ctr_Phim.SuaPhim("LICHCHIEU", txtMaLC.Text, newphim);
                MessageBox.Show("Sửa thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại !", "Thông báo");
            }
        }

        private void dgDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "TENPHIM", "*" + txtTimkiem.Text + "*");
            (dgDanhsach.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnTimkiem_Click_1(object sender, EventArgs e)
        {
            Load_Danhsach_PhongChieu();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadDTG();
        }
    }
}
