using System;
using System.IO;

namespace WebApplication1.Services.Data
{
    public class DataService : IDataService
    {
        public DataService()
        {
            CarmaDir = @"C:\gry\carma";
            PixDirs = new PixDir[]
            {
                new PixDir {
                    Path = Path.Combine(CarmaDir, @"DATA\PIXELMAP\"),
                    Name = "PIXELMAP",
                    Files = new PixFile[0]
                },
                new PixDir {
                    Path = Path.Combine(CarmaDir, @"DATA\REG\PIXELMAP\"),
                    Name = "REG\\PIXELMAP",
                    Files = new PixFile[0]
                },
                new PixDir {
                    Path = Path.Combine(CarmaDir, @"DATA\32X20X8\PIXELMAP\"),
                    Name = "32X20X8\\PIXELMAP",
                    Files = new PixFile[0]
                }
            };
            Palettes = new string[]
            {
                @"data\reg\palettes\drrender.pal",
                @"data\reg\palettes\draceflc.pal"
            };

            ActorsDir = Path.Combine(CarmaDir, @"DATA\ACTORS\");
        }

        public string[] Palettes { get; private set; }
        public string CarmaDir { get; private set; }
        public PixDir[] PixDirs { get; private set; }
        public string ActorsDir { get; private set; }
    }
}
