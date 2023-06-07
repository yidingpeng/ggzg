using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;
using System.Threading;

namespace RW.PMS.Utils.Voices
{
    public static class VoiceHelper
    {

        static TTSVoice voice = null;

        public static void Speak(string text)
        {
            if (voice == null) voice = new TTSVoice();
            voice.Speak(text);
        }
    }
}
