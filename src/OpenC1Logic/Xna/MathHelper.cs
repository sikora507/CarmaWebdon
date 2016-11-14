using System;

namespace OpenC1Logic.Xna
{
    public static class MathHelper
    {
        public static float ToRadians(float degrees)
        {
            return degrees * (float)Math.PI / 180f;
        }
    }
}
