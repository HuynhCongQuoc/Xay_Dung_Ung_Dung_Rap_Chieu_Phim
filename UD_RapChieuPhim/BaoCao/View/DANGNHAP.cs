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
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }
        private void tRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRANGCHU tc = new TRANGCHU();
            tc.Show();
            this.Hide();
        }


        // Load form
        private void DangNhap_Load(object sender, EventArgs e)
        {
        }
        // button Đăng nhập
        private void btnDangnhap_Click_1(object sender, EventArgs e)
        {

            if (txtTK.Text == "admin" && txtMK.Text == "123")
            {
                TRANGCHU tc = new TRANGCHU();
                tc.Show();
                this.Hide();
            }
            else if (txtTK.Text == "" && txtMK.Text == "")
            {
                MessageBox.Show("Nhập Tài khoản & Mật khẩu");
            }
            else if (txtTK.Text == "")
            {
                MessageBox.Show("Nhập tài khoản !");
            }
            else if (txtMK.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu !");
            }
            else MessageBox.Show("Sai thông tin đăng nhập !");

        }


    }
}
