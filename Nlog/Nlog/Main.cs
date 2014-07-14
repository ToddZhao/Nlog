using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nlog
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            Nlog nlog = new Nlog();
            nlog.Show();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            Analysis analysis = new Analysis();
            analysis.Show();
        }
    }
}
