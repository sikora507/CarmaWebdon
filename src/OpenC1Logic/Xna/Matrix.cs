using System;

namespace OpenC1Logic.Xna
{
    public struct Matrix
    {
        // Summary:
        //     Value at row 1 column 1 of the matrix.
        public float M11;
        //
        // Summary:
        //     Value at row 1 column 2 of the matrix.
        public float M12;
        //
        // Summary:
        //     Value at row 1 column 3 of the matrix.
        public float M13;
        //
        // Summary:
        //     Value at row 1 column 4 of the matrix.
        public float M14;
        //
        // Summary:
        //     Value at row 2 column 1 of the matrix.
        public float M21;
        //
        // Summary:
        //     Value at row 2 column 2 of the matrix.
        public float M22;
        //
        // Summary:
        //     Value at row 2 column 3 of the matrix.
        public float M23;
        //
        // Summary:
        //     Value at row 2 column 4 of the matrix.
        public float M24;
        //
        // Summary:
        //     Value at row 3 column 1 of the matrix.
        public float M31;
        //
        // Summary:
        //     Value at row 3 column 2 of the matrix.
        public float M32;
        //
        // Summary:
        //     Value at row 3 column 3 of the matrix.
        public float M33;
        //
        // Summary:
        //     Value at row 3 column 4 of the matrix.
        public float M34;
        //
        // Summary:
        //     Value at row 4 column 1 of the matrix.
        public float M41;

        internal static Matrix CreateTranslation(Vector3 vector3)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Value at row 4 column 2 of the matrix.
        public float M42;
        //
        // Summary:
        //     Value at row 4 column 3 of the matrix.
        public float M43;
        //
        // Summary:
        //     Value at row 4 column 4 of the matrix.
        public float M44;

        // todo implement this
        public static Matrix Identity { get { return new Matrix(); } }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            // todo implement this
            return new Matrix();
        }
    }
}
