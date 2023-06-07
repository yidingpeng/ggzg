using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Common.Auth
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        /// 查看
        /// </summary>
        Query = 2,
        /// <summary>
        /// 修改
        /// </summary>
        Edit = 4,
        /// <summary>
        /// 添加
        /// </summary>
        Add = 8,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 16,
        /// <summary>
        /// 导出
        /// </summary>
        Export = 32,
        /// <summary>
        /// 全选
        /// </summary>
        CheckAll = 64,
        /// <summary>
        /// 审核
        /// </summary>
        Audit = 128,
        /// <summary>
        /// 批准
        /// </summary>
        Approval = 256,
        /// <summary>
        /// 发布
        /// </summary>
        Publish = 512
    }


    /// <summary>
    /// 系统权限
    /// </summary>
    public class SystemAuth
    {

        /// <summary>
        /// 获取权限值
        /// </summary>
        /// <param name="authType"></param>
        /// <returns></returns>
        public static bool IsHasAuth(AuthType authType, long authVal)
        {
            var retVal = BinAuth.IsHasAuth(authVal, (long)authType);

            return retVal;
        }

        /// <summary>
        /// 获取权限值
        /// </summary>
        /// <param name="authType"></param>
        /// <returns></returns>
        public static bool IsHasAuth(long authType, long authVal)
        {
            var retVal = BinAuth.IsHasAuth(authVal, authType);
            return retVal;
        }
    }
}