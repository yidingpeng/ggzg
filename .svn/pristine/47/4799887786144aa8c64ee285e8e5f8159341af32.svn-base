namespace RW.PMS.Model
{
    public class CrumbsModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }

        /// <summary>
        /// 页面地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 所属父级ID
        /// </summary>
        public int parentID { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string flag { get; set; }

        public CrumbsModel() { }

        public CrumbsModel(string Name, string Url = "", int ParentID = 0, string flag = "")
        {
            this.menuName = Name;
            this.Url = Url;
            this.parentID = ParentID;
            this.flag = flag;
        }
    }
}
