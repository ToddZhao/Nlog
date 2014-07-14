using System.Configuration;
using System.Data;

namespace Nlog
{
    public static class NLogHelper
    {
        public static string SplitChar
        {
            get
            {
                return ConfigurationManager.AppSettings["SplitChar"];
            }
        }

        public static string Columns
        {
            get
            {
                return ConfigurationManager.AppSettings["Columns"];
            }
        }

        public static DataTable Table
        {
            get
            {
                DataTable table = new DataTable();
                foreach (var item in Columns.Split(','))
                {
                    DataColumn column = new DataColumn(item);
                    table.Columns.Add(column);
                }
                return table;
            }
        }

        public static string ConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NLogDB"].ToString();
            }
        }

        public static string LogTable
        {
            get
            {
                return ConfigurationManager.AppSettings["LogTable"];
            }
            set { LogTable = value; }
        }
    }
}
