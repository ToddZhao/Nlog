using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        /// <summary>
        /// load file of the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFileList_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFolder.Text.Trim()) && System.IO.Directory.Exists(txtFolder.Text.Trim()))
            {
                cbxFileList.DataSource = Directory.GetFiles(txtFolder.Text.Trim(), "*.log", SearchOption.AllDirectories);
            }
            else
            {
                MessageBox.Show(string.Format("請添加目錄：{0}", txtFolder.Text.Trim()));
            }
        }

        /// <summary>
        /// bind data of the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            var i = 0;
            using (var sr = new StreamReader(nlogFile))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    var splitChar = NLogHelper.SplitChar.ToCharArray();
                    var arr = line.Split(splitChar);

                    var flag = this.Filter(arr);
                    if (!flag) continue;

                    var row = table.NewRow();
                    i++;
                    row[columns[0]] = i;
                    row[columns[1]] = string.Format("{0} {1}", date, arr[0]);
                    if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]))
                    {
                        row[columns[2]] = arr[1];
                    }
                    if (arr.Length > 2 && !string.IsNullOrEmpty(arr[2]))
                    {
                        var firstColon = arr[2].IndexOf(':');
                        row[columns[3]] = arr[2].Substring(firstColon + 1, arr[2].Length - firstColon - 1);
                    }
                    if (arr.Length > 3 && !string.IsNullOrEmpty(arr[3]))
                    {
                        row[columns[4]] = arr[3];
                    }
                    table.Rows.Add(row);
                }
            }

            dgvList.AutoGenerateColumns = true;
            dgvList.DataSource = table;
        }

        /// <summary>
        /// query by the condition of the combox
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private bool Filter(string[] arr)
        {
            bool flag = false;
            if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]))
            {
                if (lbController.SelectedItems.Count > 0)
                {
                    foreach (var item in lbController.SelectedItems)
                    {
                        if (flag) break; if (string.IsNullOrEmpty(item.ToString().Trim())) continue;
                        flag = arr[1].Contains(item.ToString());
                    }
                }
                if (lbItemText.SelectedItems.Count > 0)
                {
                    foreach (var item in lbItemText.SelectedItems)
                    {
                        if (flag) break; if (string.IsNullOrEmpty(item.ToString().Trim())) continue;
                        flag = arr[1].Contains(item.ToString());
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// add some data of the combox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStuff_Click(object sender, EventArgs e)
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

            var controllers = items.Where(c => c.Contains("Controller")).Distinct().ToList();
            var itemsText = items.Where(c => !string.IsNullOrEmpty(c) && !c.Contains("Controller")).Distinct().ToList();
            itemsText = itemsText.Select(c =>
            {
                if (c.Contains("From") || c.Contains("AdultQty"))
                {
                    c = c.Split(' ')[1];
                }
                return c;
            }).Distinct().ToList();
            //controller's list
            this.lbController.DataSource = controllers;
            //item's list
            this.lbItemText.DataSource = itemsText;

            //TODO
        }

        /// <summary>
        /// export the data to one file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// export the data to one file with view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportView_Click(object sender, EventArgs e)
        {
            try
            {
                #region FileName & FilePath
                var nlogFile = cbxFileList.SelectedValue.ToString();
                var firstIndex = nlogFile.LastIndexOf("\\");
                var lastIndex = nlogFile.LastIndexOf(".");
                var date = nlogFile.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
                var fileName = string.Format("{0}.xls", date);
                var filePath = string.Format("{0}\\{1}", txtFolder.Text.Trim(), fileName);
                #endregion
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";

                // storing header part in Excel
                for (int i = 1; i < dgvList.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvList.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet
                for (int i = 0; i < dgvList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvList.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvList.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application
                app.Quit();
                MessageBox.Show("ExportView Success！");

            }
            catch
            {
                MessageBox.Show("ExportView Failure ！");
            }

        }

        private void btnExportToDB_Click(object sender, EventArgs e)
        {
            try
            {
                SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NLogHelper.ConnString, SqlBulkCopyOptions.UseInternalTransaction);
                NLogHelper.LogTable = lbLogTable.SelectedValue.ToString().Trim();
                sqlbulkcopy.DestinationTableName = NLogHelper.LogTable;//数据库中的表名
                DataTable dt = dgvList.DataSource as DataTable;
                sqlbulkcopy.WriteToServer(dt);
                MessageBox.Show("ExportToDB Success ");
            }
            catch
            {
                MessageBox.Show("ExportToDB Failure ");
            }
        }

        private void btnExportAllToDB_Click(object sender, EventArgs e)
        {
            try
            {
                var i = 0;
                foreach (var item in cbxFileList.Items)
                {
                    var nlogFile = item.ToString();
                    var firstIndex = nlogFile.LastIndexOf("\\");
                    var lastIndex = nlogFile.LastIndexOf(".");
                    var date = nlogFile.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
                    var table = NLogHelper.Table;
                    var columns = NLogHelper.Columns.Split(',');
                    if (!File.Exists(nlogFile))
                        return;
                    #region Init Table
                    using (var sr = new StreamReader(nlogFile))
                    {
                        string line = null;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var splitChar = NLogHelper.SplitChar.ToCharArray();
                            var arr = line.Split(splitChar);

                            var flag = this.Filter(arr);
                            if (!flag) continue;

                            var row = table.NewRow();
                            i++;
                            row[columns[0]] = i;
                            row[columns[1]] = string.Format("{0} {1}", date, arr[0]);
                            if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]))
                            {
                                row[columns[2]] = arr[1];
                            }
                            if (arr.Length > 2 && !string.IsNullOrEmpty(arr[2]))
                            {
                                var firstColon = arr[2].IndexOf(':');
                                row[columns[3]] = arr[2].Substring(firstColon + 1, arr[2].Length - firstColon - 1);
                            }
                            if (arr.Length > 3 && !string.IsNullOrEmpty(arr[3]))
                            {
                                row[columns[4]] = arr[3];
                            }
                            table.Rows.Add(row);
                        }
                    }
                    #endregion
                    SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NLogHelper.ConnString, SqlBulkCopyOptions.UseInternalTransaction);
                    NLogHelper.LogTable = lbLogTable.SelectedValue.ToString().Trim();
                    sqlbulkcopy.DestinationTableName = NLogHelper.LogTable;//数据库中的表名
                    sqlbulkcopy.WriteToServer(table);
                }
                MessageBox.Show("ExportAllToDB Success ");
            }
            catch
            {
                MessageBox.Show("ExportAllToDB Failure ");
            }
        }

    }
}
