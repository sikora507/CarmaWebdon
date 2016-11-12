using OpenC1Logic.Engine;
using OpenC1Logic.Parsers;
using OpenC1Logic.Parsers.Funks;
using System;
using System.Collections.Generic;

namespace OpenC1Logic
{
    public class CMaterial
    {
        public string Name { get; set; }
        public string PixName { get; set; }
        public bool DoubleSided { get; set; }
        public int SimpMatPixelIndex { get; set; }
        public int SimpMatGradientCount { get; set; }
        //public Texture2D Texture;
        public byte[] Texture;
        public BaseFunk Funk;

        public CMaterial()
        {
        }

        public CMaterial(string name, int paletteIndex)
        {
            Name = name;
            SimpMatPixelIndex = paletteIndex;
        }

        public void ResolveTexture(List<PixMap> pixmaps)
        {
            if (Texture != null) return;  //weve already resolved this material

            if (!String.IsNullOrEmpty(PixName))
            {
                PixMap pixmap = null;
                if (pixmaps != null)
                    pixmap = pixmaps.Find(p => p.Name.Equals(PixName, StringComparison.OrdinalIgnoreCase));
                else
                {
                    PixFile pixfile = new PixFile(PixName);
                    if (pixfile.Exists)
                        pixmap = pixfile.PixMaps[0];
                }
                if (pixmap != null)
                    Texture = pixmap.BgrBytes;
            }

            if (Texture == null)
            {
                //simp mat
                if (SimpMatGradientCount > 1)
                    GenerateSimpMatGradient();
                else
                    Texture = TextureGenerator.Generate(GameVars.Palette.GetRGBBytesForPixel(SimpMatPixelIndex));
            }
        }

        public void ResolveTexture()
        {
            ResolveTexture(null);
        }

        private void GenerateSimpMatGradient()
        {
            //Texture2D tex = new Texture2D(Engine.Device, 1, SimpMatGradientCount + 1, 1, TextureUsage.None, SurfaceFormat.Color);
            //Color[] pixels = new Color[1 * SimpMatGradientCount + 1];
            //for (int i = 0; i < SimpMatGradientCount + 1; i++)
            //    pixels[i] = GameVars.Palette.GetRGBColorForPixel((SimpMatPixelIndex + i) % 255);
            //tex.SetData<Color>(pixels);

            //Texture = tex;
            Texture = new byte[0];
        }
    }
}
