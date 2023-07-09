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
    public partial class KHACHHANG : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Rapphim ctr_Kh = new Control_Rapphim();
        Control_Rapphim ctr_mave = new Control_Rapphim();
        Control_Rapphim ctr_maLC = new Control_Rapphim();
        Control_Rapphim ctr_maPBV = new Control_Rapphim();
        ConnectSQL con = new ConnectSQL();
        DataSet ds;
        string table = "Khachhang";
        public KHACHHANG()
        {
            InitializeComponent();
        }
        // Load combobox lịch chiếu
        void load_combobox_MaLC()
        {
            DataTable dt = ctr_maLC.select("LICHCHIEU");
            cbMaLC.DataSource = dt;
            cbMaLC.DisplayMember = "MaLC";
            cbMaLC.ValueMember = "MaLC";
        }
        // Load Khách hàng theo mã vé
        void load_Nhanvien_TheoLop()
        {
            DataTable dt = ctr_Kh.TruyVanTheoBang("KHACHHANG", "LICHCHIEU", "MaLC", cbMaLC.SelectedValue.ToString());
            dgDanhsach.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            for (int i = 6; i < dgDanhsach.Columns.Count; i++)
                dgDanhsach.Columns[i].Visible = false;
        }

        // Load danh sách
        void AddHeader()
        {
            dgDanhsach.Columns.Clear();
            dgDanhsach.Columns.Add("Mave", "Mã vé");
            dgDanhsach.Columns[0].DataPropertyName = "MAVE";
            dgDanhsach.Columns.Add("Dayghe", "Dãy ghế");
            dgDanhsach.Columns[1].DataPropertyName = "DAYGHE";
            dgDanhsach.Columns.Add("Soghe", "Số ghế");
            dgDanhsach.Columns[2].DataPropertyName = "SOGHE";
            dgDanhsach.Columns.Add("Giave", "Giá vé");
            dgDanhsach.Columns[3].DataPropertyName = "GIAVE";
            dgDanhsach.Columns.Add("Tenkh", "Tên khách hàng");
            dgDanhsach.Columns[4].DataPropertyName = "TENKH";
            dgDanhsach.Columns.Add("MaLC", "Mã lịch chiếu");
            dgDanhsach.Columns[5].DataPropertyName = "MALC";
        }
        void loadDTG()
        {
            DataTable dtSV = ctr_Kh.select(table);
            dgDanhsach.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        private void dgDanhsach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDanhsach.CurrentRow != null)
            {
                txtMave.Text = dgDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtDayghe.Text = dgDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtSoghe.Text = dgDanhsach.CurrentRow.Cells[2].Value.ToString();
                txtGiave.Text = dgDanhsach.CurrentRow.Cells[3].Value.ToString();
                TenKh.Text = dgDanhsach.CurrentRow.Cells[4].Value.ToString();
                cbMaLC.Text = dgDanhsach.CurrentRow.Cells[5].Value.ToString();
            }
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
        private void KhachHang_Load(object sender, EventArgs e)
        {
            // Load form tổng
            loadAllNhanvien();
            //Load combobox (Mave, MaPBV, MaLC)
            load_combobox_MaLC();
        }
        // Button Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Khachhang newkh = new Khachhang();
                newkh.Mave = txtMave.Text;
                newkh.Dayghe = txtDayghe.Text;
                newkh.Soghe = int.Parse(txtSoghe.Text);
                newkh.Giave = int.Parse(txtGiave.Text);
                newkh.TenKh = TenKh.Text;
                newkh.MaLC = cbMaLC.SelectedValue.ToString();
                if (!ctr_Kh.Themkhachhang(newkh, table))
                {
                    MessageBox.Show("Trùng mã !", "Thông báo");
                }
                else
                    MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại !", "Thông báo");
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
                    ctr_Kh.Delete("Khachhang", txtMave.Text);
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
                Khachhang newkh = new Khachhang();
                newkh.Dayghe = txtDayghe.Text;
                newkh.Soghe = int.Parse(txtSoghe.Text);
                newkh.Giave = int.Parse(txtGiave.Text);
                newkh.TenKh = TenKh.Text;
                newkh.MaLC = cbMaLC.SelectedValue.ToString();
                ctr_Kh.SuaKH("KHACHHANG", txtMave.Text, newkh);
                MessageBox.Show("Sửa thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại !", "Thông báo");
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "TENKH", "*" + txtTimkiem.Text + "*");
            (dgDanhsach.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnTimkiem_Click_1(object sender, EventArgs e)
        {
            load_Nhanvien_TheoLop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDTG();
        }

        private void txtMave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
