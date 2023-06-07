using System.Diagnostics;

namespace RW.PMS.Common
{
    public static class DIService
    {
        private static DependenceManager _dependenceManger = null;

        static DIService()
        {
            _dependenceManger = new DependenceManager();
        }

        /// <summary>
        /// 获取需要的服务对象
        /// </summary>
        /// <typeparam name="T">获取的对象类型</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static T GetService<T>()
        {
            var service = _dependenceManger.Resolve<T>();
            return service;
        }
    }
}