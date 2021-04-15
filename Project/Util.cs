using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    public class Util
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
    }
}
