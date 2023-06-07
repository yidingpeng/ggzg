using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;

namespace RW.PMS.BLL
{
    internal class BLL_HomePage : IBLL_HomePage
    {
        private IDAL_HomePage _DAL = null;

        public BLL_HomePage()
        {
            _DAL = DIService.GetService<IDAL_HomePage>();
        }
        /// <summary>
        /// 获取设备数量
        /// </summary>
        /// <returns></returns>
        public int GetDeviceCount()
        {
            return _DAL.GetDeviceCount();
        }


        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        public int GetUsersCount()
        {
            return _DAL.GetUsersCount();
        }

        /// <summary>
        /// 获取完成数
        /// </summary>
        /// <returns></returns>
        public int GetCompleteCount()
        {
            return _DAL.GetCompleteCount();
        }

        /// <summary>
        /// 获取合格数
        /// </summary>
        /// <returns></returns>
        public int GetQualifiedCount()
        {
            return _DAL.GetQualifiedCount();
        }

        /// <summary>
        /// 获取异常情况
        /// </summary>
        /// <returns></returns>
        public List<ProductCompleteModel> GetAnomalyMessage()
        {
            return _DAL.GetAnomalyMessage();
        }



        /// <summary>
        /// 获取 异常反馈处理 Follow_Feedback 2020-11-28 用于大屏显示
        /// </summary>
        /// <param name="TimeStr">参数（日【%Y-%m-%d】周【%Y-%u】月【%Y-%m】</param>
        /// <returns></returns>
        public List<FollowAbnormalModel> GetFollowAbnormal(string TimeStr)
        {
            return _DAL.GetFollowAbnormal(TimeStr);
        }


        /// <summary>
        /// 获取异常情况明细
        /// </summary>
        /// <returns></returns>
        public List<ErrorModel> GetAnomalyDetail(out int totalCount, int PageSize, int PageIndex)
        {
            return _DAL.GetAnomalyDetail(out totalCount, PageSize, PageIndex);
        }
        /// <summary>
        /// 获取人员异常情况信息
        /// </summary>
        /// <returns></returns>
        public List<ErrorModel> GetPeopleAnomaly()
        {
            return _DAL.GetPeopleAnomaly();
        }
        /// <summary>
        /// 获取人员工时
        /// </summary>
        /// <returns></returns>
        public List<PeopleHourModel> GetPeopleHourData(out int totalCount, int PageSize, int PageIndex)
        {
            return _DAL.GetPeopleHourData(out totalCount, PageSize, PageIndex);
        }



        /// <summary>
        /// 获取首页轮播图片描述数据
        /// </summary>
        /// <returns></returns>
        public List<BaseImgCarousel> GetImgCarousel()
        {
            return _DAL.GetImgCarousel();
        }



    }
}
