namespace BaoCao.View
{
    partial class BAOCAOPHONGVE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAOCAOPHONGVE));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tRANGCHỦToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bÁOCÁOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThuchien = new BaoCao.View.ButtonRounded();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(13, 31);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1238, 544);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 158);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(159, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 65);
            this.panel1.TabIndex = 35;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tRANGCHỦToolStripMenuItem,
            this.bÁOCÁOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(306, 14);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 39);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tRANGCHỦToolStripMenuItem
            // 
            this.tRANGCHỦToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tRANGCHỦToolStripMenuItem.Name = "tRANGCHỦToolStripMenuItem";
            this.tRANGCHỦToolStripMenuItem.Size = new System.Drawing.Size(241, 35);
            this.tRANGCHỦToolStripMenuItem.Text = "TRANG CHỦ    |";
            this.tRANGCHỦToolStripMenuItem.Click += new System.EventHandler(this.tRANGCHỦToolStripMenuItem_Click);
            // 
            // bÁOCÁOToolStripMenuItem
            // 
            this.bÁOCÁOToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.bÁOCÁOToolStripMenuItem.Name = "bÁOCÁOToolStripMenuItem";
            this.bÁOCÁOToolStripMenuItem.Size = new System.Drawing.Size(307, 35);
            this.bÁOCÁOToolStripMenuItem.Text = "BÁO CÁO PHÒNG VÉ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 185);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 22);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Location = new System.Drawing.Point(-1, 224);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 597);
            this.panel2.TabIndex = 38;
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackColor = System.Drawing.Color.Red;
            this.btnThuchien.BackgroundColor = System.Drawing.Color.Red;
            this.btnThuchien.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnThuchien.BorderRadius = 20;
            this.btnThuchien.BorderSize = 0;
            this.btnThuchien.FlatAppearance.BorderSize = 0;
            this.btnThuchien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuchien.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThuchien.ForeColor = System.Drawing.Color.Black;
            this.btnThuchien.Location = new System.Drawing.Point(254, 178);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Size = new System.Drawing.Size(150, 40);
            this.btnThuchien.TabIndex = 37;
            this.btnThuchien.Text = "Thực hiện";
            this.btnThuchien.TextColor = System.Drawing.Color.Black;
            this.btnThuchien.UseVisualStyleBackColor = false;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // BAOCAOPHONGVE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 811);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnThuchien);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BAOCAOPHONGVE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BAOCAOPHONGVE";
            this.Load += new System.EventHandler(this.BAOCAOPHONGVE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tRANGCHỦToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bÁOCÁOToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private ButtonRounded btnThuchien;
        private System.Windows.Forms.Panel panel2;
    }
}