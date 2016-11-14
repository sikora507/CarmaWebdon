using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic.Xna
{
    public class Rectangle
    {
        public int Height;
        public int Width;
        public int X;        
        public int Y;
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
