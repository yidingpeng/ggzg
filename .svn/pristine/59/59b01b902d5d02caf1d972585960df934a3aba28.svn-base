using Newtonsoft.Json;
using System.Collections.Generic;

namespace RW.PMS.Common
{
    /// <summary>
    /// 字段 Add By Leon
    /// </summary>
    public class LFieldHelper
    {
        /// <summary>
        /// 转Json
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJson(LTable t)
        {
            try
            {
                return JsonConvert.SerializeObject(t);
            }
            catch { }
            return "";
        }
        /// <summary>
        /// Json转实体类
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static LTable ToEntity(string strJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<LTable>(strJson);
            }
            catch { }
            return null;
        }
    }

    /// <summary>
    /// 表(实体)
    /// </summary>
    public class LTable
    {
        /// <summary>
        /// 表(实体)名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字段集合
        /// </summary>
        public List<LField> FieldList { get; set; }
    }

    /// <summary>
    /// 字段
    /// </summary>
    public class LField
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNo { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsMust { get; set; }
        /// <summary>
        /// 控件类型
        /// </summary>
        public ControlType ControlType { get; set; }
        /// <summary>
        /// 下拉框绑定的数据
        /// </summary>
        public List<DropDownListItem> DataSource { get; set; }
    }

    /// <summary>
    /// 控件类型
    /// </summary>
    public enum ControlType
    {
        TextBox,
        DropDownList,
        DateTimePicker
    }

    /// <summary>
    /// 下拉框绑定的数据
    /// </summary>
    public class DropDownListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
