using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    public partial class BarcodeFollowDetailModel
    {
        public int? pf_prodModelID { get; set; }

        public int? wuliaoLJid { get; set; }

        public string wlname { get; set; }

        public string wlcode { get; set; }

        public int? isComingHang { get; set; }

        public int? replaceQty { get; set; }

        public string fd_barcode { get; set; }

        public string fd_stampNo { get; set; }

        public int? fd_componentId { get; set; }

        public string fd_componentName { get; set; }

        public int? fd_isCancel { get; set; }

        public string isCancel { get; set; }

        public Guid? fd_guid { get; set; }

        public int? fd_isWuliaoBox { get; set; }

        public int? fd_isNextScan { get; set; }

        public int? fd_checkResult { get; set; }

        public string colbtnComfirm { get; set; }
    }
}
