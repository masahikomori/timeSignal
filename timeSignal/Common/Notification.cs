﻿using System;
using System.IO;
using Windows.UI.Notifications;

namespace Common
{
    public static class Notification
    {
        /// <summary>
        /// showNotify
        /// </summary>
        public static void ShowNotify(String strLine_1, string strLine_2, Boolean blnExeFlg)
        {
            try
            {
                var tmpl = ToastTemplateType.ToastImageAndText02;
                var xml = ToastNotificationManager.GetTemplateContent(tmpl);
                var images = xml.GetElementsByTagName("image");
                var src = images[0].Attributes.GetNamedItem("src");
                var texts = xml.GetElementsByTagName("text");
                var toast = new ToastNotification(xml);
                var notify = ToastNotificationManager.CreateToastNotifier("timeSignal");
                string filePath = "";

                if(blnExeFlg == true)
                {
                    filePath = Common.Define.NotifyIconPath;
                }
                else
                {
                    filePath = Common.Define.NotifyStopIconPath;
                }

                src.InnerText = "file:///" + Path.GetFullPath(filePath);

                texts[0].AppendChild(xml.CreateTextNode(strLine_1));
                texts[1].AppendChild(xml.CreateTextNode(strLine_2));

                notify.Show(new ToastNotification(xml));
            }
            catch (Exception ex)
            {
                Common.Log.ExceptionOutput(ex, Common.Define.ErrLogPath);
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}