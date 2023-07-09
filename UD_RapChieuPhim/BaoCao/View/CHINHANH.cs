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
    public partial class CHINHANH : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Rapphim ctr_Chinhanh = new Control_Rapphim();
        Control_Rapphim ctr_MaPBV = new Control_Rapphim();
        Control_Rapphim ctr_MaNV = new Control_Rapphim();
        ConnectSQL con = new ConnectSQL();
        DataSet ds;
        string table = "PHONGBANVE";
        public CHINHANH()
        {
            InitializeComponent();
        }
        // Load datagrid
        void AddHeader()
        {
            dgDanhsach.Columns.Clear();
            dgDanhsach.Columns.Add("MaPBV", "Mã phòng bán vé");
            dgDanhsach.Columns[0].DataPropertyName = "MAPBV";
            dgDanhsach.Columns.Add("Hinhthuc", "Hình thức");
            dgDanhsach.Columns[1].DataPropertyName = "HINHTHUC";
            dgDanhsach.Columns.Add("DIADIEMPBV", "Địa điểm phòng bán vé");
            dgDanhsach.Columns[2].DataPropertyName = "DIADIEMPBV";
        }
        void loadDTG()
        {
            if (dgDanhsach.DataSource != null)
                dgDanhsach.Rows.Clear();
            DataTable dtSV = ctr_Chinhanh.select(table);
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
        // load form
        private void Chinhanh_Load(object sender, EventArgs e)
        {
            loadAllNhanvien();
        }
        private void dgDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDanhsach.CurrentRow != null)
            {
                txtMaPBV.Text = dgDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtHinhthuc.Text = dgDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtDiadiem.Text = dgDanhsach.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void txtMaPBV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // button Tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // button Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Chinhanh newcn = new Chinhanh();
                newcn.MaPBV = txtMaPBV.Text;
                newcn.Hinhthuc = txtHinhthuc.Text;
                newcn.DiadiemPBV = txtDiadiem.Text;
                if (!ctr_Chinhanh.Themchinhanh(newcn, table))
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
        // button Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    ctr_Chinhanh.Delete("PHONGBANVE", txtMaPBV.Text);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo");
            }
        }
        // button Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Chinhanh newcn = new Chinhanh();
                newcn.Hinhthuc = txtHinhthuc.Text;
                newcn.DiadiemPBV = txtDiadiem.Text;
                ctr_Chinhanh.SuaChinhanh("PHONGBANVE", txtMaPBV.Text, newcn);
                MessageBox.Show("Sửa thành công.");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại.");
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "DIADIEMPBV", "*" + txtTimkiem.Text + "*");
            (dgDanhsach.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }


    }
}
