using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RW.PMS.Web.Controllers.Common
{
    public class RepTemplDataBind
    {

        /// <summary>
        /// 签名图片目录地址
        /// </summary>
        public string SignatureImgDir { get; set; }

        /// <summary>
        /// 根据模板文件与绑定的数据源 生成报告
        /// </summary>
        /// <param name="templateFile"></param>
        /// <param name="dataSouce"></param>
        /// <returns></returns>
        public string CreateBindDataTemplate(string templateFile, object dataSouce)
        {
            try
            {
                if (!File.Exists(templateFile))
                {
                    throw new FileNotFoundException($"{nameof(templateFile)} Not Found!");
                }

                RemoveOldFiles(Path.GetDirectoryName(templateFile));

                var val = Guid.NewGuid().ToString("N");
                var documentPath = Path.Combine(Path.GetDirectoryName(templateFile), Path.GetFileNameWithoutExtension(templateFile) + val.Substring(val.Length - 11, 10)) + Path.GetExtension(templateFile);
                var document = DocumentFactory.Create<MyDocument>(templateFile, dataSouce);
                document.ImageDirectory = SignatureImgDir;
                document.Generate(documentPath);
                return documentPath;
            }
            catch (SharpDocxCompilationException ex)
            {
                throw new Exception(ex.Errors, ex);
            }
        }

        /// <summary>
        /// 删除一天前的文件
        /// </summary>
        /// <param name="dirPath"></param>
        private void RemoveOldFiles(string dirPath)
        {
            var files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fInfo = new FileInfo(file);
                if (fInfo.LastWriteTime < DateTime.Now.Date)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }
        }

    }

    public class MyDocument : DocumentBase
    {
        public ReportModel Model { get; set; }

        /// <summary>
        /// 获取引用的命名空间
        /// </summary>
        /// <returns></returns>
        public new static List<string> GetUsingDirectives()
        {
            return new List<string>
            {
                //"using RW.PMS.Web.Controllers.Common;",
                "using RW.PMS.Web.Controllers;",
                "using RW.PMS.Web;",
               // "using RW.PMS.Model.Assembly;",
                // Requires support for C# 6.
                // See https://stackoverflow.com/questions/31639602/using-c-sharp-6-features-with-codedomprovider-rosyln
            };
        }

        /// <summary>
        /// 获取引用的程序集
        /// </summary>
        /// <returns></returns>
        public new static List<string> GetReferencedAssemblies()
        {
            return new List<string>
            {
                typeof(MyDocument).Assembly.Location
            };
        }

        public override void SetModel(object model)
        {
            Model = model as ReportModel;
        }


        protected override void InvokeDocumentCode()
        {

        }

        /// <summary>
        /// 设置签名图片
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="percentage"></param>
        public void SignatureImg(string filePath, int percentage = 100)
        {
            if (File.Exists(Path.Combine(ImageDirectory, filePath)))
            {
                Image(filePath, percentage);
            }
        }
    }

    public class ReportModel
    {
        public DictionaryWrapper Items { get; set; }

        public List<AssemblyMainModel> List { get; }

        public List<TightenMachineModel> TightenList { get; }

        public ReportModel(List<AssemblyMainModel> list, List<TightenMachineModel> tightenList)
        {
            List = list;
            TightenList = tightenList;
        }

        public string GetAssemblyVal(string gwCode, string keyName)
        {
            var retVal = string.Empty;
            if (List != null)
            {
                var assemblyGw = List.Where(f => f.am_gwCode == gwCode).FirstOrDefault();
                if (assemblyGw != null && assemblyGw.Details != null)
                {
                    var val = assemblyGw.Details.Where(f => f.amr_name == keyName).FirstOrDefault();
                    if (val != null)
                    {
                        retVal = val.amr_value;
                    }
                }
            }

            return retVal;
        }

        public string GetAssemblyUser(string gwCode)
        {
            var retVal = string.Empty;
            if (List != null)
            {
                var assemblyGw = List.Where(f => f.am_gwCode == gwCode).FirstOrDefault();
                if (assemblyGw != null)
                {
                    retVal = assemblyGw.am_createUser;
                }
            }

            return retVal;
        }

        public string GetUser()
        {
            var retVal = string.Empty;
            if (TightenList != null)
            {
                var assemblyGw = TightenList[0];
                if (assemblyGw != null)
                {
                    retVal = assemblyGw.workerName;
                }
            }

            return retVal;
        }
        public string GetTime()
        {
            var retVal = string.Empty;
            if (TightenList != null)
            {
                var assemblyGw = TightenList[0];
                if (assemblyGw != null)
                {
                    retVal = assemblyGw.endTime.ToString("yyyy-MM-dd");
                }
            }

            return retVal;
        }



        public string GetVal( string keyName)
        {
            var retVal = string.Empty;
            if (TightenList != null)
            {
                if (TightenList[0].assemblyList != null) {
                    var assemblyGw = TightenList[0].assemblyList.Where(f => f.amdName == keyName).FirstOrDefault();
                    if (assemblyGw != null)
                    {
                        retVal = assemblyGw.amdValue;
                    }
                } 
            }

            return retVal;
        }

        public string GetAssemblyDate(string gwCode)
        {
            var retVal = string.Empty;
            var assemblyGw = List.Where(f => f.am_gwCode == gwCode).FirstOrDefault();
            if (assemblyGw != null)
            {
                retVal = assemblyGw.am_createDate.ToString("yyyy.MM.dd");
            }
            return retVal;
        }

        public string GetProdNo()
        {
            string retVal = string.Empty;
            if (List != null && List.Count > 0)
            {
                var model = List.FirstOrDefault();
                if (model != null && !string.IsNullOrEmpty(model.am_QRcode))
                {
                    retVal = model.am_QRcode;
                }
            }
            return retVal;
        }
    }


    public class DictionaryWrapper
    {
        private Dictionary<string, string> baseItems;
        public DictionaryWrapper(Dictionary<string, string> items)
        {
            baseItems = items;
        }
        public string this[string key]
        {
            get
            {
                try
                {
                    return baseItems[key];

                }
                catch (Exception ex)
                {
                    //TODO:  
                    throw;
                }
            }
        }
    }

}