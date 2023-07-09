using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao.View
{
    public partial class TRANGCHU : Form
    {
        public TRANGCHU()
        {
            InitializeComponent();
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
        // button thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            BAOCAOPHONGVE bc = new BAOCAOPHONGVE();
            bc.Show();
            this.Hide();
        }

        private void btnCongviec_Click(object sender, EventArgs e)
        {
            CONGVIEC cv = new CONGVIEC();
            cv.Show();
            this.Hide();
        }

        private void btnPhim_Click(object sender, EventArgs e)
        {
            PHIM p = new PHIM();
            p.Show();
            this.Hide();
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.Show();
            this.Hide();
        }

        private void btnChinhanh_Click(object sender, EventArgs e)
        {
            CHINHANH cn = new CHINHANH();
            cn.Show();
            this.Hide();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.Show();
            this.Hide();
        }
    }
}
