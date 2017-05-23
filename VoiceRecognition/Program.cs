using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1Beta1;
using System.Windows.Forms;
using System.Threading;

namespace VoiceRecognition
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{5BB05B8A-1671-44EB-89E0-4C87A3694932}"); 
       
        [STAThread]
        static void Main()
        {
            if(mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form());
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("이미 실행 중인 프로그램입니다.");
            }
        }
    }
}
