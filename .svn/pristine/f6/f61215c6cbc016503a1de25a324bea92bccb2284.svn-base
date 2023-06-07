using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.EventLog
{
    public class EventLog
    {
        public EventLog()
        {
            eventDateTime = DateTime.Now;
        }
        //public EventLogType ErrorLogType { get; set; }
        //public string Username { get; set; }
        //public string Message { get; set; }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private EventLogType errorLogType;

        public EventLogType ErrorLogType
        {
            get { return errorLogType; }
            set { errorLogType = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private DateTime eventDateTime;

        public DateTime EventDateTime
        {
            get { return eventDateTime; }
            set { eventDateTime = value; }
        }
    }
}
