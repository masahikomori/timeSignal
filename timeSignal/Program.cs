﻿using System;
using System.Windows.Forms;
using System.Threading;

namespace timeSignal
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Form1();
            CheckMultiple();
        }

        /// <summary>
        /// Multiple start check
        /// </summary>
        static void CheckMultiple()
        {
            Mutex objMutex = new System.Threading.Mutex(false, Application.ProductName);

            if (objMutex.WaitOne(0, false))
            {
                Application.Run();
            }

            GC.KeepAlive(objMutex);

            objMutex.Close();
        }
    }
}
