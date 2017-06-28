using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace QrCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(@"Type some text to QR code:");
            string sampleText = Console.ReadLine();
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode qrCode = qrEncoder.Encode(sampleText);


            //输出在控制台
            #region 输出在控制台
            //for (int j = 0; j < qrCode.Matrix.Width; j++)
            //{
            //    for (int i = 0; i < qrCode.Matrix.Width; i++)
            //    {
            //        char charToPrint = qrCode.Matrix[i, j] ? '█' : ' ';
            //        Console.Write(charToPrint);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            //保存成png文件
            #region 保存成png文件

            //string filename = @"D:\img\url.png";
            //GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5,QuietZoneModules.Two), Brushes.Black,Brushes.White);
            //using (FileStream stream = new FileStream(filename, FileMode.Create))
            //{
            //    render.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            //}

            #endregion

            //生成中文二维码
            #region 生成中文二维码
            //string filename = @"D:\img\cn.png";
            //GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black,Brushes.White);
            //Bitmap map = new Bitmap(150, 150);
            //Graphics g = Graphics.FromImage(map);
            //g.FillRectangle(Brushes.Red, 0, 0, 500, 500);
            //render.Draw(g, qrCode.Matrix, new Point(20, 20));
            //map.Save(filename, ImageFormat.Png);
            #endregion

            //调整二维码大小
            #region 调整二维码大小
            ////ModuleSize  设置图片大小
            ////QuietZoneModules  设置周边padding
            ////5----150*150 padding:5
            ////10----300*300 padding:10
            //string filename = @"D:\img\size.png";
            //GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(10, QuietZoneModules.Two),Brushes.Black,Brushes.White);
            //Point padding = new Point(10, 10);
            //DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            //Bitmap map = new Bitmap(dSize.CodeWidth + padding.X, dSize.CodeWidth + padding.Y);
            //Graphics g = Graphics.FromImage(map);
            //render.Draw(g, qrCode.Matrix, padding);
            //map.Save(filename, ImageFormat.Png);

            #endregion

            //生成带Logo的二维码
            string filename = @"D:\img\logo.png";
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            Bitmap map = new Bitmap(dSize.CodeWidth, dSize.CodeWidth);
            Graphics g = Graphics.FromImage(map);
            render.Draw(g, qrCode.Matrix);
            Image img = Image.FromFile(@"D:\img\weixiao.png");
            
            Point imgPoint = new Point((map.Width - img.Width) / 2, (map.Height - img.Height) / 2);
            g.DrawImage(img, imgPoint.X, imgPoint.Y, img.Width, img.Height);
            map.Save(filename, ImageFormat.Png);



            Console.WriteLine(@"Press any key to quit.");
            Console.ReadKey();
        }
    }
}
