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
        public DateTime SpendTime { get; set; }
        public string Tag { get; set; }
    }

    public class NLogConfirmEntity
    {
        public long ID { get; set; }
        public DateTime VisitDate { get; set; }
        public string ItemText { get; set; }
        public DateTime SpendTime { get; set; }
        public string Tag { get; set; }
    }
}
