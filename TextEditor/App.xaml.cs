﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandleExceptionOccurred;
        }

        private void UnhandleExceptionOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            Window win = Current.MainWindow;
            RenderTargetBitmap bmp =
                new RenderTargetBitmap((int) win.Width, (int) win.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(win);
            string errorPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorReports");
            if (!Directory.Exists(errorPath))
            {
                Directory.CreateDirectory(errorPath);
            }
            BitmapEncoder encoder=new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            string filePath = Path.Combine(errorPath, $"{DateTime.Now:MMddyyyyhhmmss}.png");
            using (Stream stream = File.Create(filePath))
            {
                encoder.Save(stream);
            }
        }
    }
}
