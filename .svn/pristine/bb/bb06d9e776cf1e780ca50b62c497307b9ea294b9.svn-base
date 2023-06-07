using RW.PMS.Common;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Home;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.IBLL
{
    public interface IBLL_HomePage : IDependence
    {
        /// <summary>
        /// 获取设备数量
        /// </summary>
        /// <returns></returns>
        int GetDeviceCount();

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        int GetUsersCount();

        /// <summary>
        /// 获取完成数
        /// </summary>
        /// <returns></returns>
        int GetCompleteCount();
        /// <summary>
        /// 获取合格数
        /// </summary>
        /// <returns></returns>
        int GetQualifiedCount();

        /// <summary>
        /// 获取异常情况
        /// </summary>
        /// <returns></returns>
        List<ProductCompleteModel> GetAnomalyMessage();


        /// <summary>
        /// 获取 异常反馈处理 Follow_Feedback 2020-11-28 用于大屏显示
        /// </summary>
        /// <param name="TimeStr">参数（日【%Y-%m-%d】周【%Y-%u】月【%Y-%m】</param>
        /// <returns></returns>
        List<FollowAbnormalModel> GetFollowAbnormal(string TimeStr);


        /// <summary>
        /// 获取异常情况明细
        /// </summary>
        /// <returns></returns>
        List<ErrorModel> GetAnomalyDetail(out int totalCount, int PageSize, int PageIndex);
        /// <summary>
        /// 获取人员异常情况信息
        /// </summary>
        /// <returns></returns>
        List<ErrorModel> GetPeopleAnomaly();
        /// <summary>
        /// 获取人员工时
        /// </summary>
        /// <returns></returns>
        List<PeopleHourModel> GetPeopleHourData(out int totalCount, int PageSize, int PageIndex);


        /// <summary>
        /// 获取首页轮播图片描述数据
        /// </summary>
        /// <returns></returns>
        List<BaseImgCarousel> GetImgCarousel();

    }
}
