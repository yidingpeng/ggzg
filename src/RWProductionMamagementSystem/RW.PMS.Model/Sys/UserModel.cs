using System;

namespace RW.PMS.Model.Sys
{
    /// <summary>
    /// 用户Model
    /// </summary>
    public class UserModel : BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }

        /// <summary>
        /// 员工号
        /// </summary>
        public string empNo { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string empName { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int? roleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? deptID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string deptName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday { get; set; }

        /// <summary>
        /// 生日（显示文本）
        /// </summary>
        public string birthdayText
        {
            get
            {
                if (birthday.HasValue)
                    return birthday.Value.ToString("yyyy-MM-dd");
                return "";
            }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age
        {
            get
            {
                if (birthday.HasValue)
                    return DateTime.Now.Year - birthday.Value.Year;
                return -1;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public int? sex { get; set; }

        /// <summary>
        /// 性别(显示文本)
        /// </summary>
        public string sexText
        {
            get
            {
                if (sex == 1) return "男";
                else if (sex == 0) return "女";
                return "";
            }
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? registtime { get; set; }


        public string registtimeText
        {
            get
            {
                if (registtime.HasValue)
                    return registtime.Value.ToString("yyyy-MM-dd");
                return "";
            }
        }

        /// <summary>
        /// 在职标识
        /// </summary>
        public int? inStatus { get; set; }

        /// <summary>
        /// 在职标识(显示文本)
        /// </summary>
        public string inStatusText
        {
            get
            {
                if (inStatus == 0)
                    return "离职";
                return "在职";
            }
        }

        /// <summary>
        /// 卡号
        /// </summary>
        public string cardNo { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public byte[] headPortrait { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public byte[] signature { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? deleted { get; set; }

        /// <summary>
        /// 重置密码
        /// </summary>
        public bool ResultPwd { get; set; }

        /// <summary>
        /// 人员有效期
        /// </summary>
        public int? SkillLevel { get; set; }

        /// <summary>
        /// 人员有效期
        /// </summary>
        public string SkillLevelName { get; set; }

        /// <summary>
        /// 资质有效期
        /// </summary>
        public DateTime? postTime { get; set; }

        /// <summary>
        /// 资质有效期（显示文本）
        /// </summary>
        public string postTimeText
        {
            get
            {
                if (postTime.HasValue)
                    return postTime.Value.ToString("yyyy-MM-dd");
                return "";
            }
        }

        #region menu 页面

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int menuID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public int parentID { get; set; }

        /// <summary>
        /// 限定功能使用的计算机名
        /// </summary>
        public string atWhere { get; set; }

        /// <summary>
        /// 菜单排序
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 页面路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int isShow { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string flag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createtime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updatetime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public string updateBy { get; set; }

        #endregion
    }
}
