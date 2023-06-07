using Newtonsoft.Json;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RW.PMS.AutoUpdate
{
    public partial class UploadFile : Form
    {
        public UploadFile()
        {
            InitializeComponent();
        }

        private void UploadFile_Load(object sender, EventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (p.ProcessName == "RW.PMS.WinForm")
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception)
            {
            }
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// 调用api返回json
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string HttpApi(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Method = "GET";//get或者post
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public void updateFile()
        {
            try
            {
                string WebApiUrl = "";
                string WebUrl = "";
                string xmlurl = Application.StartupPath + @"\\UpdateList.xml";

                XmlDocument xml = new XmlDocument();
                xml.Load(xmlurl);

                XmlElement xe = xml.DocumentElement;

                //获取服务器webApi地址
                string targetParm_serverWebApiURL = string.Format("AutoUpdater/Updater/ApiUrl");//生成目标获取节点的参数
                XmlNode targetNode_serverWebApiURL = xml.SelectSingleNode(targetParm_serverWebApiURL);//获得目标节点

                //获取服务器下载文件地址
                string targetParm_serverWebURL = string.Format("AutoUpdater/Updater/Url");//生成目标获取节点的参数
                XmlNode targetNode_serverWebURL = xml.SelectSingleNode(targetParm_serverWebURL);//获得目标节点

                if (targetNode_serverWebApiURL == null || targetNode_serverWebApiURL == null)
                {
                    Console.WriteLine("can not find");
                }
                else
                {
                    WebApiUrl = targetNode_serverWebApiURL.InnerText.ToString().Trim() + "/Base/GetUpdateFileSel";
                    WebUrl = targetNode_serverWebURL.InnerText.ToString().Trim();
                }


                var strjson = HttpApi(WebApiUrl);

                //序列化JSON字符串转为Lis<T>
                List<SysexeFileUpdateModel> entity = JsonConvert.DeserializeObject<List<SysexeFileUpdateModel>>(strjson);

                //获取服务器下载文件地址
                string targetParm_Files = string.Format("AutoUpdater/Files");//生成目标获取节点的参数
                XmlNode targetNode_Files = xml.SelectSingleNode(targetParm_Files);//获得目标节点
                //需要更新的文件名
                bool fileIsExist = false;

                foreach (SysexeFileUpdateModel file in entity)
                {
                    fileIsExist = false;

                    //循环XML

                    if (targetNode_Files.HasChildNodes)//如果有子节点
                    {
                        XmlNodeList list = targetNode_Files.ChildNodes;//得到子节点集合
                        foreach (XmlNode xn1 in list)//递归遍历每一个子节点
                        {

                            if (xn1.Attributes["Name"].Value.Equals(file.filesName))
                            {
                                fileIsExist = true;

                                if (!xn1.Attributes["Ver"].Value.Equals(file.versionNuber) || xn1.Attributes["Status"].Value.Equals("0"))
                                {
                                    //XML存在 该文件信息，但版本不同，则需要更新


                                    this.label1.Text = "正在下载文件：" + file.filesName + " ....";
                                    label1.Refresh();
                                    bool isDown = DownLoadFile(WebUrl + file.filePath, file.filesName);
                                    if (isDown)
                                        this.label1.Text = "文件：" + file.filesName + " 下载成功....";
                                    else
                                        this.label1.Text = "文件：" + file.filesName + " 下载失败....";

                                    label1.Refresh();

                                    if (isDown)
                                    {
                                        xn1.Attributes["Ver"].Value = file.versionNuber;
                                        xn1.Attributes["Status"].Value = "1";
                                    }
                                }

                            }

                        }

                        //XML中不存在文件的情况, 往XML写该文件信息， 并下载文件
                        if (fileIsExist == false)
                        {

                            this.label1.Text = "正在下载文件：" + file.filesName + "....";
                            label1.Refresh();
                            bool isDown = DownLoadFile(WebUrl + file.filePath, file.filesName);
                            if (isDown)
                                this.label1.Text = "文件：" + file.filesName + " 下载完成....";
                            else
                                this.label1.Text = "文件：" + file.filesName + " 下载失败....";

                            label1.Refresh();

                            if (isDown)
                            {
                                XmlNode x = xml.CreateElement("File");

                                XmlAttribute Ver = xml.CreateAttribute("Ver");
                                Ver.Value = file.versionNuber;
                                XmlAttribute Name = xml.CreateAttribute("Name");
                                Name.Value = file.filesName;
                                XmlAttribute Status = xml.CreateAttribute("Status");    //0(初始值,未更新),1(更新成功)
                                Status.Value = "1";
                                x.Attributes.Append(Ver);
                                x.Attributes.Append(Name);
                                x.Attributes.Append(Status);
                                targetNode_Files.AppendChild(x);
                            }
                        }
                    }
                }
                xml.Save(xmlurl);

                this.label1.Text = "系统文件更新完成....请重新启用系统";
                label1.Refresh();

                System.Threading.Thread.Sleep(2000);
                try
                {
                    Process[] processes = Process.GetProcesses();
                    foreach (Process p in processes)
                    {

                        if (p.ProcessName == "RW.PMS.WinForm")
                        {
                            p.Kill();
                        }
                    }
                }
                catch (Exception)
                {
                }

                Application.DoEvents();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新系统文件失败！" + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            updateFile();
        }

        /// <summary>  
        /// 下载文件
        /// </summary>  
        /// <param name="URL">网址</param>  
        /// <param name="Filename">文件名</param>  
        /// <returns>True/False是否下载成功</returns>  
        public bool DownLoadFile(string URL, string filename)//, ProgressBar Prog
        {
            try
            {
                string fullpath = System.Windows.Forms.Application.StartupPath + "\\";
                if (!System.IO.Directory.Exists(fullpath))
                {
                    System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(fullpath);
                    Dir.Refresh();
                }

                if (System.IO.File.Exists(fullpath + filename))
                {
                    System.IO.File.Delete(fullpath + filename);
                }
                if (!System.IO.File.Exists(fullpath + filename))//文件不存在就下载
                {
                    System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); //从URL地址得到一个WEB请求     
                    System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); //从WEB请求得到WEB响应     
                    long totalBytes = myrp.ContentLength; //从WEB响应得到总字节数     
                    //Prog.Maximum = (int)totalBytes; //从总字节数得到进度条的最大值     
                    System.IO.Stream st = myrp.GetResponseStream(); //从WEB请求创建流（读）     
                    System.IO.Stream so = new System.IO.FileStream(fullpath + filename, System.IO.FileMode.Create); //创建文件流（写）     
                    long totalDownloadedByte = 0; //下载文件大小     
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length); //读流     
                    while (osize > 0)
                    {
                        totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小     
                        System.Windows.Forms.Application.DoEvents();
                        so.Write(by, 0, osize); //写流     
                        //Prog.Value = (int)totalDownloadedByte; //更新进度条     
                        osize = st.Read(by, 0, (int)by.Length); //读流     
                    }
                    so.Close(); //关闭流
                    st.Close(); //关闭流
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}