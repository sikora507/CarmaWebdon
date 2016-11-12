namespace OpenC1Logic.Engine
{
    public static class TextureGenerator
    {
        //public static Texture2D Generate(Color color)
        public static byte[] Generate(byte[] rgb)
        {
            //Texture2D tex = new Texture2D(Engine.Device, 1, 1, 1, TextureUsage.None, SurfaceFormat.Color);
            //Color[] pixels = new Color[1];
            //pixels[0] = color;
            //tex.SetData<Color>(pixels);
            var tex = rgb;
            return tex;
        }

        //public static Texture2D Generate(Color color, int x, int y)
        public static byte[] Generate(byte[] rgb, int x, int y)
        {
            //Texture2D tex = new Texture2D(Engine.Device, x, y, 1, TextureUsage.None, SurfaceFormat.Color);
            byte[] pixels = new byte[x * y];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = rgb[0];
            //tex.SetData<Color>(pixels);
            //return tex;
            return pixels;
        }
    }
}
