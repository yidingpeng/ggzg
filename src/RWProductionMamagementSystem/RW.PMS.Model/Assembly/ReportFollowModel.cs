using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class ReportFollowModel
    {
        public Guid? fm_guid { get; set; }

        public int? fgw_areaID { get; set; }

        public string areaName { get; set; }

        public DateTime? startTime { get; set; }

        public DateTime? finishTime { get; set; }

        public string oper { get; set; }

        public Guid? fc_guid { get; set; }

        public string fm_prodNo { get; set; }

        public string fc_gwID { get; set; }

        public string fc_gwName { get; set; }

        public int? fc_areaID { get; set; }

        public string fc_areaName { get; set; }

        public string fc_operID { get; set; }

        public string fc_oper { get; set; }

        public DateTime? fc_starttime { get; set; }

        public DateTime? fc_finishtime { get; set; }

        public int? fc_followStatus { get; set; }

        public int? fc_selfCheckerID { get; set; }

        public string fc_selfChecker { get; set; }

        public DateTime? fc_selfCheckTime { get; set; }

        public int? fc_selfCheckResult { get; set; }

        public string fc_selfResultMemo { get; set; }

        public int? fc_mutualCheckerID { get; set; }

        public string fc_mutualChecker { get; set; }

        public DateTime? fc_mutualCheckTime { get; set; }

        public int? fc_mutualCheckResult { get; set; }

        public string fc_mutualResultMemo { get; set; }

        public int? fc_specialCheckerID { get; set; }

        public string fc_specialChecker { get; set; }

        public DateTime? fc_specialCheckTime { get; set; }

        public int? fc_specialCheckResult { get; set; }

        public string fc_specialResultMemo { get; set; }

        public string fc_remark { get; set; }

        public int? fc_uploadFlag { get; set; }

    }
}
