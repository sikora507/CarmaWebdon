using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using WebApplication1.Helpers;
using WebApplication1.Services.Common;
using WebApplication1.Services.Data;
using WebApplication1.Services.Pix;

namespace WebApplication1.Controllers
{
    public class PixController : Controller
    {
        IDataService _dataService;
        IFilesHelper _filesHelper;
        IPixService _pixService;

        public PixController(IDataService dataService, IFilesHelper filesHelper, IPixService pixService)
        {
            _dataService = dataService;
            _filesHelper = filesHelper;
            _pixService = pixService;
        }

        public JsonResult Index()
        {
            return new JsonResult(new { pixFolders = _dataService.PixDirs });
        }

        public JsonResult GetPixData(uint pixDirId, uint paletteId)
        {
            if(_dataService.PixDirs.Length-1 <  pixDirId
                || _dataService.Palettes.Length- 1 < paletteId)
            {
                return new JsonResult(new { });
            }
            else
            {
                var palette = Path.Combine(_dataService.CarmaDir, _dataService.Palettes[paletteId]);
                var pixDir = _dataService.PixDirs[pixDirId];
                if(pixDir.Files.Length == 0)
                {
                    var filePaths = _filesHelper.GetFiles(pixDir.Path, "pix");
                    pixDir.Files = filePaths.Select(path => new PixFile
                    {
                        Path = path,
                        Name = Path.GetFileName(path),
                        Images = _pixService.GetDataForPixWithPalette(path, palette)
                    }).ToArray();
                }
                return new JsonResult(new { dirName = pixDir.Name, files = pixDir.Files });
            }
        }
        public JsonResult GetPalettes()
        {
            return new JsonResult(new { palettes = _dataService.Palettes });
        }
    }
}
