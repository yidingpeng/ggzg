using Autofac;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RW.PMS.Common
{
    /// <summary>
    /// 依赖管理类
    /// </summary>
    internal class DependenceManager
    {
        private IContainer _container;

        public DependenceManager()
        {
            var builder = new ContainerBuilder();
            //获取autofac中接口程序集及实现程序集的键值对
            var assemblies = ConfigManager.GetSections("autofac");
            foreach (var item in assemblies)
            {
                var assemblyFile = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath), item.Value);
                builder.RegisterAssemblyTypes(Assembly.LoadFile(assemblyFile)).Where(t => t.GetInterface("IDependence", false) != null).AsImplementedInterfaces()
                    .SingleInstance();
            }
            _container = builder.Build();
        }

        /// <summary>
        /// 获取注入的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>()
        {
            var resolve = _container.Resolve<T>();
            return resolve;
        }
    }
}