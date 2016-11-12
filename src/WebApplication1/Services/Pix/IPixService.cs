using WebApplication1.Services.Common;

namespace WebApplication1.Services.Pix
{
    public interface IPixService
    {
        PixImage[] GetDataForPixWithPalette(string pixFilePath, string paletteFilePath);
    }
}