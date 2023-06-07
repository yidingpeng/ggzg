using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.Data;
using System.Data;

namespace RW.PMS.Utils.IO
{
    /// <summary>
    /// 读取OPC项目
    /// 原理：类型.opc文件可通过access访问读取，读取表TagList即可读取到所有的[项目]
    /// 然后可通过生成的项目生成class或者对应的opc操作
    /// 开始时间:2016-07-05 10:00
    /// 完成时间未定
    /// </summary>
    /// <author>yuanyong</author>
    public class OPCReader
    {
        IDbBase access = new OleDB();
        public OPCReader()
        {
        }

        public OPCReader(string path)
        {
            this.Connect(path);
        }

        public void Connect(string path)
        {
            access.ConnectionString = path;
        }

        public IEnumerable<OPCTag> GetTags()
        {
            string sql = "select * from TagList;";
            DataSet ds = access.GetDataSet(sql);
            List<OPCTag> lstTags = new List<OPCTag>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                OPCTag tag = new OPCTag();
                tag.Init(row);
                lstTags.Add(tag);
            }
            return lstTags;
        }

    }

    public class OPCTag
    {
        private int tagID;

        public int TagID
        {
            get { return tagID; }
            set { tagID = value; }
        }

        private int pathID;

        public int PathID
        {
            get { return pathID; }
            set { pathID = value; }
        }

        private string shortName;

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        private string runtimeName;

        public string RuntimeName
        {
            get { return runtimeName; }
            set { runtimeName = value; }
        }

        private int tagType;

        public int TagType
        {
            get { return tagType; }
            set { tagType = value; }
        }

        private int dataType;

        public int DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        private int accessRights;

        public int AccessRights
        {
            get { return accessRights; }
            set { accessRights = value; }
        }

        private int scanRate;

        public int ScanRate
        {
            get { return scanRate; }
            set { scanRate = value; }
        }

        private int icon;

        public int Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private int updated;

        public int Updated
        {
            get { return updated; }
            set { updated = value; }
        }

        public void Init(DataRow row)
        {
            this.TagID = Convert.ToInt32(row["TagID"]);
            this.PathID = Convert.ToInt32(row["PathID"]);
            this.ShortName = row["ShortName"].ToString();
            this.RuntimeName = row["RuntimeName"].ToString();
            this.TagType = Convert.ToInt32(row["TagType"]);
            this.DataType = Convert.ToInt32(row["DataType"]);
            this.AccessRights = Convert.ToInt32(row["AccessRights"]);
            this.ScanRate = Convert.ToInt32(row["ScanRate"]);
            this.Icon = Convert.ToInt32(row["Icon"]);
            this.Updated = Convert.ToInt32(row["Updated"]);
        }

    }

    public enum OPCDataTypeEnum
    {
        INT = 2,
        DINT = 3,
        REAL = 4,
        STRING = 8,
        BOOL = 11,
        BYTE = 17,
        WORD = 18,
        DWORD = 19,
    }

}
