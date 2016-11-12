using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Data;

namespace WebApplication1.Controllers
{
    public class DataController : Controller
    {
        private IDataService _dataService;
        public DataController(IDataService settingsService)
        {
            _dataService = settingsService;
        }
        [HttpGet]
        public JsonResult Index()
        {
            return new JsonResult(new { gameDir = _dataService.CarmaDir });
        }
    }
}
