using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.Common;

namespace ZXBar
{
    class Program
    {
        static void Main(string[] args)
        {

           // // create a barcode reader instance
           // BarcodeReader reader = new BarcodeReader();
           // reader.Options.CharacterSet = "UTF-8";
           // // load a bitmap
           // //var barcodeBitmap = (Bitmap)Image.FromFile("2.png");
           // Bitmap barcodeBitmap = new Bitmap("6.png");
           //// Bitmap bmp = MakeGrayscale3(barcodeBitmap);
           // // detect and decode the barcode inside the bitmap
           // LuminanceSource source = new BitmapLuminanceSource(barcodeBitmap);
           // BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
           // IDictionary<DecodeHintType, object> hints = new Dictionary<DecodeHintType, object>();

           // hints.Add(DecodeHintType.CHARACTER_SET, "UTF-8");
           // hints.Add(DecodeHintType.TRY_HARDER, "3");
           // Result[] results = reader.DecodeMultiple(source);
           // // do something with the result
           // if (results != null)
           // {
           //    // txtDecoderType.Text = result.BarcodeFormat.ToString();
           //    // txtDecoderContent.Text = result.Text;
           //     //Console.WriteLine(result.BarcodeFormat.ToString());
           //     //Console.WriteLine(result.Text);

           //     foreach (Result   res in results )
           //     {

           //         Console.WriteLine(res.Text);
           //     }

           // }


            MultiFormatReader mReader = new MultiFormatReader();
            BarcodeReaderGeneric<MultiFormatReader> gmReader = new BarcodeReaderGeneric<MultiFormatReader>();
            Bitmap barcodeBitmap = new Bitmap("6.png");
            LuminanceSource source = new BitmapLuminanceSource(barcodeBitmap);
            BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
            IDictionary<DecodeHintType, object> hints = new Dictionary<DecodeHintType, object>();

            hints.Add(DecodeHintType.CHARACTER_SET, "UTF-8");
            hints.Add(DecodeHintType.TRY_HARDER, "3");
            Result results = mReader.decode(binaryBitmap, hints);



            Console.ReadKey();
        }




        /// <summary>
        /// 处理图片灰度
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][] 
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
    }
}
