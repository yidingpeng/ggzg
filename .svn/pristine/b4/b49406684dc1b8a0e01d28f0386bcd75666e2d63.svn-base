using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RW.PMS.Utils.EventLog
{
    public class FileEventLog : IEventLog
    {
        #region IEventLog 成员

        private string filename = Application.StartupPath + "\\Event Logs\\log.txt";

        static object locker = new object();

        public void Write(EventLog log)
        {
            lock (locker)
            {
                string template = "{0}\t{1}\t{2}\t{3}\t{4}";
                object[] items = new object[] { 
                    DateTime.Now.Date.ToString("yyyy-MM-dd"), 
                    DateTime.Now.ToString("HH:mm:ss"),
                    log.ErrorLogType,
                    log.Username,
                    log.Message
                };

                string msg = string.Format(template, items);

                string path = filename.Substring(0, filename.LastIndexOf('\\'));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                StreamWriter sw = File.AppendText(filename);
                //byte[] data = Encoding.UTF8.GetBytes(log);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
                //File.AppendText();
            }
        }

        public void WriteRange(IEnumerable<EventLog> logs)
        {
            foreach (EventLog log in logs)
            {
                Write(log);
            }
        }

        public void ClearAll()
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        public void RemoveAt(int index)
        {
            List<EventLog> logs = GetAll();
            logs.RemoveAt(index);
            ClearAll();
            WriteRange(logs);
        }

        public void Remove(EventLog log)
        {
            List<EventLog> logs = GetAll();
            logs.Remove(log);
            ClearAll();
            WriteRange(logs);
        }

        public List<EventLog> GetAll()
        {
            List<EventLog> logs = new List<EventLog>();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] items = line.Split('\t');
                    EventLog log = new EventLog();
                    log.EventDateTime = Convert.ToDateTime(items[0] + " " + items[1]);
                    log.ErrorLogType = (EventLogType)Enum.Parse(typeof(EventLogType), items[2]);
                    log.Username = items[3];
                    log.Message = items[4];
                    logs.Add(log);
                }
            }
            logs.Reverse();
            return logs;
        }

        #endregion
    }
}
