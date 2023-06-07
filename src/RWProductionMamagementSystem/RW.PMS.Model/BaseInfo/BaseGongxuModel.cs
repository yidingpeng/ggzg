namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 工序信息表 LHR 2019-2-13
    /// Update By Leon 2019-12-28 
    /// </summary>
    //public class BaseGongxuModel : BaseModel
    //{
    //    /// <summary>
    //    /// ID
    //    /// </summary>
    //    public int ID { get; set; }

    //    /// <summary>
    //    /// 工序名称
    //    /// </summary>
    //    public string Gxname { get; set; }

    //    /// <summary>
    //    /// 工序视频存放地址
    //    /// </summary>
    //    public string Gxvedio { get; set; }

    //    /// <summary>
    //    /// 工序视频名称
    //    /// </summary>
    //    public string GxvedioFilename { get; set; }

    //    /// <summary>
    //    /// 工序描述
    //    /// </summary>
    //    public string Descript { get; set; }

    //    /// <summary>
    //    /// 状态
    //    /// </summary>
    //    public int GxStatus { get; set; }

    //    public string GxStatusText
    //    {
    //        get
    //        {
    //            if (GxStatus == 0)
    //                return "启用";
    //            return "禁用";
    //        }
    //    }

    //    /// <summary>
    //    /// 备注
    //    /// </summary>
    //    public string Remark { get; set; }

    //    #region 查询条件
    //    public string LIKEProcessName { get; set; }
    //    #endregion
    //}

    /// <summary>
    /// 视频实体类
    /// </summary>
    public partial class VideoModel
    {
        /// <summary>
        /// 视频存放地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 视频名称
        /// </summary>
        public string Name { get; set; }
    }
}
