﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;


namespace Microsoft.Samples.Kinect.DepthBasics
{
    /// <summary>
    /// Logica di interazione per QRWindow.xaml
    /// </summary>
    public partial class QRWindow : Window
    {
        public QRWindow()
        {
            InitializeComponent();
            renderQRCode();
        }

        private void renderQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode("www.swimmy.it", QRCodeGenerator.ECCLevel.M);
            Bitmap bitmap = qrCode.GetGraphic(20);
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            qrImage.Source = bitmapImage;

        }




    }
}
