namespace OpenC1Logic.Xna
{
    public class Vector2
    {
        public float X;
        public float Y;

        public Vector2(float tU, float tV)
        {
            X = tU;
            Y = tV;
        }

        public static Vector2 Zero { get { return new Vector2(0, 0); } }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X * value2.X, value1.Y * value2.Y);
        }

        public static Vector2 operator /(Vector2 value1, int value2)
        {
            return new Vector2(value1.X / value2, value1.Y / value2);
        }
    }
}
