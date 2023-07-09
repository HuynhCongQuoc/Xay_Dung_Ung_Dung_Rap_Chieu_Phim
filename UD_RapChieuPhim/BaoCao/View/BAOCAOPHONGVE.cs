using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace BaoCao.View
{
    public partial class BAOCAOPHONGVE : Form
    {
        public BAOCAOPHONGVE()
        {
            InitializeComponent();
        }

        private void BAOCAOPHONGVE_Load(object sender, EventArgs e)
        {

        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();

            ParameterValues inputday = new ParameterValues();
            ParameterDiscreteValue dis = new ParameterDiscreteValue();

            dis.Value = dateTimePicker1.Value;
            inputday.Add(dis);

            rpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(inputday);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void tRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TRANGCHU tc = new TRANGCHU();
            tc.Show();
            this.Hide();
        }
    }
}
