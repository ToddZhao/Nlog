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
                DateTime endDate = dtPicket.Value.Date.AddHours(12).AddMinutes(59).AddSeconds(59);
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
        }

        private void btnLoadCheckChange_Click(object sender, EventArgs e)
        {
            DataTable dt = dgNLog.DataSource as DataTable;
            foreach (var item in dt.Rows)
            {
                
            }
        }
    }
}
