using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankMangement
{
    public partial class Report : Form
    {
        List<ViewReport> list;
        //private List<ViewReport> objlist;

        public Report()
        {

        }
        public Report(List<ViewReport> objlist)
        {
            InitializeComponent();
            list = objlist;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(list);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
