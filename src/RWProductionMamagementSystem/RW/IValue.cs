namespace RW.PMS.Utils
{

    public interface IGetValue<T>
    {
        T Value { get; }
    }

    public interface IGetValue : IGetValue<double>
    {
    }

    /// <summary>
    /// 支持范型类的接口
    /// </summary>
    /// <typeparam name="T">范型，用于描述Value的类型，一般使用值类型</typeparam>
    public interface IValue<T> : IGetValue<T>
    {
        new T Value { get; set; }
    }

    /// <summary>
    /// 声明了支持Value字段的类的接口。
    /// </summary>
    public interface IValue : IValue<double>
    {
    }
}
