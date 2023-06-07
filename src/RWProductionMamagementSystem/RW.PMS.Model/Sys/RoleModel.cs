namespace RW.PMS.Model.Sys
{
    public class RoleModel : BaseModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int roleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }


    }
}
