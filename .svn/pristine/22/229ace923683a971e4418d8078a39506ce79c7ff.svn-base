using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.Sys
{
    public class MenuModel : BaseModel
    {
        public MenuModel()
        {
            //子集
            Children = new List<MenuModel>();
        }

        public int menuID { get; set; }
        public string menuName { get; set; }

        public int? parentID { get; set; }

        public string parentName { get; set; }
        public string parentNameText
        {
            get { return parentName ?? "最高级菜单"; }
            set { parentName = value; }
        }

        public string atWhere { get; set; }

        public int? sort { get; set; }

        /// <summary>
        /// 权限表
        /// </summary>
        public IEnumerable<MenuAuth> auths { get; set; }

        public string authStr { get; set; }

        public string url { get; set; }

        public int isShow { get; set; }
        public string IsShowS
        {
            get
            {
                if (isShow == 0)
                {
                    return "隐藏";
                }
                else if (isShow == 1)
                {
                    return "可见";
                }
                return "";
            }
        }

        public MenuModel Parent { get; set; }

        public string flag { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreateTimeText
        {
            get
            {
                if (CreateTime == null)
                    return "";
                return CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) CreateTime = dt;
            }
        }


        public string createBy { get; set; }

        public DateTime? UpdateTime { get; set; }


        public string UpdateTimeText
        {
            get
            {
                if (UpdateTime == null)
                    return "";
                return UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) UpdateTime = dt;
            }
        }


        public string updateBy { get; set; }

        public string remark { get; set; }

        public int? deleteFlag { get; set; }


        /// <summary>
        /// 权限表
        /// </summary>
        public IEnumerable<MenuAuth> MenuAuth { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public List<MenuModel> Children { get; set; }

        #region 功能菜单按钮
        /// <summary>
        /// 查看
        /// </summary>
        public bool ckSelect { get; set; }
        /// <summary>
        /// 修改
        /// </summary>
        public bool ckUpdate { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        public bool ckAdd { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool ckDelete { get; set; }
        /// <summary>
        /// 导出
        /// </summary>
        public bool ckExport { get; set; }
        /// <summary>
        /// 全选
        /// </summary>
        public bool ckAllCheck { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        public bool ckAudit { get; set; }
        /// <summary>
        /// 批准
        /// </summary>
        public bool ckApproved { get; set; }
        /// <summary>
        /// 发布
        /// </summary>
        public bool ckPublishing { get; set; }
        #endregion


    }
}
