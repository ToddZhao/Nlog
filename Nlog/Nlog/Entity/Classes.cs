using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlog.Entity
{
    public class NLogEntity
    {
        public long ID { get; set; }
        public DateTime VisitDate { get; set; }
        public string ItemText { get; set; }
        /// <summary>
        /// 这里使用的时候读取time部分
        /// </summary>
        public string SpendTime { get; set; }
        public string Tag { get; set; }
    }

    public class NLogEntityTime
    {
        public long ID { get; set; }
        public DateTime VisitDate { get; set; }
        public string ItemText { get; set; }
        /// <summary>
        /// 这里使用的时候读取time部分
        /// </summary>
        public DateTime SpendTime { get; set; }
        public string Tag { get; set; }
    }

    public class NLogConfirmEntity
    {
        public long ID { get; set; }
        public DateTime VisitDate { get; set; }
        public string ItemText { get; set; }
        public string SpendTime { get; set; }
        public string Tag { get; set; }
    }

    public class AnalysisEntity
    {
        public DateTime VisitDate { get; set; }
        public int Count { get; set; }
        public double AvgTimeOfConfirm { get; set; }
        public double AvgTimeOfAbacus { get; set; }
        public double AvgTimeOfAllAbacus { get; set; }
        public double AvgTimeOfHotel { get; set; }
        public double Percent { get; set; }
    }
}
