using Nlog.Entity;
using NlogData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nlog
{
    public partial class Analysis : Form
    {
        public Analysis()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            dtPicket.Value = Convert.ToDateTime("2014-06-15");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
            {
                DateTime startDate = dtPicket.Value.Date.AddHours(0).AddMinutes(0).AddSeconds(59);
                DateTime endDate = dtPicket.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                string sql = string.Format(@"SELECT  *
                                FROM    dbo.NLog
                                WHERE   VisitDate BETWEEN '{0}'
                                                  AND     '{1}'
                                        AND ( ItemText LIKE '%Confirm%'
                                             --OR ItemText LIKE N'%CheckChange%'
                                             -- OR ItemText LIKE N'%L仔(散票)可用机票%'
                                              --OR ItemText LIKE N'%機酒酒店查詢 AvailableHotelFH%'
                                              )
                                ORDER BY VisitDate ", startDate, endDate);
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "NLog");

                dgNLog.DataSource = ds.Tables[0];
            }

            btnLoadCheckChange_Click(null, null);
            //MessageBox.Show("Load Success！");
        }

        private void btnLoadCheckChange_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dtPicket.Value.Date;
                DataTable dt = dgNLog.DataSource as DataTable;
                var confirmList = dt.DataTableToList();
                var checkChangeTable = NLogHelper.Table;
                foreach (var item in confirmList)
                {
                    var confirmTime = item.VisitDate.TimeOfDay;
                    //取時間部分
                    var spendTime = Convert.ToDateTime(item.SpendTime).TimeOfDay;
                    var checkChangeTime = confirmTime - spendTime;
                    var checkChangeStartDate = date.Add(checkChangeTime).AddSeconds(-1);
                    var checkChangeEndDate = date.Add(checkChangeTime).AddSeconds(1);

                    //根據Confirm的提交時間、花費時間，計算CheckChange提交時間
                    using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
                    {
                        string sql = string.Format(@"SELECT  *
                                FROM    dbo.NLog
                                WHERE   VisitDate BETWEEN '{0}'
                                                  AND     '{1}'
                                        AND ( --ItemText LIKE '%Confirm%'
                                             ItemText LIKE N'%CheckChange%'
                                             -- OR ItemText LIKE N'%L仔(散票)可用机票%'
                                              --OR ItemText LIKE N'%機酒酒店查詢 AvailableHotelFH%'
                                              )
                                ORDER BY VisitDate ", checkChangeStartDate.ToString() + "." + checkChangeStartDate.Millisecond.ToString(), checkChangeEndDate.ToString() + "." + checkChangeEndDate.Millisecond.ToString());
                        SqlCommand com = new SqlCommand(sql, con);
                        SqlDataAdapter da = new SqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "NLog");

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            checkChangeTable.Rows.Add(row.ItemArray);
                        }

                    }
                }
                dgCheckChange.DataSource = checkChangeTable;
                List<NLogEntity> list = checkChangeTable.DataTableToList().Distinct().ToList();
                var ids = list.Select(c => c.ID).Distinct().ToList();
                List<NLogEntity> tempList = new List<NLogEntity>();
                foreach (var item in ids)
                {
                    var temp = list.Where(c => c.ID == item).FirstOrDefault();
                    tempList.Add(temp);
                }
                var tempDT = tempList.ListToDataTable();
                //checkChange
                SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NLogHelper.ConnString, SqlBulkCopyOptions.UseInternalTransaction);
                sqlbulkcopy.DestinationTableName = NLogHelper.LogTable;//数据库中的表名
                sqlbulkcopy.WriteToServer(tempDT);

                //confirm
                //SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NLogHelper.ConnString, SqlBulkCopyOptions.UseInternalTransaction);
                //sqlbulkcopy.DestinationTableName = NLogHelper.LogTable;//数据库中的表名
                //DataTable dt = dgNLog.DataSource as DataTable;
                sqlbulkcopy.WriteToServer(dt);

                MessageBox.Show("Load success！");
            }
            catch
            {
                MessageBox.Show("Load Failure！");

            }
        }

        private void btnLoadAllCheckChange_Click(object sender, EventArgs e)
        {
            //var startDate = dtPicket.Value;
            //var endDate = dtPicketEndDate.Value;
            //TimeSpan timeSpan = endDate - endDate 
            //for (int i = 0; i < endDate; i++)
            //{

            //}
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            DataTable dt = NLogHelper.Table;
            using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
            {
                DateTime startDate = dtPicket.Value.Date.AddHours(0).AddMinutes(0).AddSeconds(59);
                DateTime endDate = dtPicket.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                string sql = string.Format(@"SELECT  *
FROM    dbo.NLogConfirm
ORDER BY VisitDate  ", startDate, endDate);
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "NLog");
                dt = ds.Tables[0];
            }
            List<NLogEntityTime> nlogs = dt.DataTableToListOfTime();
            var analysisStartDate = Convert.ToDateTime("2014-06-15");
            var analysisEndDate = Convert.ToDateTime("2014-07-12");
            List<AnalysisEntity> analysisEntitys = new List<AnalysisEntity>();

            while (analysisStartDate <= analysisEndDate)
            {
                AnalysisEntity analysisEntity = new AnalysisEntity();
                //public DateTime VisitDate { get; set; }
                //public int Count { get; set; }
                //public string AvgTimeOfConfirm { get; set; }
                //public string AvgTimeOfAbacus { get; set; }
                //public string AvgTimeOfHotel { get; set; }
                analysisEntity.VisitDate = analysisStartDate;

                var tempNLogs = nlogs.Where(c => c.VisitDate >= analysisStartDate.AddHours(0).AddMinutes(0).AddSeconds(0)
                    && c.VisitDate <= analysisStartDate.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999)
                    ).ToList();
                analysisEntity.Count = tempNLogs.Where(c => c.ItemText.Contains("Confirm")).ToList().Count();
                analysisEntity.AvgTimeOfConfirm = tempNLogs.Sum(c => c.SpendTime.TimeOfDay.TotalMilliseconds) / analysisEntity.Count;
                analysisEntity.AvgTimeOfAbacus = tempNLogs.Where(c => c.ItemText.Contains("CheckChange")).Sum(c => c.SpendTime.TimeOfDay.TotalMilliseconds) / analysisEntity.Count;
                #region 得到CheckChange中Hotel的均值
                DataTable dtHotel = NLogHelper.Table;
                using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
                {
                    DateTime startDate = analysisStartDate.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
                    DateTime endDate = analysisStartDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    string sql = string.Format(@"SELECT *
  FROM [NLogDB].[dbo].[NLog]
  WHERE ItemText LIKE '%AvailableHotelFH%'
  AND VisitDate BETWEEN '{0}' AND '{1}'
            ORDER BY VisitDate  ", startDate, endDate);
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "NLog");
                    dtHotel = ds.Tables[0];
                }
                List<NLogEntityTime> nlogsHotel = dtHotel.DataTableToListOfTime();
                analysisEntity.AvgTimeOfHotel = nlogsHotel.Sum(c => c.SpendTime.TimeOfDay.TotalMilliseconds) / nlogsHotel.Count;
                #endregion

                #region 所有Abacus的均值
                DataTable dtAbacus = NLogHelper.Table;
                using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
                {
                    DateTime startDate = analysisStartDate.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
                    DateTime endDate = analysisStartDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    string sql = string.Format(@"SELECT *
  FROM [NLogDB].[dbo].[NLog]
  WHERE ItemText LIKE N'%L仔(散票)可用机票%'
  AND VisitDate BETWEEN '{0}' AND '{1}'
            ORDER BY VisitDate  ", startDate, endDate);
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "NLog");
                    dtAbacus = ds.Tables[0];
                }
                List<NLogEntityTime> nlogsAbacus = dtAbacus.DataTableToListOfTime();
                analysisEntity.AvgTimeOfAllAbacus = nlogsAbacus.Sum(c => c.SpendTime.TimeOfDay.TotalMilliseconds) / nlogsHotel.Count;
                #endregion

                analysisEntity.Percent = analysisEntity.AvgTimeOfAbacus / analysisEntity.AvgTimeOfConfirm;
                analysisEntitys.Add(analysisEntity);

                analysisStartDate = analysisStartDate.AddDays(1);
            }
            dgCheckChange.DataSource = analysisEntitys;
        }

        private void btnAbacus_Click(object sender, EventArgs e)
        {
            DataTable dt = NLogHelper.Table;
            using (SqlConnection con = new SqlConnection(NLogHelper.ConnString))
            {
                string sql = string.Format(@"SELECT *
  FROM [NLogDB].[dbo].[NLog]
  WHERE ItemText LIKE N'%L仔(散票)可用机票%'
            ORDER BY VisitDate  ");
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "NLog");
                dt = ds.Tables[0];
            }
            dgCheckChange.DataSource = dt;
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NLogHelper.ConnString, SqlBulkCopyOptions.UseInternalTransaction);
            sqlbulkcopy.DestinationTableName = NLogHelper.LogTable;//数据库中的表名
            sqlbulkcopy.WriteToServer(dt);
        }
    }
}
