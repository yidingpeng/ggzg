namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_spotcheck
    {
        public int id { get; set; }

        /// <summary>
        /// 点检序号
        /// </summary>
        public string spotid { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public int? dsc_category { get; set; }
        /// <summary>
        /// 部位
        /// </summary>
        public string dsc_position { get; set; }
        /// <summary>
        /// 活动项目
        /// </summary>
        public string dsc_project { get; set; }
        /// <summary>
        /// 所用工具/方法
        /// </summary>
        public string dsc_method { get; set; }
        /// <summary>
        /// 判定基准
        /// </summary>
        public string dsc_criteria { get; set; }
        /// <summary>
        /// 问题处理方法
        /// </summary>
        public string dsc_solving { get; set; }
        /// <summary>
        /// 设备状态
        /// </summary>
        public int? dsc_status { get; set; }
        /// <summary>
        /// 周期
        /// </summary>
        public int? dsc_cycle { get; set; }
        /// <summary>
        /// 责任人
        /// </summary>
        public string dsc_liable { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int? dsc_class { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public byte[] dsc_img { get; set; }

        /// <summary>
        /// 设备
        /// </summary>
        public int? dsc_device { get; set; }
    }
}
