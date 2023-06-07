using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.SelfTest
{
    /// <summary>
    /// 测试的标准界面
    /// </summary>
    public interface ISelfTestForm
    {
        /// <summary>
        /// 开始自检
        /// </summary>
        void Begin();

        /// <summary>
        /// 结束自检
        /// </summary>
        void Finish();

        /// <summary>
        /// 追加自检信息
        /// </summary>
        void Append(string msg);
    }
}
