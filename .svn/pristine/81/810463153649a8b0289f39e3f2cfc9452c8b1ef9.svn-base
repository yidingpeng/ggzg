using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.Model;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using RW.PMS.Common.Logger;
using System.Configuration;
using RW.PMS.Model.Sys;

namespace RW.PMS.WinForm
{
    internal class AssemblyProgramControl
    {

        /// <summary>
        /// 当前工序索引号
        /// </summary>
        public int CurrentGXIndex { get; set; }

        /// <summary>
        /// 当前工步索引号
        /// </summary>
        public int CurrentGBIndex { get; set; }

        /// <summary>
        /// 当前工步下的工具物料索引号
        /// </summary>
        public int CurrentGJWLIndex { get; set; }

        /// <summary>
        /// 当前工序工步数据模型
        /// </summary>
        public ProGXGBModel CurrentGXGBModel { get; private set; }

        /// <summary>
        /// 当前工具物料数据模型
        /// </summary>
        public ProGJValModel CurrentGJWLModel { get; private set; }

        /// <summary>
        /// 当前工具物料数据模型集合
        /// </summary>
        public List<ProGJValModel> CurrentGJWLModels { get; private set; }

        /// <summary>
        /// 当前管控方式
        /// </summary>
        public ControlMode ControlMode { get; private set; }

        public bool IsWait { get; private set; }

        /// <summary>
        /// 全部数据模型
        /// </summary>
        public List<ProGXGBModel> GXGBModels { get; private set; }

        /// <summary>
        /// 程序开始
        /// </summary>
        public event EventHandler StartInvoke;

        /// <summary>
        /// 程序完成
        /// </summary>
        public event EventHandler FinishInvoke;

        /// <summary>
        /// 工序开始
        /// </summary>
        public event EventHandler<ProGXGBModel> BeginGXInvoke;

        /// <summary>
        /// 工序结束
        /// </summary>
        public event EventHandler<ProGXGBModel> EndGXInvoke;

        /// <summary>
        /// 工步开始
        /// </summary>
        public event EventHandler<ProGXGBModel> BeginGBInvoke;

        /// <summary>
        /// 工步结束
        /// </summary>
        public event EventHandler<ProGXGBModel> EndGBInvoke;

        /// <summary>
        /// 工具/物料管控开始
        /// </summary>
        public event EventHandler<ProGJValModel> GJWLBeginInvoke;

        /// <summary>
        /// 工具/物料管控结束
        /// </summary>
        public event EventHandler<ProGJValModel> GJWLEndInvoke;

        /// <summary>
        /// 其他管控开始
        /// </summary>
        public event EventHandler<ProGXGBModel> OtherBeginInvoke;

        /// <summary>
        /// 其他管控结束
        /// </summary>
        public event EventHandler<ProGXGBModel> OtherEndInvoke;

        private Thread _timer = null;

        private Control _control = null;

        //设置跳转
        private bool _isSkip = false;

        //设置暂停（装配流程暂停）
        private bool _isPause = false;

        //是否关闭
        private bool _isStop = false;

        private object _objLock = new object();

        private object _objLock1 = new object();

        private ManualResetEventSlim _manualRestEvent = new ManualResetEventSlim(false);

        private bool _isRecordAsseLogger = false;

        private List<BaseDataModel> _controlTypes = null;

        public AssemblyProgramControl(List<ProGXGBModel> models, List<BaseDataModel> controlType, Control control)
        {
            Init();

            GXGBModels = models;

            _controlTypes = controlType;

            _control = control;

            _isRecordAsseLogger = IsRecordAsseLogger();

        }

        public void Start()
        {
            if (GXGBModels == null || GXGBModels.Count == 0)
            {
                return;
            }
            _timer = new Thread(timer_Tick);
            _timer.IsBackground = true;

            ActionStartInvoke();

            _timer.Start();

            PrintLogger("Start");
        }

        /// <summary>
        /// 等待继续
        /// </summary>
        public void Set()
        {
            lock (_objLock1)
            {
                if (!_manualRestEvent.IsSet)
                {
                    _manualRestEvent.Set();
                }
                IsWait = false;
                PrintLogger("Set");
            }
        }

        /// <summary>
        /// 等待通知（Set 方法）
        /// </summary>
        public void Wait()
        {
            IsWait = true;
            PrintLogger("IsWait");
        }

        public void Stop()
        {
            try
            {
                _isStop = true;
                _timer.Abort();
                PrintLogger("Stop");
            }
            catch (Exception ex)
            {
                //Logger.Default.Error();
            }

        }

        public void Init()
        {
            CurrentGXIndex = -1;
            CurrentGBIndex = -1;
            CurrentGJWLIndex = -1;
            PrintLogger("Init");
        }

        /// <summary>
        /// 工步跳转
        /// </summary>
        /// <param name="gbIndex"></param>
        public void Skip(int gbIndex)
        {
            if (gbIndex < 0)
            {
                gbIndex = 0;
            }

            if (gbIndex >= GXGBModels.Count)
            {
                gbIndex = GXGBModels.Count - 1;
            }

            _isSkip = true;

            Set();

            CurrentGBIndex = gbIndex - 1;

            PrintLogger("Skip , gbIndex:{0}", new object[] { gbIndex });
        }

        /// <summary>
        /// 工序返回（返回到当前工序或上一个工序）
        /// </summary>
        public void GXBack()
        {
            if (CurrentGBIndex == 0)
            {
                return;
            }

            if (CurrentGBIndex != CurrentGXIndex)
            {
                Skip(CurrentGXIndex);
            }
            else
            {
                var index = GetCurrentGXIndex(CurrentGBIndex - 1);
                Skip(index);
            }

            PrintLogger("GXBack");
        }

        private int GetCurrentGXIndex(int gbIndex)
        {
            var model = GXGBModels.Where(f => f.progGXID == GXGBModels[gbIndex].progGXID).OrderBy(f => f.gbOrder).FirstOrDefault();

            return model.RowID;
        }

        private void timer_Tick()
        {
            while (!_isStop)
            {
                lock (_objLock)
                {
                    GBWork();
                }
            }
        }

        private void GBWork()
        {
            if (!_isPause)
            {
                BeginGBWork();

                DelayTime();

                EndGBWork();
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        private void BeginGBWork()
        {
            if (GXGBModels == null || GXGBModels.Count <= CurrentGBIndex + 1)
            {
                ActionFinishInvoke();

                Init();

                Stop();

                return; //TODO: exception or return
            }

            CurrentGBIndex++;

            CurrentGXGBModel = GXGBModels[CurrentGBIndex];

            CurrentGXIndex = GetCurrentGXIndex(CurrentGBIndex);

            if (CurrentGBIndex == CurrentGXIndex)
            {
                ActionGXBeginInvoke(CurrentGXGBModel);
            }

            ActionGBBeginInvoke(CurrentGXGBModel);

            CurrentGJWLIndex = -1;
            CurrentGJWLModel = null;
            CurrentGJWLModels = null;

            CurrentGJWLModels = CurrentGXGBModel.GJWLModels.ToList();

            //获取管控方式
            ControlMode = GetControlType();
            //其他管控类型
            if (ControlMode == ControlMode.Other)
            {
                ActionOtherBeginInvoke(CurrentGXGBModel);

                PrintLogger("ActionOtherBeginInvoke,ControlMode:{0}", ControlMode);

                if (IsWait && !_isSkip)
                {
                    _manualRestEvent.Reset();
                    _manualRestEvent.Wait();
                }
            }
            else
            {
                if (CurrentGJWLModels.Count == 0)
                {

                    Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show(_control, "当前工步配置了“工具管控”或“物料管控”，但没有配置对应的工具和物料信息！", "管控方式设置错误！");
                    }));

                    return;
                }
                foreach (var model in CurrentGJWLModels)
                {
                    CurrentGJWLIndex++;
                    CurrentGJWLModel = CurrentGJWLModels[CurrentGJWLIndex];

                    //工具管控
                    if (CurrentGJWLModel.GJID.HasValue && CurrentGJWLModel.GJID.Value > 0)
                    {
                        ControlMode = ControlMode.GJ;
                    }
                    //物料管控
                    else
                    {
                        ControlMode = ControlMode.WL;
                    }

                    ActionGJWLBeginInvoke(CurrentGJWLModel);

                    PrintLogger("ActionGJWLBeginInvoke,ControlMode:{0}", ControlMode);

                    if (IsWait && !_isSkip)
                    {
                        _manualRestEvent.Reset();
                        _manualRestEvent.Wait();
                    }

                    ActionGJWLEndInvoke(CurrentGJWLModel);

                    PrintLogger("ActionGJWLEndInvoke,ControlMode:{0}", ControlMode);
                }
            }
            PrintLogger("BeginGBWork,ControlMode:{0}", ControlMode);
        }

        /// <summary>
        /// 获取管控方式
        /// </summary>
        private ControlMode GetControlType()
        {
            var controlMode = ControlMode.Other;

            var value = _controlTypes.Where(f => f.ID == CurrentGXGBModel.ControlTypeID).FirstOrDefault();
            if (value != null)
            {
                if (value.bdcode == EDAEnums.ControlType.WLGK.ToString())
                {
                    controlMode = ControlMode.WL;
                }
                else if (value.bdcode == EDAEnums.ControlType.GJGK.ToString())
                {
                    controlMode = ControlMode.GJ;
                }
            }

            return controlMode;
        }

        /// <summary>
        /// 时间延长或暂停
        /// </summary>
        private void DelayTime()
        {
            if (CurrentGXGBModel != null && ControlMode == ControlMode.Other)//时间管控
            {
                if ((CurrentGXGBModel.IsEmpCheck ?? 0) == 0 &&
                    (CurrentGXGBModel.IsInputPInfo ?? 0) == 0 &&
                    (CurrentGXGBModel.IsScan ?? 0) == 0 &&
                    (CurrentGXGBModel.IsScanOrderNo ?? 0) == 0)
                {
                    var delayTime = CurrentGXGBModel.GBDelayTime ?? 0;


                    if (!CurrentGXGBModel.progGBID.HasValue)
                    {
                        delayTime = 1;
                    }
                    if (delayTime > 0)
                    {
                        var time = delayTime * 1000;

                        PrintLogger("DelayTime,time:{0}", time);
                        //睡眠时间碎片化，以防跳转停顿时间过长
                        while (time > 0)
                        {
                            if (_isSkip)
                            {
                                return;
                            }

                            Thread.Sleep(200);
                            time = time - 200;
                        }

                        return;
                    }

                    IsWait = true;
                    _manualRestEvent.Reset();
                    _manualRestEvent.Wait();
                }
            }

            Thread.Sleep(100);
        }

        private void EndGBWork()
        {

            if (CurrentGXGBModel.GJWLModels.Count() == 0)
            {
                ActionOtherEndInvoke(CurrentGXGBModel);

                PrintLogger("ActionOtherEndInvoke,ControlMode:{0}", ControlMode);
            }

            ActionGBEndInvoke(CurrentGXGBModel);

            PrintLogger("ActionOtherEndInvoke,ControlMode:{0}", ControlMode);

            if (CurrentGXGBModel.gbOrder == GXGBModels.Where(f => f.progGXID == CurrentGXGBModel.progGXID).Max(f => f.gbOrder))
            {
                ActionGXEndInvoke(CurrentGXGBModel);

                PrintLogger("ActionGXEndInvoke");
            }

            if (_isSkip)
            {
                _isSkip = false;
            }
        }

        #region action event

        public void ActionStartInvoke()
        {
            if (StartInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    StartInvoke(this, EventArgs.Empty);
                }));
            }
        }

        public void ActionFinishInvoke()
        {
            if (FinishInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    FinishInvoke(this, EventArgs.Empty);
                }));
            }
        }

        private void ActionGXBeginInvoke(ProGXGBModel model)
        {
            if (BeginGXInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    BeginGXInvoke(this, model);
                }));
            }

        }

        private void ActionGXEndInvoke(ProGXGBModel model)
        {
            if (EndGXInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    EndGXInvoke(this, model);
                }));
            }
        }

        private void ActionGBBeginInvoke(ProGXGBModel model)
        {
            if (BeginGBInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    BeginGBInvoke(this, model);
                }));
            }

        }

        private void ActionGBEndInvoke(ProGXGBModel model)
        {
            if (EndGBInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    EndGBInvoke(this, model);
                }));
            }
        }

        private void ActionOtherBeginInvoke(ProGXGBModel model)
        {
            if (OtherBeginInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    OtherBeginInvoke(this, model);
                }));
            }
        }

        private void ActionOtherEndInvoke(ProGXGBModel model)
        {
            if (OtherEndInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    OtherEndInvoke(this, model);
                }));
            }
        }

        private void ActionGJWLBeginInvoke(ProGJValModel model)
        {
            if (GJWLBeginInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    GJWLBeginInvoke(this, model);
                }));
            }
        }

        private void ActionGJWLEndInvoke(ProGJValModel model)
        {
            if (GJWLEndInvoke != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    GJWLEndInvoke(this, model);
                }));
            }
        }

        private void Invoke(Delegate del)
        {
            if (_control != null && !_control.IsDisposed)
            {
                _control.Invoke(del);
            }
        }

        #endregion

        /// <summary>
        /// 日志记录
        /// </summary>
        private void PrintLogger(string str, params object[] args)
        {
            if (_isRecordAsseLogger)
            {
                string val = string.Format(",CurrentGBIndex:{0}", CurrentGBIndex);
                str += val;
                Logger.Default.Trace(str, args);
            }
        }

        /// <summary>
        /// 是否记录专配事件操作
        /// </summary>
        /// <returns></returns>
        private bool IsRecordAsseLogger()
        {
            var retVal = false;
            var value = ConfigurationManager.AppSettings["IsRecordAsseLogger"];
            if (value != null)
            {
                bool.TryParse(value.ToString(), out retVal);
            }
            return retVal;
        }
    }

    /// <summary>
    /// 管控方式
    /// </summary>
    public enum ControlMode
    {
        GJ,
        WL,
        Other,
    }
}
