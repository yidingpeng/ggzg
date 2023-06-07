using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RW.PMS.Utils.EventLog
{
    /// <summary>
    /// 错误日志记录接口
    /// </summary>
    public interface IEventLog
    {
        void Write(EventLog log);
        void WriteRange(IEnumerable<EventLog> logs);
        void ClearAll();
        void RemoveAt(int index);
        void Remove(EventLog log);
        List<EventLog> GetAll();
    }
}
