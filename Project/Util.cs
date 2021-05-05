using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    public static class Util
    {
        public static byte[] getByteImage(string filePath)
        {
            byte[] imageData;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                imageData = new byte[fileStream.Length];
                fileStream.Read(imageData, 0, imageData.Length);
            }
            return imageData;
        }

        public static byte[] getByteImage(IFormFile file)
        {
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                fileData = binaryReader.ReadBytes((int)file.Length);
            }

            return fileData;
        }

        public static Image Crop(this Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;
            if (bmp == null)
            {
                throw new ArgumentException("No valid bitmap");
            }

            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);
            image.Dispose();
            return cropBmp;
        }

        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
            using (MemoryStream memstr = new MemoryStream())
            {
                imageIn.Save(memstr, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memstr.ToArray();
            }
        }

        public static string getRandomNamePhoto(string name)
        {
            return string.Format("{0}-{1:N}", name, Guid.NewGuid());
        }

        public static bool belongNumberToInterval(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
