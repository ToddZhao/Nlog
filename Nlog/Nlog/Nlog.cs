using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using System.Data;

namespace Nlog
{
    public partial class Nlog : Form
    {
        public Nlog()
        {
            InitializeComponent();
            //InitForm
            InitForm();
        }

        private void InitForm()
        {
            txtFolder.Text = ConfigurationManager.AppSettings["Path"];
        }

        private void cbxFileList_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFolder.Text.Trim()))
            {
                cbxFileList.DataSource = Directory.GetFiles(txtFolder.Text.Trim(), "*.log", SearchOption.AllDirectories);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var nlogFile = cbxFileList.SelectedValue.ToString();
            var firstIndex = nlogFile.LastIndexOf("\\");
            var lastIndex = nlogFile.LastIndexOf(".");
            var date = nlogFile.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
            if (!File.Exists(nlogFile))
                return;
            var table = NLogHelper.Table;
            var columns = NLogHelper.Columns.Split(',');
            using (var sr = new StreamReader(nlogFile))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    var splitChar = NLogHelper.SplitChar.ToCharArray();
                    var arr = line.Split(splitChar);
                    var row = table.NewRow();
                    row[columns[0]] = string.Format("{0} {1}", date, arr[0]);
                    if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]))
                    {
                        row[columns[1]] = arr[1];
                    }
                    if (arr.Length > 2 && !string.IsNullOrEmpty(arr[2]))
                    {
                        var firstColon = arr[2].IndexOf(':');
                        row[columns[2]] = arr[2].Substring(firstColon + 1, arr[2].Length - firstColon - 1);
                    }
                    if (arr.Length > 3 && !string.IsNullOrEmpty(arr[3]))
                    {
                        row[columns[3]] = arr[3];
                    }
                    table.Rows.Add(row);
                }
            }
            dgvList.AutoGenerateColumns = true;
            dgvList.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //file path
            var nlogFile = cbxFileList.SelectedValue.ToString();
            if (!File.Exists(nlogFile))
                return;
            //date
            var firstIndex = nlogFile.LastIndexOf("\\");
            var lastIndex = nlogFile.LastIndexOf(".");
            var date = nlogFile.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

            //item's txt
            List<string> items = new List<string>();
            using (var sr = new StreamReader(nlogFile))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    var arr = line.Split('-', '！');
                    if (arr.Length > 2 && !string.IsNullOrEmpty(arr[1]))
                    {
                        items.Add(arr[1]);
                    }
                }
            }

            //controller's list
            cbxController.DataSource = items.Where(c => c.Contains("Controller")).Distinct().ToList();
            //item's list
            cbxItemsTxt.DataSource = items.Where(c => !string.IsNullOrEmpty(c)).Distinct().ToList();

            //TODO
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var nlogFile = cbxFileList.SelectedValue.ToString();
            var firstIndex = nlogFile.LastIndexOf("\\");
            var lastIndex = nlogFile.LastIndexOf(".");
            var date = nlogFile.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

            Type SourceType = this.dgvList.DataSource.GetType();
            if (SourceType == typeof(DataTable))
            {
                DataTable dt = (DataTable)dgvList.DataSource;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = string.Format("export{0}.xls", date);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var flag = ExportHelper.ToCsV(dgvList, sfd.FileName);
                    if (flag)
                        MessageBox.Show("Export Success !");
                    else
                        MessageBox.Show("Export Failure !");
                }

            }
            else
            {
                MessageBox.Show(string.Format(
                "Failed to cast DataGridView DataSource to DataTable because the DataSource type is {0}",
                SourceType.ToString()));
            }
        }
    }
}
