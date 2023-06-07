using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.SelfTest
{
    /// <summary>
    /// 自检帮助类
    /// 注册的自检项目保存在内存中，运行Execute方法，可执行
    /// </summary>
    public class SelfTestHelper
    {
        public static ISelfTest Instance = null;

        static SelfTestHelper()
        {
            Instance = new SelfTester();
            Instance.SelfTestEvent += new SelfTestHandler(Instance_SelfCheckEvent);
        }

        static void Instance_SelfCheckEvent(string groupName, string name)
        {
            //throw new NotImplementedException();
            if (callbacks.ContainsKey(groupName))
            {
                if (callbacks[groupName].ContainsKey(name))
                {
                    callbacks[groupName][name].Invoke(groupName, name);
                }
            }
        }

        static Dictionary<string, Dictionary<string, SelfTestHandler>> callbacks = new Dictionary<string, Dictionary<string, SelfTestHandler>>();


        public static void Register(string groupName, string name, Del del, SelfTestHandler callback)
        {
            if (callback != null)
            {
                if (callbacks.ContainsKey(groupName))
                    callbacks[groupName] = new Dictionary<string, SelfTestHandler>();
                callbacks[groupName][name] = callback;
            }
            Instance.Register(groupName, name, del);
        }

        public static void Register(string groupName, string name, Del del)
        {
            if (del == null)
                throw new NullReferenceException("自检行为不能为空！");
            Register(groupName, name, del, null);
        }


        public static void UnRegister(string groupName, string name)
        {
            Instance.UnRegister(groupName, name);
        }

        public static ISelfTestForm Form = null;
        public static void Begin()
        {
            if (Form == null)
            {
                throw new NullReferenceException("请先指定自检UI，Form不能为空。");
            }
            Form.Begin();
        }

        public static void Append(string msg)
        {
            if (Form != null)
                Form.Append(msg);
        }

        public static void End()
        {
            if (Form != null)
                Form.Finish();
        }

    }
}
