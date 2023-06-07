using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;

namespace RW.PMS.Utils.Voices
{

    public class TTSVoice
    {

        public TTSVoice()
        {

        }


        private SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        private SpVoice myVoice = new SpVoice();

        /// <summary>
        /// 语音初始化。默认系统选择语音【控制面板-语音】查看
        /// </summary>
        /// <param name="YYindex"></param>
        public void Init()
        {
            if (myVoice != null)
            {
                myVoice.Rate = 2; // 语速快慢,在登录界面实例化，调用此处的构造函数。
                //myVoice.Volume = 1; // 音量大小
                myVoice.Voice = myVoice.GetVoices(string.Empty, string.Empty).Item(0);
            }
        }

        /// <summary>
        /// 语音选择。 0为默认选择的语音，1为列表中下一个语音。【控制面板-语音】查看
        /// </summary>
        /// <param name="YYindex"></param>
        public void Init(int YYindex)
        {
            if (myVoice != null)
            {
                // 语速快慢,在登录界面实例化，调用此处的构造函数。
                myVoice.Rate = 0;

                // 0为默认选择的语音，1为列表中下一个语音
                myVoice.Voice = myVoice.GetVoices(string.Empty, string.Empty).Item(YYindex);
            }
        }

        /// <summary>
        /// 异步或同步朗读设置。0异步，1同步。默认为异步。
        /// </summary>
        /// <param name="flag"></param>
        public void SpeakFlags(int flag)
        {
            if (flag == 0) SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;//异步朗读
            if (flag == 1) SpFlags = SpeechVoiceSpeakFlags.SVSFDefault;//同步朗读
            else SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;//异步朗读
        }


        /// <summary>
        /// 文字转语音。text：简体中文
        /// </summary>
        /// <param name="text"></param>
        public int Speak(string text)
        {
            try
            {
                return myVoice.Speak(text, SpFlags);
            }
            catch
            { }
            return 0;
        }




    }
}
