using CarmaBrowser.OpenC1Logic;
using OpenC1Logic;
using OpenC1Logic.Parsers;
using WebApplication1.Services.Common;

namespace WebApplication1.Services.Pix
{
    public class PixService : IPixService
    {
        public PixImage[] GetDataForPixWithPalette(string pixFilePath, string paletteFilePath)
        {
            // todo remove this gameVars from here. It's a bit cryptic to use global variable in random places
            // this client side change affects whole application for others
            GameVars.Palette = new PaletteFile(paletteFilePath);
            var data = new PixFile(pixFilePath);
            var result = new PixImage[data.PixMaps.Count];
            for (int i = 0; i < data.PixMaps.Count; i++)
            {
                var pixMap = data.PixMaps[i];
                result[i] = new PixImage
                {
                    BgrData = pixMap.BgrBytes,
                    Width = (uint)pixMap.Width,
                    Height = (uint)pixMap.Height
                };
            }
            return result;
        }
    }
}
