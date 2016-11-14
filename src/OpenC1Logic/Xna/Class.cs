namespace OpenC1Logic.Xna
{
    public class VertexPositionNormalTexture
    {
        // Summary:
        //     The vertex normal.
        public Vector3 Normal;
        //
        // Summary:
        //     The vertex position.
        public Vector3 Position;
        //
        // Summary:
        //     The texture coordinates.
        public Vector2 TextureCoordinate;

        public VertexPositionNormalTexture(Vector3 position, Vector3 normal, Vector2 texture)
        {
            Position = position;
            Normal = normal;
            TextureCoordinate = texture;
        }
    }
}
