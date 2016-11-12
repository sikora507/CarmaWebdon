using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Services.Cars;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        private ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public JsonResult GetCarsList()
        {
            var cars = _carsService.GetCarsList().ToList();
            return new JsonResult(cars);
        }

        [HttpGet]
        public JsonResult GetCar(uint carId)
        {
            var car = _carsService.GetCarById(carId);
            return new JsonResult(car);
        }
    }
}
