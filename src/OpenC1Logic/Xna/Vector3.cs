﻿using System;

namespace OpenC1Logic.Xna
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3() { }
        public Vector3(int v1, int v2, int v3)
        {
            X = v1;
            Y = v2;
            Z = v3;
        }
        public Vector3(float v1, float v2, float v3)
        {
            X = v1;
            Y = v2;
            Z = v3;
        }

        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }

        public static Vector3 operator *(Vector3 value1, Vector3 value2)
        {
            return new Vector3(value1.X * value2.X, value1.Y * value2.Y, value1.Z * value2.Z);
        }

        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }

        internal static Vector3 Lerp(object v, Vector3 movement, float _currentPos)
        {
            // todo implement this
            return new Vector3(0, 0, 0);
        }
    }
}
