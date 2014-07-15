using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nlog.Entity;

namespace Nlog
{
    public static class NLogExtends
    {
        public static List<NLogEntity> DataTableToList(this DataTable dt)
        {
            List<NLogEntity> result = new List<NLogEntity>();
            foreach (DataRow item in dt.Rows)
            {
                var id = Convert.ToInt64(item[0].ToString().Trim());
                var visitDate = Convert.ToDateTime(item[1].ToString().Trim());
                var itemText = item[2].ToString();
                var spendTime = item[3].ToString();
                var tag = string.IsNullOrEmpty(item[4].ToString()) ? null : item[4].ToString();
                result.Add(new NLogEntity
                {
                    ID = id,
                    VisitDate = visitDate,
                    ItemText = itemText,
                    SpendTime = spendTime,
                    Tag = tag
                });
            }
            return result;
        }

        public static List<NLogEntityTime> DataTableToListOfTime(this DataTable dt)
        {
            List<NLogEntityTime> result = new List<NLogEntityTime>();
            foreach (DataRow item in dt.Rows)
            {
                var id = Convert.ToInt64(item[0].ToString().Trim());
                var visitDate = Convert.ToDateTime(item[1].ToString().Trim());
                var itemText = item[2].ToString();
                var spendTime = Convert.ToDateTime(item[3].ToString());
                var tag = string.IsNullOrEmpty(item[4].ToString()) ? null : item[4].ToString();
                result.Add(new NLogEntityTime
                {
                    ID = id,
                    VisitDate = visitDate,
                    ItemText = itemText,
                    SpendTime = spendTime,
                    Tag = tag
                });
            }
            return result;
        }

        public static DataTable ListToDataTable(this List<NLogEntity> list)
        {
            DataTable dt = NLogHelper.Table;
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                row[0] = item.ID;
                row[1] = item.VisitDate;
                row[2] = item.ItemText;
                row[3] = item.SpendTime;
                row[4] = item.Tag;
                dt.Rows.Add(row.ItemArray);
            }
            return dt;
        }
    }
}
