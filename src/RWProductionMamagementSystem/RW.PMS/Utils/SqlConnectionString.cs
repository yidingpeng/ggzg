using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.WinForm
{
	/// <summary>
	/// 数据库联接管理类
	/// SQLSERVER ONLY
	/// </summary>
	public class SqlConnectionString
	{
		#region 静态函数
		/// <summary>
		/// 获取数据库连接字符串
		/// </summary>
		/// <param name="strDataSource">数据源名称</param>
		/// <param name="strDatabaseName">数据库名称</param>
		/// <param name="bIntegratedSecurity">是否集成Windows安全验证</param>
		/// <param name="strUserName">用户名</param>
		/// <param name="strPassword">密码</param>
		/// <returns></returns>
		public static string GetConnectionString(string strDataSource, string strDatabaseName, bool bIntegratedSecurity, string strUserName, string strPassword)
		{
			if (string.IsNullOrEmpty(strDataSource))
			{
				throw new ArgumentException("缺少数据源");
			}

			if (string.IsNullOrEmpty(strDatabaseName))
			{
				throw new ArgumentException("缺少数据库名称");
			}

			if (!bIntegratedSecurity)
			{
				if (string.IsNullOrEmpty(strUserName))
				{
					throw new ArgumentException("缺少数据库登录用户名");
				}

				if (string.IsNullOrEmpty(strDatabaseName))
				{
					throw new ArgumentException("缺少数据库登录密码");
				}
			}

			// 创建连接字符串
			string strConnectionString = string.Format("data source={0};initial catalog={1};{2}",
				strDataSource, strDatabaseName,
				bIntegratedSecurity ? "integrated security=true;" : string.Format("user id={0};password={1}", strUserName, strPassword));

			return strConnectionString;
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public SqlConnectionString()
		{
			DataSource = string.Empty;
			DatabaseName = string.Empty;
			IntegratedSecurity = false;
			UserName = string.Empty;
			Password = string.Empty;
		}


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="strDataSource"></param>
		/// <param name="strDatabase"></param>
		/// <param name="bIntegratedSecurity"></param>
		/// <param name="strUserName"></param>
		/// <param name="strPassword"></param>
        public SqlConnectionString(string strDataSource, string strDatabaseName, bool bIntegratedSecurity, string strUserName, string strPassword)
		{
			DataSource = strDataSource;
			DatabaseName = strDatabaseName;
			IntegratedSecurity = bIntegratedSecurity;
			UserName = strUserName;
			Password = strPassword;

			return;
		}
		#endregion

		#region 属性
		/// <summary>
		/// 数据源名称
		/// </summary>
		public string DataSource
		{
			get;
			set;
		}


		/// <summary>
		/// 数据库名
		/// </summary>
		public string DatabaseName
		{
			get;
			set;
		}


		/// <summary>
		/// 继承验证
		/// </summary>
		public bool IntegratedSecurity
		{
			get;
			set;
		}


		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			get;
			set;
		}


		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			get;
			set;
		}


		/// <summary>
		/// 获取连接字符串
		/// </summary>
		public string GetConnectionString()
		{
			return GetConnectionString(DataSource, DatabaseName, IntegratedSecurity, UserName, Password);
		} 
		#endregion
	};
}
