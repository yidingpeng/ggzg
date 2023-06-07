using Newtonsoft.Json;
using RW.PMS.Web.Remind;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace RW.PMS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //筛选器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyyMMddHHmmss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                return setting;
            });

            //JsonSerializerSettings setting = new JsonSerializerSettings();
            ////默认值设定
            //JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            //{
            //    //日期类型默认格式化处理
            //    setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            //    setting.DateFormatString = "yyyyMMddHHmmss";

            //    //空值处理
            //    setting.NullValueHandling = NullValueHandling.Ignore;
            //    return setting;
            //});
            //人员岗位资质自动提醒 2020-02-25 禁用
            //EmployeePostTimeTask.Run();//人员岗位资质自动提醒
            //DeviceExpirationRemind.Run();//设备到期提醒


            //英文：Remove and JsonValueProviderFactory and add JsonDotNetValueProviderFactory
            //中文：删除和JsonValueProviderFactory并添加JsonDotNetValueProviderFactory
            ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
            ValueProviderFactories.Factories.Add(new JsonDotNetValueProviderFactory());

            InventoryExpirationRemind.Run();//库存到期提醒 更新
        }



        public sealed class JsonDotNetValueProviderFactory : ValueProviderFactory
        {
            // Token: 0x060004E3 RID: 1251 RVA: 0x0000F0E8 File Offset: 0x0000D2E8
            private static void AddToBackingStore(JsonDotNetValueProviderFactory.EntryLimitedDictionary backingStore, string prefix, object value)
            {
                IDictionary<string, object> dictionary = value as IDictionary<string, object>;
                if (dictionary != null)
                {
                    foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                    {
                        JsonDotNetValueProviderFactory.AddToBackingStore(backingStore, JsonDotNetValueProviderFactory.MakePropertyKey(prefix, keyValuePair.Key), keyValuePair.Value);
                    }
                    return;
                }
                IList list = value as IList;
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        JsonDotNetValueProviderFactory.AddToBackingStore(backingStore, JsonDotNetValueProviderFactory.MakeArrayKey(prefix, i), list[i]);
                    }
                    return;
                }
                backingStore.Add(prefix, value);
            }

            // Token: 0x060004E4 RID: 1252 RVA: 0x0000F18C File Offset: 0x0000D38C
            private static object GetDeserializedObject(ControllerContext controllerContext)
            {
                if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
                StreamReader streamReader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
                string text = streamReader.ReadToEnd();
                if (string.IsNullOrEmpty(text))
                {
                    return null;
                }
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = int.MaxValue;
                return javaScriptSerializer.DeserializeObject(text);
            }

            /// <summary>Returns a JSON value-provider object for the specified controller context.返回指定控制器上下文的JSON值提供程序对象</summary>
            /// <returns>A JSON value-provider object for the specified controller context.指定控制器上下文的JSON值提供程序对象</returns>
            /// <param name="controllerContext">The controller context.控制器上下文</param>
            // Token: 0x060004E5 RID: 1253 RVA: 0x0000F1F0 File Offset: 0x0000D3F0
            public override IValueProvider GetValueProvider(ControllerContext controllerContext)
            {
                if (controllerContext == null)
                {
                    throw new ArgumentNullException("controllerContext");
                }
                object deserializedObject = JsonDotNetValueProviderFactory.GetDeserializedObject(controllerContext);
                if (deserializedObject == null)
                {
                    return null;
                }
                Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                JsonDotNetValueProviderFactory.EntryLimitedDictionary backingStore = new JsonDotNetValueProviderFactory.EntryLimitedDictionary(dictionary);
                JsonDotNetValueProviderFactory.AddToBackingStore(backingStore, string.Empty, deserializedObject);
                return new DictionaryValueProvider<object>(dictionary, CultureInfo.CurrentCulture);
            }

            // Token: 0x060004E6 RID: 1254 RVA: 0x0000F240 File Offset: 0x0000D440
            private static string MakeArrayKey(string prefix, int index)
            {
                return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
            }

            // Token: 0x060004E7 RID: 1255 RVA: 0x0000F25E File Offset: 0x0000D45E
            private static string MakePropertyKey(string prefix, string propertyName)
            {
                if (!string.IsNullOrEmpty(prefix))
                {
                    return prefix + "." + propertyName;
                }
                return propertyName;
            }

            // Token: 0x020000AD RID: 173
            private class EntryLimitedDictionary
            {
                // Token: 0x060004E9 RID: 1257 RVA: 0x0000F27E File Offset: 0x0000D47E
                public EntryLimitedDictionary(IDictionary<string, object> innerDictionary)
                {
                    this._innerDictionary = innerDictionary;
                }

                // Token: 0x060004EA RID: 1258 RVA: 0x0000F290 File Offset: 0x0000D490
                public void Add(string key, object value)
                {
                    if (++this._itemCount > JsonDotNetValueProviderFactory.EntryLimitedDictionary._maximumDepth)
                    {
                        throw new InvalidOperationException("MvcResources.JsonValueProviderFactory_RequestTooLarge");
                    }
                    this._innerDictionary.Add(key, value);
                }

                // Token: 0x060004EB RID: 1259 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
                private static int GetMaximumDepth()
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;
                    if (appSettings != null)
                    {
                        string[] values = appSettings.GetValues("aspnet:MaxJsonDeserializerMembers");
                        int result;
                        if (values != null && values.Length > 0 && int.TryParse(values[0], out result))
                        {
                            return result;
                        }
                    }
                    return 1000;
                }

                // Token: 0x0400016B RID: 363
                private static int _maximumDepth = JsonDotNetValueProviderFactory.EntryLimitedDictionary.GetMaximumDepth();

                // Token: 0x0400016C RID: 364
                private readonly IDictionary<string, object> _innerDictionary;

                // Token: 0x0400016D RID: 365
                private int _itemCount;
            }
        }





    }
}