using RW.PMS.Common;
using RW.PMS.Model.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.IDAL.Programs
{
    public interface IDAL_PointInfo : IDependence
    {
        /// <summary>
        /// 查询点位信息
        /// </summary>
        /// <param name="explain"></param>
        /// <returns></returns>
        List<PointInfoModel> GetPointInfo(string explain, int id);

        /// <summary>
        /// 添加、修改点位信息
        /// </summary>
        /// <param name="model"></param>
        int EditPointInfo(PointInfoModel model);

        /// <summary>
        /// 删除点位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int DeletePointInfo(int ID);
    }
}
