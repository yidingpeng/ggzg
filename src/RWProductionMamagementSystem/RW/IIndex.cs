using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils
{
    /// <summary>
    /// 支持Index字段以及this[T value]索引器的接口，实现自IIndexFiled与IIndexes&#60;T>接口
    /// </summary>
    public interface IIndex<T> : IIndexFiled, IIndexes<T>
    {

    }

    /// <summary>
    /// 支持Index字段以及this[double value]索引器的接口，实现自IIndexFiled与IIndexes接口
    /// </summary>
    public interface IIndex : IIndexFiled, IIndexes
    {

    }

    /// <summary>
    /// 声明IIndexFiled的接口，用于统一描述包含Index字段的类
    /// </summary>
    public interface IIndexFiled
    {
        /// <summary>
        /// 获取或设置索引号
        /// </summary>
        int Index { get; set; }
    }

    /// <summary>
    /// 声明IIndexes的接口，用于统一描述包含索引的类，可以通过this访问的类
    /// </summary>
    public interface IIndexes<T>
    {
        /// <summary>
        /// 获取或设置指定的索引值
        /// </summary>
        /// <param name="index">需要获取或设置的索引值</param>
        /// <returns></returns>
        T this[int index] { get; }
    }

    public interface IIndexes : IIndexes<double>
    {
    }
}
