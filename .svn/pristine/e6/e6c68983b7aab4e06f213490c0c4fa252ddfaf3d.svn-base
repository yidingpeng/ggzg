using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RW.PMS.Web.Controllers.Program
{
    /// <summary>
    /// 标记子表的等级
    /// </summary>
    public enum TableLevel
    {
        Pro = 0,
        GX = 1,
        GB = 2,
        GJ = 3,
        Val = 4,
    }

    public class ColumnFormat
    {
        public const string None = "None";
        public const string IsEnable = "IsEnable";
        public const string IsOK = "IsOK";
        public const string Image = "Image";
        public const string Video = "Video";
        public const string Light = "Light";
    }

    public class TableColumn
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Format { get; set; }

        public string Other { get; set; }

        public TableColumn() { }

        public TableColumn(string name, string value, string format = ColumnFormat.None,string other="")
        {
            Name = name;
            Value = value;
            Format = format;
            Other = other;
        }
    }

    public class Command
    {
        public Command()
        {
            IsShow = true;
        }
        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsShow { get; set; }

    }

    public class CollapseTable<T> where T : class
    {
        public CollapseTable()
        {
            Title = new List<TableColumn>();
        }
        public int ID { get; set; }

        public TableLevel Level { get; set; }

        public List<TableColumn> Title { get; set; }

        public T Body { get; set; }

        public List<KeyValuePair<string, List<Command>>> Opertions { get; set; }
    }

}