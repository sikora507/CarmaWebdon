using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaBrowser.OpenC1Logic
{
    class Helpers
    {
        public static byte[] GetBytesForImage(byte[] pixels, int width, int height, IPalette palette)
        {
            int overhang = 0;// (4 - ((width * 4) % 4));
            int stride = (width * 4) + overhang;

            byte[] imgData = new byte[stride * height];
            int curPosition = 0;
            for (int i = 0; i < height; i++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = 0;
                    int idx = width * i + x;
                    if (idx < pixels.Length) pixel = pixels[idx];

                    if (pixel > 0)
                    {
                        byte[] rgb = palette.GetRGBBytesForPixel(pixel);
                        imgData[curPosition] = rgb[0];
                        imgData[curPosition + 1] = rgb[1];
                        imgData[curPosition + 2] = rgb[2];
                        imgData[curPosition + 3] = 0xFF;
                    }
                    curPosition += 4;
                }
                curPosition += overhang;
            }
            return imgData;
        }
    }
}
