using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.SelfTest
{
    /// <summary>
    /// 自检控制器，可分组注册自检模块
    /// 可执行自检动作
    /// </summary>
    public class SelfTester : ISelfTest
    {
        Dictionary<string, Dictionary<string, Del>> items = new Dictionary<string, Dictionary<string, Del>>();

        #region ISelfTest 成员

        public void Register(string groupName, string name, Del del)
        {
            if (!items.ContainsKey(groupName))
                items[groupName] = new Dictionary<string, Del>();
            items[groupName][name] = del;
        }

        public void UnRegister(string groupName, string name)
        {
            if (items.ContainsKey(groupName))
            {
                items[groupName].Remove(name);
                if (items[groupName].Count == 0)
                    items.Remove(groupName);
            }
        }

        public void Execute()
        {
            foreach (KeyValuePair<string, Dictionary<string, Del>> item in items)
            {
                foreach (KeyValuePair<string, Del> d in item.Value)
                {
                    if (d.Value != null)
                    {
                        d.Value.Invoke();
                        OnSelfCheckEvent(item.Key, d.Key);
                    }
                }
            }
        }

        public event SelfTestHandler SelfTestEvent;

        protected virtual void OnSelfCheckEvent(string groupName, string name)
        {
            if (SelfTestEvent != null) SelfTestEvent(groupName, name);
        }

        #endregion
    }
}
