using System;
namespace RW.PMS.Model
{
    public partial class AssemblyErrorInfoModel
    {
        public int ID { get; set; }

        public int? ErrorTypeID { get; set; }

       // public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public Guid? agw_guid { get; set; }

        public Guid? agx_guid { get; set; }

        public Guid? agb_guid { get; set; }

        public Guid? agj_guid { get; set; }

        public int? err_operID { get; set; }

        public string err_oper { get; set; }

        public int? err_gwID { get; set; }

        public string err_gw { get; set; }

        public DateTime? errDate { get; set; }

        public string errDateStr
        {
            get
            {
                if (errDate.HasValue)
                {
                    return errDate.Value.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string errorDesp { get; set; }

        public string remark { get; set; }
    }
}
