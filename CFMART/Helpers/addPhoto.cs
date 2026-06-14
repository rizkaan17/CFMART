using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Helpers
{
    public class addPhoto
    {
        public static byte[] FileToByteArray(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}
